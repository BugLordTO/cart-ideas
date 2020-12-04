public class Cart
{
    public string _id { get; set; }
    public IEnumerable<AdditionalRequest> AdditionalRequests { get; set; }
    public IEnumerable<AdditionalData> AdditionalDatas { get; set; }
    public CartInfo Info { get; set; }
    public CartOption Option { get; set; }
    public Client Client { get; set; }
    public CartExtra Extra { get; set; }
    public PaymentSummary PaymentSummary { get; set; }
    public CartForMana CartForMana { get; set; }

    //เอาไว้ track กรณีจัดการ escrow ต่อ
    public string WorkflowUnitId { get; set; } 

}

public class AdditionalRequest
{
    public string Type { get; set; }
}

public class AdditionalData
{
    public string Type { get; set; }
    public string RefType { get; set; }
    public string RefId { get; set; }
    public string Value { get; set; }
}

public class CartInfo
{
    public BillerInfo Biller { get; set; }
    public CartItemsPurchasing CartItemsPurchased { get; set; }
    public CartItemsSpending CartItemsSpending { get; set; }
    public IEnumerable<ShippingMethod> ShippingMethods { get; set; }
    public IEnumerable<string> Tags { get; set; }
}

public class CartOption
{
    // public IEnumerable<CollectibleOption> CollectibleOptions { get; set; } // old model
    public IEnumerable<string> ShopCurrencies { get; set; }
}

public class Client
{
    //User information
    public ClientInfo Info { get; set; }
    public string Nationality { get; set; }
    public IEnumerable<string> CustomerCurrencies { get; set; }

    //User Selected
    public ShippingMethod SelectedShippingMethod { get; set; }
    public Address ShippingAddress { get; set; } // model from profile
    public Address BillingAddress { get; set; }
}

public class CartExtra
{
    public string Template { get; set; }
    public string CartStatus { get; set; }
    public DateTime CreatedDate { get; set; }
}

public class PaymentSummary
{
    public IDictionary<string, decimal> TotalPrice { get; set; }
    public IDictionary<string, decimal> Discount { get; set; }
    public IDictionary<string, decimal> GrandTotal { get; set; }
}

public class CartForMana
{
    public Dictionary<string, string> WalletSlots { get; set; } // VerifyCode, WalletId
    public DateTime? CheckedoutDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public string Remark { get; set; }
}

public class BillerInfo
{
    // ของจำเป็น
    public string ShadowRefId { get; set; }
    public string BillerType { get; set; } // Shop, Personal
                                            // ข้อมูลประกอบ
                                            // Mana-app
    public string HomePageEndpoint { get; set; }
    // ทั่วไป
    public string Logo { get; set; }
    public string DisplayName { get; set; }
}

public class CartItemsPurchasing
{
    public IEnumerable<ProductCartItem> ProductItems { get; set; } // old model
    public decimal? AdHoc { get; set; }
}

public class CartItemsSpending
{
    public IEnumerable<CouponCartItem> CouponItems { get; set; } // old model
    public IEnumerable<MembershipCartItem> MembershipItems { get; set; } // old model
    public IEnumerable<WalletInfo> PersonalWallets { get; set; }
    public IEnumerable<WalletInfo> CompanyWallets { get; set; }
}

public class ShippingMethod
{
    public string _id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Type { get; set; }
    public decimal ShippingFees { get; set; }
}

public class ClientInfo
{
    // ของจำเป็น
    public string ShadowRefId { get; set; }
    public string ContactByEmail { get; set; }
    public string ContactByMobile { get; set; }
    // ข้อมูลประกอบ
    // Mana
    public string ClientType { get; set; } // Personal, Company, Service
                                            // ทั่วไป
    public string DisplayName { get; set; }
}

