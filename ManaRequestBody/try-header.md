# Get method

## 1. แยกแต่ละ field

### Request
```
GET https://localhost:44332/api/values/sep
Latitude: 1.111
Longitude: 1.111
Latitude: 1.222
Longitude: 1.222
```

### API & Model
```c#
[HttpGet("sep1")]
public IActionResult Seperate1([FromHeader] GeoLocationSep locations)
//public IActionResult Seperate1([FromHeader] double[] Latitude, [FromHeader] double[] Longitude)
{
    return Ok();
}
public class GeoLocationSep
{
    [FromHeader]
    public double[] Latitude { get; set; }
    [FromHeader]
    public double[] Longitude { get; set; }
}
```

### pros and cons
- field แยก
- ลำดับ + ความหมายไม่ชัดเจน
- ถ้าทำงานกับ gps 2 อัน ส่วนที่บอกว่า Latitude คู่กับ Longitude ไหนจะไม่ชัดเจน

## 2. แยกแต่ละ field ใช้เลขกำกับ

### Request
```
GET https://localhost:44332/api/values/sep2
Latitude1: 1.111
Longitude1: 1.111
Latitude2: 1.222
Longitude2: 1.222
```
### API & Model
```c#
[HttpGet("sep2")]
public IActionResult Seperate2(
    [FromHeader] string Latitude1, [FromHeader] string Longitude1, 
    [FromHeader] string Latitude2, [FromHeader] string Longitude2)
{
    return Ok();
}
```

### pros and cons
- field แยกชัดเจน
- parameter ที่ api รวมเป็น class ไม่ได้ เลยดูรก

## 3. lat&lon array

### Request
```
GET https://localhost:44332/api/values/sep2
location1: 10.111,107.111
location2: 11.222,108.222
```

### API & Model
```c#
[HttpGet("latlonarray")]
public IActionResult LatLonArray([FromHeader] GeoLocationSep2 LocationSep2)
{
    return Ok();
}
public class GeoLocationSep2
{
    [FromHeader]
    public double[] Location1 { get; set; }
    [FromHeader]
    public double[] Location2 { get; set; }
}
```

### pros and cons
- field แยกชัดเจน
- parameter รวมเป็น class ได้

## 4. Manual deserialize

### Request
```
GET https://localhost:44332/api/values
X-MANA-LOCATIONS: [{"Latitude": 1.123,"Longitude": 1.123},{"Latitude": 1.222,"Longitude": 1.222}]
EndpointId: nxxxyyy-123
```

### API & Model
```c#
[HttpGet]
public IActionResult Index([FromHeader] ManaRequestHeader locations)
{
    return Ok();
}
public class ManaRequestHeader
{
    public GeoLocation[] Locations { get => JsonSerializer.Deserialize<GeoLocation[]>(_locations ?? "{}"); }
    [FromHeader(Name = "X-MANA-LOCATIONS")]
    public string _locations { get; set; }
    [FromHeader]
    public string EndpointId { get; set; }
}
public class GeoLocation
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
```

### pros and cons
- deserialize ข้อมูลแล้วใช้งานได้เลย
- อาจจะไม่ตรงกับวิธีการใช้ header จริงๆ?
- ถ้าใช้ class ตามตัวอย่าง จะสามารถรับ header อื่นได้ด้วย

# Post method

### Request
```
POST https://localhost:44332/api/values
X-MANA-LOCATIONS: [{"Latitude": 1.123,"Longitude": 1.123},{"Latitude": 1.222,"Longitude": 1.222}]
content-type: application/json

{
    "Attachments": "Some file",
    "ExData": {
        "quantity": "1" ,
        "employeeid": "a1s2d3f6g5h4" 
    },
    "Form": {
        "Name":"John"
    }
}

```

### API & Model
```c#
[HttpPost]
public IActionResult Index([FromBody] ManaRequestBody<SomeForm, DeliveryLocation> body)
{
    return Ok();
}
public class DeliveryLocation : GeoLocation
{
    public string Remark { get; set; }
    public string PhoneNumber { get; set; }
}
public class ManaRequestBody<T, TL>
{
    public string Attachments { get; set; }
    public IDictionary<string, string> ExData { get; set; }
    public T Form { get; set; }
}
public class ManaRequestBody<T, TL> : ManaRequestBody<T>
    where TL : GeoLocation
{
    public TL[] Locations { get; set; }
}
public class SomeForm
{
    public string Name { get; set; }
}
```

