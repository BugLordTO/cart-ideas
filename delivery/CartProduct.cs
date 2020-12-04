//-------------------------------------------------------------- 3rd api & request/response model

class IProductController
{
    // Generate id api for mana product
    // npdtdtl-{productid}.{tag1:select}.{tag2:select}.{tag3:select}.{tag4:select}
    // npdtdtl-{prefix}.{productrefid}.{tag1:select}.{tag2:select}.{tag3:select}.{tag4:select}

    IEnumerable<ManaProductResponse> GetProduct();
    ManaProductResponse GetProduct(string id);
    ManaLink RegisterProduct(ProductRequest request);
    ManaLink EditProduct(string id, ProductRequest request);
    void DeleteProduct(string id);

    void ProductMap(ProductMapRequest request);

    IEnumerable<ProductResponse> GetProductOption();
    ProductResponse GetProductOption(string id);
    ManaLink RegisterProductOption(ProductOptionRequest request);
    ManaLink EditProductOption(string id, ProductOptionRequest request);
    void DeleteProductOption(string id);

    // IEnumerable<ProductResponse> GetProductPreference();
    // ProductResponse GetProductPreference(string id);
    // ManaLink RegisterProductPreference(ProductPreferenceRequest request);
    // ManaLink EditProductPreference(string id, ProductPreferenceRequest request);
    // void DeleteProductPreference(string id);
}

class ProductRequest
{
    public string Name { get; set; }
    public string Briefs { get; set; }
    public IEnumerbale<string> ImageUrls { get; set; }
    public CurrencyAmount UnitPrice { get; set; }
    public string ProductRef { get; set; }
    public IEnumerable<string> Tags { get; set; }
}

public class CurrencyAmount
{
    public long AmountUnit { get; set; }
    public string Currency { get; set; }
}

class ProductMapRequest
{
    public List<string> ProductTags { get; set; }
    public string MContentId { get; set; }
    public string ServiceId { get; set; }
    public string DataHookUrl { get; set; }
    public string FormPostHook { get; set; }
    // public int ShowGpsCount { get; set; } // ไม่มี gps ให้เลือก
    public bool IsRequireMembership { get; set; }
    public bool CanPinToShortcut { get; set; }
    // public bool RequireSecurityOptions { get; set; } // ยังไม่มีรายละเอียด
}

class ProductResponse
{
    ManaProduct ManaProduct { get; set; }
    ManaLink ManaLink { get; set; }
}

class ProductOptionRequest
{
    public IEnumerable<string> Tags { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public CurrencyAmount? UnitPrice { get; set; }
    public string EffectOnProductPrice { get; set; } // None, Percent, OnTop, Replace 
}

//-------------------------------------------------------------- DB base class model

// collection
class Product
{
    public string Id { get; set; }
    public string BizAccountId { get; set; }
    public string ServiceId { get; set; }
    public string Name { get; set; }
    public string Briefs { get; set; }
    public string PreviewImageId { get; set; }
    public IEnumerbale<string> ImageIds { get; set; }
    public CurrencyAmount UnitPrice { get; set; }
    public string ProductRef { get; set; }
    public IEnumerable<string> Tags { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}

// collection
class ProductOption
{
    public string Id { get; set; }
    public string BizAccountId { get; set; }
    public string ServiceId { get; set; }
    public IEnumerable<string> Tags { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public CurrencyAmount? UnitPrice { get; set; }
    public string EffectOnProductPrice { get; set; } // None, Percent, OnTop, Replace 
}

// public class Product<TPref> : Product
// {
//     public TPref Preferences { get; set; } // Default preferences 
// }
// public class DefaultTypePreference { }

// // collection
// public class ProductPreference<TPref>
// {
//     public string Id { get; set; }
//     public List<string> Tags { get; set; }
//     public TPref Preferences { get; set; }
//     public CurrencyAmount? UnitPrice { get; set; }
//     public string EffectOnProductPrice { get; set; }
//     public string ProductRef { get; set; }
// }

//-------------------------------------------------------------- View model

class ProductView
{
    public string Id { get; set; }
    public AccountInfo BizOwner { get; set; }
    public string Name { get; set; }
    public string Briefs { get; set; }
    public string PreviewImageId { get; set; }
    public IEnumerbale<string> ImageIds { get; set; }
    public CurrencyAmount UnitPrice { get; set; }
    public string ProductRef { get; set; }
    public IEnumerable<string> Tags { get; set; }
    public IEnumerable<OptionView> Options { get; set; }
}

class AccountInfo
{
    public string AccountId { get; set; } // biz endpoint make from AccountId => nbizhme-{AccountId}
    public string AccountType { get; set; } // user biz dev
    public string DisplayName { get; set; }
    public string ImageUrl { get; set; }
    public IEnumerable<string> Telephone { get; set; }
}

class OptionView
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public CurrencyAmount UnitPrice { get; set; }
    public string EffectOnProductPrice { get; set; } // None, Percent, OnTop, Replace 
}

//-------------------------------------------------------------- Submit
// send product quantity in wrapped body

class ProductRequest
{
    public string Id { get; set; }
    public IEnumerable<OptionRequest> SelectedOptions { get; set; }
}

class OptionRequest
{
    public string Id { get; set; }
    // public string Quantity { get; set; }
}
