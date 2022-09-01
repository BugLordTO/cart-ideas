# 1. การเงิน
- migration steps
    - STEP 1 delivery ใช้งานได้
        - ⌛️ การย้าย wallet
        - ⌛️ delivery ใช้เงินจริง แบบ escrow อย่างง่ายสุด
        - ⌛️ ถอนเงินจากร้าน
    - STEP 2 โฟลวที่มีอยู่แล้ว ใช้เงินจริง ให้ครบ
        - ❓ QR format > check คำถามใน sheet กับ standard
            - ✅ topup/deposit bank account
            - ✅ topup qr
            - ppay external
            - adhoc
- ultimate goal
    - STEP 3 ตะกร้า จริงจัง
    - STEP 4 delivery ใช้ contract มี escrow จริงจัง

# Server Cluster and rings plan
- 2. IdP, DOPA, AMLO, etc. => kube
    -  migration steps
        - pilot
            - ✅ upgrade to .net6 and use current libs
                - ใช้ project amlo
            - ⌛️ dockerImage/build/release pipeline
                - ใช้ project amlo
        - new build/release pipeline > ⌛️ มีแผนตามนี้ รอพีอ้นรีวิว sheet
            - idp
            - backoffice, dopa
        - move to new build/release pipeline > ⌛️ มีแผนตามนี้ รอพีอ้นรีวิว sheet
            - FileApi, SandboxApim, PartnerProxy
- 3. ความพร้อมของ rings ต่างๆ
    - migration steps
        - seprate release/prod server
        - MT แยก ring
        - fix release pipeline to pre envi
        - 🌟 optimize azure resource cost
            - ปิด resource ที่ไม่ค่อยได้ใช้ deploy ใหม่ตอนจะให้
            - จัดการ app config $1.2/day ~ ฿1,300/M * 7
    - ultimate goal
        - ทำ libs ใหม่ ของที่ mobile/server ใช้
        - standard code structure
        - standard route/request/response
        - standard xxx
        - move src

# 10. เรื่องค้างอื่นๆ ที่ควรปรับแก้
- ✅ hotfix kyc birthdate
- ✅ bug บางจุดระหว่าง test ตาม ring
- ✅ 🔥เติมเอกสาร compliance ด่วนก่อนวันที่ 21
- prevent abnormal case
    - ❌ เช็คเพิ่มจาก type ?
    - TxId not null
    - เช็ค flow อื่น/จุดอื่น ที่อาจจะเกิดประเด็นแบบนี้อีก
- จัดการเคส 20 1 2 บาท

----------------------------------------------

E Finance
    F  Migration #step1 delivery ใช้งานได้
      - S ⌛️ ย้าย wallet 
      - S ⌛️ Delivery Use ICommon interface
      - S ⌛️ ถอนเงินร้าน
    F  Migration #step2 โฟลวที่มีอยู่แล้ว ใช้เงินจริง ให้ครบ
      - S ✅ เติมเงิน QR เชื่อมเงินฝั่งพี่อ้น
      - S จ่ายเงิน qr 29 30  เชื่อมเงินฝั่งพี่อ้น
      - S ✅ เติมถอน bank account เชื่อมเงินฝั่งพี่อ้น
      - S adhoc เชื่อมเงินฝั่งพี่อ้น
    F #step3 Cart
      - S Cart Design support adhoc
    F #step4 escrow
      - S Cart Design support escrow
    F อืนๆ
      - prevent abnormal case
      - จัดการเคส 20 1 2 บาท
E Server Cluster and rings
    F kube > migration steps
        S ✅ pilot upgrade to .net6 and use current libs
        S ✅ pilot dockerImage/build/release pipeline
        S ⌛️ finalize concept
        S new build/release pipeline
        S move to new build/release pipeline
    F seprate release/prod server
    F ⌛️ ทำ libs ใหม่ ของที่ mobile/server ใช้
    F move src
    F optimize azure resource cost