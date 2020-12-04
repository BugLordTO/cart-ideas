namespace Mana.Controllers
{
    [Route("[controller]")]
    public class ReminderController : Controller
    {
        /// <summary>
        /// Visit Reminder page endpoint
        /// </summary>
        /// <param name="endpointId">endpoint id</param>
        [HttpGet("endpoints/{endpointId}")]
        public ActionResult<ClientResponse> Get(string endpointId);

        /// <summary>
        /// Get Reminder data from 3rd party
        /// </summary>
        /// <param name="id">Reminder id</param>
        [HttpGet("data/{id}")]
        public ActionResult GetData(string id);

        /// <summary>
        /// Post Reminder data to 3rd party
        /// </summary>
        /// <param name="id">Reminder id</param>
        [HttpPost("data/{id}")]
        public ActionResult PostData(string id, string address, string Latitude, string Longitude);
    }
}
