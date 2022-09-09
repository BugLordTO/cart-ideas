# Release engineer server summary

## libs
- เจอจุดที่มี reference แต่ไม่ได้ใช้ ลองคุยทีม mobile แล้ว ในอนาคตอาจจะได้ใช้

## server repo/pipeline
- มีไอเดียเริ่มต้นว่าจะมี repo อะไรบ้าง มี pipeline อะไรบ้าง
- แตกประเด็นออกไปเรื่อง "isolate ring" จะมี ring หลักแล้วตอน dev แยกเฉพาะ api/db ที่เกียวข้องออกมา
- สถานะ: รอ libs ใหม่

# isolate ring
- apim
- azure config
    - HostUrl
    - PartnerProxy:Clusters
- สร้าง/apply kube manifest file เฉพาะ deployment ที่เกี่ยวข้อง
- สร้าง db/collection แยกตามที่จะใช้งาน
- ตอนปิดจบงาน
- แตกประเด็น
    - revise เกี่ยวกับ session > scope การเงินก่อน ที่เหลือยังไม่อยู่ใน plan
    - ประเด็นที่ต้อง remind ก่อน ลงมือ dev เช่น เรื่อง session นอกจากการเงิน ใช้เทคนิกอื่นแทน
    - reverse code ส่วน db/collection มีวิธีอื่นมั้ย
- สถานะ: รอ libs ใหม่

## kube migration
- service ต่างๆ เช่น dopa amlo ใน dev & prod
    - dopa amlo แยกตัวที่ใช้ใน dev & prod แต่มี contracts api เหมือนกัน
- MT อาจจะเปลี่ยนเป็น reliable hook ในอนาคต
- MT config แบบไหน ตาม requirement
    - MT topic แต่ละ ring
- การเงิน p2d mock

## seperate release/production


#mom #202209 05 #releaseengineer 
actions
- brief ให้ทีม
    - libs การ reference และมีอัพเดทใหม่
    - setup ring process
- การเงิน
    - revise เกี่ยวกับ session
    - การเงิน p2d mock
- (ว่างแล้วไปหาวิธี) ส่วน db/collection มีวิธีอื่นมั้ย
