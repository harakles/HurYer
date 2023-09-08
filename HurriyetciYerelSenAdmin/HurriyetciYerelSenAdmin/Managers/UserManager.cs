using HurriyetciYerelSenAdmin.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataTables.Mvc;

namespace HurriyetciYerelSenAdmin.Managers
{
    public class UserManager
    {
        public static IQueryable<User> GetList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,
            out int totalCount,
            out int filteredCount)
        {
            var db = new Entities();
            var query = db.Users.Where(x => x.Deleted != true).AsQueryable();
            totalCount = query.Count();

            #region Filtering

            // Arama Bölümü
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim().ToLower();
                query = query.Where(p =>
                    p.UserName.ToString().ToLower().Contains(value) ||
                    p.UserSurname.ToString().ToLower().Contains(value) ||
                    p.UserPhoneNumber.ToString().ToLower().Contains(value) ||
                    p.UserEmail.ToString().ToLower().Contains(value)
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
                    case "UserName":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.UserName)
                            : query.OrderByDescending(x => x.UserName);
                        break;
                    case "UserSurname":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.UserSurname)
                            : query.OrderByDescending(x => x.UserSurname);
                        break;
                    case "UserPhoneNumber":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.UserPhoneNumber)
                            : query.OrderByDescending(x => x.UserPhoneNumber);
                        break;
                    case "UserEmail":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.UserEmail)
                            : query.OrderByDescending(x => x.UserEmail);
                        break;

                }
            }

            #endregion Sorting

            query = query.Skip(requestModel.Start).Take(requestModel.Length);
            return query;
        }
    }
}