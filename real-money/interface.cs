// idea
interface ICommonWalletService
{
    //กลุ่ม1
    Wallet CreateWallet(string paid);
    string StartTopupByQR(string walletId, MonetaryValue amount); // return txId
    void ExecuteTopupByQR(string txId);
    MonetaryValue GetBalance(string walletId);

    //กลุ่ม2
    Wallet CreateBizWallet(string baid); // user & biz สร้างเหมือนกัน? ใช้ด้วยกันได้ ?
    string StartAdhoc(string walletId, MonetaryValue amount); // return txId
    void ExecuteAdhoc(string txId);
    string StartEscrow(string walletId); // return txId >> input contract ? just ins outs ?
    void ExecuteEscrow(string txId);
    void ReleaseEscrow(string txId); // condition ? follow by contract ?
    string StartBizWithdraw(string baId, string walletId, MonetaryValue amount); // return txId
    void ExecuteBizWithdraw(string txId);
    string StartWithdrawPPY(string walletId, MonetaryValue amount); // return txId
    void ExecuteWithdrawPPY(string txId);

    //------------------------------------------------
    // กลุ่ม3
    // Wallet GetWallets(string walletId);
    // WalletItem GetWalletItem(string walletItemId);
    // WalletItem GetDefaultWalletItem(string walletId);
    // MonetaryValue GetDefaultWalletItemBalance(string walletId);
    // void Transfer(WalletTx tx);
    // void Escrow(WalletTx tx); // input contract ? just ins out ?

    // NOTE:
    // - work with countryCode
}






// idea primitive ๆ
interface ICommonWalletService
{
    // manage
    Wallet CreateWallet(string id); // paid baid
    MonetaryValue GetBalance(string walletId);
    //void TerminateWallet(string walletId);

    // เชื่อมต่อภายนอก เงินเข้า/ออก
    string StartDeposit(string walletId, MonetaryValue amount, Type type); // return txId
    void ExecuteDeposit(string txId);
    string StartWithdraw(string walletId, MonetaryValue amount, Type type); // return txId
    void ExecuteWithdraw(string txId);

    // โอนย้ายภายใน
    string StartTransaction(InOut ins, InOut outs, bool isEscrow = false); // return txId >> input contract ? just ins outs ?
    void UpdateTransaction(...);
    void ExecuteTransaction(string txId);
    void ReleaseEscrow(string txId); // release condition ? follow by contract ? how ?

    // ตอน start ใส่ refId เข้าไปด้วย ? เผื่อใช้อ้างถึงกรณีผิดพลาด txId หาย ?
}
class InOut
{
    public string WalletId { get; set; }
    public MonetaryValue amount { get; set; }
}
struct MonetaryValue { }







public class Wallet : DbModelBase
{
    public string UserId { get; set; }
    public IEnumerable<WalletItem> Wallets { get; set; }
    public string DefaultWalletItemId { get; set; }
}

public class WalletItem
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public MonetaryValue Balance { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdatedDate { get; set; } // last sync
}

public class WalletTx : DbModelBase
{
    // public WalletAccount Issuer { get; set; } // ???????????????
    // public WalletAccount Target { get; set; } // ???????????????
    public MonetaryValue Amount { get; set; }
    public string TxType { get; set; }
    public string Status { get; set; }
    public string RefId { get; set; }
    /// <summary>
    /// orderId adhocSessionId
    /// </summary>
    public string RefIdType { get; set; }
    public string RefCode { get; set; }
    public DateTime? CompletedDate { get; set; }
}

public class WalletAccount
{
    public string Id { get; set; }
    /// <summary>
    /// pa ba
    /// </summary>
    public string Type { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string WalletName { get; set; }
    public string WalletId { get; set; }
    public string WalletItemId { get; set; }
}

public class PossibleTxStatus
{
    public const string Creating = nameof(Creating);
    public const string Pending = nameof(Pending);
    public const string Success = nameof(Success);
    public const string Cancel = nameof(Cancel);
}

public class PossibleTxType
{
    public class Income
    {
        public const string deposit = nameof(deposit);
        public const string receive = nameof(receive);
    }
    public class Outcome
    {
        public const string withdraw = nameof(withdraw);
        public const string adhoc = nameof(adhoc);
        public const string paycart = nameof(paycart);
        public const string transfer = nameof(transfer);
    }
}