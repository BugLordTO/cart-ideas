public class CartOption
{
    public string _id { get; set; }
    public string CartId { get; set; }

    public IEnumerable<CollectibleOption> CollectibleOptions { get; set; }
    public IEnumerable<string> ShopCurrencies { get; set; }
    public IEnumerable<string> CustomerCurrencies { get; set; }
}      