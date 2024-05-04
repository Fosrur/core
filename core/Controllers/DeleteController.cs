using Microsoft.Extensions.Options;
using core.Models.Json.AddressBook;
using Microsoft.AspNetCore.Mvc;
using core.Models.Json.City;
using core.DataModels;
using core.Models;


namespace core.Controllers
{
    /// <summary>
    /// Definition of DeleteController
    /// </summary>
    [ApiController]
    [Route("api/delete")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public class DeleteController : Controller 
    {
        /// <summary>
        /// Definition of connexString
        /// </summary>
        public IOptions<SQLConfig> SQLConfig;

        /// <summary>
        /// Definition of DeleteController
        /// </summary>
        public DeleteController(IOptions<SQLConfig> sqlConfig) { SQLConfig = sqlConfig; }

        /// <summary>
        /// Delete AddressBook
        /// </summary>
        [HttpPost("DeleteAddressBook")]
        [ProducesResponseType(typeof(AddressBook), 200)]
        public IActionResult DeleteAddressBook(string utente, [FromBody] List<AddressBook> addressBook) => Content(new AddressBookDataModel(SQLConfig).Delete(utente, addressBook), "application/json");

        /// <summary>
        /// Delete City
        /// </summary>
        [HttpPost("DeleteCity")]
        [ProducesResponseType(typeof(City), 200)]
        public IActionResult DeleteCityv(string utente, [FromBody] List<City> city) => Content(new CityDataModel(SQLConfig).Delete(utente, city), "application/json");
    }
}