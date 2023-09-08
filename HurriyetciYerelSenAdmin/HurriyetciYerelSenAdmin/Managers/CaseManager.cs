using DataTables.Mvc;
using HurriyetciYerelSenAdmin.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HurriyetciYerelSenAdmin.Managers
{
    public class CaseManager
    {
        public static IQueryable<Broadcast> GetList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,
            string TurID,
            out int totalCount,
            out int filteredCount)
        {
            var Id = Convert.ToInt32(TurID);
            var db = new Entities();
            var query = db.Broadcasts.Where(x => x.Deleted != true && x.BroadcastClassID == Id).AsQueryable();
            totalCount = query.Count();

            #region Filtering

            // Arama Bölümü
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim().ToLower();
                query = query.Where(p =>
                    p.BroadcastName.ToString().ToLower().Contains(value)
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
                    case "BroadcastName":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.BroadcastName)
                            : query.OrderByDescending(x => x.BroadcastName);
                        break;

                }
            }

            #endregion Sorting

            query = query.Skip(requestModel.Start).Take(requestModel.Length);
            return query;
        }
    }
}