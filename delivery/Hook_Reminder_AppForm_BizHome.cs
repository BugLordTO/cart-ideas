# hook

[GET] /api/{serviceId}/Hooks //List all hooks
[GET] /api/{serviceId}/Hooks/{id} //Get a hook info
[DELETE] /api/{serviceId}/Hooks/{id} //Delete the hook

[POST] /api/{serviceId}/Hooks/data //Register url white list => can call from svc.CallApiGet(mcid, url); directly

//[POST] /api/{serviceId}/Hooks/product //Register the product hook => ไม่มี hook ตัวกลาง ใช้ของแต่ละอันไปเลย โดยการ map mcid กับ product tags
[POST] /api/{serviceId}/Hooks/cart //Register the cart hook and the resolution
[POST] /api/{serviceId}/Hooks/order //Register the order hook
[POST] /api/{serviceId}/Hooks/payment //Register the payment hook

[POST] /api/{serviceId}/Hooks/receiveeslip //Register the receive eslip hook
[POST] /api/{serviceId}/Hooks/useeslip //Register the use eslip hook

[POST] /api/{serviceId}/Hooks/contract //Register contract the hook
[POST] /api/{serviceId}/Hooks/employee //Register employee the hook
[POST] /api/{serviceId}/Hooks/membership //Register membership the hook => register, leave
[POST] /api/{serviceId}/Hooks/subscribe //Register subscribe the hook

[POST] /api/{deveId}/Hooks/sandboxpublish //Register sandbox publish the hook
[POST] /api/{deveId}/Hooks/productionpublish //Register production publish the hook


class HookRequest
{
    public string Url { get; set; }
}

class HookResponse
{
    public string Id { get; set; }
    public string TestTriggerUrl { get; set; }
    public HookRegistry Hook { get; set; }
}

class HookRegistry
{
    public string HookType { get; set; }
    public string Url { get; set; }
    public DateTime? AcknowledgedDateTime { get; set; }
}

# reminder

class ReminderController
{
    [GET] IEnumerable<ReminderResponse> GetReminder();
    [GET] ReminderResponse GetReminder(string id);
    [POST] ManaLink RegisterReminder(ReminderRequest request);
    [PUT] ManaLink EditReminder(string id, ReminderRequest request);
    [DELETE] void DeleteReminder(string id);

    [POST] TokenInfo CheckTokenInfo(string tempId);
    [POST] ReminderStatus SendReminder(ReminderMessageRequest request);
    [PUT] ReminderStatus EndReminderSession(ReminderMessageRequest request);
}

class ReminderResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string MContentId { get; set; }
    public string DataHookUrl { get; set; }
    public string FromPostHookUrl { get; set; }
    public int ShowGpsCount { get; set; }
    public bool IsAllowMultiSession { get; set; }
    public bool IsRequireMembership { get; set; }
    public bool CanPinToShortcut { get; set; }
    public DateTime CreatedDate { get; set; }
}

class ReminderRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string MContentId { get; set; }
    public string DataHookUrl { get; set; }
    public string FromPostHookUrl { get; set; }
    public int ShowGpsCount { get; set; }
    public bool IsAllowMultiSession { get; set; }
    public bool IsRequireMembership { get; set; }
    public bool CanPinToShortcut { get; set; }
    // public bool RequireSecurityOptions { get; set; } // ยังไม่มีรายละเอียด
}

class ReminderMessageRequest
{
    public string Description { get; set; }
    public string Status { get; set; }
    public bool CanDelete { get; set; }
    public string Option { get; set; } // UpdateHomeFeed, ShowMessage
    public string WorkflowState { get; set; }
    public DateTime? ChangeExpiredDate { get; set; }
    public string ReminderSessionId { get; set; }
}

class TokenInfo
{
    public string Id { get; set; }
    public string ReminderSessionId { get; set; }
    public DateTime CreatedDate { get; set; }
}

class ReminderStatus
{
    public string Message { get; set; }
    public string ReminderSessionId { get; set; }
    public DateTime? ExpiredDate { get; set; }
    public int RemindCount { get; set; }
}

