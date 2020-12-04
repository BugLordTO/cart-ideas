// model พวกนี้เก็บไว้ที่ server แล้ว build ขึ้น nuget ตัวใหม่
// ถ้า client จะให้ก็ดึง nuget มา
// สามารถแชร์ให้ 3rd ดึงไปใช้ได้
// อาจจะเอา ManaRequest (ตัวที่ใช้ wrap submit form) มาไว้ด้วยกัน

// service เห็นว่าร้านใช้ service อื่นได้มั้ย
//     - เห็นได้
// public int RequestGps { get; set; } // 0 / 1 / 2 อัน
//     - flag delivery shipping ทิ้งขยะ ...

public class Product
{
    public string Id { get; set; } // รหัสที่ mana ใช้
    // ไม่ได้ใช้ SubscriptioId เพราะ Subscription อาจจะขาดได้ (ไม่จ่ายเงิน ยกเลิก ...)
    // ถ้าใช้ BizAccountId + ServiceId จะทำให้ maintain product นี้ต่อได้
    public string BizAccountId { get; set; }
    public string ServiceId { get; set; }
    public string Name { get; set; }
    public string Briefs { get; set; }
    public string PreviewImageId { get; set; } // mana จะมี api เอาไว้ดึงรูปโดยส่ง ImageId ไปถึงใช้ได้ ถ้า service อื่นดึงไปใช้ จะไม่ได้
    public IEnumerbale<string> ImageIds { get; set; }
    public CurrencyAmount UnitPrice { get; set; }
    public string ProductRef { get; set; }
    public List<string> Tags { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
public class Product<TPref> : Product
{
    public TPref Preferences { get; set; } // Default preferences 
}
public class DefaultTypePreference { } // TPref
// discount per unit ? // แยกไปอีกเป็นโปรโมชั่น มีเวลาจำกัด

public class ProductPreference<TPref>
{
    public List<string> Tags { get; set; }
    public TPref Preferences { get; set; }
    public CurrencyAmount? UnitPrice { get; set; }
    public string EffectOnProductPrice { get; set; }
    public string ProductRef { get; set; }
}

// EXample 
var x = new ProductPreference<ShoeTypePreference>();

public class DefaultTypePreference { } // TPref
public class ShoeTypePreference
{
    public string Color { get; set; }
    public string Size { get; set; }
}

public class ProductPreferenceChoice
{
    public List<string> Tags { get; set; } // [ "SingleDishMeal" ]
    public string PropertyName { get; set; } // MeatType
    public string Name { get; set; } // ไก่ หมู เนื้อ กุ้ง ปลาหมึก ทะเล
    public string Value { get; set; } // Chicken Pork Meat Shrimp Squid SeaFood
    public CurrencyAmount? UnitPrice { get; set; } // 0 0 10000 10000 10000 10000
    public string EffectOnProductPrice { get; set; } // OnTop
}

public class ProductOption
{
    public string Id { get; set; }
    public string BizAccountId { get; set; }
    public string ServiceId { get; set; }
    public List<string> Tags { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }   // Just in case ... 
    public CurrencyAmount? UnitPrice { get; set; }
    public string EffectOnProductPrice { get; set; }    // None, Percent, OnTop, Replace 
}

public class CurrencyAmount
{
    public long AmountUnit { get; set; }
    public string Currency { get; set; }
}

class AccountInfo
{
    public string AccountId { get; set; } // biz endpoint make from AccountId => nbizhme-{AccountId}
    public string AccountType { get; set; } // user biz dev
    public string DisplayName { get; set; }
    public string ImageUrl { get; set; }
    public List<string> Telephone { get; set; }
}

public class ShippingMethod
{
    public string _id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Type { get; set; } //delivery,Logistic
    public long ShippingFees { get; set; }
    //เวลาจัดส่งโดยประมาณ ??
}

public class PointDiscount 
{
    public int PointUsed { get; set; }
    public CurrencyAmount PointUsedDiscount { get; set; }
}

public class Cart
{
    public AccountInfo Owner { get; set; } // biz
    public List<CartProduct> Products { get; set; }
    // create from service ? => มีผลกับ contract + budget +++++++++++++++++++++++ escrow

    //public List<string> CartRequests { get; set; }

    public int RequestGps { get; set; } // 0 / 1 / 2 อัน
    // Memberships เด๊วคุยกันปรับอีกที
    public List<string> PrivilegeMemberships { get; set; } // user เป็นสมาชิกของ Memberships บลาๆ หรือเปล่า จะได้ให้ point
    public Member MembershipRequest { get; set; }  //Request member level
    // ba / ba123456 / membership => ข้อมูลสมาชิกจากร้าน ba123456
    // ba / ba123456 / membership / {memberid} / level / gold => ข้อมูลสมาชิกจากร้าน ba123456 ระดับ gold
    // ba / ba123456 / membership / {memberid} / level / gold / + => ข้อมูลสมาชิกจากร้าน ba123456 ระดับ gold ขึ้นไป
    // sv / sv123456 / membership => ข้อมูลสมาชิกจาก service sv123456
    public ShippingMethod ShippingMethodRequest { get; set; }  // ยิง qr จาก delivery จะ เลือกอย่างอื่นไม่ได้
    // ba / grab1356 / delivery => ข้อมูล shipping จาก delivery grab1356

    public Reminder ReminderRequest { get; set; }

    public List<string> Eslip { get; set; }
    // eslip / es123456 => ใช้คูปอง es123456 ได้ => user/mana เติม id คูปองที่ user มีมาต่อท้าย
    //                                        => user เอาออก
    // eslip / es123456 / id / e12356

    //รอคุยกันก่อนมีประเด็น point ร้าน point มานะ
    public int PointUsed { get; set; }
    // ba / ba123456 / membership => ใช้แต้มจากร้าน ba123456 ได้ => user/mana เติม id สมาชิกของ user และจำนวนตะแนนที่จะใช้มาต่อท้าย
    //                                                       => user เอาออก
    // ba / ba123456 / membership / m123456 / point / 20

    public string PromoCode { get; set; }
    public CurrencyAmount PromoCodeDiscount { get; set; }

    public List<string> BizEslip { get; set; }
    // eslip / es123456 => ร้านมีคูปอง es123456 แจกให้ใช้ เช่น ถ้าซื้อซาลาเปา ลด 50 เปอ

    public List<CurrencyAmount> TotalBeforeDiscount { get; set; }
    public List<CurrencyAmount> Discount { get; set; }
    public List<CurrencyAmount> OtherFee { get; set; }
    public List<CurrencyAmount> Tax { get; set; }
    public List<CurrencyAmount> TotalToPay { get; set; }

    public string CartHash { get; set; }
}

public class CartProduct<TPref>
{
    public string ProductId { get; set; }
    public string Name { get; set; }
    public CurrencyAmount UnitPrice { get; set; }
    public string ProductRef { get; set; }
    public TPref Preferences { get; set; }
    // remark ของ product จะถูกนำมาใส้ใน option เพื่อเอาไปแสดงหน้า ui 
    List<OptionNameValue> Options { get; set; }
    public int Quantity { get; set; }
    public CurrencyAmount PromotionPrice { get; set; }
    public DateTime? PromotionStartDate { get; set; }
    public DateTime? PromotionExpriredDate { get; set; }
}

// Should have a common name-value pair 
public class OptionNameValue
{
    public string Name { get; set; }
    public string Value { get; set; }
}

// Composing, Checkout, Paid? 
public class Order : TxUnit
{
    public Cart Cart { get; set; }
    // public string Payment { get; set; } --> Ins? 

    public AccountInfo Owner { get; set; } // user
    public List<AccountInfo> CoOrders { get; set; }

    public List<Membership> Memberships { get; set; } // membership ที่ user เป็น ตามที่ cart อยากได้(PrivilegeMembership)

    //public IEnumerable<ShippingMethod> ShippingMethods { get; set; } // เอาไว้เลือก
    public ShippingMethod SelectedShippingMethod { get; set; }

    public Address StartAddress { get; set; } // ไปรับที่ไหน สินค้า/ผู้โดยสาร
    public Address ShippingAddress { get; set; } // ไปส่งที่ไหน สินค้า/ผู้โดยสาร
    public Address BillingAddress { get; set; }
    public string AddressRemark { get; set; }

    public DateTime LastUpdate { get; set; }

    public string CartHash { get; set; }    //? 
}

class Membership
{
    public string MemberId { get; set; } // MemberId จะรู้ว่าเป็นของ biz ไหนอยู่แล้ว
    public string Level { get; set; }
}

// one cart in service => from hook

public class TxUnit : WfUnitBase
{
    public string Status { get; set; }
    public List<string> Ins { get; set; } // cash eslip point
    public List<string> Outs { get; set; }
    // enforce Contract on Outs 

    public DateTime TxRequestOn { get; set; }
    public DateTime? TxBeginOn { get; set; }
    public DateTime? TxEndOn { get; set; }
}

public class WfUnitBase
{
    private PrivateUnitArea PrivateArea { get; set; }
    public WfUnitBase ParentUnit { get; set; }
    public bool ParentRequireFeedback { get; set; } // or feeeback url 
}

public class PrivateUnitArea
{
    public CurrencyAmount Balance { get; set; }
}