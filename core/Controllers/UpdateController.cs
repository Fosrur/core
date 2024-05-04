using Microsoft.Extensions.Options;
using core.Models.Json.AddressBook;
using Microsoft.AspNetCore.Mvc;
using core.Models.Json.City;
using core.DataModels;
using core.Models;


namespace core.Controllers
{
    /// <summary>
    /// Definition of UpdateController
    /// </summary>
    [ApiController]
    [Route("api/update")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public class UpdateController : Controller
    {
        /// <summary>
        /// Definition of connexString
        /// </summary>
        public IOptions<SQLConfig> SQLConfig;

		/// <summary>
		/// Definition of UpdateController
		/// </summary>
		public UpdateController(IOptions<SQLConfig> sqlConfig) { SQLConfig = sqlConfig; }


		/// <summary>
		/// Sets AddressBook
		/// </summary>
		[HttpPost("SetAddressBook")]
        [ProducesResponseType(typeof(AddressBook), 200)]
        public IActionResult SetAddressBook(string utente, [FromBody] AddressBook addressBook) => Content(new AddressBookDataModel(SQLConfig).Update(utente, addressBook), "application/json");

        /// <summary>
		/// Sets City
		/// </summary>
		[HttpPost("SetCity")]
        [ProducesResponseType(typeof(City), 200)]
        public IActionResult SetCity(string utente, [FromBody] City city) => Content(new CityDataModel(SQLConfig).Update(utente, city), "application/json");
    }
}
