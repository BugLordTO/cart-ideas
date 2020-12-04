namespace Mana.Controllers
{
    [Route("[controller]")]
    public class BizAccountController : Controller
    {
        /// <summary>
        /// Visit BizAccount page endpoint
        /// </summary>
        /// <param name="endpointId">endpoint id</param>
        [HttpGet("endpoints/{endpointId}")]
        public ActionResult<ClientResponse> Get(string endpointId);

        /// <summary>
        /// Get BizAccountPage data
        /// </summary>
        /// <param name="id">The BizAccountPage id</param>
        /// <returns></returns>
        [HttpGet("bizpage/{id}")]
        public IActionResult BizAccountPage(string id);
    }
}
