# Mana request body
## Topic
- ❓Mobile data collect
- ✅Models
- ✅Mobile and API communications
- ❓3rd hook
- ❓3rd MContent

---

## ❓Mobile data collect
- by design

## ✅Models
![](out/manarequestbody/ManaRequestBody.png)

## ✅Mobile and API communications
- GetDataApi
    - ส่ง gps ไปที่ api ผ่าน headers
    - response model แล้วแต่ข้อมูลที่ API ส่งกลับมา
- Submit data
    - ส่ง gps (รวมถึงข้อมูลอื่นๆ) ไปที่ api ผ่าน ManaRequestBody
    - response model : ClientResponse

### Issues
- GeoLocation รอดู design and usage
- AccessInfo key conflict with FQDN
    - workaround >> เอา AccessInfo key (sas) ออกก่อน submit
    - ❓encrypt by base64

![](out/sequence/sequence.png)


## ❓3rd hook

![](out/sequence-api/sequence.png)

## ❌3rd MContent
- MContent ส่ง gps ไปด้วย
- MContent ส่ง endpoint id ไปด้วย

![](out/sequence-mcontent/sequence.png)
