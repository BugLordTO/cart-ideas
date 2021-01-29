public class WorkflowUnit // : T
{
    public string Id { get; set; }
    public string Workflow { get; set; }
    // public T Body { get; set; }
    public ServerCommand[] Commands { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdate { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string Status { get; set; }
    /// <summary>
    /// HTTP call status
    /// </summary>
    public bool isSucceeded { get; set; }
    //sign ??
}

abstract class ServerCommand {
    public string Action { get; set; }
}

abstract class ServerCommand<T> : ServerCommand {
    public T Parameter { get; set; }
}

abstract class TxCommand<T> : ServerCommand<T> where T : TxCommandParameter { }
abstract class WalletCommand<T> : ServerCommand<T> where T : WalletCommandParameter { }

abstract class ServerCommandParameter
{
    // public string Owner { get; set; }
    // public string Grant { get; set; }
    // public string Command { get; set; }
    // public string Proof { get; set; }
}

abstract class TxCommandParameter : ServerCommandParameter { }
abstract class TxCommandIdParameter : TxCommandParameter
{
    public string Id { get; set; }
}
abstract class WalletCommandParameter : ServerCommandParameter { }
abstract class WalletCommandIdParameter : WalletCommandParameter
{
    public string Id { get; set; }
}

//----- stateless command-----
class GetAssetBalanceCommand : TxCommand<GetAssetBalanceCommandParameter> { }
class GetAssetBalanceCommandParameter : TxCommandIdParameter { }

class GetEscrowContractCommand : TxCommand<GetEscrowContractCommandParameter> { }
class GetEscrowContractCommandParameter : TxCommandIdParameter { }

//----- stateful command-----
class CreateWalletCommand : WalletCommand<GetEscrowContractCommandParameter> { }
class CreateWalletCommandParameter : WalletCommandIdParameter { }

class CreateBizWalletCommand : WalletCommand<CreateBizWalletCommandParameter> { }
class CreateBizWalletCommandParameter : WalletCommandIdParameter { }

class CreateAllowanceCommand : WalletCommand<CreateAllowanceCommandParameter> { }
class CreateAllowanceCommandParameter {
    CurrencyAmount AmountUnit;
}

class GrantAllowanceCommand : TxCommand<GrantAllowanceCommandParameter> { }
class GrantAllowanceCommandParameter : TxCommandIdParameter {
    CurrencyAmount AmountUnit;
}

class CreateBudgetCommand : WalletCommand<CreateBudgetCommandParameter> { }
class CreateBudgetCommandParameter : WalletCommandIdParameter {
    CurrencyAmount AmountUnit;
}

class GrantBudgetCommand : TxCommand<GrantBudgetCommandParameter> { }
class GrantBudgetCommandParameter : TxCommandIdParameter {
    CurrencyAmount AmountUnit;
}

class CreateEscrowContractCommand : TxCommand<CreateEscrowContractCommandParameter> { }
class CreateEscrowContractCommandParameter : TxCommandParameter {
    object[] ins;
    object[] outs;
}

class ExcuteEscrowCommand : TxCommand<ExcuteEscrowCommandParameter> { }
class ExcuteEscrowCommandParameter : TxCommandParameter {
    object[] ins;
    object[] outs;
}

class GetEscrowCommand : TxCommand<GetEscrowCommandParameter> { }
class GetEscrowCommandParameter : TxCommandIdParameter { }

class ReleaseEscrowCommand : TxCommand<ReleaseEscrowCommandParameter> { }
class ReleaseEscrowCommandParameter : TxCommandIdParameter {
    object[] outs;
}

class FinalcialExchangeCommand : WalletCommand<FinalcialExchangeCommandParameter> { }
class FinalcialExchangeCommandParameter : WalletCommandParameter {
{
    string FromWallet;
    string ThruWallet;
    string UnitAmount;
    string Method;
}

enum Method { // or const string
    DepositPromptpay
    DepositRTP
    Withdraw2External
}