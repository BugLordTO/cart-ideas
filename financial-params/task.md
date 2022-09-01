E 🔥(3) Finance > ตอนนี้อยู srcx > ทำ finalize design > ทำอยางไรทีไหน
    F  Migration #step1 delivery ใช้งานได้
      - S ⌛️ ยาย wallet 
      - S ⌛️ Delivery Use ICommon interface
      - S ⌛️ ถอนเงินร้าน
    F  Migration #step2 โฟลวที่มีอยู่แล้ว ใช้เงินจริง ให้ครบ
      - S ✅ เติมเงิน QR เชื่อมเงินฝั่งพี่อ้น
      - S จ่ายเงิน qr 29 30  เชื่อมเงินฝั่งพี่อ้น
      - S ✅ เติม  bank account เชื่อมเงินฝั่งพี่อ้น
      - S ถอน bank account เชื่อมเงินฝั่งพี่อ้น
      - S ถอน bank account เชื่อมเงินฝั่งพี่อ้น
      - S adhoc เชื่อมเงินฝั่งพี่อ้น
E Server Cluster and rings
    F kube > migration steps
        S ✅ pilot upgrade to .net6 and use current libs
        S ✅ pilot dockerImage/build/release pipeline
        S ⌛️ finalize concept > 🔥(2) uml conponent diagram
    F seprate release/prod server
    F ⌛️ ทำ libs ใหม่ ของที่ mobile/server ใช้ > finalize concept
    F 🔥(1) optimize azure resource cost
E 10
  F อืนๆ
    - S prevent abnormal case txid > topup qr แล้ว txid และจุดอื่นๆ
    - S prevent abnormal case จ่ายเงิน > แก้ตอนหักตังช้า
    - S ปลดล็อกถอน rtp
    - S kyc pdpa
    - S จัดการเคส เติมเงิน qr (20-1) 1 2 บาท
-------------------------------------------
🔥(1) ยังไม่มีอัพเดท
🔥(2) กำลังทำ วันนี้ถ้ามีเวลาจะอัพเดท
🔥(3) stanกby ไว้ก่อนถ้าพี่อ้นมีเวลาพร้อมเชื่อมกับ srcx (แผนเดิม) ก็พร้อมจัดได้เลย หรือรอทุกอย่างพร้อมที่ src ใหม่

❓ prevent abnormal case
❓ จดการเคส 20 1 2 บาท
- delivery

---------------------------------------

1. Delivery P2 (15 Aug)
  - support delivery
  - prevent abnormal case txid > จากเคสทีเจอ topup qr และ txid ในจุดอื่นๆ
  - prevent abnormal case จ่ายเงิน > แก้ตอนหักตังช้า
2. Delivery P2.5
  - ปลดล็อกถอน rtp
  - kyc pdpa
3. Use P'On infrastructure for financial flows
  - uml conponent diagram for ทำ libs ใหม่
  - Migration #step1
  - Migration #step2
  - จัดการเคส 20 1 2 บาท
4. Reduce loading time from 3rd-party server
5. Coupon feature goes live
    - cart support ?
    - new/old concept ?
    - management system ?
6. Multiple-wallets (fiats) feature goes live
7. IW and exchanging feature go live
8. M+ feature goes live
9. v1 of advanced BA goes live

---------------------------------------

# Issue
- Wallet id ฝั่งไหนเป็นคนกำหนด > ปัจจุบันส่ง PaId, BaId ไปสร้าง > ต้องใช้จากฝั่ง core การเงิน
- กระเป๋าประเภท crypto มานะเก็บเองหรือสร้างที่ฝั่งพี่อ้นด้วย
    - ✅ กระเป๋าเร็วอยู่ core การเงิน
    - ❓ กระเป๋า cryto จริงเก็บที่ไหน ?? mana client | server > ดูที่ flow
- currency ต้องส่งไปใน parameter ด้วย
- exchange rate / fee ฝั่งพี่อ้นจะเป็นคนคำนวณให้ใช่มั้ย > ลองดู design mex ก่อน

---------------------------------------

# financial
## operation อะไรบ้าง
- อาจจะดูตาม flow ที่มี
- เช่น design concept ตารางเดิมทีเคยทำ

| TxType | Start | StartResult | Execute | ExecuteResult |
|---|---|---|---|---|
| topup | xxx | yyy | zzz | aaa |
| deposit | xxx | yyy | zzz | aaa |
| biz deposit |  |  | zzz | aaa |

## ความเชื่อมโยงแต่ละระบบ
- เช่น sequence each tx type
## เริ่มลงรายละเอียดแต่ละส่วน
- เช่น overall components
## ออกแบบตามรายละเอียด
- interface + model
## prove
## ทำที่ไหน
## implement

# ความพร้อมของ rings
## ลองออกแบบ repo pipeline kube ใช้ uml

# อืนๆ
- prevent abnormal case
- จัดการเคส 20 1 2 บาท
- kyc
