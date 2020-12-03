namespace Vm
{    
    public class UserCart
    {
        public string _id { get; set; }
        public CustomerShortInfo CustomerShortInfo { get; set; }
        public MerchantShortInfo MerchantShortInfo { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }

        public string CartStatus { get; set; }//UnPaid, HookedReject, Paid, Packaging, Shipping, Arrived, Received 
        public string Remark { get; set; }
        public string Template { get; set; }//Checkout, Pay, Adhoc
        public IEnumerable<string> Tags { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime? CheckedoutDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        //public IEnumerable<ProductCartItem> ProductItems { get; set; } 
        //public IEnumerable<CouponCartItem> CouponItems { get; set; }
        //public IEnumerable<MembershipItem> MembershipItems { get; set; }//Subscribing (purchasing) membership
        //public IEnumerable<CollectibleOption> CollectibleOptions { get; set; }//combination of all ProductItem's CollectibleOptions ???
        //public IEnumerable<string> ShopCurrencies { get; set; }
        //public IEnumerable<string> CustomerCurrencies { get; set; }
        //public IEnumerable<ShippingMethod> ShippingMethods { get; set; }
        //public IEnumerable<string> WalletIds { get; set; }

        /// <summary>
        /// The key is productId in cart
        /// The value is selected Collectible Option (1 full / 0.* partial)
        /// </summary>
        public IDictionary<string , List<CollectibleOption>> SelectedOptions { get; set; }
        public ShippingMethod SelectedShippingMethod { get; set; }
        public IEnumerable<string> SelectedWalletIds { get; set; }
        public IEnumerable<CollectibleItem> DiscountItems { get; set; }
        
        /// <summary>
        /// The key of TotalPrice Discount and GrandTotal is currency code
        /// </summary>
        public IDictionary<string, decimal> TotalPrice { get; set; }//Calculated from shop when hook to CartHook with Nationality
        public IDictionary<string, decimal> Discount { get; set; }//Calculated from shop when hook to CartHook with Nationality
        public IDictionary<string, decimal> GrandTotal { get; set; }//Calculated from shop when hook to CartHook with Nationality
        public string Nationality { get; set; }//For charge price
    }

    public class CustomerShortInfo
    {
        //public string UserId { get; set; }
        public string DisplayName { get; set; }
        public Contact Contact { get; set; }
        public Address Address { get; set; }
    }

    public class MerchantShortInfo
    {
        public string Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string HomePageEndpoint { get; set; }
    }

    public class ShippingMethod
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal ShippingFees { get; set; }
    }

    public class CartMembership
    {
        public string MemberId { get; set; }
        public string MemberLevel { get; set; }
        public int Point { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string MerchantId { get; set; }
    }
}
