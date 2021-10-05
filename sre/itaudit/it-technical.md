# QP-03
- ✅"ประธานเจ้าหน้าที่ฝ่ายเทคโนโลยี" เข้าสู่ระบบต้องมีการพิสูจน์ตัวตน โดยการใช้ multi-factor
- ❓re-start service
    - production จะจำกัดการเข้าถึงอย่างมาก
        - ใช้ runbook ช่วย
- ✅monitor ระบบ
    - application insights
- ✅ไม่สามารถเข้าถึงระบบจากการทำงานระยะไกลได้
    - manage accessible locations & IPs
        - https://portal.azure.com
        - More services
        - Azure AD
        - Security
        - Named locations
- ✅เข้าถึงด้วย VPN
    - เฉพาะ wfh
- ✅Activity log ใน VPN server
    - document https://docs.microsoft.com/en-us/azure/azure-monitor/essentials/activity-log
    - example https://portal.azure.com/#@perfenterprise.com/resource/subscriptions/c52ba97d-59c8-426b-af00-8d49a6383585/resourceGroups/mana-dev-fun/providers/Microsoft.ContainerService/managedClusters/mana-dev-aks/eventlogs
- ✅ยกเลิกการเชื่อมต่อที่ผิดปกติ "เครือข่ายภายในของบริษัท (internal network)"
- ✅ไม่อนุญาตให้พนักงานใช้อุปกรณ์ส่วนตัว "เครือข่ายภายในของบริษัท (internal network)"
- แยก Username / password
    - azure ad > technical account
    - gsuit > organize account
    - mana > operate account
    - ❓medium > gsuit @mana2018.co.th
- ซอฟแวร์ที่ถูกต้องตามลิขสิทธิ์
    - azure subscription
- ขอการอนุมัติสิทธิ์พิเศษในการเข้าถึงระบบ
    - azure ad
    - gsuit
    - mana

# QP-04
- ✅นโยบายรหัสผ่าน
    - azure ad
        - https://docs.microsoft.com/en-us/azure/active-directory/authentication/concept-sspr-policy#:~:text=A%20minimum%20of%208%20characters,Uppercase%20characters.
        - Characters allowed	
            A – Z
            a - z
            0 – 9
            @ # $ % ^ & * - _ ! + = [ ] { } | \ : ' , . ? / ` ~ " ( ) ; < >
            blank space
        - Password restrictions	
            - A minimum of 8 characters and a maximum of 256 characters.
                ❗❗❗แจ้งอัพเดทเอกสาร
            - Requires three out of four of the following:
            - Lowercase characters.
            - Uppercase characters.
            - Numbers (0-9).
            - Symbols
    - gsuit
    - mana
        - active email verification
        - active mobile otp verification
# QP-07
- ✅การสำรองและการกู้คืนข้อมูล
    - https://portal.azure.com
    - More services
    - Azure Cosmos DB
    - [Select DB (manaringdev)]
    - Backup & Restore

# QP-08

# QP-09
- ✅Azure DevOps
    - การควบคุมโปรแกรมต้นฉบับ
        - git repository
    - การอนุมัติการเปลี่ยนแปลงแก้ไข
        - pull request & review
    - และการนำขึ้นสู่ระบบ (deployment)
        - release pipeline
            - approve by CTO
        - app store review
    - ระบบงานหลัก (Production)
- การประเมินผลกระทบ
    - issue

# QP-13
- BOT report by email
