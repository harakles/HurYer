using DataTables.Mvc;
using HurriyetciYerelSenAdmin.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HurriyetciYerelSenAdmin.Managers
{
    public class BranchManager
    {
        public static IQueryable<Branch> GetList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,
            out int totalCount,
            out int filteredCount)
        {
            var db = new Entities();
            var query = db.Branchs.Where(x => x.Deleted != true).AsQueryable();
            totalCount = query.Count();

            #region Filtering


            // Arama Bölümü
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim().ToLower();
                query = query.Where(p =>
                    p.BranchName.ToString().ToLower().Contains(value) ||
                    p.BranchPhone.ToString().ToLower().Contains(value) ||
                    p.BranchEMail.ToString().ToLower().Contains(value) ||
                    p.BranchNumber.ToString().ToLower().Contains(value) 
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
                    case "BranchName":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.BranchName)
                            : query.OrderByDescending(x => x.BranchName);
                        break;
                    case "BranchPhone":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.BranchPhone)
                            : query.OrderByDescending(x => x.BranchPhone);
                        break;
                    case "BranchEMail":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.BranchEMail)
                            : query.OrderByDescending(x => x.BranchEMail);
                        break;
                    case "BranchNumber":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.BranchNumber)
                            : query.OrderByDescending(x => x.BranchNumber);
                        break;

                }
            }

            #endregion Sorting

            query = query.Skip(requestModel.Start).Take(requestModel.Length);
            return query;
        }
        public static IQueryable<SubBranch> GetSubBrachList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,
            int BranchID,
           out int totalCount,
           out int filteredCount)
        {
            var db = new Entities();
            var query = db.SubBranches.Where(x => x.Deleted != true && x.BranchID == BranchID).AsQueryable();
            totalCount = query.Count();

            #region Filtering


            // Arama Bölümü
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim().ToLower();
                query = query.Where(p =>
                    p.SubBranchName.ToString().ToLower().Contains(value) ||
                    p.Email.ToString().ToLower().Contains(value) ||
                    p.PhoneNumber.ToString().ToLower().Contains(value)
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
                    case "SubBranchName":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.SubBranchName)
                            : query.OrderByDescending(x => x.SubBranchName);
                        break;
                    case "PhoneNumber":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.PhoneNumber)
                            : query.OrderByDescending(x => x.PhoneNumber);
                        break;
                    case "Email":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.Email)
                            : query.OrderByDescending(x => x.Email);
                        break;

                }
            }

            #endregion Sorting

            query = query.Skip(requestModel.Start).Take(requestModel.Length);
            return query;
        }
        public static IQueryable<BranchMember> GetBranchMemberList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,
            int BranchID,
           out int totalCount,
           out int filteredCount)
        {
            var db = new Entities();
            var query = db.BranchMembers.Where(x => x.Deleted != true && x.BranchID == BranchID).AsQueryable();
            totalCount = query.Count();

            #region Filtering


            // Arama Bölümü
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim().ToLower();
                query = query.Where(p =>
                    p.Name.ToString().ToLower().Contains(value) ||
                    p.PhoneNumber.ToString().ToLower().Contains(value) ||
                    p.EMailAdress.ToString().ToLower().Contains(value) ||
                    p.Position.ToString().ToLower().Contains(value)
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
                    case "PhoneNumber":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.PhoneNumber)
                            : query.OrderByDescending(x => x.PhoneNumber);
                        break;
                    case "Position":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.Position)
                            : query.OrderByDescending(x => x.Position);
                        break;

                }
            }

            #endregion Sorting

            query = query.Skip(requestModel.Start).Take(requestModel.Length);
            return query;
        }
    }
}