class ManaLink
{
    public string Url { get; set; }
    public string QrCode { get; set; }
    public string QrImageUrl { get; set; }
    public string AppLinkUrl { get; set; }
    public string ItemType { get; set; }
    public DateTime? ExpiredDate { get; set; }
}

// ***** db
class Reminder
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string MContentId { get; set; }
    public string DataHookUrl { get; set; }
    public string FromPostHookUrl { get; set; }
    public int ShowGpsCount { get; set; }
    public bool IsAllowMultiSession { get; set; }
    public bool IsRequireMembership { get; set; }
    public bool CanPinToShortcut { get; set; }
    // public bool RequireSecurityOptions { get; set; } // ยังไม่มีรายละเอียด

    public string ServiceId { get; set; }
    public string BizAccountId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}

# application form

class ApplicationFormController
{
    [GET] IEnumerable<ApplicationFormResponse> GetApplicationForm();
    [GET] ApplicationFormResponse GetApplicationForm(string id);
    [POST] ManaLink RegisterApplicationForm(ApplicationFormRequest request);
    [PUT] ManaLink EditApplicationForm(string id, ApplicationFormRequest request);
    [DELETE] void DeleteApplicationForm(string id);
}

class ApplicationFormResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string MContentId { get; set; }
    public string DataHookUrl { get; set; }
    public string FromPostHookUrl { get; set; }
    public int ShowGpsCount { get; set; }
    public bool IsRequireMembership { get; set; }
    public bool Pinable { get; set; }
    public DateTime CreatedDate { get; set; }
}

class ApplicationFormRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string MContentId { get; set; }
    public string DataHookUrl { get; set; }
    public string FromPostHookUrl { get; set; }
    public int ShowGpsCount { get; set; }
    public bool IsRequireMembership { get; set; }
    public bool CanPinToShortcut { get; set; }
    // public bool RequireSecurityOptions { get; set; } // ยังไม่มีรายละเอียด
}

// ***** db
class ApplicationForm : DbModelBase
{
    public string ServiceId { get; set; }
    public string BizAccountId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public string MContentId { get; set; }
    public Hook DataHook { get; set; }
    public Hook FromPostHook { get; set; }
    public bool Pinable { get; set; }
    // public bool IsRequireMembership { get; set; }
    public GpsSection GpsSection { get; set; }
}

# biz homepage

class BizHomepageController
{
    [GET] IEnumerable<BizHomepageResponse> GetBizHomepage();
    [GET] BizHomepageResponse GetBizHomepage(string id);
    [POST] ManaLink RegisterBizHomepage(BizHomepageRequest request);
    [PUT] ManaLink EditBizHomepage(string id, BizHomepageRequest request);
    [DELETE] void DeleteBizHomepage(string id);
}

class BizHomepageResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string MContentId { get; set; }
    public string DataHookUrl { get; set; }
    // public string FromPostHookUrl { get; set; }
    public int ShowGpsCount { get; set; }
    public bool IsRequireMembership { get; set; }
    public bool CanPinToShortcut { get; set; }
    public DateTime CreatedDate { get; set; }
}

class BizHomepageRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string MContentId { get; set; }
    public string DataHookUrl { get; set; }
    // public string FromPostHookUrl { get; set; }
    public int ShowGpsCount { get; set; }
    public bool IsRequireMembership { get; set; }
    public bool CanPinToShortcut { get; set; }
    // public bool RequireSecurityOptions { get; set; } // ยังไม่มีรายละเอียด
}

// ***** db
class BizHomepage
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string MContentId { get; set; }
    public string DataHookUrl { get; set; }
    // public string FromPostHookUrl { get; set; }
    public int ShowGpsCount { get; set; }
    public bool IsRequireMembership { get; set; }
    public bool CanPinToShortcut { get; set; }
    // public bool RequireSecurityOptions { get; set; } // ยังไม่มีรายละเอียด

    public string ServiceId { get; set; }
    public string BizAccountId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}