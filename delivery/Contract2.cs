==================================================== 3rd Controller

[Route("[controller]/{serviceId}/{bizAccountId}")]
class BizAccount3rdController {
    [HttpGet("contract")]
    List<ContractResponse> Contract(string serviceId, string bizAccountId);
    [HttpGet("contract/{id}")]
    ContractResponse Contract(string serviceId, string bizAccountId, string id);

    [HttpPost("contract/deliveryowner")] // register delivery
    ContractResponse DeliveryOwnerContract(string serviceId, string bizAccountId, DeliveryOwnerContractRequest request);
    [HttpPost("contract/subscribedelivery")] // regsiter restaurant
    ContractResponse SubScribeDeliveryContract(string serviceId, string bizAccountId, SubScribeDeliveryContractRequest request);

    // biz detail api
}
[Route("[controller]/{serviceId}/{bizAccountId}")]
class Employee3rdController {
    [HttpGet("contract")]
    List<ContractResponse> Contract(string serviceId, string bizAccountId);
    [HttpGet("contract/{id}")]
    ContractResponse Contract(string serviceId, string bizAccountId, string id);

    [HttpGet("register")] // register employee
    ContractResponse Register(string serviceId, string bizAccountId, EmployeeRegisterRequest request);

    // employee detail api
}

==================================================== mana Controller

class BizAccountController {
    [HttpGet("contract/{contractId}/deliveryowner")]
    ContractResponse DeliveryOwnerContract(); // deliveryowner data
    [HttpPost("contract/{contractId}/deliveryowner")] // consent deliveryowner
    ClientResponse DeliveryOwnerConsent (string contractId, ConsentRequest request);
    
    [HttpGet("contract/{contractId}/subscribedelivery")]
    ContractResponse SubscribeDeliveryContract(); // subscribedelivery data
    [HttpPost("contract/{contractId}/subscribedelivery")] // consent subscribedelivery
    ClientResponse SubscribeDeliveryConsent (string contractId, SubscribeDeliveryRequest request);
}
class EmployeeController {
    [HttpGet("contract/{contractId}/rider")]
    ContractResponse SubscribeDeliveryContract(); // rider data
    [HttpPost("contract/{contractId}/rider")] // consent rider
    ClientResponse RiderConsent (string contractId, ConsentRequest request);
    
    [HttpGet("{id}/admin")] // admin data
    ContractResponse SubscribeDeliveryContract(); // subscribedelivery data
    [HttpPost("{id}/admin")] // consent normal employee role admin, no contract
    ClientResponse EmployeeConsent (string id, ConsentRequest request);
}

==================================================== 3rd Controller already exists

public class Product3rdController : ApiControllerBase {
    // หลาย menu
}

==================================================== mana Controller already exists

public class BizAccountController : ApiControllerBase { }
public class ProductController : ApiControllerBase { }
public class CartController : ApiControllerBase { }
public class EscrowController : ControllerBase { }

==================================================== 3rd Controller models

class DeliveryOwnerContractRequest {
    string Title;
    string Agreement; // plain text
    string RefCode; // PA refcode of BA owner
    string BizName; // Biz name to be create
    Address BizAddress; // include GPS
    int OperateRadius; // in KM
    string Mobile;
    decimal AllowanceAmount; // THB
    decimal SharingForDeveloper; // 30 in percent
    // decimal SharingForDelivery; // 60 in percent => ที่เหลือเข้านี่หมด
    decimal SharingForRider; // 10 in percent
}
class SubScribeDeliveryContractRequest {
    string Title;
    string Agreement; // plain text
    string RefCode; // BA refcode of biz owner
    string DeliveryBizId; // delivery to be add
    string Mobile;
    decimal AllowanceAmount; // THB
    decimal ShippingFee; // 20 constant
    decimal SharingForRestaurant; // 85 in percent of items price
    decimal SharingForDelivery; // 15 in percent of item price
}
class EmployeeRegisterRequest {
    string Title;
    string Agreement; // plain text
    string RefCode; // PA refcode of biz owner
    string Mobile;
    // string DeliveryOwnerContractRefId; // เอา DeliveryOwnerContract ของสัญญาไหนไปโชว์
}
class ContractResponse {
    string _id;
    string ContractType; // DeliveryOwnerContract, SubscribeDeliveryContract, RiderContract
    string Agreement; // plain text
    List<ContractorResponse> Contractors; // ผู้ร่างสัญญา
    List<PartyResponse> Parties; // ส่ง contract ให้ pa ไหนเป็นผู้ทำสัญญา
    DateTime CreatedDate;
    DateTime? ExpiredDate;
    List<SharingResponse> Sharings; // รายการส่วนแบ่งเงิน เหลือจากในรายการ OnBehalfOf จะเป็นผู้รับ
}
class ContractorResponse {
    string PaId;
    string Name;
    string LogoUrl;
    OnBehalfOfResponse OnBehalfOf; // ในนามของ PA, BA, DA
}
class PartyResponse {
    string PaId;
    string Name;
    string LogoUrl;
    string RefCode;
    string Mobile; // 3rd เก็บ ? / mana ไม่ได้เก็บ ?
    DateTime? SignDate;
    OnBehalfOfResponse OnBehalfOf; // ในนามของ PA, BA, DA
}
class OnBehalfOfResponse {
    string RefId;
    string Name;
    string LogoUrl;
    string RefType; // PA, BA, DA
    string RefCode;
}
class SharingResponse {
    string RefId;
    string RefType; // PA, BA, DA, contract
    int value;
    string EffectOnValue; // Percent, Constant
}

