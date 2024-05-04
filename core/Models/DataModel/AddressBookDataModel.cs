using Microsoft.Extensions.Options;
using core.Models.Json.AddressBook;
using core.Extensions;
using System.Data;
using core.Models;


namespace core.DataModels
{
    /// <summary>
    /// Definition of AddressBookDataModel
    /// </summary>
    public class AddressBookDataModel : BaseModel
    {
        /// <summary>
        /// Definition of SQLConfig
        /// </summary>
        public IOptions<SQLConfig>? SQLConfig;

        /// <summary>
        /// Definition of AddressBookDataModel
        /// </summary>
        public AddressBookDataModel(IOptions<SQLConfig> sqlConfig) : base(sqlConfig) { }

        /// <summary>
        /// Definition of SelectAddressBook
        /// </summary>
        public string Select(string email, AddressBook addressBook)
        {
            if (string.IsNullOrEmpty(email) || addressBook == null)
                throw new Exception("EX001");

            try
            {
                UserEmail = email;
                ProcedureName = "AddressBook_SELECT_AddressBook";

                List<AddressBook> list = new() { addressBook };

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
        /// Definition of InsertAddressBook
        /// </summary>
        public string Insert(string email, List<AddressBook> addressBook)
        {
            if (string.IsNullOrEmpty(email) || addressBook == null)
                throw new Exception("EX001");

            try
            {
                UserEmail = email;
                ProcedureName = "AddressBook_INSERT_AddressBook";

                DataTable dataTable = addressBook.ToDataTable();

                Insert(dataTable);
                return SerializeResponse();
            }
            catch (Exception ex)
            {
                return SerializeErrorResponse(ex);
            }
        }

        /// <summary>
        /// Definition of UpdateAddressBook
        /// </summary>
        public string Update(string email, AddressBook addressBook)
        {
            if (string.IsNullOrEmpty(email) || addressBook == null)
                throw new Exception("EX001");

            try
            {
                UserEmail = email;
                ProcedureName = "AddressBook_UPDATE_AddressBook";

                List<AddressBook> list = new List<AddressBook>
                {
                    addressBook
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
        /// Definition of DeleteAddressBook
        /// </summary>
        public string Delete(string email, List<AddressBook> addressBook)
        {
            if (string.IsNullOrEmpty(email) || addressBook == null)
                throw new Exception("EX001");

            try
            {
                UserEmail = email;
                ProcedureName = "AddressBook_DELETE_AddressBook";

                DataTable dataTable = addressBook.ToDataTable();

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