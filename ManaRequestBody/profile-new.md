# ==================== m2 ====================

## models

```c#
public class ManaUserView
{
    public string DisplayName { get; set; }
    public string ProfileImageUrl { get; set; }
    public string RefId { get; set; }
    public string KycState { get; set; }
    public string KycEndpointUrl { get; set; }
    public string ShippingEndpointUrl { get; set; }
    public string BillingEndpointUrl { get; set; }
}
```

```json
{
    "displayName": null,
    "profileImageUrl": null,
    "refId": null,
    "kycState": null,
    "kycEndpointUrl": null,
    "shippingEndpointUrl": null,
    "billingEndpointUrl": null
}
```

## workflow

- visit profile > N2P(UserAccount) / https://s.manal.ink/np/npflacc-home

## apis

```c#
[Route("[controller]")]
public class ProfileController : ApiControllerBase
{
    // [HttpGet("visit/{endpointid}")]
    // public async Task<ActionResult<ClientResponse>> ProfileVisit(string endpointid);
    [HttpGet]
    public async Task<ActionResult<ManaUserView>> ProfileData();
}
```

# ==================== m3, m9 ====================

## models

```c#
public class AddressesResponse<T> where T : StreetAddress
{
    public string DefaultId { get; set; }
    public string CreateEndpointUrl { get; set; }
    public string ChangeDefaultEndpointUrl { get; set; }
    public IEnumerable<AddressWithUrl<T>> Addresses { get; set; }
}
public class AddressWithUrl<T> where T : StreetAddress
{
    public string EditEndpointUrl { get; set; }
    public string DeleteEndpointUrl { get; set; }
    public T Address { get; set; }
}
public interface IStreetAddress {}
public abstract class AddressBase {}
public class StreetAddress : AddressBase, IStreetAddress {}
public interface IHaveContactNo {}
public class ContactableAddress : StreetAddress, IHaveContactNo {}
public interface IHaveGpsAddress {}
public class ShippingAddress : ContactableAddress, IHaveGpsAddress {}
public class BillingAddress : ContactableAddress {}
```

```json
{
    "defaultId": null,
    "createEndpointUrl": null,
    "changeDefaultEndpointUrl": null,
    "addresses": [
        {
            "editEndpointUrl": null,
            "deleteEndpointUrl": null,
            "address": { }
        }
    ]
}
```

## workflow

- visit shipping addresses > https://s.manal.ink/np/npflads-home
- visit billing addresses > https://s.manal.ink/np/npfladb-home

## apis

```c#
[Route("[controller]")]
public class ProfileController : ApiControllerBase
{
    // [HttpGet("visit/{endpointid}/shipping")]
    // public async Task<ActionResult<ClientResponse>> ShippingVisit(string endpointid);
    [HttpGet("shipping")]
    public async Task<ActionResult<AddressesResponse<ShippingAddress>>> ShippingData();
    
    // [HttpGet("visit/{endpointid}/billing")]
    // public async Task<ActionResult<ClientResponse>> BillingVisit(string endpointid);
    [HttpGet("billing")]
    public async Task<ActionResult<AddressesResponse<BillingAddress>>> BillingData();
}
```

# ==================== m4, m10, m7 ====================

## models

```c#
public class AddressWithToggle<T> where T : StreetAddress
{
    public bool IsDefault { get; set; }
    public T Address { get; set; }
}
```

```json
{
    {
        "IsDefault": null,
        "address": { }
    }
}
```

## workflow

- visit create shipping address > https://s.manal.ink/np/npflads-create
- visit edit shipping address > https://s.manal.ink/np/npflads-{id}
- visit delete shipping address > https://s.manal.ink/np/npflads.delete-{id}
- visit change shipping address > https://s.manal.ink/np/npflads-change

- visit create billing address > https://s.manal.ink/np/npfladb-create
- visit edit billing address > https://s.manal.ink/np/npfladb-{id}
- visit delete billing address > https://s.manal.ink/np/npfladb.delete-{id}
- visit change billing address > https://s.manal.ink/np/npfladb-change

## apis