==================================================== mana Controller models

class ConsentRequest {
    bool IsAgree;
}
class SubscribeDeliveryRequest : ConsentRequest {
    string SelectedBaId;
}

==================================================== Db models

class ContractDraft {
    string _id;
    string Title;
    string ServiceId; // ร่างสัญญาผ่าน service ไหน
    string ContractType; // DeliveryOwnerContract, SubscribeDeliveryContract, RiderContract
    string Agreement; // plain text
    List<Contractor> Contractors; // ผู้ร่างสัญญา
    List<Party> Parties; // ส่ง contract ให้ pa ไหนเป็นผู้ทำสัญญา
    DateTime CreatedDate;
    DateTime? ExpiredDate;
    List<Sharing> Sharings;
    string Status; // Pending, Accepted/Denied, Changed(เปลี่ยนไปใช้สัญญาใหม่) , Cancel
}
class Contractor {
    string PaId;
    OnBehalfOf OnBehalfOf; // ในนามของ PA, BA, DA
}
class Party {
    string PaId;
    string RefCode;
    string Mobile; // 3rd เก็บ ? / mana ไม่ได้เก็บ ?
    DateTime? SignDate;
    OnBehalfOf OnBehalfOf; // ในนามของ PA, BA, DA
}
class OnBehalfOf {
    string RefId;
    string RefType; // PA, BA, DA
    string RefCode;
}
class Sharing {
    string RefId;
    string RefType; // PA, BA, DA, contract
    int value;
    string EffectOnValue; // Percent, Constant, Weigth
}

# DeliveryOwner Contract
{
    "_id" : "ct001",
    "ServiceId" : "svc001",
    "ContractType" : "DeliveryOwnerContract",
    "Contractors" : [{
        "PaId" : "pa001",
        "OnBehalfOf" : {
            "RefId" : "ba001", // dev baid
            "RefType" : "BizAccount",
            "RefCode" : "refba001"
        }
    }],
    "Parties" : [{
        "PaId" : "pa002",
        "RefCode" : "refpa002",
        "Mobile" : "0822222222",
        "SignDate" : null,
        "OnBehalfOf" : {
            "RefId" : "", // delivery baid => create ba and fulfill when consent contract (ba002)
            "RefType" : "BizAccount",
            "RefCode" : "" // delivery RefCode => create ba and fulfill when consent contract (ba002)
        }
    }],
    "Status" : "Pending",
    "CreatedDate" : "2020-01-01",
    "ExpiredDate" : "2021-01-01",
    "Sharings" : [{
        "Type" : "BizAccount",
        "RefId" : "ba001", // dev BizAccount
        "value" : 30,
        "EffectOnValue" :"Percent"
    },{
        "Type" : "BizAccount",
        "RefId" : "", // delivery BizAccount => create ba and fulfill when consent contract (ba002)
        "value" : 60,
        "EffectOnValue" :"Percent"
    },{
        "Type" : "RiderContract",
        "RefId" : "", // rider contractid => fulfill after order hook (ct003)
        "value" : 10,
        "EffectOnValue" :"Percent"
    }]
}

# SubScribeDelivery Contract
{
    "_id" : "ct002",
    "ServiceId" : "svc001",
    "ContractType" : "SubScribeDeliveryContract",
    "Contractors" : [{
        "PaId" : "pa002",
        "OnBehalfOf" : {
            "RefId" : "ba002", // delivery baid
            "RefType" : "BizAccount",
            "RefCode" : "refba002"
        }
    }],
    "Parties" : [{
        "PaId" : "pa003",
        "RefCode" : "refpa003",
        "Mobile" : "0833333333",
        "SignDate" : null,
        "OnBehalfOf" : {
            "RefId" : "", // restaurant baid => select ba and fulfill when consent contract (ba003)
            "RefType" : "BizAccount",
            "RefCode" : "" // restaurant baid => select ba and fulfill when consent contract (ba003)
        }
    }],
    "CreatedDate" : "2020-01-01",
    "ExpiredDate" : "2020-02-01",
    "Sharings" : [{
        "Type" : "DeliveryOwnerContract",
        "RefId" : "ct001",
        "value" : 20, // rely on shipping fee of delivery ba
        "EffectOnValue" :"Constant"
    },{
        "Type" : "DeliveryOwnerContract",
        "RefId" : "ct001",
        "value" : 15, // GP
        "EffectOnValue" :"Percent"
    },{
        "Type" : "BizAccount",
        "RefId" : "", // restaurant baid => select ba and fulfill when consent contract (ba003)
        "value" : 85,
        "EffectOnValue" :"Percent"
    }]
}

