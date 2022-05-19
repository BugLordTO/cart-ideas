# Eslip (ตัวเดิม)
- ## [create / update / delete] eslip stub (ตัวเดิม)
- ## [create / update / delete] eslip distribution (qr) (ตัวเดิม)
- ## [receive / use] eslip (ตัวเดิม)
    - ยังใช้ตัวเดิม => เป็นแค่ setup ข้อมูล ไม่ได้ใช้ wfu
- ## [receive / use] eslip CouponCart (คูปองลดราคาตัวเดิม)
    - ใช้ผ่านหน้าจ่ายเงินร้านค้า adhoc => ดูต่อ wfu adhoc

# Eslip New concept

later ...
<details>
<summary>Image</summary>

```plantuml
@startuml new concept
Bob -> Alice : Hello!
@enduml
```
</details>


# Privilege
- ## [create / update / delete] privilege
    - เป็นแค่ setup ข้อมูล ยังไม่ได้ใช้ wfu
- ## [แลก point เป็นคูปอง]
<details>
<summary>Image</summary>

```plantuml
@startuml new concept

actor user
participant client
participant manaapi
participant workflowunit
participant "3rd party" as 3rd

user -> client : แลก point เป็นคูปอง
client -> manaapi : visit privilege endpoint
manaapi --> client : [CR] wf
client --> user :  Display privilege page
user -> client : confirm
client -> manaapi : take action
manaapi -> workflowunit : create transaction : cart
activate workflowunit
workflowunit -> workflowunit : create actor
workflowunit --> manaapi : cart
manaapi -> 3rd : hook(s)
manaapi --> client : [CR] N2M cart
client --> user : display cart info

user -> client : checkout
client -> manaapi : take action
manaapi -> manaapi : คำนวน point ที่ใช้จากของใน cart
manaapi -> workflowunit : Setup : หัก point จาก user เข้าร้าน
manaapi -> workflowunit : Setup : grant coupon จากร้าน ไป user
manaapi -> workflowunit : execute transaction
workflowunit -> workflowunit :หัก point จาก user เข้าร้าน
workflowunit -> workflowunit : grant coupon จากร้าน ไป user
workflowunit -> workflowunit : complete transaction
workflowunit -> workflowunit : clear actor
workflowunit --> manaapi : [Boardcast][Type:Payment] notify complete transaction 
deactivate workflowunit
manaapi -> manaapi : Complete flow
manaapi -> 3rd : hook(s)
manaapi --> client : send noti result
client --> user : display noti message

@enduml
```
</details>

- scenarios
    - กด link ของที่จะซื้อ
    - เพิ่มเข้าตะกร้า
        - สำเร็จ
        - สินค้าหมด
        - สมัครสมาชิกก่อน
            - กดสมัคร
            - ไม่สมัคร
        - ยังไม่ถึงเวลา
        - หมดอายุ
    - เช็คเอ้า
        - สำเร็จ
        - สินค้าหมด
        - สมัครสมาชิกก่อน
            - กดสมัคร
            - ไม่สมัคร
        - ยังไม่ถึงเวลา
        - หมดอายุ
        - พ้อยไม่พอ
    - ยกเลิกตะกร้า
- common services
    - CRUD
    - Validate
    - AddToCart
    - CancelCart
    - Purchase

# Cart adhoc
- ## จ่ายเงินใช้ [คูปองลดราคา(ตัวเดิม)]
<details>
<summary>Image</summary>

```plantuml
@startuml new concept

actor user
participant client
participant manaapi
participant workflowunit

user -> client : จ่ายเงินใช้คูปองลดราคาตัวเดิม
client -> manaapi : visit cart adhoc endpoint
manaapi --> client : [CR] wf
client --> user :  Display cart page
user -> client : select coupon
client -> client : apply coupon
user -> client : checkout
client -> manaapi : take action
manaapi -> manaapi : คำนวนเงินทุกอย่าง
manaapi -> workflowunit : create transaction : cart
activate workflowunit
workflowunit -> workflowunit : create actor
workflowunit --> manaapi : cart
manaapi -> workflowunit : Setup: ใช้ coupon ของ user
manaapi -> workflowunit : Setup: หักเงินจาก user เข้าร้าน
manaapi -> workflowunit : execute transaction
workflowunit -> workflowunit : ใช้ coupon ของ user
workflowunit -> workflowunit :หักเงินจาก user เข้าร้าน
workflowunit -> workflowunit : complete transaction
workflowunit -> workflowunit : clear actor
workflowunit --> manaapi : [Boardcast][Type:Payment] notify complete transaction 
deactivate workflowunit
manaapi -> manaapi : Complete flow
manaapi -> "3rd party" : hook(s)
manaapi --> client : send noti result
client --> user : display noti message

@enduml
```
</details>

