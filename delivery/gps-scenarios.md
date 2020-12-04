# scenarios
### action
- user profile & business profile
    - show location on top of address page
    - touch to change location
    - submit change location
- cart
    - [VM, MContent, script] show default delivery location on top of cart page
    - [dialog, gps] select delivery address
    - recalculate distance from business and delivery location when changed
    - [dialog] select delivery service
    - submit cart with delivery location

---
- manage delivery service
    - X setup work area -- distance, village, province, region, country
### scenarios
- user ดูแผนที่จากที่อยู่ที่เลือก
- user แก้ไขที่อยู่ตั้งค่าให้เป็น "ที่อยู่ส่งของ" แต่ไม่มี location -- ระบบแจ้งว่าไม่ให้บันทึก
- user เพิ่ม location ให้ที่อยู่ใหม่
- user แก้ไขที่อยู่เดิม และเพิ่ม location
- user แก้ไขที่อยู่เดิม และแก้ไข location
- business owner ดูแผนที่ของร้าน
- business owner แก้ไขแผนที่ของร้าน
- user เปลี่ยน location สำหรับ delivery ใน cart
---
- delivery service (business) owner ตั้งค่าพื้นที่สามารถจัดส่งสินค้า
    ** เซตค่าจัดส่ง
- user เปลี่ยน location สำหรับ delivery ใน cart -- ระบบแจ้งว่าอยู่นอกพื้นที่ delivery service
- user เปลี่ยน delivery service ใน cart
- user เปลี่ยน delivery service ใน cart -- ระบบแจ้งว่าอยู่นอกพื้นที่ delivery service
** ค่าจัดส่ง

# upgrade module
- mobile
    + MContent1ButtonLocationPage / MContent1ButtonLocationFormVM -- for address & cart page
    + MapPage / MapPageVM -- for show map to select location
    + GetLocationCommand -- for show MapPage and return location
    * submit with location mechanism
        - http header
        - attach on submit (overide submit)
    <details>
    <summary>Sequence</summary>

    ```plantuml
    @startuml
    participant user
    participant MContent1ButtonLocationPage_VM as locP
    participant GetLocationCommand_Handler as Lcmd
    participant MapPage_VM as mapP

    user -> locP : edit address
    activate locP
        locP -> locP : show address
        locP -> locP : call script setLocation
    deactivate locP
    user -> locP : select location
    locP ->  Lcmd : call GetLocationCommand(current_location)
    activate locP
        Lcmd -> Lcmd : create TaskCompletionSource to parameter
        activate Lcmd
            Lcmd -> mapP : open MapPage(parameter)
            activate mapP
                mapP -> mapP : InitMap(google_map)
                mapP -> mapP : SetViewParameter(parameter)
                mapP -> mapP : set map location from parameter \nset to current location if parameter is null
            deactivate mapP
            user -> mapP : Select location
            activate mapP
                mapP -> mapP : GetNearbyPlace from google/mana
                mapP -> mapP : show select place dialog
            deactivate mapP
            user -> mapP : Select place
            activate mapP
                mapP -> mapP : SetResult(selected place)
            deactivate mapP
            Lcmd --> locP : selected place
        deactivate Lcmd
        locP -> locP : show selected place
    deactivate locP
    user -> locP : submit form
    activate locP
        locP -> locP : attach location with place to body
        locP -> locP : base.Submit()
    deactivate locP

    @enduml
    ```
    </details>

- zip
    - content
        + SelectAddress ionic page -- open from cart page
        * shopping-cart page
        * javascript lib function SetLocation(location: MapLocation); -- for set location section of MContent1ButtonLocationPage
        * user-profile-edit-address page
        * merchant-edit-address
    - workflow
        * edit user address
        + edit biz address
- server
    * user profile model support location
    * business profile model support location
    ```c#
        public class Address
        {
            public string Title { get; set; }
            public string StreetAddress { get; set; }
            public string District { get; set; }
            public string City { get; set; }
            public string Province { get; set; }
            public string PostalCode { get; set; }
            public string TelephoneNumber { get; set; }
            public string MobileNumber { get; set; }
            public MapLocation MapLocation { get; set; }// <-- add this
        }
        public class MapLocation
        {
            public string Title { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }
        }
    ```
    * cart model => business location + delivery location
    ---
    * calculate distance from business location and delivery location
    * business profile model support delivery area

