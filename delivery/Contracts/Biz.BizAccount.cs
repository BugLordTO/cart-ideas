namespace BizPortal.Controllers
{
    [ApiController]
    [Route("[controller]/{serviceId}/{bizAccountId}")]
    public class BizAccountController : ControllerBase
    {
        /// <summary>
        /// ลงทะเบียนหน้าแรกของร้าน สามารถมีได้ร้านละหนึ่งหน้า
        /// </summary>
        [HttpPost]
        public ActionResult<ManaLinkRegistry> RegisterBizPage(string serviceId, string bizAccountId, RegisterBizPageRequest request);
    }
}

namespace Models.Core
{
    public class ManaLinkRegistry
    {
        /// <summary>
        /// link for access this asset
        /// https://s.manal.ink/np/nxxxyyy-id00001
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// qr code for access this asset
        /// https://qr.manal.ink/np/nxxxyyy-id00001
        /// </summary>
        public string QrCode { get; set; }
        public string QrImageUrl { get; set; }
        public string AppLinkUrl { get; set; }
        public string ItemType { get; set; }
        public DateTime? ExpiredDate { get; set; }
    }

    public class ManaLinkRegistryItemTypePossible
    {
        public const string BizHome = nameof(BizHome);
        public const string Product = nameof(Product);
        public const string Reminder = nameof(Reminder);
    }

    public class GpsSection
    {
        public bool ShowAddress { get; set; }
        public int CurrentLocationOnly { get; set; }
        public int GpsMode { get; set; }
        public bool Changeable { get; set; }
    }
}

namespace Models.BizAccount
{
    public class RegisterBizPageRequest
    {
        public string MContentId { get; set; }
        public string DataHookUrl { get; set; }
        public string FormPostHookUrl { get; set; }
        public bool Pinable { get; set; }
        // public bool IsRequireMembership { get; set; }
        public GpsSection GpsSection { get; set; }
    }
}

namespace DbModels.BizAccount
{
    public class DbModelBase
    {
        public string _id { get; set; }
    }

    public class BizAccountPage : DbModelBase
    {
        public string ServiceId { get; set; }
        public string BizAccountId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public string MContentId { get; set; }
        public Hook DataHook { get; set; }
        public Hook FormPostHook { get; set; }
        public bool Pinable { get; set; }
        // public bool IsRequireMembership { get; set; }
        public GpsSection GpsSection { get; set; }
    }
}
