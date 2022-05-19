# Api3rd.MContentOptionController
## Contract
```c#
[HttpPost]
public async Task<IActionResult<ManaLinkRegistry>> RegisterMContentOption(MContentOption mcontentOption);
[HttpPost]
public async Task<IActionResult> MContentOptionMapping(MContentOptionMapping mapping);
```

## Model
```c#
public class MContentOption {
    public string Title { get; set; }
    ...
}

public class ManaLinkRegistry {
    public string Id { get; set; }
    ...
}

public class MContentOptionMapping {
    public IEnumerable<string> string MContentOptionIds { get; set; }
}
```

# ApiMana.MContentFormController
## Contract
```c#
public async Task<ActionResult<ClientResponse>> Visit(string id);
```

## Model
```c#
public class ManaLinkRegistry {

}

public class MContentOption {
    public string _id { get; set; }
}

public class MContentOptionMapping {
    public string MContentId { get; set; }
    public IEnumerable<string> string MContentOptionIds { get; set; }
}
```