# Feature
- Reminder
    - อัพเดท reminder พร้อมแจ้งเตือนผ่าน noti (มีแล้วจาก daily reward)
    - reminder ที่เป็น submit from ตอนให้ rating (มีแล้วจาก daily reward)
        - user เป็นคนปิด reminder (submit rating)
        - hook
    - อัพเดทข้อมูลในหน้านั้นใช้ change workflow state
- Pin MContent shortcut (มีแล้ว)
- GPS MContent
    - Home Shops
        - mana จัดการแสดง gps ให้เอาอันล่าสุดที่ user ใช้มาให้ จาก cart ที่ใช้ delivery
    - เปลี่ยน address -> Mana ส่ง GPS ให้ mcontent ตอนเปิดหน้าเพื่อค้นหาร้านตามระยะ GPS
- ตะกร้า บนขวา หน้า mcontent (รอถามพี่บุ๊ง)
    - home ไม่มีตะกร้าแล้ว
    - add product แล้ว มีตะกร้าค้างที่ feed (เป็นตะกร้าของร้านอาหาร)
- Cart
    - note : ตอน add จะถามว่า มีตะกร้าของ service นี้ค้างอยู่หรือเปล่า
    - เปลี่ยน delivery (Dialog ?) -> ปรับดีไซน์ ใช้ option dialog
    - เปลี่ยน GPS
    - ใช้คูปอง (คิดว่าเอาไว้ก่อน)
    - กดเพิ่มสินค้า กลับไป mcontent ของ 3rd
    - ตะกร้าที่ยังไม่เสร็จจะมี feed หน้า home (รอถามคอนเฟริมอีกที)
    - hook
        - cart hook (change address, change delivery)
        - add product hook (delivery อาจจะไม่ได้ใช้)
        - checkout hook
- Profile
    - Manage GPS
- BizCenter ???
    - Manage GPS / หรือให้ delivery จัดการเรื่องที่อยู่ร้านเอง ?
- Budget
    - เอาไว้ compensate
- X Escrow
    - release escrow (หลังจาก biker กดส่งของเสร็จ)

--------------------------------
# 2020-05-12

- สมัคร biker ??
    - สมัคร mana -> delivery กรอกเบอร์โทร biker -> ส่ง reminder ให้ biker consent การเป็น employee (โครงสร้าง mana ยังไม่เป็น member ส่ง reminder ไม่ได้?)
        - เคยมีไอเดียเรื่อง refcode ของ user/ร้าน เอาไปใช้คู่กับ เบอร์/เมล์ เพื่อระบุคนที่จะทำธุรกรรมด้วย
    - hook biker consent registered employee
- ร้านอาหารสมัครใช้ delivery ??
    - สมัคร mana -> delivery กรอกเบอร์โทร ร้าน -> ส่ง reminder ให้ ร้าน consent การใช้ delivery
        - เคยมีไอเดียเรื่อง refcode ของ user/ร้าน เอาไปใช้คู่กับ เบอร์/เมล์ เพื่อระบุคนที่จะทำธุรกรรมด้วย
- ขอข้อมูลร้าน(พนักงาน , GPS , mobile etc.) ??hook แจ้งการอัพเดทข้อมูลร้าน จะมีมั้ย => ดึงจาก mana สดๆๆๆ
- Consent Contract (เป็นเงื่อนไข Escrow????) -> start wf + condition -> release/refund/partial(txid)
    - mana control การจัดการ contract 

# menu
- 3rd เตรียม menu แล้ว app restaurant กด confirm ส่งไปให้ mana insert/update/delete
    - อนาคตอาจจะมี clone product ใน mana ผ่านการ consent เลย คือ delivery สร้าง product ใน mana แล้วสร้าง qr ให้เจ้าของร้าน apply product ผ่าน mana consent