# Rider Contract
{
    "_id" : "ct003",
    "ServiceId" : "svc001",
    "ContractType" : "RiderContract",
    "Contractors" : [{
        "PaId" : "pa002",
        "OnBehalfOf" : {
            "RefId" : "ba002", // delivery baid
            "RefType" : "BizAccount",
            "RefCode" : "refba002"
        }
    }],
    "Parties" : [{
        "PaId" : "pa004",
        "RefCode" : "refpa004",
        "Mobile" : "0844444444",
        "SignDate" : null,
        "OnBehalfOf" : {
            "RefId" : "", // rider paid => fulfill when consent contract (pa004)
            "RefType" : "BizAccount",
            "RefCode" : "" // rider paid => fulfill when consent contract (ba004)
        }
    }],
    "CreatedDate" : "2020-01-01",
    "ExpiredDate" : "2020-02-01",
    "Sharings" : [{
        "Type" : "PersonalAccount",
        "RefId" : "", // rider paid => fulfill when consent contract (pa004)
        "value" : 100,
        "EffectOnValue" :"Percent"
    }]
}

=======================================================

- add product
- pay
    - create escrow by SubScribeDeliveryContract
- rider accept order
    - update escrow by RiderContract
- restaurant complete order
- rider receive order to deliver
- user receive order
- user rate this order
    - release escrow

=======================================================

- add product
- pay
    - get Contract (ct002)
        Contract.ContractType == "SubScribeDeliveryContract"
        Contract.Contractor.OnBehalfOf.RefId == selectedDeliveryBaId
        Contract.Parties.OnBehalfOf.RefId == cartBaId
    - create escrow
        - escrow.ins 
            cart.items.sumPrice
            cart.shippingFee
        - escrow.outs
            ct002.Sharings[0] 20THB to ct001
            ct002.Sharings[1] amount*15% to ct001
            ct002.Sharings[2] amount*85% to ba003
    
    - get Contract (ct001)
    - update escrow
        - escrow.outs
            - replace [ct002.Sharings[0] 20THB to ct001] to [
                ct001.Sharings[x] 20THB*30% to ba001
                ct001.Sharings[x] 20THB*60% to ba002
                ct001.Sharings[x] 20THB*10% to ""
            ]
            - replace [ct002.Sharings[1] amount*15% to ct001] to [
                ct001.Sharings[x] (amount*15%)*30% to ba001
                ct001.Sharings[x] (amount*15%)*60% to ba002
                ct001.Sharings[x] (amount*15%)*10% to ""
            ]
        - result escrow.outs
            ct001.Sharings[0] 20THB*30% to ba001
            ct001.Sharings[1] 20THB*60% to ba002
            ct001.Sharings[2] 20THB*10% to ""
            ct001.Sharings[3] (amount*15%)*30% to ba001
            ct001.Sharings[4] (amount*15%)*60% to ba002
            ct001.Sharings[5] (amount*15%)*10% to ""
            ct002.Sharings[6] amount*85% to ba003

- rider accept order
    - get Contract (ct003)
    - update escrow
        - escrow.outs type == RiderContract
            - replace [ct001.Sharings[2] 20THB*10% to ""] to [
                ct001.Sharings[x] 20THB*10% to pa004
            ]
            - replace [ct001.Sharings[5] (amount*15%)*10% to ""] to [
                ct001.Sharings[x] (amount*15%)*10% to pa004
            ]
        - result escrow.outs
            ct001.Sharings[0] 20THB*30% to ba001
            ct001.Sharings[1] 20THB*60% to ba002
            ct001.Sharings[2] 20THB*10% to pa004
            ct001.Sharings[3] (amount*15%)*30% to ba001
            ct001.Sharings[4] (amount*15%)*60% to ba002
            ct001.Sharings[5] (amount*15%)*10% to pa004
            ct002.Sharings[6] amount*85% to ba003

- restaurant complete order
- rider receive order to deliver
- user receive order
- user rate this order
    - release escrow
