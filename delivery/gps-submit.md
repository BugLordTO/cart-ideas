# visit endpoint
```plantuml
@startuml
mobile -> server : visitendpoint sv01.nbachme-123
note right: delivery home page
mobile -> server : visitendpoint sv01.nbachme-234
note right: banmor home page
mobile -> server : visitendpoint sv01.npdtdtl-345
note right: product cappuccino page
mobile -> server : visitendpoint sv01.ncrtodr-456
note right: order page
@enduml
```

# show gps
```plantuml
@startuml
participant mobile
participant server
mobile -> server : visitendpoint sv01.nbachme-123
note right: delivery home page
server --> mobile
note right
{
    Actions:[{CallEndpoint("url/sv01.nbachme-123")}],
    Workflow:{
        EmbeddedURLs:[{
            "url/sv01.nbachme-123":{
                Actions:[{
                    NavigateToMContent:{
                        ...
                        EndpointId: "sv01.nbachme-123",
                        MContentInfos:[{
                            AllowAddShortcut:true,
                            ShowButton:true,
                            **GpsSection:{**
                                **ShowAddress:true,**
                                **GpsMode:1,**
                                **CanChangeAddress:true,**
                                **UseCurrentLocation:1,**
                            **}**
                            **IsShowCart:false**
                        }]
                    },
                }],
            }
        }]
        RegisteredEndpointId: "sv01.nbachme-123",
    }
}
end note
@enduml
```

# hide gps
```plantuml
@startuml
participant mobile
participant server
mobile -> server : visitendpoint sv01.nbachme-234
note right: banmor home page
mobile -> server : visitendpoint sv01.npdtdtl-345
note right: product cappuccino page
server --> mobile
note right
{
    Actions:[{CallEndpoint("url/sv01.nbachme-123")}],
    Workflow:{
        EmbeddedURLs:[{
            "url/sv01.nbachme-123":{
                Actions:[{
                    NavigateToMContent:{
                        ...
                        EndpointId: "sv01.nbachme-123",
                        MContentInfos:[{
                            AllowAddShortcut:true,
                            ShowButton:true,
                            **GpsSection:{**
                                **ShowAddress:false,**
                                **GpsMode:1,**
                                **CanChangeAddress:false,**
                                **UseCurrentLocation:1,**
                            **}**
                            **IsShowCart:false**
                        }]
                    },
                }],
            }
        }]
        RegisteredEndpointId: "sv01.nbachme-123",
    }
}
end note
@enduml
```

# order (หลัง add to cart / กดจาก feed ยังไม่ checkout )
```plantuml
@startuml
participant mobile
participant server
mobile -> server : visitendpoint sv01.ncrtodr-456
server --> mobile
note right
{
    Actions:[{CallEndpoint("url/sv01.ncrtodr-456")}],
    Workflow:{
        EmbeddedURLs:[{
            "url/sv01.ncrtodr-456":{
                Actions:[{
                    NavigateToMContent:{
                        ...
                        EndpointId: "sv01.ncrtodr-456",
                        MContentInfos:[{
                            AllowAddShortcut:true,
                            ShowButton:true,
                            **GpsSection:{**
                                **ShowAddress:true,**
                                **GpsMode:1,**
                                **CanChangeAddress:true,**
                                **UseCurrentLocation:1,**
                            **}**
                            **IsShowCart:false**
                        }]
                    },
                }],
            }
        }]
        RegisteredEndpointId: "sv01.ncrtodr-456",
    }
}
end note
@enduml
```

# from feed (checkout แล้ว)
```plantuml
@startuml
participant mobile
participant server
mobile -> server : visitendpoint ncrtodr-567
server --> mobile
note right
{
    Actions:[{CallEndpoint("url/ncrtodr-567")}],
    Workflow:{
        EmbeddedURLs:[{
            "url/ncrtodr-567":{
                Actions:[{
                    NavigateToMContent:{
                        ...
                        EndpointId: "ncrtodr-567",
                        MContentInfos:[{
                            AllowAddShortcut:true,
                            ShowButton:true,
                            **GpsSection:{**
                                **ShowAddress:true,**
                                **GpsMode:1,**
                                **CanChangeAddress:false,**
                                **UseCurrentLocation:1,**
                            **}**
                            **IsShowCart:true**
                        }]
                    },
                }],
            }
        }]
        RegisteredEndpointId: "ncrtodr-567",
    }
}
end note
@enduml
```

------------------------------
# Submit GPS

```c#
/// <summary>
/// The Mana info request body
/// </summary>
public class ManaRequestBody
{
    /// <summary>
    /// The id, url value pairs for the attachments
    /// </summary>
    public IEnumerable<FileAttachment> Attachments { get; set; }
    public IEnumerable<GpsLocation> Locations { get; set; }
    public JsonElement Form { get; set; }
}

/// <summary>
/// The request body with quantity
/// </summary>
/// <example>Use with add product to cart</example>
public class ManaRequestBodyWithQuantity : ManaRequestBody
{
    /// <summary>
    /// (Optional) The quantity, if specified
    /// </summary>
    public int Quantity { get; set; }
}

public class FileAttachment
{
    public string Id { get; set; }
    public string ContentType { get; set; }
    public string Url { get; set; }
}

public class GpsLocation
{
    public string Address { get; set; } // full address string or location title from map
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string PhoneNumber { get; set; }
    public string Remark { get; set; }
}
```

# Address db model
```csharp
public class UserAddress
{
    public string _id { get; set; }
    public string PaId { get; set; }
    public int? BillingAddressIndex { get; set; }        
    public int? ShippingAddressIndex { get; set; }
    public DateTime CreatedDate { get; set; }
}

public class Address
{
    public string _id { get; set; }
    public string PaId { get; set; }
    public string Title { get; set; }
    public string StreetAddress { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string PostalCode { get; set; }
    public string TelephoneNumber { get; set; }
    public string MobileNumber { get; set; }
    public GpsLocation Location { get; set; }
    public DateTime CreatedDate { get; set; }
}

public class GpsLocation
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
```