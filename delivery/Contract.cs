///3rd API
void RequestConsent(ContractInfo contract);
ContractInfo GetBAContract(string OwnerId, string ContractorId, string ServiceId);

///Mana API
ClientResponse ConsentContract(string contractId, bool IsAgree);
ContractInfo GetContractDetail(string contractId); //feed detail. mana standard

///Hook 3rd
void ResponseContract(DeliveryContractInfo contract);

//Model
class ContractInfo
{
    public string _id { get; set; }
    public string OwnerId { get; set; } // TODO: type and info คนที่สร้างสัญญา
    public string OwnerType { get; set; }  //BA , DA
    public ContractorInfo Contractor { get; set; } // may be list
    public OnBehalfOf OnBehalfOf { get; set; } // คนที่กด consent 
    public string ServiceId { get; set; }
    public string ContractType { get; set; } //Delivery, Software, Employee
    public string Status { get; set; } //Pending, Accepted/Denied, Changed(เปลี่ยนไปใช้สัญญาใหม่) , Cancel
    public DateTime CreatedDate { get; set; }
    public DateTime? ResponseDate { get; set; }
    public DateTime? ExpiredDate { get; set; }
    public List<SharingInfo> Sharings { get; set; }
}
class ContractorInfo
{
    public string PaId { get; set; } 
    public string Mobile { get; set; } // 3rd เก็บ ? / mana ไม่ได้เก็บ ?
    public string RefCode { get; set; } // ba / pa / da
}
class OnBehalfOf
{
    public string RefId { get; set; }
    public string RefType { get; set; } // ba / svc
}
class SharingInfo
{
    public string Type { get; set; } //dev, ba, pa, contract
    public string RefId { get; set; }
    public int? Value { get; set; }
    public string EffectOnValue { get; set; } //Percent, Constant
    public int Priority { get; set; } // Less number is more important
}
class SoftwareContract : ContractInfo
{
    public string BudgetNameRequest { get; set; } //สร้าง ชื่อ budget ที่ให้ Software เข้าถึง
    public CurrencyAmount BudgetRequest { get; set; } //จำนวน เงิน ใน budget 
    public string BudgetEmployeeTitleRequest { get; set; } //ตำแหน่งใช้เข้าถึง  budget
    public BizAccount BizAccountCreate { get; set; }  //ร้าน ที่จะถูกสร้างให้ผู้ทำสัญญา
}
class ShippingContract : ContractInfo
{
    public CurrencyAmount ShipppingFeeLimit { get; set; }
}

# SoftwareContract
{
    "_id" : "ct001",
    "OwnerId" : "svc001", 
    "Contractor" : {
        "PaId" : "pa001",
        "Mobile" : "0812345678",
        "RefCode" : "refpa001"
    },
    "OnBehalfOf" : {
        "RefId" : "ba001", // baid => create ba and fulfill when consent contract (ba001)
        "RefType" : "BizAccount"
    },
    "ServiceId" : "svc001",
    "ContractType" : "Software",
    "Status" : "Pending",
    "CreatedDate" : "2020-01-01",
    "ResponseDate" : null,
    "ExpiredDate" : "2020-02-01",
    "Sharings" : [
        {
            "Type" : "Developer",
            "RefId" : "svc001",
            "Value" : 30,
            "EffectOnValue" :"Percent",
            "Priority" : 1
        },
        {
            "Type" : "Employee",
            "RefId" : "", // contractid => fulfill after order hook
            "Value" : 10,
            "EffectOnValue" :"Percent",
            "Priority" : 1
        }
    ]
}

# DeliveryContract
{
    "_id" : "ct002",
    "OwnerId" : "ba001", 
    "Contractor" : {
        "PaId" : "pa002",
        "Mobile" : "0876543210",
        "RefCode" : "refpa002"
    },
    "OnBehalfOf" : {
        "RefId" : "ba002", // baid => fulfill when consent contract
        "RefType" : "BizAccount"
    },
    "ServiceId" : "svc001",
    "ContractType" : "Delivery",
    "Status" : "Pending",
    "CreatedDate" : "2020-01-01",
    "ResponseDate" : null,
    "ExpiredDate" : "2020-02-01",
    "Sharings" : [
        {
            "Type" : "Contract", // SoftwareContract
            "RefId" : "ct001",
            "Value" : null, // rely on shipping fee
            "EffectOnValue" :"Constant",
            "Priority" : 1
        },
        {
            "Type" : "Contract", // SoftwareContract
            "RefId" : "ct001",
            "Value" : 15,
            "EffectOnValue" :"Percent",
            "Priority" : 2
        }
    ]
}



///////////////////////

class SoftwareContract : ContractInfo
{
    public decimal SharingForOwner { get; set; } // percentage
    public decimal SharingForContractor { get; set; } // percentage
    public decimal SharingForBiker { get; set; } // percentage
}
class DeliveryContract : ContractInfo
{
    public decimal SharingForOwner { get; set; } // percentage
    public decimal ShippingFee { get; set; } // constant
    public decimal TotalAmount { get; set; } //?????
}
class EmployeeContract : ContractInfo
{
    public string Title { get; set; }
    public string Code { get; set; }
}