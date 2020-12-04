namespace BizPortal.Controllers
{
    [ApiController]
    [Route("[controller]/{serviceId}/{bizAccountId}")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<ProductResponse>> GetProduct(string serviceId, string bizAccountId);
        [HttpGet("{id}")]
        public ActionResult<ProductResponse> GetProduct(string serviceId, string bizAccountId, string id);
        [HttpPost]
        public ActionResult<ProductResponse> RegisterProduct(string serviceId, string bizAccountId, ProductRequest request);
        [HttpPut("{id}")]
        public ActionResult<ProductResponse> EditProduct(string serviceId, string bizAccountId, string id, ProductRequest request);
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(string serviceId, string bizAccountId, string id);

        [HttpGet("map")]
        public ActionResult<IEnumerable<ProductMapResponse>> ProductMap(string serviceId, string bizAccountId);
        [HttpPost("map")]
        public ActionResult<ProductMapResponse> ProductMap(string serviceId, string bizAccountId, ProductMapRequest request);

        [HttpGet("external")]
        public ActionResult<ProductExternalResponse> ProductExternal(string serviceId, string bizAccountId);
        [HttpPost("external")]
        public IActionResult RegisterProductExternal(string serviceId, string bizAccountId, ProductExternalRequest request);

        [HttpGet("option")]
        public ActionResult<IEnumerable<ProductResponse>> GetProductOption(string serviceId, string bizAccountId);
        [HttpGet("option/{id}")]
        public ActionResult<ProductResponse> GetProductOption(string serviceId, string bizAccountId, string id);
        [HttpPost("option")]
        public ActionResult<ProductResponse> RegisterProductOption(string serviceId, string bizAccountId, ProductOptionRequest request);
        [HttpPut("option/{id}")]
        public ActionResult<ProductResponse> EditProductOption(string serviceId, string bizAccountId, string id, ProductOptionRequest request);
        [HttpDelete("option/{id}")]
        public IActionResult DeleteProductOption(string serviceId, string bizAccountId, string id);
    }
}

namespace Models.Core
{
    public class CurrencyAmount
    {
        public long AmountUnit { get; set; }
        public string Currency { get; set; }
    }
}

namespace Models.Product
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string Briefs { get; set; }
        public string PreviewImageId { get; set; }
        public IEnumerable<string> ImageIds { get; set; }
        public CurrencyAmount UnitPrice { get; set; }
        public string ProductRef { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string DataHookUrl { get; set; }
        public string FormPostHookUrl { get; set; }
    }

    public class ProductMapRequest
    {
        public List<string> ProductTags { get; set; }
        public string MContentId { get; set; }
        public string ServiceId { get; set; }
        public bool Pinable { get; set; }
        // public bool IsRequireMembership { get; set; }
        public GpsSection GpsSection { get; set; }
    }

    public class ProductExternalRequest
    {
        public string ApiBaseUrl { get; set; }
    }

    public class ProductExternalResponse
    {
        public string Prefix { get; set; }
    }

    public class ProductResponse
    {
        public string _id { get; set; }
        public ProductRequest ManaProduct { get; set; }
        public ManaLinkRegistry ManaLink { get; set; }
    }

    public class ProductOptionRequest
    {
        public IEnumerable<string> Tags { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public CurrencyAmount? UnitPrice { get; set; }
        /// <summary>
        /// None, Percent, OnTop, Replace 
        /// </summary>
        public string EffectOnProductPrice { get; set; }
    }

    public class ProductOptionResponse
    {
        public string _id { get; set; }
        public ProductOptionRequest ProductOption { get; set; }
    }
}

namespace DbModels.Product
{
    public class DbModelBase
    {
        public string _id { get; set; }
    }

    public class Hook
    {
        public string Url { get; set; }
    }

    public class Product : DbModelBase
    {
        public string ServiceId { get; set; }
        public string BizAccountId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public string Name { get; set; }
        public string Briefs { get; set; }
        public string PreviewImageId { get; set; }
        public IEnumerable<string> ImageIds { get; set; }
        public CurrencyAmount UnitPrice { get; set; }
        public string ProductRef { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public Hook DataHook { get; set; }
        public Hook FormPostHook { get; set; }
    }

    public class ProductMap : DbModelBase
    {
        public string ServiceId { get; set; }
        public string BizAccountId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public List<string> ProductTags { get; set; }
        public string MContentId { get; set; }
        public bool Pinable { get; set; }
        // public bool IsRequireMembership { get; set; }
        public GpsSection GpsSection { get; set; }
    }

    public class ProductExternal : DbModelBase
    {
        public string ServiceId { get; set; }
        public string BizAccountId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Hook ApiBaseUrl { get; set; }
        public string Prefix { get; set; }
    }

    public class ProductOption : DbModelBase
    {
        public string ServiceId { get; set; }
        public string BizAccountId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public IEnumerable<string> Tags { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public CurrencyAmount? UnitPrice { get; set; }
        /// <summary>
        /// None, Percent, OnTop, Replace 
        /// </summary>
        public string EffectOnProductPrice { get; set; }
    }
}