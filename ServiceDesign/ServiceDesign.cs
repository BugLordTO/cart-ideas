[HttpPost("biz/{baId}")]
public async Task<ActionResult<ServiceResponse>> CreateService(string baId, [FromBody]CreateServiceRequest request) { }

public class CreateServiceRequest{
    public string Name { get; set; } //require
    public string Logo { get; set; } // หรือาจจะต้องไป upload ใส่ทีหลัง
    public PublishData PublishData { get; set; }
    public string SandboxBaseUrl { get; set; }
}
public class ServiceResponse{
    public string _id { get; set; }
    public string Name { get; set; }
}

//ServiceSandBoxDB
public class Service {
    public string _id { get; set; }
    public string BaId { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public PublishData PublishData { get; set; }
    public string SandboxBaseUrl { get; set; }
    public string ProductionBaseUrl { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? DeleteDateTime { get; set; }   
}
public class PublishData {
    public MonetaryValue Price { get; set; }   
    public DateTime? ReleaseDateSchedule  { get; set; }
    public IEnumerable<string> Tags { get; set; } //?? ใช้ทำอะไรบ้าง ต้องใส่ตอน create ไหม
    public string Description { get; set; }
    //etc.รอ UI
}

[HttpPost("biz/{baId}/svc/{svcId}/hook/")]
public async Task<ActionResult<ManaHookResponse>> RegisterHook(string baId, string svcId , RegisterHookRequest request){} 
public class RegisterHookRequest{
    public string PathUrl { get; set; }
    public string HookType { get; set; }
}
public class ManaHookResponse{
    public string _id { get; set; }
    public string HookType { get; set; }
    public string FullUrl { get; set; }
} 

//HookDB
public class Hook 
{
    public string _id { get; set; }
    public string ServiceId { get; set; }
    //Payment , Order , Product
    public string Type { get; set; }
   // public string BaseUrl { get; set; }
    public string PathUrl { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime? DeleteDateTime { get; set; }
}

//ServiceProductionDB
public class ServiceProduction : Service {
   public List<ServicePublishVersion> ServiceVersions { get; set; }
   public string LatestVersion { get; set; }
}
public class ServiceEarnestMoney {
    public string _id { get; set; }
    public string ServiceId { get; set; }
    public string EarnestMoneyWalletId { get; set; } 
    public MonetaryValue EarnestMoneyAmount { get; set; }
}
public class ServicePublishVersion : PublishData {
    public string Version { get; set; }
     // Prerelease , RequestPublish , Publish
    public string PublishStatus { get; set; }
    public string? ContractId { get; set; } 
}
public class Contract  
{
    //ผู้ร่าง   ManaServiceCompany
    //ผู้เซ็น   BizOwnerService
    //ส่วนแบ่ง 
}