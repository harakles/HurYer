using DataTables.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HurriyetciYerelSenAdmin.EDMX;

namespace HurriyetciYerelSenAdmin.Managers
{
    public class ConfederationManager
    {
        public static IQueryable<Confederation> GetList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,
           out int totalCount,
           out int filteredCount)
        {
            var db = new Entities();
            var query = db.Confederations.Where(x => x.Deleted != true).AsQueryable();
            totalCount = query.Count();

            #region Filtering


            // Arama Bölümü
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim().ToLower();
                query = query.Where(p =>
                    p.Name.ToString().ToLower().Contains(value) ||
                    p.PrezName.ToString().ToLower().Contains(value) 
                ).OrderByDescending(p => p.Id);
            }

            filteredCount = query.Count();

            #endregion Filtering


            #region Sorting

            var sortedColumns = requestModel.Columns.GetSortedColumns();
            var isSorted = false;
            foreach (var column in sortedColumns)
                if (!isSorted)
                {
                    Sort(column.Data, column.SortDirection);
                    isSorted = true;
                }
                else
                {
                    Sort(column.Data, column.SortDirection);
                }

            void Sort(string column, Column.OrderDirection orderDirection)
            {
                switch (column)
                {
                    case "Id":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.Id)
                            : query.OrderByDescending(x => x.Id);
                        break;
                    case "Name":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.Name)
                            : query.OrderByDescending(x => x.Name);
                        break;
                    case "PrezName":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.PrezName)
                            : query.OrderByDescending(x => x.PrezName);
                        break;
                }
            }

            #endregion Sorting

            query = query.Skip(requestModel.Start).Take(requestModel.Length);
            return query;
        }
    }
}