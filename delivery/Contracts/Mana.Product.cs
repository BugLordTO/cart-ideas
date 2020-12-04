namespace Mana.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        /// <summary>
        /// Visit Product page endpoint
        /// </summary>
        /// <param name="endpointId">endpoint id</param>
        [HttpGet("endpoints/{endpointId}")]
        public ActionResult<ClientResponse> Get(string endpointId);

        /// <summary>
        /// Add Product to cart
        /// </summary>
        /// <param name="id">Product id</param>
        [HttpPost("data/{id}")]
        public ActionResult<ClientResponse> Post(ProductForm form, string id, int Quantity, string Address1, string Latitude1, string Longitude1, string PhoneNumber1, string Remark1);

        /// <summary>
        /// Get Product data
        /// </summary>
        /// <param name="id">Product id</param>
        [HttpGet("data/{id}")]
        public ActionResult<ProductViewResponse> GetData(string id);
    }
}

namespace Models.View.Core
{
    public class AccountInfo
    {
        /// <summary>
        /// biz endpoint make from AccountId => nbizhme-{BaId}
        /// </summary>
        public string AccountId { get; set; }
        /// <summary>
        /// user biz dev
        /// </summary>
        public string AccountType { get; set; }
        public string DisplayName { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<string> Phonenumbers { get; set; }
    }

    public class CurrencyAmount
    {
        public long AmountUnit { get; set; }
        public string Currency { get; set; }
    }
}

namespace Models.View.Product
{
    public class ProductViewResponse
    {
        public AccountInfo BizAccount { get; set; }
        public ProductView Product { get; set; }
        public IEnumerable<OptionView> Options { get; set; }
    }

    public class ProductView
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string Briefs { get; set; }
        public string PreviewImageId { get; set; }
        public IEnumerable<string> ImageIds { get; set; }
        public CurrencyAmount UnitPrice { get; set; }
        public string ProductRef { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }

    public class OptionView
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public CurrencyAmount UnitPrice { get; set; }
        /// <summary>
        /// None, Percent, OnTop, Replace 
        /// </summary>
        public string EffectOnProductPrice { get; set; }
    }

    public class ProductForm
    {
        public IEnumerable<OptionRequest> SelectedOptions { get; set; }
    }

    public class OptionRequest
    {
        public string Name { get; set; }
        public string Value { get; set; }
        // public string Quantity { get; set; }
    }
}