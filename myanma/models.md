```c#
// --- config ---
A_TEMP_MEX_TH_BAID
A_TEMP_MEX_MM_BAID
A_TEMP_MTM_MM_BAID
A_TEMP_MTM_WITHDRAW_FEE

// --- Mana Api ---
public class TopupMexSession {
    public string Id { get; set; }
    
    //คน scan
    public string SrcPaId { get; set; }
    public string SrcDisplayName { get; set; }
    public string SrcLogo { get; set; } 
    public string SrcWalletName { get; set; }
    public string SrcWalletId { get; set; }    

    //คนสร้าง qr
    public string DestPaId { get; set; }
    public string DestDisplayName { get; set; }
    public string DestLogo { get; set; } 
    public string DestWalletId { get; set; }
    public MonetaryValue TopupAmount { get; set; }
    public string Remark { get; set; }

    //blackbox info
    public RateResult Rate { get; set; }
    public string? TxId { get; set; }

    // DB
    public DateTime CreatedDate { get; set; }
}

public class WithdrawMtmSession {
    public string Id { get; set; }

    public string SrcPaId { get; set; }
    public string SrcDisplayName { get; set; }
    public string SrcLogo { get; set; }

    public string BankCode { get; set; }
    public string BankName { get; set; }
    public string BankLogo { get; set; }
    public string AccountNo { get; set; }
    public string AccountName { get; set; }

    public string? SrcWalletName { get; set; }
    public string? SrcWalletId { get; set; }
    public MonetaryValue? Amount { get; set; }
    public MonetaryValue? Fee { get; set; }
    public string? PhoneNo { get; set; }
    public string? Remark { get; set; }

    public string Status { get; set; } // Creating, Pending, Accepted, Rejected
    public DateTime RequestedDate { get; set; }
    public DateTime? ResponseDate { get; set; }
    public string? SlipImageUrl { get; set; }
    public string? Reason { get; set; }

    // DB
    public DateTime CreatedDate { get; set; }
}

// --- Mana 3rd Api ---
public class WithdrawRequest {
    public string SessionId { get; set; }

    public string SrcPaId { get; set; }
    public string SrcDisplayName { get; set; }
    public string SrcLogo { get; set; }

    public string BankCode { get; set; }
    public string BankName { get; set; }
    public string BankLogo { get; set; }
    public string AccountNo { get; set; }
    public string AccountName { get; set; }

    public string SrcWalletName { get; set; }
    public string SrcWalletId { get; set; }
    public MonetaryValue Amount { get; set; }
    public MonetaryValue Fee { get; set; }
    public string PhoneNo { get; set; }
    public string Remark { get; set; }

    public DateTime RequestedDate { get; set; }
}

public class SendWithdrawResult {
    public string SessionId { get; set; }
    public bool IsAccept { get; set; }
    public string SlipImageUrl { get; set; }
    public string Reason { get; set; }
}

// --- Blackbox ---
// get rate
public class RateRequest {
    public long Amount { get; set; }
    public string Direction { get; set; } // src dest
    public string SrcCurrency { get; set; }
    public string DestCurrency { get; set; }
}
public class RateResult {
    public string RateId { get; set; }
    public decimal Rate { get; set; }
    public decimal SrcFee { get; set; }
    public decimal DestFee { get; set; }
    public MonetaryValue CalculatedAmount { get; set; }
    public DateTime RateExpiration { get; set; }
}

// execute adhoc mex
public class CartAdhocMex {
    public string RateId { get; set; }
    public string SrcManalinkWalletid { get; set; }
    public string DestManalinkWalletid { get; set; }
    public MonetaryValue Amount { get; set; }
}
public class CartAdhocMexExecuteResult {
    public string TxId { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}
```