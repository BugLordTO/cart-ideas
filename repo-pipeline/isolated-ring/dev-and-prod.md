![](out/dev-and-prod/dev-and-prod.png)

[raw diagram](dev-and-prod.puml)

#mom #202209 01

#releaseengineer #dev&prod

# amlo/dopa dev & prod
1. [ข้อสรุป] service ของ Amlo ตัว Sandbox กับตัวจริง request/response บางอย่างไม่เหมือนกัน ใน dev เลยจะไม่ทำ sync กับ Amlo Sandbox จะทำแค่ส่วน chack ข้อมูล
2. [ขอทีมเทสช่วย] ให้ทีมเทสช่วยกำหนด fixed เคสตอนเทส check dopa/amlo ใน dev เช่น
    - ส่งรหัสประชาชนแบบไหนมา จะได้ตอบกลับแบบไหน
    - ถ้าส่งเลขบัตรจริงได้ อาจจะไม่ต้องคิดข้อแรก เป็นต้น
3. [pilot] pipeline VM > เอาขึ้น kube ได้เลย
    - มีเรื่องเขียนไฟล์ ลองเล่นที่ kube
    - whitelist amlo/dopa สำหรับ kube ขอเผื่อ prodution ไว้แล้ว วิ่งออกจากได้เลย

# [ประเด็นคิดต่อ] p2d dev & prod
- 0.1 MT อาจจะเปลี่ยนเป็น reliable hook ในอนาคต
- 0.2 MT config แบบไหน ตาม requirement
    - ถ้าสร้าง MT topic แต่ละ ring ไว้ แล้ว AddConsume topic ได้ตาม config แต่ละ ring น่าจะแก้ปัญหาให้ไม่ชนกันได้
1. ถ้าเทสเรื่องการเงินเคสต่างได้
2. effort operation อื่นในการเงิน
3. เคส lookup เอาจาก db
4. เคสอื่นนอกจาก lookup
- **REF: [dev & prod - p2d](dev-and-prod-p2d.md)**

# เพิ่มเติม
- process ดึงข้อมูล amlo เช่น 
    - image ที่ทำเรื่อง sync พอจบแล้วก็ปิดตัวเอง
    - ใช้ schedule เหมือนที่ใช้ เปิด/ปิด kube
    - docker มี command รับจบแล้วปิดอยู่
    - [optional] monitoring เช็คสถานะ

=============================================

# จาก [ประเด็นคิดต่อ] p2d dev & prod #mom #202209 01

- 0.1 ✅ MT อาจจะเปลี่ยนเป็น reliable hook ในอนาคต
- 0.2 MT config แบบไหน ตาม requirement
    - ถ้าสร้าง MT topic แต่ละ ring ไว้ แล้ว AddConsume topic ได้ตาม config แต่ละ ring น่าจะแก้ปัญหาให้ไม่ชนกันได้
1. ถ้าเทสเรื่องการเงินเคสต่างได้
2. effort operation อื่นในการเงิน
3. ✅ เคส lookup เอาจาก db
4. เคสอื่นนอกจาก lookup
