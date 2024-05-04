using Microsoft.Extensions.Options;
using core.Models.Json.City;
using core.Extensions;
using System.Data;
using core.Models;


namespace core.DataModels
{
    /// <summary>
    /// Definition of CityDataModel
    /// </summary>
    public class CityDataModel : BaseModel
    {
        /// <summary>
        /// Definition of SQLConfig
        /// </summary>
        public IOptions<SQLConfig>? SQLConfig;

        /// <summary>
        /// Definition of CityDataModel
        /// </summary>
        public CityDataModel(IOptions<SQLConfig> sqlConfig) : base(sqlConfig) { }

        /// <summary>
        /// Definition of SelectCity
        /// </summary>
        public string Select(string email, City city)
        {
            if (string.IsNullOrEmpty(email) || city == null)
                throw new Exception("EX001");

            try
            {
                UserEmail = email;
                ProcedureName = "City_SELECT_City";

                List<City> list = new() { city };

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
		/// Definition of InsertCity
		/// </summary>
		public string Insert(string email, List<City> city)
        {
            if (string.IsNullOrEmpty(email) || city == null)
                throw new Exception("EX001");

            try
            {
                UserEmail = email;
                ProcedureName = "City_INSERT_City";

                DataTable dataTable = city.ToDataTable();

                Insert(dataTable);
                return SerializeResponse();
            }
            catch (Exception ex)
            {
                return SerializeErrorResponse(ex);
            }
        }

		/// <summary>
		/// Definition of UpdateCity
		/// </summary>
		public string Update(string email, City city)
        {
            if (string.IsNullOrEmpty(email) || city == null)
                throw new Exception("EX001");

            try
            {
                UserEmail = email;
                ProcedureName = "City_UPDATE_City";

                List<City> list = new List<City>
                {
                    city
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
		/// Definition of DeleteCity
		/// </summary>
		public string Delete(string email, List<City> city)
        {
            if (string.IsNullOrEmpty(email) || city == null)
                throw new Exception("EX001");

            try
            {
                UserEmail = email;
                ProcedureName = "City_DELETE_City";

                DataTable dataTable = city.ToDataTable();

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