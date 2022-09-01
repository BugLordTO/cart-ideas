![](out/financial-interface-tx-params/financial-interface.png)

#mom #financial #202209 01
- doc id runner datetick จาก libs
- จะมีปรับ monetaryValue จาก libs
- ตอนปรับ code ปรับชื่อ filed ให้สอดคล้องกัน เช่น  billref1, billref2
- check flow ตั้งแต่ ส่ง ไปจนถึงรับ result MT จะปรับอะไรมั้ย

```plantuml
@startuml financial-interface

interface ICommonWalletService <PHASE CHANGE TX PARAMS> {
    // ***** OPERATION ที่ body มีการเปลี่ยนแปลง ***** ()
    ExecuteTopupByQR(walletId, amount): TopupQRInfo
    ExecuteTopupBankAccountByQR(walletId, accNumber, bankCode, amount): TopupQRInfo
    ExecuteTopupPPayByRTP(walletId, accNumber, ppayType, amount): TopupInfo

    // CreateWallet(paid): CreateWalletResult
    CreateWallet(ownerId, ownerType, initialBalance: MonetaryValue): CreateWalletResult
    
    // ***** OPERATION ที่ body ที่ไม่ได้เปลี่ยนแปลง ***** ()
    StartWithdrawBankAccount(walletId, ppyType, ppyId, amount, bankCode): StartWithdrawResult
    ExecuteWithdrawBankAccount(walletId, txId): MonetaryBase
    
    StartWithdrawPPY(walletId, ppyid, ppyType, amount): StartWithdrawResult
    ExecuteWithdrawPPY(walletId, txId): MonetaryBase

    LookupPpay(accType, typeCode, ppayId, bankCode): LookupResult
    
    GetBalance(countryCode, walletId): MonetaryValue
}

note left of ICommonWalletService
@@@@@ Body ที่ส่งไป P2D แบบเดิม @@@@@

ExecuteTopupByQR > call to p2d
{
    ResultHost = ResultHostName,
    AmountThb = amount.AmountUnit,
    TEx = walletId,
}
ExecuteTopupBankAccountByQR > call to p2d
{
    ResultHost = ResultHostName,
    AmountThb = amount.AmountUnit,
    TEx = walletId,
}
ExecuteTopupPPayByRTP > call to p2d
{
    ResultHost = ResultHostName,
    PpayType = ppayType,
    PpayId = ppayId,
    BankCode = bankCode, // null, SCB, KTB, TTB
    AmountThb = amount.AmountUnit,
    TEx = walletId,
}
CreateWallet > call to p2d
{
    countryCode: 66
    walletId: 0123456789
    initialBalance: 50000
}
end note

note right of ICommonWalletService
@@@@@ Body ที่ส่งไป P2D แบบใหม่ @@@@@

ExecuteTopupByQR > call to p2d
{
    requestType: dynamic
    usage: onetime
    channel: qr
    operationCode: 400
    balance: 50 THB
    walletId: 0123456789
}
ExecuteTopupBankAccountByQR > call to p2d
{
    requestType: dynamic
    usage: onetime
    channel: qr
    operationCode: 401
    balance: 50 THB
    walletId: 0123456789
}
ExecuteTopupPPayByRTP > call to p2d
{
    requestType: dynamic
    usage: onetime
    channel: rtp
    operationCode: 402
    balance: 50 THB
    walletId: 0123456789

    // PpayType: string > mobile, pid
    PpayId: string // เลข ppay
}
CreateWallet > call to p2d
{
    countryCode: 66
    ownerId: 0123456789 // baId, paId, daId
    ownerType: pa // ba, pa, da
    initialBalance: 50 THB
}
end note

note top of ICommonWalletService
@@@@@ Body ที่ไม่ได้เปลี่ยนแปลง @@@@@

StartWithdrawBankAccount > call to p2d
StartWithdrawPPY > call to p2d
{
    PpayType = ppyType,
    PpayId = ppyId,
    BankCode = bankCode,
    AmountThb = amount.AmountUnit,
    TEx = walletId,
}
ExecuteWithdrawBankAccount > call to p2d
ExecuteWithdrawPPY > call to p2d
{
    ResultHost = ResultHostName,
    ManaLink = walletId,
    Signature = "03x2df02672sdf6000217",
}
LookupPpay > call to p2d
{
    PpayType = typeCode,
    PpayId = ppayId,
    BankCode = bankCode,
}
end note

class MonetaryBase {
    IsSucceeded: bool
    Message: string
}
ICommonWalletService .[hidden].> MonetaryBase

class TopupInfo extends MonetaryBase {
    TxId: string
    WalletId: string
    Amount: MonetaryValue
}

class TopupQrInfo extends MonetaryBase {
    TxId: string
    WalletId: string
    Ref1: string
    Ref2: string
    Amount: MonetaryValue
}

class StartWithdrawResult extends MonetaryBase {
    TxId: string
}

class CreateWalletResult extends MonetaryBase {
    WalletId: string
}

class WithdrawResponse<From P2D> {
    HasFound
    Id
    Bbf
    AccNo
    NameEN
    NameTH
    TEx
}
MonetaryBase .[hidden]r.> WithdrawResponse

class WithdrawQrResponse<From P2D> {
    HasFound
    Id
    Bbf
    AccNo
    NameEN
    NameTH
    BillRef1
    BillRef2
    TEx
}
MonetaryBase .[hidden]r.> WithdrawQrResponse

class LookupResult<From P2D> {
    AccountNumber
    AccountType
    AccountCode
    AccountNameTH
    AccountNameEN
}
MonetaryBase .[hidden]r.> LookupResult

@enduml
```