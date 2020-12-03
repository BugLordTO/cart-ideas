public class CollectibleOption
{
    public string Title { get; set; }
    public DateTime ValidDate { get; set; }
    public DateTime ExpiredDate { get; set; }
    /// <summary>
    /// THB, JPY, USD
    /// BTC, ETH
    /// </summary>
    public string Currency { get; set; }
    public decimal Price { get; set; }
    public IEnumerable<CollectibleItem> CollectibleItems { get; set; }
}

public class CollectibleItem
{
    public DateTime ExpiredDate { get; set; }
}

public class PhysicalCurrencyItem : CollectibleItem { }

public class CartCouponItem : CollectibleItem
{
    public string CartCouponId { get; set; }
    public string Currency { get; set; }
    public decimal Discount { get; set; }
}

public class ManaPointItem : CollectibleItem { }

public class MembershipPointItem : CollectibleItem
{
    public string MerchantId { get; set; }
}
