migrate action plan
 [1]- เช็ค/ปรับ parameter flow ที่เชื่อมไปแล้วในปัจจุบัน (พี่อ้นอยากปรับอะไรเพิ่มอีกมั้ย)
   - เติม qr express
   - เติม qr bank account
   - เติม ppay rtp
   - ถอน
 [1]- ปรับการดึง balance จากเดิมดึงจากมานะ ไปดึงจากฝั่งพี่อ้น
 [1]- ปรับโค้ดตอนสร้าง user/ba ไปสร้าง wallet ที่ฝั่งพี่อ้น
 [2]- เพิ่ม ICommonWalletService flow ที่เกี่ยวข้อง
    - ปรับโค้ดตอนหักเงิน wallet (cart)
    - ปรับโค้ดตอนแจกจ่ายเงินให้คนอื่น (delivery)
    - ถอนเงินร้าน

 [3]- reset ข้อมูลฝั่งพี่อ้น
 [4]- migrate ข้อมูลเงิน user/ba ฝั่งมานะทั้งหมดไปที่พี่อ้น create wallet interface 
    - เคลียร์ข้อมูลเงิน user/ba ฝั่งมานะให้เป็น 0 --> ไม่ต้องปรับ
    - เก็บ walletid ที่ได้จากการ migrate ลงที่ฝั่งมานะ
    - migrate tx log > last option แค่ backup ไม่ได้ migrate tx log

 note เติม/ถอน ฝั่งพี่อ้นต้องอัพเดทด้วย wallet ใหม่

 --------------------------------------------------


## migrate financial action plan
 - reset ข้อมูลฝั่งพี่อ้น
 - migrate ข้อมูลเงิน user/ba ปัจจุบันที่ใช้งานไแล้ว
    - เก็บ walletid ที่ได้จากการ migrate ที่ฝั่งมานะ
    - migrate tx log > last option แค่ backup ไม่ได้ migrate tx log
      - ถ้า migrate ไปเลยอาจจะมีประเด็นในการสรุปข้อมูลย้อนหลัง??
- ปรับการดึง balance
- ปรับโค้ดตอนสร้าง user/ba
    - [step1] ปรับ ICommonWalletService flow ที่เกี่ยวข้อง
- เติม/ถอน ฝั่งพี่อ้นต้องอัพเดทด้วย wallet ใหม่


- เติม qr express
   ExecuteTopupByQR(string walletId, MonetaryValue amount);
- เติม qr account
   ExecuteTopupBankAccountByQR(string walletId, string accNumber, string bankCode, MonetaryValue amount);// ref1, ref2 , billerid(fix ไว้ที่ qr api)
- เติม rtp
   ExecuteTopupPPayByRTP(string walletId, string accNumber, string ppayType, MonetaryValue amount);// ref1, ref2 , billerid(fix ไว้ที่ qr api)