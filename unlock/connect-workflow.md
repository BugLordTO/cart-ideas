@startuml
title รับคูปอง
hide footbox
actor User
participant Mana
participant API as "Mana API"
participant WFU
participant Tx as "Tx Only"

User -> Mana: Scan QR
Mana -> API: Call endpoint
API --> Mana: CR
Mana -> Mana: Show MContent

==คูปองไม่มีเงื่อนไข==
User -> Mana: กดรับคูปอง
Mana -> API: Take action
API -> API: Generate key
API -> Tx: [Validated] Start
Tx -> Tx: Grant key
Tx -> Tx: มอบ Asset
Tx --> API:
note right
    ตอนแรกคิดเป็น consumer
    แต่เข้าใจว่าถ้า Tx ไม่ต้องรอ
    ก็สามารถใช้แบบนี้ได้
endnote
API --> Mana: CR ผลการรับคูปอง + Complete WF
Tx --> API: **SUCCEEDED**

==คูปองมีค่าใช้จ่าย==
User -> Mana: กดรับคูปอง + ยืนยันจ่ายเงิน
Mana -> API: Take action
API -> API: Generate key
API -> Tx: [Validated] Start
Tx -> Tx: Grant key
Tx -> Tx: หักเงิน + มอบ Asset
Tx --> API:
API --> Mana: CR ผลการรับคูปอง + Complete WF
Tx --> API: **SUCCEEDED**

==คูปองที่ต้องเป็นสมาชิกก่อน + ยังไม่เป็นสมาชิก==
User -> Mana: กดรับคูปอง
Mana -> API: Take action (รับคูปอง)
API -> API: ตรวจสอบเงื่อนไข
API -> Tx: Start( LOCK-membership )
Tx --> API: **PENDING**, Required membership
API --> Mana: CR: Membership WF
Mana -> Mana: เปิดหน้าสมัครสมาชิก
group MassTransit
    Tx --> API: [Publish] ผลการรับคูปอง
    note right
        TxId: T01
        Status: Pending
        Reason: Required membership
    endnote
    API -> API: [Consumer]\nตรวจว่า unlock ได้หรือไม่
end
User -> Mana: ยอมรับการสมัคร
Mana -> API: Take action (สมัครสมาชิก)
API -> API: ตรวจสอบเงื่อนไข
API -> Tx: Start( refTxId: T01 )
Tx -> Tx: มอบ Asset (สมาชิก)
Tx --> API: **SUCCEEDED**
API --> Mana: CR: Complete WF(สมัครสมาชิก)
group MassTransit
    Tx --> API: [Publish] สมัครสมาชิกสำเร็จ
    note right
        TxId: T02
        Status: Succeeded
        RefTxId: T01
    endnote
    API -> API: [Consumer]\nตรวจ Tx ที่เกี่ยวข้อง
    API -> Tx: [Consumer] Start( T01 )
    Tx -> Tx: มอบ Asset (คูปอง)
    Tx --> API: [Publish] ผลการรับคูปอง
    API -> Mana: [Consumer]\nNotification Complete WF (รับคูปอง)
end

@enduml