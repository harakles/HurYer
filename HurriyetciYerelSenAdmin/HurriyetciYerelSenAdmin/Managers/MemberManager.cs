using DataTables.Mvc;
using HurriyetciYerelSenAdmin.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HurriyetciYerelSenAdmin.Managers
{
    public class MemberManager
    {
        public static IQueryable<Member> GetList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,
            out int totalCount,
            out int filteredCount)
        {
            var db = new Entities();
            var query = db.Members.Where(x => x.Deleted != true).AsQueryable();
            totalCount = query.Count();

            #region Filtering

            // Arama Bölümü
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim().ToLower();
                query = query.Where(p =>
                    p.MemberName.ToString().ToLower().Contains(value) ||
                    p.MemberSurname.ToString().ToLower().Contains(value) ||
                    p.MemberPosition.ToString().ToLower().Contains(value) ||
                    p.MemberPhoneNumber.ToString().ToLower().Contains(value) 
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
                    case "MemberName":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.MemberName)
                            : query.OrderByDescending(x => x.MemberName);
                        break;
                    case "MemberSurname":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.MemberSurname)
                            : query.OrderByDescending(x => x.MemberSurname);
                        break;
                    case "MemberPhoneNumber":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.MemberPhoneNumber)
                            : query.OrderByDescending(x => x.MemberPhoneNumber);
                        break;
                    case "MemberPosition":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.MemberPosition)
                            : query.OrderByDescending(x => x.MemberPosition);
                        break;

                }
            }

            #endregion Sorting

            query = query.Skip(requestModel.Start).Take(requestModel.Length);
            return query;
        }
    }
}