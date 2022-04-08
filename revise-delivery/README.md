# current api
## delivery
✅ = มีใน apim
⛔ = route ยังไม่ถูก format
- Auth3rd
    [POST] /dev/{daId}/service/{svcId}/loginflow
        /Auth3rd/dev/{daId}/service/{svcId}/loginflow  <!-- register login flow --> ✅
- BizAccount3rd
    [GET] /dev/{daId}/service/{svcId}/biz/{baId}  <!-- get bizAccount --> ✅
    [PUT] /BizAccount3rd/{serviceId}/{bizAccountId} <!-- update bizAccount --> ✅⛔
    [POST] ​/BizAccount3rd​/{serviceId}​/{bizAccountId}​/page <!-- register catalog page --> ✅⛔
- Contract3rd
    [POST] /Contract3rd/{serviceId}/delivery/create <!-- create delivery contract --> ✅⛔
    [POST] /Contract3rd/{serviceId}/{bizAccountId}/shipping/create <!-- create shipping contract --> ✅⛔
- Employee3rd
    [POST] /Employee3rd/{serviceId}/{bizAccountId}/register <!-- register employee --> ✅⛔
- Escrow3rd
    [POST] ​/Escrow3rd​/{serviceId}​/{bizAccountId}​/rating <!-- submit rating --> ✅⛔
    [POST] ​/Escrow3rd​/{serviceId}​/{bizAccountId}​/release <!-- release escrow --> ✅⛔
    [PUT] /Escrow3rd​/{serviceId}​/{bizAccountId}​/cancel <!-- cancel escrow order --> ✅⛔
    [POST] ​/Escrow3rd​/{serviceId}​/{bizAccountId}​/update <!-- update escrow feed state --> ✅⛔
    [POST] ​/Escrow3rd​/{serviceId}​/{bizAccountId}​/updaterider <!-- update escrow (update rider) --> ✅⛔
## Service Management
- MContent3rd
    [POST]​ /MContent3rd/{serviceId}/form <!-- register mcontent --> ⛔
    [POST]​ /MContent3rd/{serviceId}/hook <!-- register hook --> ⛔
- Service3rd
    [POST]​ /Service3rd/{devAccountId} <!-- register service --> ⛔

    
# api/module ที่ใช้งานได้
- mcontent api
# api/module ที่ต้องปรับ
- service api
- contract api
- bizAccount api
- hook >> product, cart, order, employee
- product api
- cart
    - แยกระหว่าง delivery/normal cart
    - final cart model
- order
    - final order model
- escrow + reminder + form ตอนนี้รวมกันอยู่ > แยกกัน ?
    - escrow >> update rider profit
    - reminder >> 3rd ส่งข้อความมาแสดง
    - form >> standard form >> request cancel order / submit rating





## backoffice
- BizAccount3rd
    - [POST] /dev/{daId}/service/{svcId}/biz/{baId}/basic/result
- Kyc3rd
