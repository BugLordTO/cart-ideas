# NOTE: IT audit + sre for mana

## Incedent response / Posmortem

0. ของที่ต้อง setup
- role > (FM-04-01 Rev. 0)[https://docs.google.com/spreadsheets/d/1Dfr_KFN-QkKkkjuh7JMolxYYguBH4hiO/edit#gid=820286269]
    - policy
        - Board of Director (BOD)
            - Risk management committee
                - Risk management
            - Compliance
            - Chief Executive Officer (CEO)
    - azure ad
    - mana employee
- ฯ

1. ยืนยันว่าเกิดขึ้นจริง > มี alert แล้วไปเช็ค log
- check log
- system status dashboard
- reproduce

2. จัดระดับความรุนแรง เช่น class A, B, C
- resolvable by system 
- resolvable by protocal
- minor bug > define scope ว่าแบบไหนไม่ร้ายแรง > แยกตาม module ?
- critical bug > define scope ว่าแบบไหน critical > แยกตาม module ? เกี่ยวกับเงิน ?
- unknowned issue > ของที่ไม่เข้าเคสด้านบน หรือยังหาสาเหตุไม่ได้

3. แก้ไขเบื้องต้น เช่น ปิดระบบ, รีสตาร์ท, กู้คืน, ระงับบัญชีชั่วคราว, รีเซ็ทรหัสผ่าน
* เราไม่แตะเรื่องเงินไม่ได้ อย่างมากปิดบัญชีดึงคืน mana 
- resolvable by system 
    > performance monitor
        - scale
        - restart
- resolvable by protocal
    > mana backoffice
        - คิดเรื่อง role ที่เข้าใช้ mana backoffice ได้
            - ตาม (FM-04-01 Rev. 0)[https://docs.google.com/spreadsheets/d/1Dfr_KFN-QkKkkjuh7JMolxYYguBH4hiO/edit#gid=820286269]
        - ปัญหาจากระบบ
        - ปัญหาการใช้งานทั่วไป
        - ช่องทางสอบถามปัญหาทางเทคนิกจาก it
        - user แจ้ง bug > ถ้าเป็น bug จริง มีช่องทางแจ้งไป minor bug / critical bug / unknowned issue
- minor bug
    > สร้าง board issue
    > แก้ข้อมูลให้ถูก
    > สร้าง board issue > fixed release ถัดไป > patching
- critical bug
    > shut down service ที่เกี่ยวข้อง
    > สร้าง board issue > hot fixed เดี๋ยวนั้นเลย
- unknowned issue
    > ทีม it คุยตัดสินใจว่าเข้าเคสไหนข้างบน (2 3 4)

4. รายงานเหตุการณ์ที่เกิดขึ้น
- คนที่ต้องแจ้ง
    - แจ้งเตือนผู้ที่อาจจะได้รับผลกระทบหรือหน่วยงานที่เกี่ยวข้องทันที เช่น ลูกค้า, ธนาคาร, ตำรวจ, ก.ล.ต.
    - แจ้งผู้ได้รับผลกระทบหลังแก้ไขแล้ว
- การรายงานแต่ละเคส
    - resolvable by system 
        > it operator
        > cto > เกี่ยวกับค่าใช้จ่าย หรือต้อง optimize, it operator รวบรวม อาจจะรายงานรายเดือน/รายปี
        > it operator แจ้งต่อให้ customer service กรณี maintain/ฉุกเฉิน ให้ตอบคำถามลูกค้าได้
    - resolvable by protocal
        > customer service, user
        > ข้อขัดข้องการใช้งานระบบ fraud / server down transaction ไม่จบ
    - minor bug
        > 
    - critical bug
        >
    - unknowned issue
        >

5. ประเมินผลการตอบสนองและการฟื้นคืนเพื่อป้องกันเหตุในอนาคต
- เอาเคสข้อ 4 มาลิสต์แล้วเลือกว่าจะ posmortem ข้อไหนบ้าง
- process
    - ใครบ้าง ?
    - ยังไงบ้าง ?
    - ที่ไหน ?