- service มี tier พิเศษ
    - ตอน user add product แล้ว service ได้รับ cart hook จะได้ตะกร้าของ user นั้นในแต่ละร้านใน service ทั้งหมด
    - ตอน service response hook คิดต่อว่าจะเคลียร์ตกร้าร้านอื่นยังไง


Find solution
    Post	Cancel Order	หมายเหตุการขอยกเลิก		Mana ส่ง cancel request ไปที่ admin 3rd
    tag and category
        product
        merchant
    access 3rd party asset

-------------------------------
# 2020-05-13
## สรุปประเด็น
## Mana
- Reminder
    - สร้างเมื่อ checkout 
    - ใช้ Reminder พูดคุยระหว่าง user และ service 
    - อัพเดทข้อมูลในหน้านั้นใช้ change workflow state
- ตะกร้าที่ยังไม่เสร็จ
    - โชที่หน้า หน้า 3rd บนขวา เมื่ออยู่ในร้านนั้นๆแล้วมีของในตะกร้า
    - มี feed ที่หน้า home ไว้กลับไปตะกร้า (not remider)
- Pin ไว้ที่ shortcut ได้ 
- GPS MContent
    - Home Shops
        - mana จัดการแสดง gps ให้เอาอันล่าสุดที่ user ใช้มาให้ จาก cart ที่ใช้ delivery
    - เปลี่ยน address -> Mana ส่ง GPS ให้ mcontent ตอนเปิดหน้าเพื่อค้นหาร้านตามระยะ GPS
- เพิ่ม bike 
    - กรอกเบอโทรที่ 3rd แล้ว กดยอมรับที่ mana
- เพิ่ม ร้าน ใส่ contract
    - กรอกเบอโทรที่ 3rd แล้ว กดยอมรับที่ mana ถ้าเป็นเจ้าของหลายร้าน ต้องเลือก 1 ร้านก้อนกดยอมรับ
- BizCenter
    - มี location รอ UI
    - ตั้ง เวลาเปิดปิดร้าน  รอ UI
    - 3rd ขอข้อมูลร้าน(พนักงาน , GPS , mobile etc.)  => ดึงจาก mana สดๆๆๆ

- Profile setting
    - มี location รอ UI
- Cart
    - เปลี่ยน delivery ใช้ option dlg
      - ใช้คูปอง (เอาไว้ก่อน)
    - กลับไปเพิ่มสินค้าได้
    - เปลี่ยน location ได้
    - ตอนที่สร้างตะกร้าร้านใหม่ โดยที่ยังมีร้านอื่นอยู่ จะส่งไปบอกใน Hook ด้วย(มี tier พิเศษแจ้งว่ามีตระกร้าของservice อยู่) ให้ service จัดการ แล้ว return มาบอกให้ mana จัดการต่อ
        - design carthook รองรับการส่ง config และจัดการ return เพิ่ม replace new cart

## Delivery
- 3rd เตรียม menu (ข้อมูลที่จะเอาไปเป็น product ใน mana) แล้วสร้างเป็น qr

## Restaurant app
-  app restaurant สแกน qr menu จาก delivery ที่สร้างไว้ แล้วกด confirm ส่งไปให้ mana insert/update/delete
    - อนาคตอาจจะมี clone products ใน mana ผ่านการ consent เจ้าของร้านเลย คือ delivery สร้าง products ใน mana แล้วสร้าง qr ให้เจ้าของร้าน apply products ผ่าน mana consent

## Mana ประเด็นค้าง
- ประเภทสินค้า
    - mana ใช้ tags เพื่อระบุประเภทสินค้า และระบุอื่นๆ....
    - ร้านสามารถกำหนดประเภทสินค้าไว้หลายๆหมวด(3rd เก็บเอง) แล้วตอนเพิ่มเมนูจะระบุประเภทสินค้าไว้อย่างนึง 
        - 3rd จัดการทุกอย่าง
        - XXXX ตอนที่ส่งไปสร้าง product ที่ mana ประเภทสินค้านี้จะกลายเป็น tags ของ product (ทำให้ตอนนี้ tags ของ product จะมีแค่อันเดียว)
