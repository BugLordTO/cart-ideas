# flow ที่กระทบ
- login
  - create account/wallet ข้างหลัง fixed TH
- เติมเงิน
- ถอนเงิน
- ❌ ผูกบัญชี
- ที่อยู่ > zipcode fixed for TH
- kyc
- ba/da (currency)
  1 ✅ ปิด flow สร้าง ba/da ของ MM > สร้าง ba MTM manual เปลี่ยนเป็นสกุล MMK
    - มีคนสร้าง ba สร้างจาก mana thai ก็ได้
    - เปลี่ยน owner เป็นคนพม่าที่ operate
    - เปลี่ยน currency ของ wallet ba ใน DB ให้เป็น MMK
  2 ปิด flow สร้าง ba/da ของ MM > สร้าง ba MTM ตาม flow ปกติ
    - เพิ่ม parameter ตอนสร้าง ba wallet ให้รับ currency
- ✅ auto add delivery shortcut > ไม่เป็นไรอยู่ พท อยู่แล้ว

*** ส่วนของพม่า mex mtm ตีว่าเป็น flow ใหม่
# คำถาม
- ba ที่ต้องสร้างมีไรบ้าง > mtm
-----------------------

# TOPPIC
- Mana For Myanmar
    - แยกคน ตามประเทศ
    - BA ตามประเทศ
- ไปหน้ายังไง
  - มี cmd เอาไว้แยก flow
  ✅- มี zip 2 v. (th/mm)
    - จัดการเรื่องภาษาได้
  - เปลี่ยนการทำงานบางตัว เช่น เอาออกจาก zip ให้วิ่งไปถาม server
✅- kyc version
  - มี version อยู่ > 800
  - ของที่เก็บใน DB ไม่มีประเด็น
  - ❓kyc ที่ IDP เก็บ ต้องไม่เก็บ PID ใน DB
03.รองรับคนพม่า
    1. เบอร์พม่า > login
    2. แยก flow ไทย/พม่า
    ❌3. ลบ KYC ในเครื่อง (kyc version)
        - มีการ sync ตอนเปิดแอพ ให้ server จัดการให้ได้
        - ถ้าต้องทำ kyc v. ใหม่ server จะตอบกลับมาว่ายังไม่ kyc
    3. Store > th+us > th+us+mm
1.  Vue ใช้ tag <a href> แทนการ call endpoint แบบเดิม
11.Js deserializer error (new line)
🔽 - apptext for mcontent

- TopUp QR MMk
- MTM Withdraw
- Back Office for MEX

- คนพม่าใช้ mana-th จะ kyc เพื่อรับเงินไทยยังไง


# Mobile
🔽 01. IDP Refresh Token & Get kem M
  1. พอแยก 3rd config แล้วทำให้ 3rd party ไม่สามารถ refresh token ได้แบบปรกติ (แก้แบบชั่วคราวแล้ว แต่ต้องรีบแก้ตัวนี้ต่อ) ส่วนต่างๆที่เกี่ยวข้อง IDP, APIM, Mana API for 3rd party (Mana API ไม่ต้องแก้เพราะมันมีช่องทาง refresh ของมันเอง)
02. Playground
  1. ทำ Playground สำหรับ Sandbox ให้ 3rd party ใช้
  2. เปิดหน้าที่ไม่ได้อยู่ใน zip wf จะเข้าไปยังไง
  3. ring อื่นที่ไม่ใช้ devmaster
  4. ใช้งานยาก
✅ 03.รองรับคนพม่า
  1. เบอร์พม่า
  2. แยก flow ไทย/พม่า
  3. ลบ KYC ในเครื่อง (kyc version)
  4. Store
04.จำเบอร์โทร
🔽 05. Mana mobile pipeline (Release engineer)
  1. เหลือแค่ตกลงกันว่าจะกำหนด environment ไว้ตรงไหนบ้าง
06. ระบบช้า
  1. Waiting dialog ไม่ขึ้นพร่ำเพรื่อ
  2. Progress bar (REQ Pilot✈️)
  3. เซิฟเวอร์ support & review
✅ 07. Vue ใช้ tag <a href> แทนการ call endpoint แบบเดิม
08. Dialog ติด delay 30 วิ
✅ 09. GPS header ไม่สอดคล้องกัน เพราะโดน server reject
10.Login with username
✅ 11.Js deserializer error (new line)
12.Security PIN
13.BA Header