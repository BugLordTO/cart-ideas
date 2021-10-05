# team
- by repo/project
    - mana api
        - biz
        - profile
        - commuications
        - dev
        - financial
        - cart
        - product
        - gps
        - contract
        - subscription
        - workflow unit
        - budget & allowance
        - escrow
    - partner api
        - biz
        - dev
        - product
        - contract
    - service
        - file
        - qr
        - idp
    - mana app
    - mana content
        - ionic
        - zip
        - 
    - back office
    - delivery

- by feature >> รับผิดชอบทั้งหมด api config
    - mobile
    - identity
    - security
    
    # service
    - gps
    - file
    - qr
    - proxy

    # biz with ui
    - biz
    - employee
    - profile
    - dev account
    - financial & bank addount & user wallet
    - cart
    - product
    - contract
    - kyc

    # biz no ui
    - subscription
    - service & hook & mcontent
    - commuications
    - workflow unit
    - budget & allowance
    - escrow

    # ui
    - biz
    - employee
    - profile
    - dev account
    - financial & bank account & user wallet
    - cart
    - product
    - contract
    - kyc

    - tools
    
    - back office issue
    - back office forzen
    - back office kyc
    - delivery admin
    - delivery operator
    - delivery restaurant
    - delivery rider

- by scope
    - identity
        - idp
        - security
    - mobile app
    - mobile interact
        - commuications
        - gps
        - *search
        - *session reminder
    - biz center
        - biz account
        - employee
        - subscription
        - *service market
        - *co owner
        - *subscription manage
    - developer
        - dev account
        - service
        - hook
        - mcontent
        - contract
    - user
        - profile
        - kyc
    - financial
        - financial
        - bank account
        - wallet
        - topup & deposit
        - budget & allowance
        - *transfer
        - *tag money
        - *M cash
    - business
        - cart
        - product
        - *eslip
        - *express
        - *split bill
        - *membership
        - *privilege
        - *ads
    - core
        - lib
        - escrow
        - workflow unit
    - mana ui
    - utility
        - file
        - qr
        - proxy
    - tools
    - back office api
    - back office ui
        - issue
        - forzen
        - kyc
    - delivery ui
        - admin
        - operator
        - restaurant
    - delivery api
    - delivery app
        - rider

-----------------------------------------------

    - identity
    - mobile app
    - mobile interact
    - biz center
    - developer
    - user
    - financial
    - business
    - core
    - mana ui
    - utility
        - file
        - qr
        - proxy
    - tools
    - back office api
    - back office ui
        - issue
        - forzen
        - kyc
    - delivery ui
        - admin
        - operator
        - restaurant
    - delivery api
    - delivery app



=========================== RELEASE =====================================
Test flight เอาไรขึ้นบ้าง x3 weeks (24/10/2021)
  [GOAL] Pipeline & mobile
  Obfuscate
  srcx
  RequestBody
  Pipelin dev > prod
  Zip tool
  Switch ring tool
  IDP login
  Playground

Pre Release (0x/11/2021) migrate minimal srcx > src
  - mobile interact
      - commuications
      - gps
  - biz center
      - biz account
  - user
      - profile

Release 1 (0x/12/2021)
  [GOAL] จ่ายเงินได้ พี่บุ๊งไปเดโม่ได้
  ขึ้น store แต่ไม่ให้ใครใช้เลย
  scan จ่ายเงินธรรมดา
  จ่ายเงิน + hook ได้ (จ่ายเงินแล้วแจ้งคนอื่นรู้ได้ว่าจ่ายแล้ว)

  - Migrate user db
  - biz center
      - subscription
  - developer
      - dev account
      - service
      - hook
  - core
      - workflow unit
  - financial
      - financial
      - bank account
      - wallet
      - topup & deposit

Release 2 Delivery สำหรับร้านที่สนิท (บ้านมอ) (0x/01-2022)
  - biz center
      - employee
  - user
      - kyc
  - developer
      - mcontent
      - contract
  - business
      - cart
      - product
  - financial
      - budget & allowance

Release 3 (0x/02/2022)
  [GOAL] Delivery
  ไม่ประชาสัมพันธ์ แต่คนนอกใช้ได้
  mk วิ่งออกร้าน
  minimal delivery srcx > src
  Rider
  Restautant

  - core
      - escrow

เก็บขยะ
แลกเงิน
ซื้อข้าว
QR จ่ายเงิน
EV
ทำ delivery ภายในปีนี้ ไม่จำเป็นต้องสมบูรณ์