- รูป
    - จัดการ upload เองจากใน delivery 
    - ใส่ whitelist ตอน register mcontent
    - mana product มีหลายรูป
- มาตรฐานเลขใน barcode 



# 2020-05-14

- location 
    - เมื่อเปลี่ยนแล้วจะมีที่เก็บไว้ สามารถ ดึงกลับมาดูได้
- ยกเลิกทีละรายได้การ(ขอทำทีหลัง) คืนเงินเป็นรายการ หรือ ถาม user ยกเลิกทั้งหมด
- user ยกเลิก 
    - เลือกเหตุผลแล้ว submit ไปที่ 3rd



## แบ่งงาน design
- 3rd api
    - employee  
    - contract  
    - mcontent  
        - biz page (กดเพิ่มสินค้าหน้าตะกร้า)
        - gps page
    - cart + product 
    - reminder (เพิ่ม workflow stage)
    - hook
        - cart hook (ถาม replace ตะกร้า)
- mana api
    - profile gps
    - Biz info + gps + เวลาเปิดปิดร้าน
    
# 2020-05-15

## เปิดปิดร้าน
![](Del_Wireframe-User.png)

- m3 mana รู้ว่าเป็นร้านไหน จะบอกสถานะมั้ย ตรงไหน ?
- m4, m7, m8 = หน้า mana = มีสถานะเปิดปิดร้าน
    - แสดงมั้ย
    - กดปุ่มจะต้องบอกได้ว่าร้านปิด
- m2 มีสถานะแต่ละร้านว่าปิดมั้ย ? => แล้วแต่ 3rd

## contract
- consent แล้ว hook บอก 3rd เสมอ

## cart & product
- product ใช้ mcontent => default/group ระบุพร้อมกับ tags ถ้า product ไหนมี tags ตรงจะใช้ mcontent นั้น
```
mcontents
    name - food
    tags - [food]

    name - drink
    tags - [food]

products
    name - curry
    tags - [food curry ]
    
    name - latte
    tags - [drink ]
```
- mana product id
    - 3rd run เอง
    - call mana run ให้
- ตัวเลือกของสินค้า => register แยกกับ product ระบุพร้อมกับ tags ถ้า product ไหนมี tags ตรง จะใช้ตัวเลือกนั้นได้
    - preference => สี ขนาด ความหวาน
        - choice
        - มีผลกับราคา % fixed
    - optional => เพิ่มช็อต เพิ่มวิปครีม
        - choice
        - มีผลกับราคา % fixed

ชานมเย็น
    tag - #เครื่องดื่ม #วิธี #ความหวาน

Tags
    tag - #ความหวาน
    name - ไม่หวาน
    price - 0

    tag - #ความหวาน
    name - หวานปกติ
    price - 0

    tag - #ความหวาน
    name - หวานมาก
    price - 0

    tag - #วิธี
    name - ร้อน
    price - 5

    tag - #วิธี
    name - เย็น
    price - 10
    
    tag - #วิธี
    name - ปั่น
    price - 15



products
    name : ชานม
    tags : drink ice frappe tea
    
    name : พร้าวปั่น
    tags : drink frappe coconut

options
    name - รุ่น
    tags -  tea
    choices + price
        normal + 0
        turbo + 5
        ยกล้อ + 10
        
    name - ปั่นละเอียด
    tags -  frappe
    choices + price
        หยาบ + 0
        ละเอียด + 0
        เละ + 0

preferences
    
    name - ความหวาน
    tags -  tea
    choices + price
        น้อย + 0
        กลาง + 0
        หวาน + 5
        
    name - ความหวาน
    tags -  coconut
    choices + price
        น้อย + 0
        กลาง + 0
        หวาน + 5
        บาดลิ้น +10


        submit options+preferences
        product model
        upload image

# 2020-05-16, 2020-05-17 product model
[CartProduct.cs](CartProduct.cs)

# 2020-05-18 cart model
[Cart.cs](Cart.cs)

# 2020-05-19 flow detail