# Cart & prdoducts
- ## จ่ายเงินแบบเต็มรูปแบบ
<details>
<summary>Image</summary>

```plantuml
@startuml new concept

actor user
participant client
participant manaapi
participant workflowunit
participant "3rd party" as 3rd

user -> client : สแกน QR สินค้า
client -> manaapi : visit product endpoint
manaapi --> client : [CR] wf
client --> user :  Display product page
user -> client : input amount
user -> client : add to cart
client -> manaapi : take action
manaapi -> workflowunit : create transaction : cart
activate workflowunit
workflowunit -> workflowunit : create actor
workflowunit --> manaapi : cart
manaapi -> 3rd : hook(s) [product hook]
manaapi --> client : [CR] N2M cart
client --> user : display cart info
user -> client : select point [optional]
user -> client : select coupon [optional]

user -> client : checkout
client -> manaapi : take action
manaapi -> manaapi : คำนวนเงินทุกอย่าง & point & discount
manaapi -> workflowunit : Setup: หักเงินจาก user เข้าร้าน
manaapi -> workflowunit : Setup: หัก point จาก user เข้าร้าน [optional]
manaapi -> workflowunit : Setup: ใช้ coupon ของ user [optional]
manaapi -> 3rd : hook(s) [order hook]
manaapi --> client :  bill
user -> client : pay
client -> manaapi : take action
manaapi -> workflowunit : execute transaction
workflowunit -> workflowunit : หักเงินจาก user เข้าร้าน
workflowunit -> workflowunit :หัก point จาก user เข้าร้าน [optional]
workflowunit -> workflowunit : ใช้ coupon ของ user [optional]
workflowunit -> workflowunit : complete transaction
workflowunit -> workflowunit : clear actor
workflowunit --> manaapi : [Boardcast][Type:Payment] notify complete transaction 
deactivate workflowunit
manaapi -> manaapi : Complete flow
manaapi -> 3rd : hook(s) [payment]
manaapi --> client : send noti result
client --> user : display noti message

@enduml
```
</details>

# Cart & prdoduct & reminder (coffee shop)
- ## จ่ายเงินแบบเต็มรูปแบบ และมี session ส่งข้อความหลังจากจ่ายเงิน
<details>
<summary>Image</summary>

```plantuml
@startuml new concept

actor user
participant client
participant manaapi
participant workflowunit
participant "3rd party" as 3rd

user -> client : สแกน QR สินค้า
client -> manaapi : visit product endpoint
manaapi --> client : [CR] wf
client --> user :  Display product page
user -> client : input amount
user -> client : add to cart
client -> manaapi : take action
manaapi -> workflowunit : create transaction : cart
activate workflowunit
workflowunit -> workflowunit : create actor
workflowunit --> manaapi : cart
manaapi -> 3rd : hook(s) [product hook]
manaapi --> client : [CR] N2M cart
client --> user : display cart info
user -> client : select point [optional]
user -> client : select coupon [optional]

user -> client : checkout
client -> manaapi : take action
manaapi -> manaapi : คำนวนเงินทุกอย่าง & point & discount
manaapi -> workflowunit : Setup: หักเงินจาก user เข้าร้าน
manaapi -> workflowunit : Setup: หัก point จาก user เข้าร้าน [optional]
manaapi -> workflowunit : Setup: ใช้ coupon ของ user [optional]
manaapi -> 3rd : hook(s) [order hook]
manaapi --> client :  bill

user -> client : pay
client -> manaapi : take action
manaapi -> workflowunit : execute transaction
workflowunit -> workflowunit : หักเงินจาก user เข้าร้าน
workflowunit -> workflowunit :หัก point จาก user เข้าร้าน [optional]
workflowunit -> workflowunit : ใช้ coupon ของ user [optional]
workflowunit -> workflowunit : complete transaction
workflowunit -> workflowunit : clear actor
workflowunit --> manaapi : [Boardcast][Type:Payment] notify complete transaction 
deactivate workflowunit
manaapi -> manaapi : Complete flow
manaapi -> 3rd : hook(s) [payment]
activate manaapi
manaapi -> manaapi : create session
manaapi --> client : send noti result
client --> user : display noti message
manaapi <-- 3rd : send message to session (รับกาแฟ)
manaapi --> client : send noti result
deactivate manaapi
client --> user : display noti message

@enduml
```
</details>

# Cart & prdoduct & reminder & delivery (escrow)
- ## จ่ายเงินแบบเต็มรูปแบบ 
    - มี session สถานะการขนส่ง หลังจากจ่ายเงิน
    - ลูกค้าจ่ายเงินเข้า esscrow ก่อน
    - ร้านได้รับเงินหลังจากลูกค้ารับสินค้า
