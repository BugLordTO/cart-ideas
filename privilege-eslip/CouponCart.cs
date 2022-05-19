public class CouponCart {
    public string _id { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string BannerImageUrl { get; set; }
    public string IconImageUrl { get; set; }
    public IEnumerable<string> Tags { get; set; }
    public int TotalQuantity { get; set; }
    public bool IsOnlyMember { get; set; }
    public bool CanGetOnce { get; set; }
    public bool CanTransfer { get; set; }
    public bool IsManualApprove { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? SuspendedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? ExpiredDate { get; set; }
    public ShortInfo OwnerService { get; set; }
    public ShortInfo OwnerMerchant { get; set; }
    public IEnumerable<EslipSchedule> Schedules { get; set; }

    public IEnumerable<CouponCartStubConditionSet> ConditionSets { get; set; }
    public IEnumerable<CouponCartStubEffectSet> EffectSets { get; set; }
    public bool IsAllowOnePerCart { get; set; }
}

public class CouponCartStubConditionSet {
    public IEnumerable<CouponCartStubCondition> Conditions { get; set; }
}

public class CouponCartStubCondition { }

public class CouponCartStubConditionForCart : CouponCartStubCondition {
    public string CartId { get; set; }
}

public class CouponCartStubConditionForMerchant : CouponCartStubCondition {
    public string MerchantId { get; set; }
    public decimal? MinimumPrice { get; set; }
    public decimal? MaximumPrice { get; set; }
    public int? Quantity { get; set; }
}

public class CouponCartStubConditionForMerchants : CouponCartStubCondition {
    public IEnumerable<string> MerchantIds { get; set; }
    public decimal? MinimumSumPrice { get; set; }
    public decimal? MaximumSumPrice { get; set; }
    public int? SumQuantity { get; set; }
}

public class CouponCartStubConditionForProduct : CouponCartStubCondition {
    public string ProductId { get; set; }
    public decimal? MinimumPrice { get; set; }
    public decimal? MaximumPrice { get; set; }
    public int? Quantity { get; set; }
}

public class CouponCartStubConditionForProducts : CouponCartStubCondition {
    public IEnumerable<string> ProductIds { get; set; }
    public decimal? MinimumSumPrice { get; set; }
    public decimal? MaximumSumPrice { get; set; }
    public int? SumQuantity { get; set; }
}

public class CouponCartStubConditionForCart : CouponCartStubCondition {
    public decimal? MinimumTotalPrice { get; set; }
    public decimal? MaximumTotalPrice { get; set; }
    public int? TotalQuantity { get; set; }
}

public class CouponCartStubConditionLocation : CouponCartStubCondition {
    public decimal? LocationLatitude { get; set; }
    public decimal? LocationLongtitude { get; set; }
    public decimal? DistanceKMFromLocation { get; set; }

    public decimal? DistanceKMFromMerchant { get; set; }

    public string ShippingAddressDistrict { get; set; }
    public string ShippingAddressCity { get; set; }
    public string ShippingAddressProvince { get; set; }

    public string BillingAddressDistrict { get; set; }
    public string BillingAddressCity { get; set; }
    public string BillingAddressProvince { get; set; }
}

public class CouponCartStubEffectSet { 
    public IEnumerable<CouponCartStubEffect> Effects { get; set; }
}

public class CouponCartStubEffect { }

public class CouponCartStubEffectCartDiscountConstant : CouponCartStubEffect {
    public decimal Amount { get; set; }
}

public class CouponCartStubEffectCartDiscountPercentage : CouponCartStubEffect {
    public decimal Percentage { get; set; }
}

public class CouponCartStubEffectProductDiscountConstant : CouponCartStubEffect {
    public IEnumerable<string> ProductIds { get; set; }
    public decimal Amount { get; set; }
}

public class CouponCartStubEffectProductDiscountPercentage : CouponCartStubEffect {
    public IEnumerable<string> ProductIds { get; set; }
    public decimal Percentage { get; set; }
}

public class ShortInfo {
    public string _id { get; set; }
    public string Name { get; set; }
    public string LogoImageUrl { get; set; }
    public string FullAddress { get; set; }
}

public class EslipSchedule {
    public bool IsSunday { get; set; }
    public bool IsMonday { get; set; }
    public bool IsTuesday { get; set; }
    public bool IsWednesday { get; set; }
    public bool IsThursday { get; set; }
    public bool IsFriday { get; set; }
    public bool IsSaturday { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}

public class CouponCartInstance {
    public string _id { get; set; }
    public DateTime AcquireDate { get; set; }
    public DateTime? ActivatedDate { get; set; }
    public ShortInfo OwnerUser { get; set; }
    public ShortInfo DistributerMerchant { get; set; }
    public EslipStubShortInfo EslipStub { get; set; }
    public IEnumerable<RequestUseLog> RequestUseLogs { get; set; }
    public IEnumerable<TransferLog> TransferLogs { get; set; }
}

public class EslipStubShortInfo
{
    public string Description { get; set; }
    public string Condition { get; set; }
    public ShortInfo OwnerMerchant { get; set; }
}