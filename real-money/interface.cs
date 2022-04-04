// https://docs.google.com/spreadsheets/d/1zdXogQrCmyDzalphl6nTuulqvo2Dsvd0GAz37pItrkE/edit#gid=0

// idea
interface ICommonWalletService
{
    string countryCode { get; set; }

    //กลุ่ม1
    Wallet CreateWallet(string paId);
    StartTopupByQRResult StartTopupByQR(string walletId, MonetaryValue amount); // return txId
    TopupInfo ExecuteTopupByQR(string txId);// ref1, ref2 , billerid(fix ไว้ที่ qr api)
    MonetaryValue GetBalance(string walletId); //ทำแล้วใน deviceController แค่ย้ายโค้ดมาใส่ตรงนี้ แล้วเรียกใช้

    CreateBizWalletResult CreateBizWallet(string baId); // user & biz สร้างเหมือนกัน? ใช้ด้วยกันได้ ?
    QRInfo GetBizQrInfo(string baId); // user & biz สร้างเหมือนกัน? ใช้ด้วยกันได้ ?
    StartAdhocResult StartAdhoc(string walletId, string baId, MonetaryValue amount); // return txId
    MonetaryBase ExecuteAdhoc(string txId);

    public class MonetaryBase
    {
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
    }

    public class StartTopupByQRResult : MonetaryBase
    {
        public string TxId { get; set; }
        public MonetaryValue Amount { get; set; }
    }

    public class TopupInfo : MonetaryBase
    {
        public string TxId { get; set; }
        public string UserId { get; set; }
        public string WalletId { get; set; }
        public MonetaryValue Amount { get; set; }
    }

    public class CreateBizWalletResult : MonetaryBase
    {
        public string WalletId { get; set; }
    }

    public class StartAdhocResult : MonetaryBase // <<<<<< มี model StartTxResultBase : MonetaryBase ที่มีแค่ TxId เอาไว้ใช้กลางๆ
    {
        public string TxId { get; set; }
    }

    //Wallet3rd
    void DepositSuccess(DepositeRequest request);

    //[HttpPost("depositeresult", Name = "DepositeResult")]
    Task<ActionResult> DepositeResult(DepositeRequest request); //TxId, IsSuccess, Message
    //[HttpPost("result/adhoc", Name = "AdhocResult")]
    Task<ActionResult> AdhocResult(DepositeRequest request);
    Task<string> EscrowResult(EscrowRequest request);

    public class DepositeRequest : MonetaryBase // <<<<<< มี model TxResultBase : MonetaryBase ที่มีแค่ TxId เอาไว้ใช้กลางๆ
    {
        public string TxId { get; set; }
    }
    //กลุ่ม2
    StartTxResultBase StartEscrow(string walletId, string baId, MonetaryValue amount); // cart created / first product added >>> currently support 1 source wallet
    MonetaryBase UpdateStartingEscrow(string txId, MonetaryValue amount); // add more product / changing shipping method
    MonetaryBase CancelStartingEscrow(string txId); // cart canceled
    MonetaryBase ExecuteEscrow(string txId, EscrowOut[] outs); // user paid, calculate outs from contract, cannot change amount after execute
    MonetaryBase UpdateEscrow(string txId, EscrowOutUpdate[] outUpdates); // update outs > receiver walletId and status
    MonetaryBase ReleaseEscrow(string txId); // distributing money, all outs must be set and status must be include
    MonetaryBase CancelEscrow(string txId); // distributing money to outs that status is include, refund from outs that status is exclude to source walletId

    StartTxResultBase StartBizWithdraw(string baId, string walletId, MonetaryValue amount); // return txId
    MonetaryBase ExecuteBizWithdraw(string txId);

    LookupResponse LookupPPayByPID(string pid);
    LookupResponse LookupPPayByMobile(string mobileNumber);
    LookupResponse LookupฺBankAccount(string accNo, string bank);

    StartTopupByQRResult StartTopupPPay(string walletId, string prompmtpayid, string type, MonetaryValue amount); // return txId
    TopupInfo ExecuteTopupPPay(string txId);// ref1, ref2 , billerid(fix ไว้ที่ qr api)

    string StartWithdrawPPY(string walletId, string prompmtpayid, MonetaryValue amount); // return txId PPYNameTH PPYNameEN
    WithdrawInfo ExecuteWithdrawPPY(string txId);


    public class LookupResponse
    {
        public string AccountNumber { get; set; }
        // BankAccount , PropmtPay
        public string AccountType { get; set; }
        // PropmtPayType (mobile , pid)    BankAccountType (BBL ,KTB ,BAY ,etc)
        public string AccountCode { get; set; }
        public string AccountNameTH { get; set; }
        public string AccountNameEN { get; set; }
    }

    public class EscrowOut
    {
        public string RefId { get; set; } // generated id for reference back > eg. case update rider to escrow
        public string WalletId { get; set; }
        public string Status { get; set; } // include = ready for distribute, exclude = marked for cancel
        public MonetaryValue Amount { get; set; }
    }

    public class EscrowOutUpdate
    {
        public string RefId { get; set; }
        public string WalletId { get; set; }
        public string Status { get; set; }
    }

    //Wallet3rd
    Task<ActionResult> AdhocResult(DepositeRequest request);
    Task<ActionResult> PPayPaymentResult(DepositeRequest request);
    Task<ActionResult> WithdrawResult2021([FromBody] PPayExchangeResult ppay);

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

public interface ICommonWalletResultService
{
    /// <summary>
    /// ผลฝากเงิน
    /// </summary>
    /// <param name="request"></param>
    /// <returns>success, not found, conflict</returns>
    Task<string> DepositSuccess(DepositeRequest request);
    /// <summary>
    /// ผลการจ่ายเงิน
    /// </summary>
    /// <param name="request"></param>
    /// <returns>success, not found, error</returns>
    Task<string> AdhocResult(DepositeRequest request);
    /// <summary>
    /// ผลการแจกจ่ายเงินตาม escrow
    /// </summary>
    /// <param name="request"></param>
    /// <returns>Success, NotFound, Error, Cancel, OutNotComplete</returns>
    Task<string> EscrowResult(EscrowRequest request);
}






// idea primitive ๆ
interface ICommonWalletService
{
    string countryCode { get; set; }

    #region manage
    /// <summary>
    /// Visit MContent page endpoint
    /// </summary>
    /// <param name="id">paid baid</param>
    /// <returns>Wallet</returns>
    Wallet CreateWallet(string id);
    MonetaryValue GetBalance(string walletId);
    //void TerminateWallet(string walletId);
    #endregion maange

    #region เชื่อมต่อภายนอก เงินเข้า/ออก
    string StartDeposit(string walletId, MonetaryValue amount, Type type); // return txId
    void ExecuteDeposit(string txId);
    string StartWithdraw(string walletId, MonetaryValue amount, Type type); // return txId
    void ExecuteWithdraw(string txId);
    #endregion เชื่อมต่อภายนอก เงินเข้า/ออก

    #region โอนย้ายภายใน
    string StartTransaction(InOut[] ins, InOut[] outs, bool isEscrow = false); // return txId >> input contract ? just ins outs ?
    void UpdateTransaction(...); // rider accept order after user has paid
    void ExecuteTransaction(string txId);
    void ReleaseEscrow(string txId); // release condition ? follow by contract ? how ?
    #endregion โอนย้ายภายใน

    // ตอน start ใส่ refId เข้าไปด้วย ? เผื่อใช้อ้างถึงกรณีผิดพลาด txId หาย ?
    //
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