<details>
<summary>สั่งซื้อ</summary>

```plantuml
@startuml new concept

actor user
participant client
participant manaapi
participant workflowunit
participant "3rd party" as 3rd

user -> client : สแกน QR สินค้า
client -> manaapi : visit product endpoint
manaapi --> client : [CR] wf
client --> user :  Display product page
user -> client : input amount
user -> client : add to cart
client -> manaapi : take action
manaapi -> workflowunit : create transaction : cart
activate workflowunit
workflowunit -> workflowunit : create actor
workflowunit --> manaapi : cart
manaapi -> 3rd : hook(s) [product hook]
manaapi --> client : [CR] N2M cart
client --> user : display cart info
user -> client : select coupon [optional]

user -> client : checkout
client -> manaapi : take action
manaapi -> manaapi : คำนวนเงินทุกอย่าง & point & discount
manaapi -> workflowunit : Setup: หักเงินจาก user ไป escrow
manaapi -> workflowunit : Setup: หัก point จาก user ไป escrow [optional]
manaapi -> workflowunit : Setup: lock coupon ของ user เตรียมใช้ [optional]
manaapi -> 3rd : hook(s) [order hook]
manaapi --> client :  bill

@enduml
```

</details>

---
<details>
<summary>จ่ายเงิน</summary>

```plantuml
@startuml new concept

actor user
participant client
participant manaapi
participant workflowunit
participant "3rd party" as 3rd

user -> client : pay
client -> manaapi : take action
manaapi -> workflowunit : execute transaction
workflowunit -> workflowunit : หักเงินจาก user ไป escrow
workflowunit -> workflowunit : หัก point จาก user ไป escrow [optional]
workflowunit -> workflowunit : lock coupon ของ user เตรียมใช้ [optional]
workflowunit --> manaapi : [Boardcast][Type:Payment escrow] notify execute transaction 
manaapi -> manaapi : create session
activate manaapi
manaapi -> 3rd : hook(s) [payment escrow]
manaapi --> client : send noti result
client --> user : display noti message
manaapi <-- 3rd : send message to session (update delivery status)
manaapi --> client : send noti result
client --> user : display noti message

@enduml
```

</details>

---
<details>
<summary>รับของ</summary>

```plantuml
@startuml new concept

user -> client : receive product
client -> manaapi : take action
manaapi -> workflowunit : Setup: หักเงินจาก escrow ไป ร้าน
manaapi -> workflowunit : Setup: หัก point จาก escrow ไป ร้าน [optional]
manaapi -> workflowunit : Setup: ใช้ coupon ของ user [optional]
manaapi -> workflowunit : execute transaction
workflowunit -> workflowunit : หักเงินจาก escrow ไป ร้าน
workflowunit -> workflowunit : หัก point จาก escrow ไป ร้าน [optional]
workflowunit -> workflowunit : ใช้ coupon ของ user [optional]
workflowunit -> workflowunit : complete transaction
workflowunit -> workflowunit : clear actor
workflowunit --> manaapi : [Boardcast][Type:Payment escrow complete] notify complete transaction 
deactivate workflowunit
manaapi -> manaapi : end session
manaapi -> manaapi : Complete flow
manaapi -> 3rd : hook(s) [payment escrow complete]
deactivate manaapi
manaapi --> client : send noti result
client --> user : display noti message

@enduml
```
</details>

# Membership New concept
- ## สมัครสมาชิกผ่าน cart
<details>
<summary>Image</summary>

```plantuml
@startuml new concept

actor user
participant client
participant manaapi
participant workflowunit
participant "3rd party" as 3rd

user -> client : สแกน QR สมัครสมาชิก
client -> manaapi : visit สมัครสมาชิก endpoint
manaapi --> client : [CR] wf
client --> user :  Display สมัครสมาชิก page
user -> client : สมัครสมาชิก
client -> manaapi : take action
manaapi -> workflowunit : create transaction : cart
workflowunit -> workflowunit : create actor
workflowunit --> manaapi : cart
manaapi -> 3rd : hook(s) [product hook]
manaapi --> client : [CR] N2M cart
client --> user : display cart info

user -> client : checkout
client -> manaapi : take action
manaapi -> workflowunit : Setup: user regiser member
manaapi -> workflowunit : execute transaction
workflowunit -> workflowunit : user regiser member
workflowunit -> workflowunit : complete transaction
workflowunit -> workflowunit : clear actor
workflowunit --> manaapi : [Boardcast][Type:Payment] notify complete transaction 
manaapi -> manaapi : Complete flow
manaapi -> 3rd : hook(s) [payment]
manaapi --> client : send noti result
client --> user : display noti message

@enduml
```
</details>

