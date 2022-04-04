# เติมเงิน
- PPay QR > mana สร้าง qr ppay เติมเงิน แล้วเอา ธ. ไหนมาจ่ายเข้าก็ได้
- PPay RTP > ยัง support มั้ย ?
- BankAccount >
# ถอนเงิน 
- PPay > กรอกเลข ppay ที่เคยผูกและเติมเงินแล้ว
- BankAccount > กรอกเลข BankAccount ที่เคยผูกและเติมเงินแล้ว
# Mana จ่าย Mana 
- Adhoc > จ่ายเงินเข้าร้าน จากไหนก็ได้
- Cart
    pay
    cancel order
    release escrow
# Mana จ่าย PPay ร้านข้างนอก
- PPay

- biz withdraw
- budget/allowance delivery
- สร้าง wallet user > ตอน login mana ครั้งแรก
- สร้าง wallet biz > ตอน kym เสร็จ
- get ยอดเงิน

------------------------------------------
# เรื่องเงิน จัดกลุ่ม และ เรียงตาม priority
- เชื่อจุดไหนเป็นตัวแรก ลองเชื่อม > ลองใน test environment ?
    - สร้าง wallet user > ตอน login mana ครั้งแรก
    - เติมเงิน PPay QR > mana สร้าง qr ppay เติมเงิน แล้วเอา ธ. ไหนมาจ่ายเข้าก็ได้
    - get ยอดเงิน
    - สร้าง wallet biz > ตอน kym เสร็จ
- จุดไหนจำเป็นต้องใช้ > operate delivery + backoffice เท่าที่จำเป็น
    - Adhoc > จ่ายเงินเข้าร้าน จากไหนก็ได้
    - Cart pay > escrow + release escrow
    - biz withdraw > ร้าน เข้า เจ้าของร้าน
    - ถอนเงิน PPay > กรอกเลข ppay ที่เคยผูกและเติมเงินแล้ว
- อันที่ทำหลังสุด
    - get tx (backoffice)
    - revert tx (backoffice)
    - retry tx (backoffice)
    - ❓ cart cancel order escrow
    - เติมเงิน BankAccount
    - ถอนเงิน BankAccount
    - Mana จ่าย PPay ร้านข้างนอก
    - เติมเงิน PPay RTP
    - โอน mana user - mana user
----------------------------------------------
- concept อื่นๆ
    - cancel tx ? > เช่น POS จ่ายเงินผิดต้องคืนเงินแล้วจ่ายใหม่ > cancel ได้ / manual คืนเงิน ?
    - budget / allowance
    - crypto
    - cash coupon
    - m cash
    - tx มี custom tag เอาไว้ filter/search ได้ (concept บัญชีรายรับรายจ่าย)
