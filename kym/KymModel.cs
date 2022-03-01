class KymRequest
{
    public BizAccountDetail Request { get; set; }
    public BizAccountDetail Current { get; set; }
}

class BizAccountDetail
{
    public string Id { get; set; }
    public DateTime RequestDate { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string BizType { get; set; }
    public BizAccountOwner Owner { get; set; }
}

class BizAccountOwner
{
    public string UserId { get; set; }
    public string DisplayName { get; set; }
    public string MaskedEmail { get; set; }
    public string MaskedMobile { get; set; }
    public string KycName { get; set; }
    public string KycStatus { get; set; } // none pending passed
}

//******************************************

