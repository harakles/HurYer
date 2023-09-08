using DataTables.Mvc;
using HurriyetciYerelSenAdmin.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HurriyetciYerelSenAdmin.Managers
{
    public class RoleManager
    {
        public static IQueryable<UserClass> GetList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,
            out int totalCount,
            out int filteredCount)
        {
            var db = new Entities();
            var query = db.UserClasses.Where(x => x.Deleted != true).AsQueryable();
            totalCount = query.Count();

            #region Filtering

            // Arama Bölümü
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim().ToLower();
                query = query.Where(p =>
                    p.UserClassName.ToString().ToLower().Contains(value)
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
                    case "UserClassName":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.UserClassName)
                            : query.OrderByDescending(x => x.UserClassName);
                        break;
                }   
            }

            #endregion Sorting

            query = query.Skip(requestModel.Start).Take(requestModel.Length);
            return query;
        }
    }
}