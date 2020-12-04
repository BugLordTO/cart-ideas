namespace Mana.Controllers
{
    [Route("[controller]")]
    public class CartController : Controller
    {
        /// <summary>
        /// Visit Cart page endpoint
        /// </summary>
        /// <param name="endpointId">endpoint id</param>
        [HttpGet("endpoints/{endpointId}")]
        public ActionResult<ClientResponse> Get(string endpointId);

        /// <summary>
        /// Takeaction Cart => Order, Checkout
        /// </summary>
        /// <param name="endpointId">endpoint id</param>
        [HttpPost("endpoints/{endpointId}")]
        public ActionResult<ClientResponse> Post(string endpointId);

        /// <summary>
        /// Get Cart data
        /// </summary>
        /// <param name="id">Cart id</param>
        [HttpGet("data/{id}")]
        public ActionResult<OrderView> GetData(string id);
    }
}

namespace Models.View.Core
{
    class AccountInfo
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

namespace Models.View.Cart
{
    public class CartView
    {
        public AccountInfo Owner { get; set; }
        public IEnumerbale<CartProduct> Products { get; set; }

        public IEnumerbale<CurrencyAmount> TotalBeforeDiscount { get; set; }
        public IEnumerbale<CurrencyAmount> Discount { get; set; }
        public IEnumerbale<CurrencyAmount> OtherFee { get; set; }
        public IEnumerbale<CurrencyAmount> Tax { get; set; }
        public IEnumerbale<CurrencyAmount> TotalToPay { get; set; }
    }

    public class CartProduct
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public CurrencyAmount UnitPrice { get; set; }
        public string OptionSummary { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderView
    {
        public CartView Cart { get; set; }
        public bool CanChangeShippingMethod { get; set; }
        public ShippingMethod SelectedShippingMethod { get; set; }
        public Address ShippingAddress { get; set; } // ไปส่งที่ไหน สินค้า/ผู้โดยสาร
        public string AddressRemark { get; set; }
    }

    public class ShippingMethod
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string ImageUrl { get; set; }
    }
}
