class EslipStub {
    // nesprcv-{_id}
    public string _id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Condition { get; set; }
    public string BannerImageUrl { get; set; }
    public string IconImageUrl { get; set; }
    public bool IsManualApprove { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime ExpiredDate { get; set; }
}

class EslipTail {
    // nespuse-{_id}
    public string _id { get; set; }
    public string EndpointId { get; set; }
    public DateTime AcquireDate { get; set; }
    public DateTime? RequestUseDate { get; set; }
    public DateTime? ActivatedDate { get; set; }
    public OwnerUser OwnerUser { get; set; }

    public BizAccountInfo DistributerMerchant { get; set; }
    public EslipStub EslipStub { get; set; }
}

class BizAccountInfo {
    public string _id { get; set; }
    public string Name { get; set; }
    public string LogoImageUrl { get; set; }
    public string FullAddress { get; set; }
}

class OwnerUser {
    public string UserId { get; set; } // memberId
    public string DisplayName { get; set; }
    public string ProfileImageUrl { get; set; }
}

[Route("[controller]")]
class Eslip3rdController {
    [HttpGet("stubs")]
    IEnumerable<EslipStubResponse> GetEslipStubs();
    [HttpGet("stubs/expired")]
    IEnumerable<EslipStubResponse> GetExpiredEslipStubs();
    [HttpGet("stubs/{id}")]
    EslipStubResponse GetEslipStub(string id);
    [HttpPost("stubs")]
    EslipStubResponse CreateEslipStub(EslipStubRequest request);
    [HttpPut("stubs/{id}")]
    ActionResult UpdateEslipStub(string id, EslipStubRequest request);
    [HttpPut("stubs/{id}/suspend")]
    ActionResult SuspendEslipStub(string id);
    [HttpPut("stubs/{id}/unsuspend")]
    ActionResult UnsuspendEslipStub(string id);
    [HttpGet("stubs/{id}/logs")]
    IEnumerable<EslipTail> GetAllEslipUsedLog(string id);

    [HttpGet("stubs/{id}/requestapprove")]
    IEnumerable<EslipTail> GetRequestApproveEslip(string id);
    [HttpPut("{id}/approve")]
    ActionResult ApproveEslip(EslipApprove request);
}

class EslipStubResponse {
    public string _id { get; set; }
    public EslipStub EslipStub { get; set; }
    public ManaLinkRegistry ManaLinkRegistry { get; set; }
}

class EslipStubRequest {
    public string Name { get; set; }
    public string Description { get; set; }
    public string Condition { get; set; }
    public string BannerImageUrl { get; set; }
    public string IconImageUrl { get; set; }
    public int TotalQuantity { get; set; }
    public int RemainQuantity { get; set; }
    public bool CanGetOnce { get; set; }
    public bool IsManualApprove { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? ExpiredDate { get; set; }
}

class EslipApprove
{
    public bool IsApprove { get; set; }
    public string Remark { get; set; }
}

[Route("[controller]")]
class EslipController {
    [HttpGet("bizaccounts")]
    IEnumerable<BizAccountEslipInfo> GetBizAccounts(); // list merchant page จะมีแค่ promome
    [HttpGet("bizaccounts/{id}")]
    BizAccountEslipInfo GetBizAccountEslip(string id); // list eslip by ba page

    [HttpGet("distributions/{id}")]
    EslipDistribution GetEslipDistribution(string id);// stubId
    [HttpPost("{id}/receive")]
    ClientResponse EslipReceivePost(string id);// stubId
    
    [HttpGet("{id}")]
    EslipTail GetEslip(string id);
    [HttpPost("{id}/use")]
    ClientResponse EslipUsePost(string id);
}

class BizAccountEslipInfo {
    public BizAccountInfo Merchant { get; set; }
    public string MerchantEslipUrl { get; set; }
    public int EslipCount { get; set; }
    public IEnumerable<EslipTail> Eslips { get; set; }
}

class EslipDistribution {
    public string _id { get; set; }
    public string EndpointId { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? ExpiredDate { get; set; }
    public BizAccountInfo DistributerMerchant { get; set; }
    public EslipStub EslipStub { get; set; }
}