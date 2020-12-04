~account
npfedtl-account         get
npfedtl-detail          get put
npfedtl-addresses       get post
npfedtl-addresses.0     get put delete

---

~account
npfedtl-account                     get

~account.kyc
npfedtl-account.kyc                 get
npfedtl-account.basic               post
npfedtl.form-account.basic          post
npfedtl-account.advance             post
npfedtl.form-account.advance        get post
npfedtl.signature-account.advance   post
npfedtl.picture-account.advance     post
npfedtl.wait-account.advance        post
npfedtl.success-account.advance     get post

~account.phoneandemail
npfedtl-phoneandemail               get
npfedtl-phone                       post
npfedtl.otp-phone                   get post
npfedtl-phone.0                     post
npfedtl-email                       post
npfedtl.code-email                  get post
npfedtl-email.0                     post

~account.address
npfedtl-addresses                   get
npfedtl-addresses.add               post
npfedtl-addresses.shipment          get post
npfedtl-addresses.bill              get post
npfedtl-addresses.0                 get put