## flow list
- create service
    - RegisterManaAccount()
        - dev เข้า mana app เพื่อสร้าง mana account แบบปกติ
    - RequestConsentRegisterDevAccount(); // for Delivery Service
    - ConsentServiceDevAccount(IsAgree)
    - CreateDevAccount(BizAccount)
    - CompleteConsentDeliveryFeed(feedId)
- config service
    - RegisterMcontent() // ปรับ model และการทำงานบางส่วน
    - RegisterProductHook() // เดิม
    - RegisterCartHook() // เดิม
    - RegisterCheckoutHook() // เดิม
    - RegisterOrderHook() // เดิม
    - RegisterContractHook() // ใหม่
    //- RegisterSV2USConsentHook() // ใหม่ service - [user สร้าง grab]
    //- X RegisterSV2BAConsentHook() // ใหม่ service - ba 
    //- RegisterBA2USConsentHook() // ใหม่ ba - user [สร้าง biker / ผูกร้าน]
    //- X RegisterBA2BAConsentHook() // ใหม่ ba - ba 
- create delivery BA 
    - RequestConsentDelivery(refId,mobileId) 
        - service ส่ง consent ให้ user ที่จะทำข้อตกลงพิเศษ  กำหนดส่วนแบ่ง และชื่อร้านใน contract
    - ConsentDelivery(IsAgree) 
        - user ยืนยันข้อตกลงผ่านมานะ
    - ConsentDeliveryHook(Contract) 
        - hook api ของ service
    - CreateDeliveryBA(BizAccount) 
        - มานะสร้าง delivery BA ให้ user ตามชื่อที่ service กำหนดใน contract
    - CompleteConsentDeliveryFeed(feedId) 
        - อัพเดท feed ว่าระบบสร้าง delivery BA ให้แล้ว
- register biker
    - RegisterManaAccount()
        - biker สร้าง mana account
    - RequestConsentRegisterEmployee(phoneNumber, refcode, title, BA, description)
        - delivery ส่ง consent ให้ user (เบอร์โทรศัพท์) ที่ต้องการเป็นพนักงาน(biker title)
    - ConsentRegisterEmployee(IsAgree)
        - user ตอบ consent
    - ConsentRegisterEmployeeHook(Contract, IsAgree) 
        - hook api ของ service
    - RegisterEmployee(UserId, BA, Title)
        - มานะลงทะเบียนพนักงานให้ delivery
    - CompleteRegisterEmployee(feedId) 
        - อัพเดท feed ว่าระบบลงทะเบียนพนักงานให้ biker แล้ว

        
- restaurant join delivery
    - CreateBa({name,photo});
        - submit form - แก้ให้ทำงานกับ workflow unit แล้วรอตอบกลับ
        - เจ้าของร้านอาหาร สร้างร้านใน mana
    - LoginWithMana();
        - เจ้าของ delivery login ด้วย mana เพื่อเข้าใช้ admin app - username/password ?
    - RequestConsentRegisterRestaurant(string tel, string code); - api ใหม่ที่ 3rd
        - เจ้าของ delivery/admin ส่งคำสั่งให้ร้านอาหารเข้าร่วม ไปที่เจ้าของร้านอาหาร ผ่าน admin app
        - admin app ส่งคำสั่งไป 3rd api
        - 3rd api ส่ง noti ไปเจ้าของร้านอาหาร
    - ConsentRegisterRestaurant(IsAgree)
    - ConsentRegisterRestaurantHook(Contract, IsAgree)
    - ผูกร้านอาหารกับ delivery
    - CompleteRegisterEmployee(feedId)
---
## Topic discussion
- Generalize service
    - Consent
        - Service (Contract)
        - Delivery (Contract)
        - Biker (Employee)
        - BA to BA (Contract)
    - Contract type (action after consented)
        - UpdateContract()
        - Service
            - CreateDeliveryService()
        - Delivery
            - CreateDeliveryBA()
            - Hook to 3rd
        - Employee
            - RegisterEmployee()
            - Hook to 3rd
        - BA2BA 
            - Hook to 3rd