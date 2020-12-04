namespace api3rd
{
    class MContentController
    {
        [GET] IEnumerable<MContentResponse> GetMContent();
        [GET] MContentResponse GetMContent(string id);

        [POST] MContentResponse RegisterMContentPage(MContentPageRequest request);
        [PUT] MContentResponse EditMContentPage(string id, MContentPageRequest request);

        [POST] MContentResponse RegisterMContentForm(MContentFormRequest request);
        [PUT] MContentResponse EditMContentForm(string id, MContentFormRequest request);

        [POST] MContentResponse RegisterMContentOption(MContentOptionRequest request);
        [PUT] MContentResponse EditMContentOption(string id, MContentOptionRequest request);

        [GET] void DeleteMContent(string id);

        [POST] MContentResponse MContentOptionBinding(MContentOptionBind request);
    }
}

namespace shared
{
    class MContentBase
    {
        public string Name { get; set; }
        public string BaseUrl { get; set; } // base url include base path that specify in <base href="basePath"/>
        public string ContentType { get; set; } // Html, BindableHtml, Url
        public string ContentHtml { get; set; } // only path of content, exclude host and base path
        public string ContentUrl { get; set; } // parameterized-formatted
        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<string> AllowUrls { get; set; } // for white list

        public IEnumerable<ActionItem> ActionItems { get; set; }
        public string DataHook { get; set; } // default DataHook
    }

    class MContentPageRequest : MContentBase { }

    class MContentFormRequest : MContentBase
    {
        public bool IsShowButton { get; set; }
        public string FormPostHook { get; set; } // default FormPostHook
        // public IEnumerable<DataField> RequestedFields { get; set; } // เติมทีหลัง
    }

    class MContentOptionRequest : MContentBase { }

    class MContentOptionBind
    {
        public IEnumerable<string> MContentOptionIds { get; set; }
    }

    class MContentOption : MContentBase { }

    class MContentResponse
    {
        public string MContentId { get; set; }
        public string ManaUrl { get; set; } // test url => https://mana.com/mcontent/{mcontentid}/nmctmck-{mcontentid}
    }

    public class ActionItem
    {
        public string Name { get; set; } // Display text
        public string Action { get; set; } // Javascript function name to call
    }
}

namespace db
{
    class MContent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string BaseUrl { get; set; } // base url include base path that specify in <base href="basePath"/>
        public string ContentType { get; set; } // Html, BindableHtml, Url
        public string ContentHtml { get; set; } // only path of content, exclude host and base path
        public string ContentUrl { get; set; } // parameterized-formatted
        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<string> AllowUrls { get; set; } // for white list
        public IEnumerable<ActionItem> ActionItems { get; set; }
        public Hook DataHook { get; set; } // default DataHook
        public Hook FormPostHook { get; set; } // default FormPostHook

        public string ItemType { get; set; }
        public string ServiceId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public IEnumerable<string> OptionIds { get; set; }
    }

    class Hook
    {
        public string Url { get; set; }
    }

    class MContentItemTypePossible
    {
        public string MContentPage = nameof(MContentPage);
        public string MContentForm = nameof(MContentForm);
        public string MContentOption = nameof(MContentOption);
    }
}

// public bool CanPinToShortcut { get; set; } // แล้วแต่ endpoint ที่เอาไปใข้
// public int ShowGpsCount { get; set; } // 0 1 2 // แล้วแต่ endpoint ที่เอาไปใข้
// public bool IsRequireMembership { get; set; } // แล้วแต่ endpoint ที่เอาไปใข้
// public IEnumerable<string> RequireSecurityOptions { get; set; } // แล้วแต่ endpoint ที่เอาไปใข้

///Response
// public DateTime? ExpiredDate { get; set; } => rely to service instead of itself




// class BizController
// {
//     /// <summary>
//     /// ลงทะเบียนหน้าแรกของร้าน สามารถมีได้ร้านละหนึ่งหน้า
//     /// X ซึ่งเป็นหน้าที่แสดงเมนูตะกร้าที่ navigation bar ได้ หาก user มีการเพิ่มสินค้าเข้าตะกร้าแล้ว
//     /// / แสดงเมนูตะกร้าทุกหน้าของร้าน
//     /// </summary>
//     ManaLink RegisterBizPage(string id, RegisterBizPageRequest request);
// }

// class RegisterBizPageRequest
// {
//     public string MContentId { get; set; }
// }
