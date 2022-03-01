user login mana
    - create loginKey ? keep and send to core ?
    - txOnly
        unlocking: /wallet/{userid:email}
        grantTo: {userid:email}
        proof: loginKey
    - core create user wallet
        wallet
            userWallet
        grant
            /wallet/{userid:email}

user register dev account
    - create regDevKey ? keep and send to core ?
    - txOnly
        unlocking: /dev/{userid:email}
        grantTo: {userid:email}
        proof: regDevKey
    - core create 
        wallet
            userWallet
        grant
            /wallet/{userid:email}
            /dev/{userid:email}