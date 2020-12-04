public abstract class Partner
{
    public string _id { get; set; }
    public string ManaId { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public decimal Balance { get; set; }
    public Address Address { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? UpdatedDateTime { get; set; }
}
public class MerchantAccount : Partner
{
    public DateTime? ApprovedDateTime { get; set; }
    public DateTime? SuspendDateTime { get; set; }
    public string MerchantTier { get; set; }
    public string NewWalletId { get; set; }
}

//*************************************************

public class BizAccount
{
    public string _id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string RefCode { get; set; }
    public Address Address { get; set; }
    public IEnumerable<PhoneNumber> PhoneNumbers { get; set; } // เหมือนจะมีเบอ fix default ห้ามลบ
    public OpeningTime OpeningTime { get; set; }
    public string Tier { get; set; } // Lite, Standard, Professional, Custom, ...
    public DateTime CreatedDate { get; set; }
    public DateTime? ApprovedDateTime { get; set; }
    public DateTime? SuspendedDateTime { get; set; }
    public string OwnerPaId { get; set; }
    public bool IsUseAdvanceMenu { get; set; }
    // wallet
    // CoOwners
}

public class PhoneNumber
{
    public string Title { get; set; }
    public string Number { get; set; }
}

public class OpeningTime
{
    public IEnumerable<Period> Sunday { get; set; }
    public IEnumerable<Period> Monday { get; set; }
    public IEnumerable<Period> Tuesday { get; set; }
    public IEnumerable<Period> Wednesday { get; set; }
    public IEnumerable<Period> Thursday { get; set; }
    public IEnumerable<Period> Friday { get; set; }
    public IEnumerable<Period> Saturday { get; set; }
    //เวลาร้านชั่วคราวถึงเวลา
    public DateTime? TemporaryCloseThruTime { get; set; }
}

public class Period
{
    // 24h formate  : hhmm => 0800 , 2200
    public int OrderFromTime { get; set; }
    public int OrderThruTime { get; set; }
}

// contract
// employee
// budget / allowance
// financial history
// qr
// service subscription

//********************* VIEW MODEL ****************************

public class BizAccountsList // M2
{
    public IEnumerable<BizAccountInList> BizAccounts { get; set; }
    // public string CreateBizAccountEndpointUrl { get; set; } // https://s.manal.ink/np/nbizdtl-create
}

public class BizAccountInList // M2
{
    public string _id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Status { get; set; }
    // public string MenuState { get; set; }
    // public string EndpointUrl { get; set; } // https://s.manal.ink/np/nbizdtl-{{id}}
}

public class BizAccountCreate // M3 - request model
{
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Phone { get; set; }
    public Address Address { get; set; } // M3.1 how ?
}

public class BizAccountBasic // M4
{
    public string _id { get; set; }
    public string Status { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Balance { get; set; } // server determine how to display floting point and currency format
    // public string QrEndpointUrl { get; set; } // https://s.manal.ink/np/nbizqrp-{{id}}
    // public string WithdrawEndpointUrl { get; set; } // https://s.manal.ink/np/nbizwit-{{id}}
    // public string AdvanceMenuEndpointUrl { get; set; }
}

public class BizAccountAdvance // M5
{
    public string _id { get; set; }
    public string Status { get; set; }
    public string Tier { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string RefCode { get; set; }
    public IEnumerable<BizSubscribeService> Services { get; set; }
    public string Balance { get; set; } // server determine how to display floting point and currency format
    // public string BasicMenuEndpointUrl { get; set; }
    // public string EditProfileEndpointUrl { get; set; } // https://s.manal.ink/np/nbizpfl-{{id}}
    // public string TransactionEndpointUrl { get; set; } // https://s.manal.ink/np/nbiztxl-{{id}}$list
    // public string QrEndpointUrl { get; set; } // https://s.manal.ink/np/nbizqrp-{{id}}
    // public string WithdrawEndpointUrl { get; set; } // https://s.manal.ink/np/nbizwit-{{id}}
    // public string DepositEndpointUrl { get; set; } // https://s.manal.ink/np/nbiztop-{{id}}
    // public string EmployeeEndpointUrl { get; set; } // https://s.manal.ink/np/nbizemp-{{id}}$list
    // public string BudgetEndpointUrl { get; set; } // https://s.manal.ink/np/nbizbgt-{{id}}$list
}

public class BizSubscribeService // M5
{
    public string Name { get; set; }
    public string Logo { get; set; }
}

public class BizAccountProfile // M6
{
    public string _id { get; set; }
    public string Tier { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string RefCode { get; set; }
    // public string EditNameEndpointUrl { get; set; } // https://s.manal.ink/np/nbiznme-{{id}}
    // public string EditCodeEndpointUrl { get; set; } // https://s.manal.ink/np/nbizcde-{{id}}
    // public string PhoneEndpointUrl { get; set; } // https://s.manal.ink/np/nbiztel-{{id}}$list
    // public string AddressEndpointUrl { get; set; } // https://s.manal.ink/np/nbizads-{{id}}
    // public string ScheduleEndpointUrl { get; set; } // https://s.manal.ink/np/nbizsch-{{id}}
    // public string ContractEndpointUrl { get; set; } // https://s.manal.ink/np/nbizctt-{{id}}$list
    // public string PledgeEndpointUrl { get; set; } // https://s.manal.ink/np/nbizplg-{{id}}$list
}

public class BizAccountEditName // M6.1
{
    public string Name { get; set; }
}

public class BizAccountRefCode // M6.2
{
    public string _id { get; set; }
    public string RefCode { get; set; }
    // public string ChangeRefCodeEndpointUrl { get; set; } // https://s.manal.ink/np/nbizcde-{{id}}
}

public class BizPhonesList // M6.3
{
    public string _id { get; set; }
    public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
    // public string AddPhoneNumberEndpointUrl { get; set; } // https://s.manal.ink/np/nbizphn-{{id}}$create
}

public class PhoneNumber // M6.3
{
    public string _id { get; set; }
    public string Title { get; set; }
    public string Number { get; set; }
    // public string EndpointUrl { get; set; } // https://s.manal.ink/np/nbizphn-{{id}}${{index}}
}

public class PhoneNumberRequest // M6.3.1, 6.3.2 - request model
{
    public string Title { get; set; }
    public string Number { get; set; }
}

// Address M6.4

public class OpeningTime // M6.5
{
    public string _id { get; set; }
    public IEnumerable<Period> Sunday { get; set; }
    public IEnumerable<Period> Monday { get; set; }
    public IEnumerable<Period> Tuesday { get; set; }
    public IEnumerable<Period> Wednesday { get; set; }
    public IEnumerable<Period> Thursday { get; set; }
    public IEnumerable<Period> Friday { get; set; }
    public IEnumerable<Period> Saturday { get; set; }
    public DateTime? TemporaryCloseThruTime { get; set; }
}

public class Period // M6.5
{
    // 24h formate  : hhmm => 0800 , 2200
    public int OrderFromTime { get; set; }
    public int OrderThruTime { get; set; }
}

public class BizContractsList // M6.6
{
    public IEnumerable<BizContractInList> Contracts { get; set; }
}

public class BizContractInList // M6.6
{
    public string _id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Body { get; set; }
    // public string EndpointUrl { get; set; } // https://s.manal.ink/np/nbizctt-{{id}}
}

public class BizContract // M6.6.1
{
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Body { get; set; }
}

public class BizPledgesList // M6.7
{
    public IEnumerable<BizPledgeInList> Pledges { get; set; }
}

public class BizPledgeInList // M6.7
{
    public string _id { get; set; }
    public string Title { get; set; }
    public string Holder { get; set; }
    public string PledgeDate { get; set; }
    public string Balance { get; set; }
    // public string EndpointUrl { get; set; } // https://s.manal.ink/np/nbizplg-{{id}}
}

// M7 Tx list

public class BizAccountPaymentQr // M8
{
    public string Name { get; set; }
    public string Logo { get; set; }
    public string QrUrl { get; set; }
    // public string ChangeQrEndpointUrl { get; set; }
    // public string SaveQrEndpointUrl { get; set; }
    // public string QrApplink { get; set; }
}

// M9 Deposit

// M10 Withdraw

public class BizEmployeesList // M11
{
    public string _id { get; set; }
    public IEnumerable<BizEmployeeInList> BizEmployees { get; set; }
    // public string AddEmployeeEndpointUrl { get; set; } // https://s.manal.ink/np/nbizemp-{{id}}$create
}

public class BizEmployeeInList // M11
{
    public string _id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Phone { get; set; }
    public string Position { get; set; }
    //public string BizEmployeeEndpointUrl { get; set; } // https://s.manal.ink/np/nbizemp-{{id}}
}

public class BizBudgetsList // M12
{
    public string _id { get; set; }
    public IEnumerable<BizBudgetInList> BizBudgets { get; set; }
    // public string CreateBudgetEndpointUrl { get; set; } // https://s.manal.ink/np/nbizbgt-{{id}}$create
}

public class BizBudgetInList // M12
{
    public string _id { get; set; }
    public string Title { get; set; }
    public string Balance { get; set; } // server determine how to display floting point and currency format
    //public string BizBudgetEndpointUrl { get; set; } // https://s.manal.ink/np/nbizbgt-{{id}}
}
