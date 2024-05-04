using Microsoft.Extensions.Options;
using core.Models.Json.AddressBook;
using Microsoft.AspNetCore.Mvc;
using core.Models.Json.City;
using core.DataModels;
using core.Models;


namespace core.Controllers
{
    /// <summary>
    /// Definition of InputController
    /// </summary>
    [ApiController]
    [Route("api/input")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public class InputController : Controller
    {
        /// <summary>
        /// Definition of connexString
        /// </summary>
        public IOptions<SQLConfig> SQLConfig;

		/// <summary>
		/// Definition of InputController
		/// </summary>
		public InputController(IOptions<SQLConfig> sqlConfig) { SQLConfig = sqlConfig; }


        /// <summary>
        /// Set AddressBook
        /// </summary>
        [HttpPost("SetAddressBook")]
        [ProducesResponseType(typeof(AddressBook), 200)]
        public IActionResult SetAddressBook(string utente, [FromBody] List<AddressBook> addressBook) => Content(new AddressBookDataModel(SQLConfig).Insert(utente, addressBook), "application/json");

        /// <summary>
        /// Set City
        /// </summary>
        [HttpPost("SetCity")]
        [ProducesResponseType(typeof(City), 200)]
        public IActionResult SetCity(string utente, [FromBody] List<City> city) => Content(new CityDataModel(SQLConfig).Insert(utente, city), "application/json");
    }
}