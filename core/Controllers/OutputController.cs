using Microsoft.Extensions.Options;
using core.Models.Json.AddressBook;
using Microsoft.AspNetCore.Mvc;
using core.Models.Json.Gender;
using core.Models.Json.City;
using core.DataModels;
using core.Models;


namespace core.Controllers
{
    /// <summary>
    /// Definition of OutputController
    /// </summary>
    [ApiController]
    [Route("api/output")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public class OutputController : Controller
    {
		/// <summary>
		/// Definition of connexString
		/// </summary>
		public IOptions<SQLConfig> SQLConfig;

		/// <summary>
		/// Definition of OutputController
		/// </summary>
		public OutputController(IOptions<SQLConfig> sqlConfig) { SQLConfig = sqlConfig; }

        /// <summary>
        /// Gets AddressBook
        /// </summary>
        [HttpPost("GetAddressBook")]
        [ProducesResponseType(typeof(AddressBook), 200)]
        public IActionResult GetAddressBook(string utente, [FromBody] AddressBook addressBook) => Content(new AddressBookDataModel(SQLConfig).Select(utente, addressBook), "application/json");

        /// <summary>
        /// Gets City
        /// </summary>
        [HttpPost("GetCity")]
        [ProducesResponseType(typeof(City), 200)]
        public IActionResult GetCity(string utente, [FromBody] City city) => Content(new CityDataModel(SQLConfig).Select(utente, city), "application/json");

        /// <summary>
        /// Gets Gender
        /// </summary>
        [HttpPost("GetGender")]
        [ProducesResponseType(typeof(Gender), 200)]
        public IActionResult GetGender(string utente, [FromBody] Gender gender) => Content(new GenderDataModel(SQLConfig).Select(utente, gender), "application/json");
    }
}