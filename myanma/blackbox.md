api sign mean
```
+ method
- param
> output
* extra action
```
# blackbox > method & params
+ get rate
    - amount
    - direction (src/dest)
    - src currency
    - dest currency
    > rate id
    > rate
    > src fee
    > dest fee
    > calculated amount
    > rate expiration
+ execute adhoc mex
    - adhoc cart
        - rate id
        - src manalink walletid > คนไทย < มี country code อยู่ในนี้
        - dest manalink walletid > คนพม่า < มี country code อยู่ในนี้
        - amount
        - currency > thb
    > execute result
        - txid
        - is success
        - message
    * send noti result to mm
+ config rate
    - src currency
    - dest currency
    - rate

# note
- มีร้าน mex เงินบาท เอาไว้รับเงินคนไทย
- มีร้าน mex เงินจ๊าด เอาไว้จ่ายเงินคนพม่า
- รหัสร้านอยู่ config ก่อน
- เติมเงิน mmk เข้าร้าน mtm (mmk) ยังไง
    - manual แก้ db
- mcontent mex + mtm จะเอาไว้ใน zip mana เลย
- upload slip มาแสดงบน mana ทำได้ 2 แบบ
    - upload เอง แล้วใส่ whitelists blob ที่ mcontent
    - ✅ upload ไปที่ mana file service

---------------------------------

# adhoc api (topup mm)
+ m3 > visit / submit
+ m4 > visit / submit
+ m5 > visit
+ th > visit / data / takeaction
+ log wallet
+ log ba

# endpoint
- ndepmmk-home > m2
- ndepmmk.mtm-home > mX
- ndepmmk.qr-home > m3
- ndepmmk.confirm-{dest-walletid}${amount-long}${currency} > m4
- ndepmmk.qr-{dest-walletid}${amount-long}${currency} > m5
- nahcmex-{dest-walletid}${amount-long}${currency} > endpoint for gen qr

# 3rd api
+ ❌ config rate

---------------------------------

# withdraw api
+ withdraw-mm (include: withdraw-select-bank) > m2, m2.1
    - visit / submit
+ withdraw-mm-amount-preset > m3
+ withdraw-mm-amount-specify > m4
    - visit / data / submit
+ withdraw-mm-edit > m5
    - visit / submit
+ withdraw-mm-confirm > m6, m7, m8.1
    - visit / takeaction
+ mex-fee-detail > m11
    - visit
+ withdraw-mm-completed > m8
    - visit
+ withdraw-mm-status > m10, m10.1, m10.2, m10.3
    - visit / takeaction > ❌ update WF state
        * create feed

# endpoint
- nmtmwdw-home > m2
- nmtmwdw.amount-{sessionid} > m4
- nmtmwdw.edit-{sessionid} > m5
- nmtmwdw.confirm-{sessionid} > m6, m7
- nmtmwdw.requested-{sessionid} > m8
- nmtmwdw.fee-home > m11
- nmtmwdw.status-{sessionid} > m10, m10.1, m10.2, m10.3

# 3rd api
+ send withdraw result
    - session id
    - accept/reject
        * noti update feed
        * refund
    - slip url
    - reason

# mtm api
+ mana hook withdraw

-------------------------------------------------

adhoc mex (scan qr mmk) (เติมเงิน mmk) (ย้ายเงินข้ามจากไทยไปพม่า)
    - gen qr from mana-mmk
        - ✅ mana qr multi use (goal > single use = session)
        - new endpoint use adhoc flow
          - nxxxyyy-{เติมไปที่ใคร}${จำนวนเงิน}
        - ❌ create session
    - mana-th scan qr 
    - display mex
        - get conversion rate from black box
            - rate
            - fee ทั้งต้นทาง ปลายทาง
    - mana-th submit
        - reduce amount(th)mana-th to ba-mtm (p2d interface)
        - ❌ ba-mtm transfer mmk to mana-th (p2d interface)
        - ba-mtm transfer mmk to mana-mmk immediately (p2d interface)
        - log tx conversion rate
        - ❌ end session
        - create mana-th wallet log
        - create mana-mmk wallet log
    - noti to mana-mmk > no feed

!!qr multiple use