```c#
[Route("[controller]")]
public class ProfileController : ApiControllerBase
{
    // [HttpGet("visit/{endpointid}/shipping/create")]
    // public async Task<ActionResult<ClientResponse>> ShippingCreateVisit(string endpointid);
    [HttpGet("shipping/create")]
    public async Task<IActionResult> ShippingCreateData(); // return no content to avoid 404
    [HttpPost("shipping/create")]
    public async Task<ActionResult<ClientResponse>> ShippingCreateSubmit([FromBody] ShippingAddress request, [FromQuery] GpsFromQuery1 gpsFromQuery);
    // [HttpGet("visit/{endpointid}/shipping/edit")]
    // public async Task<ActionResult<ClientResponse>> ShippingEditVisit(string endpointid);
    [HttpGet("shipping/{endpointid}")]
    public async Task<ActionResult<AddressWithToggle<ShippingAddress>>> ShippingEditData(string endpointid);
    [HttpPost("shipping/{endpointid}")]
    public async Task<ActionResult<ClientResponse>> ShippingEditSubmit(string endpointid, [FromBody] ShippingAddress request, [FromQuery] GpsFromQuery1 gpsFromQuery);
    // [HttpGet("visit/{endpointid}/shipping/delete")]
    // public async Task<ActionResult<ClientResponse>> ShippingVisit(string endpointid);
    [HttpPost("shipping/{endpointid}/delete")]
    public async Task<ActionResult<ClientResponse>> ShippingDeleteSubmit(string endpointid);
    // [HttpGet("visit/{endpointid}/shipping/change")]
    // public async Task<ActionResult<ClientResponse>> ShippingChangeVisit(string endpointid);
    
    // [HttpGet("visit/{endpointid}/billing/create")]
    // public async Task<ActionResult<ClientResponse>> BillingCreateVisit(string endpointid);
    [HttpGet("billing/create")]
    public async Task<IActionResult> BillingCreateData(); // return no content to avoid 404
    [HttpPost("billing/create")]
    public async Task<ActionResult<ClientResponse>> BillingCreateSubmit([FromBody] BillingAddress request);
    // [HttpGet("visit/{endpointid}/billing/edit")]
    // public async Task<ActionResult<ClientResponse>> BillingEditVisit(string endpointid);
    [HttpGet("billing/{endpointid}")]
    public async Task<ActionResult<AddressWithToggle<BillingAddress>>> BillingEditData(string endpointid);
    [HttpPost("billing/{endpointid}")]
    public async Task<ActionResult<ClientResponse>> BillingEditSubmit(string endpointid, [FromBody] BillingAddress request);
    // [HttpGet("visit/{endpointid}/billing/delete")]
    // public async Task<ActionResult<ClientResponse>> BillingVisit(string endpointid);
    [HttpPost("billing/{endpointid}/delete")]
    public async Task<ActionResult<ClientResponse>> BillingDeleteSubmit(string endpointid);
    // [HttpGet("visit/{endpointid}/billing/change")]
    // public async Task<ActionResult<ClientResponse>> BillingChangeVisit(string endpointid);
}
```

# ==================== m6 ====================

## models

```c#
public class ItemsSelect<T>
{
    public string SelectedId { get; set; }
    public IEnumerable<T> Items { get; set; }
}
```

```json
{
    {
        "SelectedId": null,
        "Items": []
    }
}
```

## workflow

- visit select shipping address > https://s.manal.ink/np/npflads-select
- visit select shipping address > https://s.manal.ink/np/npfladb-select

## apis

```c#
[Route("[controller]")]
public class ProfileController : ApiControllerBase
{
    // [HttpGet("visit/{endpointid}/shipping/select")]
    // public async Task<ActionResult<ClientResponse>> ShippingSelectVisit(string endpointid);
    [HttpGet("shipping/select")]
    public async Task<ActionResult<ItemsSelect<ShippingAddress>>> ShippingData();
    
    // [HttpGet("visit/{endpointid}/billing/select")]
    // public async Task<ActionResult<ClientResponse>> BillingSelectVisit(string endpointid);
    [HttpGet("billing/select")]
    public async Task<ActionResult<ItemsSelect<BillingAddress>>> BillingData();
}
```
