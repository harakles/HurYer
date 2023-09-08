using DataTables.Mvc;
using HurriyetciYerelSenAdmin.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HurriyetciYerelSenAdmin.Managers
{
    public class ApplicationManager
    {
        #region List
        public static IQueryable<Application> GetList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,
            string CaseID,
           out int totalCount,
           out int filteredCount)
        {
            var db = new Entities();
            var query = db.Applications.Where(x => x.Deleted != true).AsQueryable();
            totalCount = query.Count();

            #region Filtering

            // Arama Bölümü
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim().ToLower();
                query = query.Where(p =>
                    p.ApplicationName.ToString().ToLower().Contains(value) ||
                    p.ApplicationSurname.ToString().ToLower().Contains(value) ||
                    p.ApplicationPhoneNumber.ToString().ToLower().Contains(value) ||
                    p.ApplicationEmail.ToString().ToLower().Contains(value)
                ).OrderByDescending(p => p.Id);
            }

            if (!string.IsNullOrEmpty(CaseID))
            {
                var idsArr = CaseID.Split(',');
                var myInts = idsArr.Select(int.Parse).ToArray();
                query = query.Where(p => myInts.Contains(p.ApplicationCaseID.Value));
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
                    case "ApplicationName":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.ApplicationName)
                            : query.OrderByDescending(x => x.ApplicationName);
                        break;
                    case "ApplicationSurname":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.ApplicationSurname)
                            : query.OrderByDescending(x => x.ApplicationSurname);
                        break;
                    case "ApplicationPhoneNumber":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.ApplicationPhoneNumber)
                            : query.OrderByDescending(x => x.ApplicationPhoneNumber);
                        break;
                    case "ApplicationEmail":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.ApplicationEmail)
                            : query.OrderByDescending(x => x.ApplicationEmail);
                        break;
                    case "ApplicationCaseID":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.ApplicationCaseID)
                            : query.OrderByDescending(x => x.ApplicationCaseID);
                        break;
                }
            }

            #endregion Sorting

            query = query.Skip(requestModel.Start).Take(requestModel.Length);
            return query;
        }
        #endregion

        #region GenderList
        public static IQueryable<ApplicationGender> GetGenderList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,
          out int totalCount,
          out int filteredCount)
        {
            var db = new Entities();
            var query = db.ApplicationGenders.Where(x => x.Deleted != true).AsQueryable();
            totalCount = query.Count();

            #region Filtering

            // Arama Bölümü
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim().ToLower();
                query = query.Where(p =>
                    p.Gender.ToString().ToLower().Contains(value) 
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
                    case "Gender":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.Gender)
                            : query.OrderByDescending(x => x.Gender);
                        break;
                }
            }

            #endregion Sorting

            query = query.Skip(requestModel.Start).Take(requestModel.Length);
            return query;
        }
        #endregion

        #region EducationList
        public static IQueryable<ApplicationEducation> GetEducationList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,
          out int totalCount,
          out int filteredCount)
        {
            var db = new Entities();
            var query = db.ApplicationEducations.Where(x => x.Deleted != true).AsQueryable();
            totalCount = query.Count();

            #region Filtering

            // Arama Bölümü
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim().ToLower();
                query = query.Where(p =>
                    p.EducationName.ToString().ToLower().Contains(value) 
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
                    case "EducationName":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.EducationName)
                            : query.OrderByDescending(x => x.EducationName);
                        break;
                }
            }

            #endregion Sorting

            query = query.Skip(requestModel.Start).Take(requestModel.Length);
            return query;
        }
        #endregion

        #region Organisation
        public static IQueryable<ApplicationOrganisation> GetOrganisationList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,
          out int totalCount,
          out int filteredCount)
        {
            var db = new Entities();
            var query = db.ApplicationOrganisations.Where(x => x.Deleted != true).AsQueryable();
            totalCount = query.Count();

            #region Filtering

            // Arama Bölümü
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim().ToLower();
                query = query.Where(p =>
                    p.OrganisationName.ToString().ToLower().Contains(value) 
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
                    case "OrganisationName":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.OrganisationName)
                            : query.OrderByDescending(x => x.OrganisationName);
                        break;
                }
            }

            #endregion Sorting

            query = query.Skip(requestModel.Start).Take(requestModel.Length);
            return query;
        }
        #endregion

        #region Province
        public static IQueryable<ApplicationProvince> GetProvinceList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,
          out int totalCount,
          out int filteredCount)
        {
            var db = new Entities();
            var query = db.ApplicationProvinces.Where(x => x.Deleted != true).AsQueryable();
            totalCount = query.Count();

            #region Filtering

            // Arama Bölümü
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim().ToLower();
                query = query.Where(p =>
                    p.Province.ToString().ToLower().Contains(value) 
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
                    case "Province":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.Province)
                            : query.OrderByDescending(x => x.Province);
                        break;
                }
            }

            #endregion Sorting

            query = query.Skip(requestModel.Start).Take(requestModel.Length);
            return query;
        }
        #endregion

        #region District
        public static IQueryable<ApplicationDistrict> GetDistrictList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,
            int ProvinceID,
          out int totalCount,
          out int filteredCount)
        {
            var db = new Entities();
            var query = db.ApplicationDistricts.Where(x => x.Deleted != true && x.ProvinceId == ProvinceID).AsQueryable();
            totalCount = query.Count();

            #region Filtering

            // Arama Bölümü
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim().ToLower();
                query = query.Where(p =>
                    p.District.ToString().ToLower().Contains(value)
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
                    case "District":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.District)
                            : query.OrderByDescending(x => x.District);
                        break;
                }
            }

            #endregion Sorting

            query = query.Skip(requestModel.Start).Take(requestModel.Length);
            return query;
        }
        #endregion

        #region Staff
        public static IQueryable<ApplicationStaff> GetStafftList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,
          out int totalCount,
          out int filteredCount)
        {
            var db = new Entities();
            var query = db.ApplicationStaffs.Where(x => x.Deleted != true ).AsQueryable();
            totalCount = query.Count();

            #region Filtering

            // Arama Bölümü
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim().ToLower();
                query = query.Where(p =>
                    p.Staff.ToString().ToLower().Contains(value)
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
                    case "Staff":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.Staff)
                            : query.OrderByDescending(x => x.Staff);
                        break;
                }
            }

            #endregion Sorting

            query = query.Skip(requestModel.Start).Take(requestModel.Length);
            return query;
        }
        #endregion

        #region BloodType
        public static IQueryable<ApplicationBloodType> GetBloodTypetList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,
          out int totalCount,
          out int filteredCount)
        {
            var db = new Entities();
            var query = db.ApplicationBloodTypes.Where(x => x.Deleted != true).AsQueryable();
            totalCount = query.Count();

            #region Filtering

            // Arama Bölümü
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim().ToLower();
                query = query.Where(p =>
                    p.BloodType.ToString().ToLower().Contains(value)
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
                    case "BloodType":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.BloodType)
                            : query.OrderByDescending(x => x.BloodType);
                        break;
                }
            }

            #endregion Sorting

            query = query.Skip(requestModel.Start).Take(requestModel.Length);
            return query;
        }
        #endregion

        #region Case
        public static IQueryable<ApplicationCase> GetCaseList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,
          out int totalCount,
          out int filteredCount)
        {
            var db = new Entities();
            var query = db.ApplicationCases.Where(x => x.Deleted != true).AsQueryable();
            totalCount = query.Count();

            #region Filtering

            // Arama Bölümü
            if (requestModel.Search.Value != string.Empty)
            {
                var value = requestModel.Search.Value.Trim().ToLower();
                query = query.Where(p =>
                    p.Situation.ToString().ToLower().Contains(value)
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
                    case "Situation":
                        query = orderDirection == Column.OrderDirection.Ascendant
                            ? query.OrderBy(x => x.Situation)
                            : query.OrderByDescending(x => x.Situation);
                        break;
                }
            }

            #endregion Sorting

            query = query.Skip(requestModel.Start).Take(requestModel.Length);
            return query;
        }
        #endregion

    }
}