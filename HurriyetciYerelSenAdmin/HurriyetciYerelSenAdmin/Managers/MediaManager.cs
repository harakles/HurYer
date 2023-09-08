using DataTables.Mvc;
using HurriyetciYerelSenAdmin.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HurriyetciYerelSenAdmin.Managers
{
    public class MediaManager
    {
        public static IQueryable<SystemMedia> GetList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,
            string TurID,
            out int totalCount,
            out int filteredCount)
        {
            var db = new Entities();
            var query = db.SystemMedias.Where(x => x.Deleted != true).AsQueryable();
            totalCount = query.Count();

            #region Filtering

            if (!string.IsNullOrEmpty(TurID))
            {
                var Tur = Convert.ToInt32(TurID);
                query = query.Where(x=>x.MediaTypeID == Tur);
            }

            // Arama Bölümü
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim().ToLower();
                query = query.Where(p =>
                    p.MediaTittle.ToString().ToLower().Contains(value) ||
                    p.MediaType.TypeName.ToString().ToLower().Contains(value) ||
                    p.MediaDate.ToString().ToLower().Contains(value) ||
                    p.MediaLastDate.ToString().ToLower().Contains(value) 
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
                    case "MediaTittle":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.MediaTittle)
                            : query.OrderByDescending(x => x.MediaTittle);
                        break;
                    case "MediaDate":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.MediaDate)
                            : query.OrderByDescending(x => x.MediaDate);
                        break;
                    case "MediaLastDate":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.MediaLastDate)
                            : query.OrderByDescending(x => x.MediaLastDate);
                        break;
                    case "MediaType":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.MediaType.TypeName)
                            : query.OrderByDescending(x => x.MediaType.TypeName);
                        break;

                }
            }

            #endregion Sorting

            query = query.Skip(requestModel.Start).Take(requestModel.Length);
            return query;
        }
    }
}