public class ProductCartItem
{
    public string _id { get; set; }
    public Product ProductDetail { get; set; }
    public int? Quantity { get; set; } // 3rd response hook กลับมา เติม/ไม่เติม ก็ได้
    public int? StockQuantity { get; set; } // 3rd เติมตอน response hook กลับมา เติม/ไม่เติม ก็ได้
    public ManaProductPrice DefaultPrice { get; set; }
    public decimal? AdditionalPrice { get; set; } // summary from Preferences and options
    public string AdditionalText { get; set; } // concat title from Preferences and options eg. "ความหวาน:หวานน้อย, ขนาด:S, เพิ่มวิปครีม"
    public decimal? Discount { get; set; } // ติดไว้ก่อน
    public DateTime? DiscountExpiredDate { get; set; }
    public decimal Total { get; set; } // ManaProductPrice.Price + AdditionalPrice - Discount
    // public string CurrencyType { get; set; }
    public IEnumerable<string> Tags { get; set; }  // เพิ่มใหม่
    public IEnumerable<ProductPreference> Preferences { get; set; }
    public IEnumerable<ProductOption> Options { get; set; }
}

public class WalletInfo
{
    public string Currency { get; set; }
    public decimal Amount { get; set; }
    public string VerifyCode { get; set; }
}

public class ProductPreference
{
    public string _id { get; set; }
    public string Title { get; set; } // ชื่อที่แสดง เช่น ความหวาน
    public int Quantity { get; set; }
    public ProductChoice Choice { get; set; }
}

public class ProductChoice
{
    public string Title { get; set; } // ชื่อที่แสดง เช่น หวานน้อย หวานมาก
    public string Code { get; set; } // ทำหน้าที่เหมือน id
    public decimal Value { get; set; } // เงินที่ต้องจ่ายเพิ่ม
    // public string CurrencyType { get; set; }
}

public class ProductOption
{
    public string _id { get; set; }
    public string Title { get; set; } // ชื่อที่แสดง เช่น เพิ่มไข่ดาว
    public decimal Value { get; set; } // เงินที่ต้องจ่ายเพิ่ม
    // public string CurrencyType { get; set; }
}

{
    "_id" : "637067097535372556",
    "_t" : "Cart",
    "AdditionalRequests" : [ 
        {
            "Type" : "Member"
        }, 
        {
            "Type" : "MemberDisplayName"
        }
    ],
    "AdditionalDatas" : null,
    "Info" : {
        "Biller" : {
            "ShadowRefId" : "637056708179266308",
            "BillerType" : "shop",
            "HomePageEndpoint" : null,
            "Logo" : "https://promomerising.blob.core.windows.net/mana-merchant-logo-dev/637056708179266308.jpg",
            "DisplayName" : "MO TO - O"
        },
        "CartItemsPurchased" : {
            "ProductItems" : [],
            "AdHoc" : NumberDecimal("0")
        },
        "CartItemsSpending" : {
            "CouponItems" : null,
            "MembershipItems" : null,
            "PersonalWallets" : null,
            "CompanyWallets" : null
        },
        "ShippingMethods" : [ 
            {
                "Name" : "จ่ายที่ร้าน",
                "Type" : "OnShop",
                "ShippingFees" : NumberDecimal("0")
            }
        ],
        "Tags" : [ 
            "InnovationMarket"
        ]
    },
    "Option" : {
        "CollectibleOptions" : [ 
            {
                "CollectibleItems" : [ 
                    {
                        "Value" : 50,
                        "DiscountExpiredDate" : null,
                        "ItemType" : "Coupon",
                        "PhysicalCurrencyItem" : null,
                        "DigitalCurrencyItem" : null,
                        "CouponItem" : {
                            "CouponId" : "637067079860508343",
                            "Currency" : "THB",
                            "CouponExpiredDate" : null,
                            "Discount" : NumberDecimal("50")
                        },
                        "MembershipItem" : null
                    }
                ],
                "OptionType" : "PartialOption"
            }
        ],
        "ShopCurrencies" : [ 
            "THB"
        ]
    },
    "Client" : null,
    "Extra" : {
        "Template" : "express",
        "CartStatus" : "UnPaid",
        "CreatedDate" : ISODate("2019-10-15T04:15:53.537Z")
    },
    "PaymentSummary" : null,
    "CartForMana" : null,
    "_partitionKey" : "WWpqAJFc+Qg="
}