withdraw mtm-mmk
    - create withdraw request
        - create feed
        - reduce amount(mmk) from mana-mmk (only mana db)
        - response & noti to user
        - hook to mtm
    - mtm backoffice response request (accept/reject) Mana 3rd API
        [accept]
        - noti result feed (display slip)

        [reject]
        - revert amount(mmk) to mana-mmk
        - noti result feed

-------------------------------

# SCENARIOS
- คนพม่ามาทำงานที่ไทย > ใช้มือถือเบอร์ไทย > mana-th
- ญาติที่พม่า > ใช้มือถือเบอร์พม่า > mana-mm
- คนพม่าจะโอนเงินกลับให้ญาติที่พม่า > ญาติที่พม่าเอา mana-mm สร้าง qr topup > คนพม่าที่ไทยเอา mana-th scan จ่ายเงินออก

# FLOW
- TopUp QR MMk
  - blackbox วางไว้ให้ถูกที่ แต่ยังไม่มีการทำงานอะไร
  - จะยังไม่มี LP
  - "qr endpoint ใหม่" เฉพาะเรื่องพม่า แต่ใช้ flow เดียวกับ adhoc
    - visit / data / submit
  - mana-mm สร้าง qr แล้วเอา mana-th scan
  - มีหน้า mex มาคั่น
  - มีร้าน ba-MMK เอาไว้โอนเงินให้ mana-mm
   (MTM)
  - มีร้าน ba-THB เอาไว้รับเงินจาก mana-th
  - มี log
    - mana-mm จะเป็น log topup
    - mana-th จะเป็น log adhoc
    - rate ปัจจุบัน (ของที่พี่บุ๊งพรีเซน)
- Back Office for MEX
  - ช่องทางสำหรับ config rate (เช่น web app, azure function ฯ)
- Mana For Myanmar
  - แยกคนจาก mobile
    - ที่ mobile เก็บ country code อยู่
  - แยกคนจาก server
  - ❓ idp token มี country code
- MTM Withdraw
  - มีร้าน ba-MMK (MTM) เอาไว้รับเงินจาก mana-mm (จ่าย adhoc)
    - หักเงินเลย
  - hook ไปบอก MTM
  - MTM จัดการโอนเงิน manual
  - มี api accept/reject เฉพาะเรื่อง MTM
  - MTM ส่ง accept > อัพเดท feed > ปิด feed
  - MTM ส่ง reject > คืนเงิน > อัพเดท feed > ปิด feed

# ISSUES
- คนพม่าใช้ mana-th จะ kyc เพื่อรับเงินไทยยังไง
  - ❓ มีนายหน้าคนไทยทำให้
- kyc
  - version
  - backoffice
- ไปหน้ายังไง
  - cmd condition IsCountry("TH")

--------------------------------------------------

#mom mex server+mobile

# flow ที่กระทบ > ตีว่าเป็น flow ใหม่
- login
- เติมเงิน
- ถอนเงิน
- ❌ ผูกบัญชี
- ที่อยู่ > zipcode fixed for TH
- kyc
- ba/da (currency) > ปิดสร้าง ba > manual สร้าง ba เปลี่ยน owner & เป็นสกุล MMK
- auto add delivery shortcut > ไม่เป็นไรอยู่ พท อยู่แล้ว

# TOPPIC
- รองรับคนพม่า
    - มี zip 2 v. (th/mm)
    - เบอร์พม่า > login > supported เช็คก่อน
- kyc version on mobile
    - มี version อยู่ > 800
    ❌- on mobile ลบ KYC ในเครื่อง (kyc version) > server จัดการให้ได้
    ❓ - [ติดไว้ก่อน] kyc ที่ IDP เก็บ ต้องไม่เก็บ PID ใน DB
  - Store > th+us > th+us+mm
- คนพม่าใช้ mana-th จะ kyc เพื่อรับเงินไทยยังไง > วัด

# ถ้าเอาขึ้นพร้อมกันได้ก็ทำ
- Vue ใช้ tag <a href> แทนการ call endpoint แบบเดิม
- Js deserializer error (new line)

# คำถาม
- ba ที่ต้องสร้างมีไรบ้าง > mtm