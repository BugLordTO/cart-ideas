/// <summary>
/// Request KYM to backoffice
/// </summary>
public class SendKymRequest
{
    public string BaId { get; set; }
    /// <summary>
    /// Owner PaId
    /// </summary>
    public string PaId { get; set; }
    /// <summary>
    /// basic, advance
    /// </summary>
    public string KymType { get; set; }
    public string KymInfoFileUrl { get; set; }
    public AccessInfo AccessInfo { get; set; }
}

// API >>> /dev/{daId}/service/{svcId}/biz/{baId}/consent
/// <summary>
/// Backoffice request manager to consent high risk biz
/// </summary>
public class KymSessionRequest
{
    public string OperatorId { get; set; }
    public string SessionId { get; set; }
    public string UserId { get; set; }
    public string ManagerId { get; set; }
    public string Note { get; set; }
}

// API >>> /dev/{daId}/service/{svcId}/biz/{baId}/basic/result
/// <summary>
/// Backoffice approve/reject to biz
/// </summary>
public class SendKymResultRequest
{
    public string BaId { get; set; }
    public string KymInfoFileUrl { get; set; }
    public bool IsApproved { get; set; }
    public string RejectNote { get; set; }
    public AccessInfo AccessInfo { get; set; }
}
