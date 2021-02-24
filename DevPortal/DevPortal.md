# API Management service

## Users
- ใช้ mana login เท่าที่ลองหาข้อมูลดู จะทำผ่าน Azure Active directory B2C

## Gateway
มี gateway 2 set มี api เหมือนกัน แต่ sandbox จะมี api สำหรับ publish service เพิ่มเข้ามา
-  Sandbox gateway
-  Production gateway

##  Products
- ใช้ feature products ของ API Management จัดการการเข้าถึง api เป็นหลายๆระดับ

### All API
<details>
<summary></summary>
<pre>
- Dev API
    - Developer
    - Service
    - MContent
    - Hook & Feature
    - Service Subscription
    - Contract (S2B S2P)
    - Db Schema
- 3rd API
    - Form
    - Reminder
    - Membership
    - Eslip
    - Cart & Product
    - Privilege
    - Budget
    - Delivery
    - Contract (B2B B2P)
    - Db
    - Tournament
    - Event
    - Biz (Only for sandbox)
    - Service Publish API (Only for sandbox)
</pre>
</details>

### Starter
- Dev API (Only for sandbox)
    - Developer
    - Service
    - MContent
    - Hook & Feature
    - Service Subscription
- 3rd API
    - Form
    - Reminder
    - Membership
    - Eslip
    - Cart & Product
    - Privilege
    - Budget
    - Biz (Only for sandbox)

### Publisher [Only for sandbox gateway]
- Dev API
    - Service Publish API

### Delivery [Exclusive]
- Dev API
    - Contract (D2B D2P)
- 3rd API
    - Delivery
    - Contract (B2B B2P)

### DbManager [Exclusive]
- Dev API
    - Db Schema
- 3rd API

### Tournament [Exclusive]
### Event [Exclusive]

## Subscriptions
เริ่มต้นจะจัดการ subscription ผ่าน azure portal เพราะ developer เป็นของ mana เอง  
แล้วค่อยทำเว็บจัดการผ่าน api ที่ azure เปิดให้
- [Rest API call to approve](https://docs.microsoft.com/en-us/rest/api/apimanagement/2019-12-01/subscription)


# issues
- custom ui - self hosting
    - can clone can run
    - can manage thru api (make own web&host) ```demodevapi555.management.azure-api.net```
- consumption plan
    - no portal menu
    - no Sas gen menu
    - no api to manage
        - try call thru api get ```getaddrinfo ENOTFOUND consumapi.management.azure-api.net``` response

- sas permission เหมือนกับ service อื่นรึเปล่า
    - ไม่เหมือน ใช้ของตัวเอง
    - https://login.microsoftonline.com/93793cef-3400-4bdb-81f4-925ccb3a6924/oauth2/authorize
    - https://login.microsoftonline.com/93793cef-3400-4bdb-81f4-925ccb3a6924/oauth2/token

```
TenantId: 93793cef-3400-4bdb-81f4-925ccb3a6924
ClientId: 615c74dc-fdc2-432d-9c0e-090b8feec65c
KeyId: 64d69d50-9d27-447b-8d6e-6b583d62d237
Key: d0G-qk8XCp~55.B7hdq8mAc1sfS-j-m93V

{
  "clientId": "4288cd50-d150-4f56-8a87-02fb824ca91c",
  "clientSecret": "MmJL_XRsTI3WpGcyRGIlAXW5Yp8PQP-E_6",
  "subscriptionId": "7874dd6f-3591-4b3a-84d8-9f42a96ccddd",
  "tenantId": "93793cef-3400-4bdb-81f4-925ccb3a6924",
  "activeDirectoryEndpointUrl": "https://login.microsoftonline.com",
  "resourceManagerEndpointUrl": "https://management.azure.com/",
  "activeDirectoryGraphResourceId": "https://graph.windows.net/",
  "sqlManagementEndpointUrl": "https://management.core.windows.net:8443/",
  "galleryEndpointUrl": "https://gallery.azure.com/",
  "managementEndpointUrl": "https://management.core.windows.net/"
}
```
mana-portal-msi