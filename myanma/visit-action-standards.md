visit
    zip
        https://s.namal.ink/np/nxxxyyy-123456789
    mcproxy
        https://mcproxy.space/np/nxxxyyy-123456789
        https://xapimana.space/visit/{endpointid}

        https://mcproxy.space/np/nxxxyyy.zzz-123456789
        https://xapimana.space/visit/{endpointid}/zzz

    return
        ActionsEx.N2M(endpointid, mcId);
        ActionsEx.N2M(endpointid, mcId, ViewModelNames.MContent0ButtonPageVM);
        ActionsEx.N2P(endpointid, mcId, $"{manaLinkOptions.Mana}/np/{endpointid}");
        ActionsEx.N2P(endpointid, "kyc-agreement", $"{manaLinkOptions.Mana}/np/{EndpointPrefixPossible.KycBasic}-create", AppTxt.Button.Accept, HttpMethod.Get.Method, showWaiting: false);
        ActionsEx.N2M(endpointid, mContentInfos: new MContentInfo[]
            {
                new MContentInfo("kyc-basic-create"),
                new MContentInfo("kyc-tel-confirm", isOption: true)
            });

data
    mcid เดียวกัน
        https://mcproxy.space/data/{mcid}/{endpointid1}
        https://mcproxy.space/data/{mcid}/{endpointid2}
        https://xapimana.space/{endpointid}

    คนละ mcid แต่ endpoint เดียวกัน
        https://mcproxy.space/data/{mcid1}/{endpointid}
        https://xapimana.space/1/{endpointid}

        https://mcproxy.space/data/{mcid2}/{endpointid}
        https://xapimana.space/2/{endpointid}

        private method

command ที่ใช้บ่อย
    ActionsEx.CompleteWorkflow(endpointid, feedId);
    ActionsEx.ShowResultMsg(endpointid, {message}, DialogStatus.Fail); // ติด 30 วิ flow ที่มี noti
    ActionsEx.ShowResultMsg2(endpointid, {message}, DialogStatus.Fail); // ไม่ติด 30 วิ
    ActionsEx.CallEndpoint($"{manaLinkOptions.Mana}/np/nbizdtl-{endpoint.EntityId}${status}");

ตัวอย่าง controller
    BizAccountController
    KycController
    