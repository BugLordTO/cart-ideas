# api projects

## current api
file api
for partners api
mana api
mana backoffice api
partner proxy
qr api
sandbox apim
idp

## module
profile
    user information
    kyc
communications
    home feed
    os noti
    in app noti
biz center
    biz information
    employee
    co owner
    subscription manage
dev account
    register dev account
    services
    hooks
    subscription
        manage
        validation subscription
    mcontent
        mcontent
        mcontent option
    form
        security
workflow unit
financial
    bank account binding
wallet
    deposit
    withdraw
    transfer
    tx
budget & allowance
cart
    adhoc cart
    full cart
    express
    split bill
product
escrow
gps
contract
    consent
------------- future module
service market
eslip
    coupon
    ticket
membership
    point
privilege
session reminder
search
    command
tag money
ads
M cash

## may be api
1. มี module อื่นมาใช้งานเยอะ >> share
2. มี workload เยอะ >> scale
3. function เยอะ
4. ไม่ควรเป็น stateful ?

communications >> 1 2
workflow unit >> 1
cart >> 2

----------------------------------------------------

# Delivery
profile
    user information
    kyc
communications
    home feed
    os noti
    in app noti
biz center
    biz information
    employee
dev account
    register dev account
    services
    hooks
    subscription
        manage
        validation subscription
    mcontent
workflow unit
financial
    bank account binding
wallet
    deposit
    withdraw
    tx
budget & allowance
cart
    adhoc cart
    full cart
product
escrow
gps
contract
    consent

# แยก

## api
m = mana api
3 = partner api

m  profile
m  communications
m  financial
m  wallet
m  cart
m  gps
m3 biz center
m3 dev account
m3 product
m3 contract

## libs
dev account - subscription
    manage
    validation subscription
workflow unit
budget & allowance
escrow

------------------------------------------------------------
# minimum
profile
    user information
    kyc
communications
    home feed
    os noti
    in app noti
biz center
    biz information
dev account
    register dev account
    services
    hooks
    subscription
        manage
        validation subscription
    mcontent
workflow unit
financial
    bank account binding
wallet
    deposit
    withdraw
    tx
cart
    adhoc cart
security
    - pin

# Delivery
biz center
    employee
dev account
    form
        security
budget & allowance
cart
    full cart
product
escrow
gps
contract
    consent

# Future
service market
biz center
    co owner
    subscription manage
wallet
    transfer
cart
    express
    split bill
eslip
    coupon
    ticket
membership
    point
privilege
session reminder
search
    command
tag money
ads
M cash
security
    - face

