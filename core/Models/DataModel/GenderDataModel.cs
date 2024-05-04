using Microsoft.Extensions.Options;
using core.Models.Json.Gender;
using core.Extensions;
using System.Data;
using core.Models;


namespace core.DataModels
{
    /// <summary>
    /// Definition of GenderDataModel
    /// </summary>
    public class GenderDataModel : BaseModel
    {
        /// <summary>
        /// Definition of SQLConfig
        /// </summary>
        public IOptions<SQLConfig>? SQLConfig;

        /// <summary>
        /// Definition of GenderDataModel
        /// </summary>
        public GenderDataModel(IOptions<SQLConfig> sqlConfig) : base(sqlConfig) { }

        /// <summary>
        /// Definition of SelectGender
        /// </summary>
        public string Select(string email, Gender Gender)
        {
            if (string.IsNullOrEmpty(email) || Gender == null)
                throw new Exception("EX001");

            try
            {
                UserEmail = email;
                ProcedureName = "Gender_SELECT_Gender";

                List<Gender> list = new() { Gender };

                DataTable dataTable = list.ToDataTable();

                Select(dataTable);
                return SerializeResponse();
            }
            catch (Exception ex)
            {
                return SerializeErrorResponse(ex);
            }
        }

		/// <summary>
		/// Definition of InsertGender
		/// </summary>
		public string Insert(string email, List<Gender> Gender)
        {
            if (string.IsNullOrEmpty(email) || Gender == null)
                throw new Exception("EX001");

            try
            {
                UserEmail = email;
                ProcedureName = "Gender_INSERT_Gender";

                DataTable dataTable = Gender.ToDataTable();

                Insert(dataTable);
                return SerializeResponse();
            }
            catch (Exception ex)
            {
                return SerializeErrorResponse(ex);
            }
        }

		/// <summary>
		/// Definition of UpdateGender
		/// </summary>
		public string Update(string email, Gender Gender)
        {
            if (string.IsNullOrEmpty(email) || Gender == null)
                throw new Exception("EX001");

            try
            {
                UserEmail = email;
                ProcedureName = "Gender_UPDATE_Gender";

                List<Gender> list = new List<Gender>
                {
                    Gender
                };

                DataTable dataTable = list.ToDataTable();

                Update(dataTable);
                return SerializeResponse();
            }
            catch (Exception ex)
            {
                return SerializeErrorResponse(ex);
            }
        }

        /// <summary>
		/// Definition of DeleteGender
		/// </summary>
		public string Delete(string email, List<Gender> Gender)
        {
            if (string.IsNullOrEmpty(email) || Gender == null)
                throw new Exception("EX001");

            try
            {
                UserEmail = email;
                ProcedureName = "Gender_DELETE_Gender";

                DataTable dataTable = Gender.ToDataTable();

                Delete(dataTable);
                return SerializeResponse();
            }
            catch (Exception ex)
            {
                return SerializeErrorResponse(ex);
            }
        }

    }
}