public class Product : DbModelBase
{
    // public string ServiceId { get; set; }
    public string BizAccountId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? SuspendedDate { get; set; }
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

    [BsonExtraElements]
    public IDictionary<string, object> ExtraElements { get; set; }
}

//=========================================================================================

public class CartOrder : DbModelBase
{
    public string PaId { get; set; }
    public List<CartProduct> Products { get; set; }
    public Address ShippingAddress { get; set; }
    public ShippingMethod ShippingMethod { get; set; }
    public BizAccount BizAccount { get; set; }
    public List<CurrencyAmount> TotalToPay { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? PaidDate { get; set; }
    public DateTime? CanceledDate { get; set; }
}

public class BizAccount
{
    public string _id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string EndpointUrl { get; set; }
}

public class CartProduct
{
    public string _id { get; set; }
    public string Name { get; set; }
    public string PreviewImageUrl { get; set; }
    public CurrencyAmount UnitPrice { get; set; }
    public List<OptionNameValue> Options { get; set; }
    public int Quantity { get; set; }
}
public class OptionNameValue
{
    public string Name { get; set; }
    public string Value { get; set; }
    //public int Quantity { get; set; }
    public CurrencyAmount UnitPrice { get; set; } // +
}

public class ShippingMethod
{
    public string _id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    // public string Type { get; set; } //delivery,Logistic
    public CurrencyAmount ShippingFees { get; set; }
}

//=========================================================================================

public class Order {
    public string _id { get; set; }
    public CartOrder Cart { get; set; }
    public string State { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public DateTime? CanceledDate { get; set; }
}
public class DeliveryOrder : Order {
    // neschfd-{_id} nescccl-{_id} nescfnh-{_id}
    // cart - ยกมาทั้งก้อน
    // rider - ใครส่ง
    // state - up to 3rd // paid, rideraccepted, restaurantcompleted, ridertakeitem, riderdelivered, completed, canceled
    // cancel endpoint - หน้าขอยกเลิก nescccl-{_id} 
    // completed endpoint - จบแล้วไปหน้าไหนต่อ > rating nescfnh-{_id}

    // CreatedDate
    // CompletedDate
    // CanceledDate

    public Rider Rider { get; set; }
}
public class Rider {
    public string _id { get; set; } // employeeId
    public string RefId { get; set; } // riderId
    public string Name { get; set; }
    public string ImageUrl { get; set; }
}










s a t o r
a r e p o
t e n e t
o p e r a
r o t a s