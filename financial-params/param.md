- ของเดิม
    - request
        - countryCode
        - walletId
        - initialBalance

- สร้าง wallet
    - request
        - countryCode
        - ownerId > baId, paId, daId
        - ownerType > ba, pa, da
        - currency
        > ❌ ตองแยกประเภท currency มั้ย ? เช่น fiat, crypto
        - +initialBalance
    - response
        - walletId
    
- ❌ migrate wallet
    - request
        - walletId
        - initialBalance

==============================

1) บอกว่าเป็น 
1.1. static(forever), dynamic(session)
1.2. one-time, multi-use
1.3. QR or RTP refer by channel of request
200 -> โอน
300 -> ถอน

- request
    - requestType > static, dynamic
    - usage > onetime (dynamic), multiple (static, dynamic) > ใช้กับ qr เทานั้น
    - channel > qr (static, dynamic), rtp (dynamic)
    - operationCode เช่น
        - 200 -> โอน
        - 300 -> ถอน
    - balance > <nullable | 0>
    - walletId

2) ได้ ref1, ref2 กลับมา
2.1. Biller ID? -> ✅ configuration?
2.2. txid? > ✅ สงมาตอน return

- response
    - ref1
    - ref2
    - txid ? static ไมมี, dynamic มี
    
3) เอาไป gen QR
3.1. (also RTP) -> เช็ค workflow ว่าต้องการจะบันทึกเก็บไว้รึปล่าว

- gen qr
    - ref1
    - ref2
    - balance
    - billerId > from configuration
    - ❌ walletId

คำถาม
- walletId มีโอกาสเป็นเหมือน true wallet มั้ย > ถ้ามีตอน gen qr ต้องส่ง walletId มั้ย

========================
static  multiple    qr  >   adhoc qr
dynamic onetime     qr  >   เติมเงิน
dynamic multiple    qr  >   บัตรกาชาด, แชร์บิล
dynamic onetime    rtp  >   เติมเงิน ppay ที่ผูกไว้