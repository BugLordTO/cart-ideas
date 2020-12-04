/wallet/wl101
/wallet/wl101/budget
/wallet/wl101/allowance
/wallet/wl101/budget/bg102
/wallet/wl101/allowance/aw102

/bizaccount/ba201
/bizaccount/ba201/bamem
/bizaccount/ba201/bamem/bm202 => one per ba
/bizaccount/ba201/bamem/bm202/mem
/bizaccount/ba201/bamem/bm202/mem/mem203 => ทั้ง user/ba จะมี grant นี้
/bizaccount/ba201/bamem/bm202/level/0/id/mem203? => ทั้ง user/ba จะมี grant นี้
    /bizaccount/ba201/bamem/bm202/mem => require member
    /bizaccount/ba201/bamem/bm202/mem?level=0 => require member level 0
    /bizaccount/ba201/bamem/bm202/mem?level>3 => require member level greater than 3
    /bizaccount/ba201/bamem/bm202/mem?level>=3 => require member level greater or equal 3
/bizaccount/ba201/bamem/bm202/mem/mem203/wallet => ทั้ง user/ba จะมี grant นี้
/bizaccount/ba201/bamem/bm202/mem/mem203/wallet/mw202 => ทั้ง user/ba จะมี grant นี้
    /bizaccount/ba201/bamem/bm202/mem/mem203/wallet/{id}/point => ใช้ point ได้
    /bizaccount/ba201/bamem/bm202/mem/mem203/wallet/{id}/point/50 => ใช้ point 50
/mem/mem201
/mem/mem201/wallet
/mem/mem201/wallet/mw202 => user เก็บ point ที่นี่
/mem/mem203?level=0
/mem/mem203?level=1

/bizaccount/ba301
/bizaccount/ba301/eslip
/bizaccount/ba301/eslip/es302
/bizaccount/ba301/eslip/es302/tail/303 => ทั้ง user/ba จะมี grant นี้
/tail/301

/bizaccount/ba401
/bizaccount/ba401/wallet
/bizaccount/ba401/wallet/bw402 => one per ba
/bizaccount/ba401/wallet/bw402/budget
/bizaccount/ba401/wallet/bw402/allowance
/bizaccount/ba401/wallet/bw402/budget/bg403
/bizaccount/ba401/wallet/bw402/allowance/aw403
/bizaccount/ba401/wallet/bw402/budget/bg403/allowance/aw404
/bizaccount/ba401/wallet/bw402/budget/bg403/budget/bg404

/bizaccount/ba401/contract/ct01/owner -> owner(delivery)
/bizaccount/ba555/info
/bizaccount/ba555/schedule
/bizaccount/ba555/subscription/sc01

/bizaccount/ba401/contract/ct01/owner/bizaccount/ba555/info
/bizaccount/ba401/contract/ct01/owner/bizaccount/ba555/schedule
/bizaccount/ba401/contract/ct01/owner/bizaccount/ba555/subscription/sc01
/bizaccount/ba401/contract/ct01/owner/escrow/es01

/bizaccount/ba401/contract/ct01/contractor -> contractor(restuarant)


/devaccount/d501
/devaccount/d501/wallet
/devaccount/d501/wallet/dw502 => one per da
/devaccount/d501/wallet/dw502/budget
/devaccount/d501/wallet/dw502/allowance
/devaccount/d501/wallet/dw502/budget/bg503
/devaccount/d501/wallet/dw502/allowance/aw503

/devaccount/d601
/devaccount/d601/subscription
/devaccount/d601/subscription/sp602




COMMAND:
/wallet/wl101/budget/bg102/withdraw/500
/wallet/wl101/budget/bg102/withdraw/limit/1000

{
    Owner: /user/u001
    Grant: /wallet/wl101/budget/bg102
    Command: /wallet/wl101/budget/bg102/grant
}






/tags/"brand:nike","color:red"



https://docs.google.com/spreadsheets/d/12nPcDG5D7RjYlJ4GL6HNtzDwizqQ9nzoPM2W4J-s-7o/edit#gid=0




wallet/132
ba/1123/thb
bm/123