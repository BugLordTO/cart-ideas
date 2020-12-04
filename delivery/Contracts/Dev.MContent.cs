namespace DevPortal.Controllers
{
    [ApiController]
    [Route("[controller]/{serviceId}")]
    public class MContentController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<MContentResponse>> GetMContent(string serviceId);

        [HttpGet("{id}")]
        public ActionResult<MContentResponse> GetMContent(string serviceId, string id);

        [HttpGet("{id}")]
        public IActionResult DeleteMContent(string serviceId, string id);

        [HttpPost("page")]
        public ActionResult<MContentResponse> RegisterMContentPage(string serviceId, MContentPageRequest request);

        [HttpPut("page/{id}")]
        public ActionResult<MContentResponse> EditMContentPage(string serviceId, string id, MContentPageRequest request);

        [HttpPost("form")]
        public ActionResult<MContentResponse> RegisterMContentForm(string serviceId, MContentFormRequest request);

        [HttpPut("form/{id}")]
        public ActionResult<MContentResponse> EditMContentForm(string serviceId, string id, MContentFormRequest request);

        [HttpPost("option")]
        public ActionResult<MContentResponse> RegisterMContentOption(string serviceId, MContentOptionRequest request);

        [HttpPut("option/{id}")]
        public ActionResult<MContentResponse> EditMContentOption(string serviceId, string id, MContentOptionRequest request);

        [HttpPut("option/{id}/bind")]
        public ActionResult<MContentResponse> MContentOptionBinding(string serviceId, string id, MContentOptionBind request);
    }
}

namespace Models.MContent
{
    public class MContentResponse
    {
        public string MContentId { get; set; }
        public MContentPageRequest MContent { get; set; }
        /// <summary>
        /// test url => https://mana.com/mcontent/{mcontentid}/nmctmck-{mcontentid}
        /// </summary>
        public string ManaUrl { get; set; }
    }

    public class MContentBase
    {
        public string Name { get; set; }
        /// <summary>
        /// base url include base path that specify in <base href="basePath"/>
        /// </summary>
        public string BaseUrl { get; set; }
        /// <summary>
        /// Html, BindableHtml, Url
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// only path of content, exclude host and base path
        /// </summary>
        public string ContentHtml { get; set; }
        /// <summary>
        /// parameterized-formatted
        /// </summary>
        public string ContentUrl { get; set; }
        public IEnumerable<string> Tags { get; set; }
        /// <summary>
        /// for white list
        /// </summary>
        public IEnumerable<string> AllowUrls { get; set; }

        public IEnumerable<ActionItem> ActionItems { get; set; }
        /// <summary>
        /// default DataHookUrl
        /// </summary>
        public string DataHookUrl { get; set; }
    }

    public class ActionItem
    {
        /// <summary>
        /// Display text
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Javascript function name to call
        /// </summary>
        public string Action { get; set; }
    }

    public class MContentPageRequest : MContentBase { }

    public class MContentFormRequest : MContentBase
    {
        public bool IsShowButton { get; set; }
        /// <summary>
        /// default FormPostHookUrl
        /// </summary>
        public string FormPostHookUrl { get; set; }
    }

    public class MContentOptionRequest : MContentBase { }

    public class MContentOptionBind
    {
        public IEnumerable<string> MContentOptionIds { get; set; }
    }
}

namespace DbModels.MContent
{
    public class DbModelBase
    {
        public string _id { get; set; }
    }

    public class Hook
    {
        public string Url { get; set; }
    }

    public class MContent : DbModelBase
    {
        public string ItemType { get; set; }
        public string ServiceId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public IEnumerable<string> OptionIds { get; set; }

        public string Name { get; set; }
        /// <summary>
        /// base url include base path that specify in <base href="basePath"/>
        /// </summary>
        public string BaseUrl { get; set; }
        /// <summary>
        /// Html, BindableHtml, Url
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// only path of content, exclude host and base path
        /// </summary>
        public string ContentHtml { get; set; }
        /// <summary>
        /// parameterized-formatted
        /// </summary>
        public string ContentUrl { get; set; }
        public IEnumerable<string> Tags { get; set; }
        /// <summary>
        /// for white list
        /// </summary>
        public IEnumerable<string> AllowUrls { get; set; }
        public IEnumerable<ActionItem> ActionItems { get; set; }
        /// <summary>
        /// default DataHook
        /// </summary>
        public Hook DataHook { get; set; }
        /// <summary>
        /// default FormPostHook
        /// </summary>
        public Hook FormPostHook { get; set; }
    }

    public class MContentItemTypePossible
    {
        public string MContentPage = nameof(MContentPage);
        public string MContentForm = nameof(MContentForm);
        public string MContentOption = nameof(MContentOption);
    }
}
