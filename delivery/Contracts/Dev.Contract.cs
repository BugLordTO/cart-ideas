namespace DevPortal.Controllers
{
    class ContractController
    {
        ///3rd API
        void RequestConsent(ContractInfo contract);
        ContractInfo GetBAContract(string OwnerId, string ContractorId, string ServiceId);

        ///Mana API
        ClientResponse ConsentContract(string contractId, bool IsAgree);
        ContractInfo GetContractDetail(string contractId); //feed detail. mana standard

        ///Hook 3rd
        void ResponseContract(DeliveryContractInfo contract);
    }
    //Model
    class ContractInfo
    {
        public string _id { get; set; }
        public string OwnerId { get; set; }
        public ContractorInfo Contractor { get; set; }
        public string ServiceId { get; set; }
        public string ContractType { get; set; } //Delivery, Software, Employee
        public string Status { get; set; } //Pending, Accepted/Denied, Changed(เปลี่ยนไปใช้สัญญาใหม่)
        public datetime CreatedDate { get; set; }
        public datetime? ResponseDate { get; set; }
        public datetime? ExpiredDate { get; set; }
        public List<SharingInfo> Sharings { get; set; }

    }
    class ContractorInfo
    {
        public string UserId { get; set; }
        public string Mobile { get; set; }
        public string RefCode { get; set; }
    }
    class SharingInfo
    {
        public string Type { get; set; } //dev, ba, mana, contract
        public string RefId { get; set; }
        public string Value { get; set; }
        public string EffectOnValue { get; set; } //Percent, constant, Employee title??(Code)
    }

    ///////////////////////

    class DeliveryContract : ContractInfo
    {
        public decimal SharingForOwner { get; set; } // percentage
        public decimal ShippingFee { get; set; } // constant
        public decimal TotalAmount { get; set; } //?????
    }
    class SoftwareContract : ContractInfo
    {
        public decimal SharingForOwner { get; set; } // percentage
        public decimal SharingForContractor { get; set; } // percentage
        public decimal SharingForBiker { get; set; } // percentage
    }
    class EmployeeContract : ContractInfo
    {
        public string Title { get; set; }
        public string Code { get; set; }
    }