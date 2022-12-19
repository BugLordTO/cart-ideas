# ServiceData

## 🤝 MTM Service

- ID: 370840722997259
<details>
  <summary>ServiceData</summary>
  
  - ที่ Logo เปลี่ยน manadevmaster เป็นของ ring ปลายทาง
  ```json
  {
    "_id" : "638066776010331728",
    "_t" : "ServiceData",
    "Name" : "MTMService",
    "Logo" : "https://manadevmaster.blob.core.windows.net/images/dfshop.png",
    "CreateDate" : ISODate("2022-12-15T05:06:41.032Z"),
    "BA" : "370829497991177"
  }
  ```
</details>

## 🤝 Mex Service

- ID: 638066882558737169
<details>
  <summary>ServiceData</summary>
  
  - ที่ Logo เปลี่ยน manadevmaster เป็นของ ring ปลายทาง
  ```json
  {
      "_id" : "638066882558737169",
      "_t" : "ServiceData",
      "Name" : "MexService",
      "Logo" : "https://manadevmaster.blob.core.windows.net/images/dfshop.png",
      "CreateDate" : ISODate("2022-12-15T08:04:15.873Z"),
      "BA" : "370840722997259"
  }
  ```
</details>

# BizAccount
  
## 🏪 👩‍💻 Mex DA

- ID: 370840722997259
- เอาไว้ call Mana 3rd Api
- ไม่มีเรื่องเงิน
<details>
  <summary>BizAccount</summary>
  
  - download รูปจาก url ใน field 3 ตัวด้านล่างไป upload เข้า blob ของ ring ปลายทาง แล้วเปลี่ยน url ให้เป็น ring ปลายทาง
    - Logo
    - PaymentQrImageUrl
    - CustomPaymentQrImageUrl
  - เปลี่ยน OwnerPaId ให้เป็นคนที่มีอยู่ใน ring ปลายทาง
  ```json
  {
      "_id" : "370840722997259",
      "Name" : "Mex",
      "Logo" : "manadevmaster.blob.core.windows.net/images/dfshop.png",
      "BannerUrl" : null,
      "RefCode" : "52248",
      "Address" : null,
      "ContactNos" : [],
      "OpeningSchedule" : {
          "TimeZoneOffset" : 7,
          "Schedules" : null,
          "TemporaryClosingThruTime" : null
      },
      "Tier" : "Free",
      "Type" : "SoftwareCompany",
      "LogisticType" : "",
      "CreatedDate" : ISODate("2022-12-15T08:03:37.313Z"),
      "ApprovedDateTime" : ISODate("2022-12-15T08:03:46.857Z"),
      "SuspendedDateTime" : null,
      "OwnerPaId" : "301005069615105",
      "IsUseAdvanceMenu" : false,
      "PaymentQrImageUrl" : "https://manadevmaster.blob.core.windows.net/ppayqr/1739a593-ea7d-4503-bbb9-090c2b49c3c9.png",
      "CustomPaymentQrImageUrl" : "https://manadevmaster.blob.core.windows.net/ppayqrcustom/88e4b834-8b8d-4778-a9ac-33c0b919acc3.png",
      "OperationRadius" : 10,
      "WalletId" : "370840722997259",
      "KymStatus" : {
          "BasicStatus" : "Approved",
          "AdvanceStatus" : "No",
          "RejectedNote" : null,
          "RequestDate" : ISODate("2022-12-15T08:03:37.313Z"),
          "ResubmitDate" : null,
          "RequestKym" : {
              "Mode" : "http",
              "HostFqdn" : "fileapi-devmaster.onmana.space",
              "Path" : "kymtemp/data/temp-kym/upload/a4e2afdc-43ba-4974-8e37-eca9906b766f",
              "Grant" : {
                  "Key" : "temp-kym/upload/a4e2afdc-43ba-4974-8e37-eca9906b766f",
                  "ExpiredDate" : ISODate("2022-12-15T08:33:38.998Z"),
                  "Permissions" : 1
              },
              "NextPage" : -1,
              "Resources" : [ 
                  {
                      "Name" : "225c7efd-5fcf-4401-87fb-35ec9ec78637",
                      "Grant" : {
                          "Key" : "temp-kym/upload/a4e2afdc-43ba-4974-8e37-eca9906b766f/225c7efd-5fcf-4401-87fb-35ec9ec78637",
                          "ExpiredDate" : ISODate("2022-12-15T08:33:38.998Z"),
                          "Permissions" : 1
                      }
                  }
              ]
          },
          "ApprovedKym" : {
              "Mode" : "http",
              "HostFqdn" : "fileapi-devmaster.onmana.space",
              "Path" : "kym/data/kym/370840722997259/basic",
              "Grant" : {
                  "Key" : "kym/data/kym/370840722997259/basic",
                  "ExpiredDate" : ISODate("2022-12-22T08:03:46.898Z"),
                  "Permissions" : 1
              },
              "NextPage" : -1,
              "Resources" : [ 
                  {
                      "Name" : "225c7efd-5fcf-4401-87fb-35ec9ec78637",
                      "Grant" : {
                          "Key" : "kym/data/kym/370840722997259/basic/225c7efd-5fcf-4401-87fb-35ec9ec78637",
                          "ExpiredDate" : ISODate("2022-12-22T08:03:46.979Z"),
                          "Permissions" : 1
                      }
                  }
              ]
          },
          "RiskLevel" : "low"
      }
  }
  ```
</details>

<details>
  <summary>Wallet</summary>
  
  - ที่ Wallets.LogoUrl เปลี่ยน manadevmaster เป็นของ ring ปลายทาง
  ```json
  {
      "_id" : "638066882269994490",
      "_t" : "Wallet",
      "UserId" : "370840722997259",
      "Wallets" : [ 
          {
              "_id" : "370840722997259",
              "Name" : "Main",
              "LogoUrl" : "https://manadevmaster.blob.core.windows.net/images/serwall%403x.png",
              "Balance" : NumberLong(0),
              "Security" : null,
              "CreatedDate" : ISODate("2022-12-15T08:03:46.999Z"),
              "DeletedDate" : null,
              "Currency" : "THB"
          }
      ],
      "DefaultWalletId" : "370840722997259",
      "NewWalletId" : "370840722997259"
  }
  ```
</details>

<details>
  <summary>BackOfficeKym</summary>
  
  - เปลี่ยน ManaUser เป็น operator ที่มีจริงใน ring ปลายทาง
  - เปลี่ยน Logo ตาม BizAccount
  ```json
  {
      "_id" : "370840722997259",
      "_t" : "BackOfficeKym",
      "CreateDate" : ISODate("2022-12-15T08:03:44.120Z"),
      "DeletedDate" : null,
      "Operator" : null,
      "ManaUser" : {
          "DisplayId" : "301005069615105",
          "DisplayName" : "Tachapong Khumkom aaa",
          "ProfileImageUrl" : "https://fileapi-deva.onmana.space/profile/data/account/container/folder/7138573d-5cbe-487f-9754-bf6eec776fce",
          "IsOnline" : false,
          "MarkedMail" : "ma**@g***.com",
          "MarkedPhoneNumber" : "081*****23"
      },
      "Permission" : null,
      "CompleteDate" : ISODate("2022-12-15T08:03:46.797Z"),
      "Logo" : "https://manadevmaster.blob.core.windows.net/images/dfshop.png",
      "ShopName" : "Mex",
      "Risk" : "low"
  }
  ```
</details>

<details>
  <summary>BackOfficeKymRequest</summary>
  
  - ไม่ต้องเปลี่ยนอะไร
  ```json
  {
      "_id" : "638066882262272942",
      "_t" : "BackOfficeKymRequest",
      "CreateDate" : ISODate("2022-12-15T08:03:44.120Z"),
      "DeletedDate" : null,
      "ParentId" : "370840722997259",
      "Number" : "KYM0094",
      "Type" : "Basic",
      "Detail" : "สินค้าและบริการ",
      "CompleteDate" : null,
      "CompleteBy" : "s01",
      "KycRequestId" : "637950330066519449",
      "AccessInfo" : {
          "Mode" : "http",
          "HostFqdn" : "fileapi-devmaster.onmana.space",
          "Path" : "kymtemp/data/temp-kym/upload/a4e2afdc-43ba-4974-8e37-eca9906b766f",
          "Grant" : {
              "Key" : "temp-kym/upload/a4e2afdc-43ba-4974-8e37-eca9906b766f",
              "ExpiredDate" : ISODate("2022-12-15T08:33:38.998Z"),
              "Permissions" : 1
          },
          "NextPage" : -1,
          "Resources" : [ 
              {
                  "Name" : "225c7efd-5fcf-4401-87fb-35ec9ec78637",
                  "Grant" : {
                      "Key" : "temp-kym/upload/a4e2afdc-43ba-4974-8e37-eca9906b766f/225c7efd-5fcf-4401-87fb-35ec9ec78637",
                      "ExpiredDate" : ISODate("2022-12-15T08:33:38.998Z"),
                      "Permissions" : 1
                  }
              }
          ]
      },
      "InfoFileUrl" : "aHR0cHM6Ly9maWxlYXBpLWRldm1hc3Rlci5vbm1hbmEuc3BhY2Uva3ltdGVtcC9kYXRhL3RlbXAta3ltL3VwbG9hZC9hNGUyYWZkYy00M2JhLTQ5NzQtOGUzNy1lY2E5OTA2Yjc2NmYvMjI1YzdlZmQtNWZjZi00NDAxLTg3ZmItMzVlYzllYzc4NjM3",
      "RiskLevel" : "low",
      "ApproveDate" : ISODate("2022-12-15T08:03:46.797Z"),
      "RejectDate" : null
  }
  ```
</details>

## 🏪 Mex BA (MMK)

- ID: 370840763891725
- เอาไว้จ่ายเงินให้ mana-mm ใน flow เติมเงิน adhoc mm (mana mm สร้าง qr แล้ว mana th scan จ่าย)
- 💡 ที่ release เดี๋ยวมาคุยกันต่อว่าจะเซตอัพเงินเริ่มต้น (Wallets.Balance) เท่าไร (ปัจจุบันเซตไว้ 60m MMK ~ 1m THB)
<details>
  <summary>BizAccount</summary>
  
  - download รูปจาก url ใน field 3 ตัวด้านล่างไป upload เข้า blob ของ ring ปลายทาง แล้วเปลี่ยน url ให้เป็น ring ปลายทาง
    - Logo
    - PaymentQrImageUrl
    - CustomPaymentQrImageUrl
  - เปลี่ยน OwnerPaId ให้เป็นคนที่มีอยู่ใน ring ปลายทาง
  ```json
  {
      "_id" : "370840763891725",
      "Name" : "MexMMK",
      "Logo" : "manadevmaster.blob.core.windows.net/images/dfshop.png",
      "BannerUrl" : null,
      "RefCode" : "e8beb",
      "Address" : null,
      "ContactNos" : [],
      "OpeningSchedule" : {
          "TimeZoneOffset" : 7,
          "Schedules" : null,
          "TemporaryClosingThruTime" : null
      },
      "Tier" : "Free",
      "Type" : "Shop",
      "LogisticType" : "",
      "CreatedDate" : ISODate("2022-12-15T08:04:16.395Z"),
      "ApprovedDateTime" : ISODate("2022-12-15T08:04:16.813Z"),
      "SuspendedDateTime" : null,
      "OwnerPaId" : "301005069615105",
      "IsUseAdvanceMenu" : false,
      "PaymentQrImageUrl" : "https://manadevmaster.blob.core.windows.net/ppayqr/23485ac0-84ee-4be6-a8d7-3d2c7332b8c2.png",
      "CustomPaymentQrImageUrl" : "https://manadevmaster.blob.core.windows.net/ppayqrcustom/049bf5f5-2845-4d49-9b0f-8bb3a7209000.png",
      "OperationRadius" : 10,
      "WalletId" : "370840763891725",
      "KymStatus" : {
          "BasicStatus" : "Approved",
          "AdvanceStatus" : "No",
          "RejectedNote" : null,
          "RequestDate" : ISODate("2022-12-15T08:04:16.395Z"),
          "ResubmitDate" : null,
          "RequestKym" : {
              "Mode" : "http",
              "HostFqdn" : "fileapi-devmaster.onmana.space",
              "Path" : "kymtemp/data/temp-kym/upload/423f0c44-cd6f-4428-833a-64b6f1d6c0ee",
              "Grant" : {
                  "Key" : "temp-kym/upload/423f0c44-cd6f-4428-833a-64b6f1d6c0ee",
                  "ExpiredDate" : ISODate("2022-12-15T08:34:16.432Z"),
                  "Permissions" : 1
              },
              "NextPage" : -1,
              "Resources" : [ 
                  {
                      "Name" : "02bf4fbc-4630-4a71-b327-c3b57270d426",
                      "Grant" : {
                          "Key" : "temp-kym/upload/423f0c44-cd6f-4428-833a-64b6f1d6c0ee/02bf4fbc-4630-4a71-b327-c3b57270d426",
                          "ExpiredDate" : ISODate("2022-12-15T08:34:16.432Z"),
                          "Permissions" : 1
                      }
                  }
              ]
          },
          "ApprovedKym" : {
              "Mode" : "http",
              "HostFqdn" : "fileapi-devmaster.onmana.space",
              "Path" : "kym/data/kym/370840763891725/basic",
              "Grant" : {
                  "Key" : "kym/data/kym/370840763891725/basic",
                  "ExpiredDate" : ISODate("2022-12-22T08:04:16.808Z"),
                  "Permissions" : 1
              },
              "NextPage" : -1,
              "Resources" : [ 
                  {
                      "Name" : "02bf4fbc-4630-4a71-b327-c3b57270d426",
                      "Grant" : {
                          "Key" : "kym/data/kym/370840763891725/basic/02bf4fbc-4630-4a71-b327-c3b57270d426",
                          "ExpiredDate" : ISODate("2022-12-22T08:04:16.837Z"),
                          "Permissions" : 1
                      }
                  }
              ]
          },
          "RiskLevel" : "low"
      }
  }
  ```
</details>

<details>
  <summary>Wallet</summary>
  
  - ที่ Wallets.LogoUrl เปลี่ยน manadevmaster เป็นของ ring ปลายทาง
  - 💡 ที่ release เดี๋ยวมาคุยกันต่อว่าจะเซตอัพเงินเริ่มต้น (Wallets.Balance) เท่าไร (ปัจจุบันเซตไว้ 60m MMK ~ 1m THB)
  ```json
  {
    "_id" : "638066882568574813",
    "_t" : "Wallet",
    "UserId" : "370840763891725",
    "Wallets" : [ 
        {
            "_id" : "370840763891725",
            "Name" : "Main",
            "LogoUrl" : "https://manadevmaster.blob.core.windows.net/images/serwall%403x.png",
            "Balance" : NumberLong(60000000000),
            "Security" : null,
            "CreatedDate" : ISODate("2022-12-15T08:04:16.857Z"),
            "DeletedDate" : null,
            "Currency" : "THB"
        }
    ],
    "DefaultWalletId" : "370840763891725",
    "NewWalletId" : "370840763891725"
  }
  ```
</details>

<details>
  <summary>BackOfficeKym</summary>
  
  - เปลี่ยน ManaUser เป็น operator ที่มีจริงใน ring ปลายทาง
  - เปลี่ยน Logo ตาม BizAccount
  ```json
  {
    "_id" : "370840763891725",
    "_t" : "BackOfficeKym",
    "CreateDate" : ISODate("2022-12-15T08:04:16.473Z"),
    "DeletedDate" : null,
    "Operator" : null,
    "ManaUser" : {
        "DisplayId" : "301005069615105",
        "DisplayName" : "Tachapong Khumkom aaa",
        "ProfileImageUrl" : "https://fileapi-deva.onmana.space/profile/data/account/container/folder/7138573d-5cbe-487f-9754-bf6eec776fce",
        "IsOnline" : false,
        "MarkedMail" : "ma**@g***.com",
        "MarkedPhoneNumber" : "081*****23"
    },
    "Permission" : null,
    "CompleteDate" : ISODate("2022-12-15T08:04:16.799Z"),
    "Logo" : "https://manadevmaster.blob.core.windows.net/images/dfshop.png",
    "ShopName" : "MexMMK",
    "Risk" : "low"
  }
  ```
</details>

<details>
  <summary>BackOfficeKymRequest</summary>
  
  - ไม่ต้องเปลี่ยนอะไร
  ```json
  {
    "_id" : "638066882566756496",
    "_t" : "BackOfficeKymRequest",
    "CreateDate" : ISODate("2022-12-15T08:04:16.473Z"),
    "DeletedDate" : null,
    "ParentId" : "370840763891725",
    "Number" : "KYM0095",
    "Type" : "Basic",
    "Detail" : "สินค้าและบริการ",
    "CompleteDate" : null,
    "CompleteBy" : "s01",
    "KycRequestId" : "637950330066519449",
    "AccessInfo" : {
        "Mode" : "http",
        "HostFqdn" : "fileapi-devmaster.onmana.space",
        "Path" : "kymtemp/data/temp-kym/upload/423f0c44-cd6f-4428-833a-64b6f1d6c0ee",
        "Grant" : {
            "Key" : "temp-kym/upload/423f0c44-cd6f-4428-833a-64b6f1d6c0ee",
            "ExpiredDate" : ISODate("2022-12-15T08:34:16.432Z"),
            "Permissions" : 1
        },
        "NextPage" : -1,
        "Resources" : [ 
            {
                "Name" : "02bf4fbc-4630-4a71-b327-c3b57270d426",
                "Grant" : {
                    "Key" : "temp-kym/upload/423f0c44-cd6f-4428-833a-64b6f1d6c0ee/02bf4fbc-4630-4a71-b327-c3b57270d426",
                    "ExpiredDate" : ISODate("2022-12-15T08:34:16.432Z"),
                    "Permissions" : 1
                }
            }
        ]
    },
    "InfoFileUrl" : "aHR0cHM6Ly9maWxlYXBpLWRldm1hc3Rlci5vbm1hbmEuc3BhY2Uva3ltdGVtcC9kYXRhL3RlbXAta3ltL3VwbG9hZC80MjNmMGM0NC1jZDZmLTQ0MjgtODMzYS02NGI2ZjFkNmMwZWUvMDJiZjRmYmMtNDYzMC00YTcxLWIzMjctYzNiNTcyNzBkNDI2",
    "RiskLevel" : "low",
    "ApproveDate" : ISODate("2022-12-15T08:04:16.799Z"),
    "RejectDate" : null
  }
  ```
</details>

## 🏪 MTM BA (THB)

- ID: 370840789057551
- เอาไว้รับเงินจาก mana-th ใน flow เติมเงิน adhoc mm (mana mm สร้าง qr แล้ว mana th scan จ่าย)
<details>
  <summary>BizAccount</summary>
  
  - download รูปจาก url ใน field 3 ตัวด้านล่างไป upload เข้า blob ของ ring ปลายทาง แล้วเปลี่ยน url ให้เป็น ring ปลายทาง
    - Logo
    - PaymentQrImageUrl
    - CustomPaymentQrImageUrl
  - เปลี่ยน OwnerPaId ให้เป็นคนที่มีอยู่ใน ring ปลายทาง
  ```json
  {
    "_id" : "370840789057551",
    "Name" : "MexTHB",
    "Logo" : "manadevmaster.blob.core.windows.net/images/dfshop.png",
    "BannerUrl" : null,
    "RefCode" : "3a9b1",
    "Address" : null,
    "ContactNos" : [],
    "OpeningSchedule" : {
        "TimeZoneOffset" : 7,
        "Schedules" : null,
        "TemporaryClosingThruTime" : null
    },
    "Tier" : "Free",
    "Type" : "Shop",
    "LogisticType" : "",
    "CreatedDate" : ISODate("2022-12-15T08:04:40.783Z"),
    "ApprovedDateTime" : ISODate("2022-12-15T08:04:41.482Z"),
    "SuspendedDateTime" : null,
    "OwnerPaId" : "301005069615105",
    "IsUseAdvanceMenu" : false,
    "PaymentQrImageUrl" : "https://manadevmaster.blob.core.windows.net/ppayqr/81b98806-3566-4ea7-aa0f-b5d774ff0fa6.png",
    "CustomPaymentQrImageUrl" : "https://manadevmaster.blob.core.windows.net/ppayqrcustom/6a76057d-b05b-41f7-8cbd-83b213a718a7.png",
    "OperationRadius" : 10,
    "WalletId" : "370840789057551",
    "KymStatus" : {
        "BasicStatus" : "Approved",
        "AdvanceStatus" : "No",
        "RejectedNote" : null,
        "RequestDate" : ISODate("2022-12-15T08:04:40.783Z"),
        "ResubmitDate" : null,
        "RequestKym" : {
            "Mode" : "http",
            "HostFqdn" : "fileapi-devmaster.onmana.space",
            "Path" : "kymtemp/data/temp-kym/upload/1647e4a1-2e81-4233-b29a-e66c7be7d6ee",
            "Grant" : {
                "Key" : "temp-kym/upload/1647e4a1-2e81-4233-b29a-e66c7be7d6ee",
                "ExpiredDate" : ISODate("2022-12-15T08:34:40.816Z"),
                "Permissions" : 1
            },
            "NextPage" : -1,
            "Resources" : [ 
                {
                    "Name" : "fef590d8-855a-4317-a8c7-a2fb39a225bf",
                    "Grant" : {
                        "Key" : "temp-kym/upload/1647e4a1-2e81-4233-b29a-e66c7be7d6ee/fef590d8-855a-4317-a8c7-a2fb39a225bf",
                        "ExpiredDate" : ISODate("2022-12-15T08:34:40.816Z"),
                        "Permissions" : 1
                    }
                }
            ]
        },
        "ApprovedKym" : {
            "Mode" : "http",
            "HostFqdn" : "fileapi-devmaster.onmana.space",
            "Path" : "kym/data/kym/370840789057551/basic",
            "Grant" : {
                "Key" : "kym/data/kym/370840789057551/basic",
                "ExpiredDate" : ISODate("2022-12-22T08:04:41.477Z"),
                "Permissions" : 1
            },
            "NextPage" : -1,
            "Resources" : [ 
                {
                    "Name" : "fef590d8-855a-4317-a8c7-a2fb39a225bf",
                    "Grant" : {
                        "Key" : "kym/data/kym/370840789057551/basic/fef590d8-855a-4317-a8c7-a2fb39a225bf",
                        "ExpiredDate" : ISODate("2022-12-22T08:04:41.507Z"),
                        "Permissions" : 1
                    }
                }
            ]
        },
        "RiskLevel" : "low"
    }
  }
  ```
</details>

<details>
  <summary>Wallet</summary>
  
  - ที่ Wallets.LogoUrl เปลี่ยน manadevmaster เป็นของ ring ปลายทาง
  ```json
  {
    "_id" : "638066882815265054",
    "_t" : "Wallet",
    "UserId" : "370840789057551",
    "Wallets" : [ 
        {
            "_id" : "370840789057551",
            "Name" : "Main",
            "LogoUrl" : "https://manadevmaster.blob.core.windows.net/images/serwall%403x.png",
            "Balance" : NumberLong(0),
            "Security" : null,
            "CreatedDate" : ISODate("2022-12-15T08:04:41.526Z"),
            "DeletedDate" : null,
            "Currency" : "THB"
        }
    ],
    "DefaultWalletId" : "370840789057551",
    "NewWalletId" : "370840789057551"
  }
  ```
</details>

<details>
  <summary>BackOfficeKym</summary>
  
  - เปลี่ยน ManaUser เป็น operator ที่มีจริงใน ring ปลายทาง
  - เปลี่ยน Logo ตาม BizAccount
  ```json
  {
    "_id" : "370840789057551",
    "_t" : "BackOfficeKym",
    "CreateDate" : ISODate("2022-12-15T08:04:41.114Z"),
    "DeletedDate" : null,
    "Operator" : null,
    "ManaUser" : {
        "DisplayId" : "301005069615105",
        "DisplayName" : "Tachapong Khumkom aaa",
        "ProfileImageUrl" : "https://fileapi-deva.onmana.space/profile/data/account/container/folder/7138573d-5cbe-487f-9754-bf6eec776fce",
        "IsOnline" : false,
        "MarkedMail" : "ma**@g***.com",
        "MarkedPhoneNumber" : "081*****23"
    },
    "Permission" : null,
    "CompleteDate" : ISODate("2022-12-15T08:04:41.467Z"),
    "Logo" : "https://manadevmaster.blob.core.windows.net/images/dfshop.png",
    "ShopName" : "MexTHB",
    "Risk" : "low"
  }
  ```
</details>

<details>
  <summary>BackOfficeKymRequest</summary>
  
  - ไม่ต้องเปลี่ยนอะไร
  ```json
  {
    "_id" : "638066882813351245",
    "_t" : "BackOfficeKymRequest",
    "CreateDate" : ISODate("2022-12-15T08:04:41.114Z"),
    "DeletedDate" : null,
    "ParentId" : "370840789057551",
    "Number" : "KYM0096",
    "Type" : "Basic",
    "Detail" : "สินค้าและบริการ",
    "CompleteDate" : null,
    "CompleteBy" : "s01",
    "KycRequestId" : "637950330066519449",
    "AccessInfo" : {
        "Mode" : "http",
        "HostFqdn" : "fileapi-devmaster.onmana.space",
        "Path" : "kymtemp/data/temp-kym/upload/1647e4a1-2e81-4233-b29a-e66c7be7d6ee",
        "Grant" : {
            "Key" : "temp-kym/upload/1647e4a1-2e81-4233-b29a-e66c7be7d6ee",
            "ExpiredDate" : ISODate("2022-12-15T08:34:40.816Z"),
            "Permissions" : 1
        },
        "NextPage" : -1,
        "Resources" : [ 
            {
                "Name" : "fef590d8-855a-4317-a8c7-a2fb39a225bf",
                "Grant" : {
                    "Key" : "temp-kym/upload/1647e4a1-2e81-4233-b29a-e66c7be7d6ee/fef590d8-855a-4317-a8c7-a2fb39a225bf",
                    "ExpiredDate" : ISODate("2022-12-15T08:34:40.816Z"),
                    "Permissions" : 1
                }
            }
        ]
    },
    "InfoFileUrl" : "aHR0cHM6Ly9maWxlYXBpLWRldm1hc3Rlci5vbm1hbmEuc3BhY2Uva3ltdGVtcC9kYXRhL3RlbXAta3ltL3VwbG9hZC8xNjQ3ZTRhMS0yZTgxLTQyMzMtYjI5YS1lNjZjN2JlN2Q2ZWUvZmVmNTkwZDgtODU1YS00MzE3LWE4YzctYTJmYjM5YTIyNWJm",
    "RiskLevel" : "low",
    "ApproveDate" : ISODate("2022-12-15T08:04:41.467Z"),
    "RejectDate" : null
  }
  ```
</details>
  
## 🏪 👩‍💻 MTM DA

- ID: 370829497991177
- เอาไว้ call Mana 3rd Api
- ไม่มีเรื่องเงิน
<details>
  <summary>BizAccount</summary>
  
  - download รูปจาก url ใน field 3 ตัวด้านล่างไป upload เข้า blob ของ ring ปลายทาง แล้วเปลี่ยน url ให้เป็น ring ปลายทาง
    - Logo
    - PaymentQrImageUrl
    - CustomPaymentQrImageUrl
  - เปลี่ยน OwnerPaId ให้เป็นคนที่มีอยู่ใน ring ปลายทาง
  ```json
  {
    "_id" : "370829497991177",
    "Name" : "MTM",
    "Logo" : "manadevmaster.blob.core.windows.net/images/dfshop.png",
    "BannerUrl" : null,
    "RefCode" : "bc86d",
    "Address" : null,
    "ContactNos" : [],
    "OpeningSchedule" : null,
    "Tier" : "Free",
    "Type" : "SoftwareCompany",
    "LogisticType" : "",
    "CreatedDate" : ISODate("2022-12-15T05:05:12.073Z"),
    "ApprovedDateTime" : ISODate("2022-12-15T05:06:01.900Z"),
    "SuspendedDateTime" : null,
    "OwnerPaId" : "301005069615105",
    "IsUseAdvanceMenu" : false,
    "PaymentQrImageUrl" : "https://manadevmaster.blob.core.windows.net/ppayqr/acb3a51b-65ed-42bd-ae6d-cb8fc0f1338e.png",
    "CustomPaymentQrImageUrl" : "https://manadevmaster.blob.core.windows.net/ppayqrcustom/c32f5aa9-3697-4ccf-8365-283d1d6af2be.png",
    "OperationRadius" : 10,
    "WalletId" : "370829497991177",
    "KymStatus" : {
        "BasicStatus" : "Approved",
        "AdvanceStatus" : "No",
        "RejectedNote" : null,
        "RequestDate" : ISODate("2022-12-15T05:05:12.073Z"),
        "ResubmitDate" : null,
        "RequestKym" : {
            "Mode" : "http",
            "HostFqdn" : "fileapi-devmaster.onmana.space",
            "Path" : "kymtemp/data/temp-kym/upload/201378ff-dd89-41da-b9bb-856cfd31a075",
            "Grant" : {
                "Key" : "temp-kym/upload/201378ff-dd89-41da-b9bb-856cfd31a075",
                "ExpiredDate" : ISODate("2022-12-15T05:35:12.375Z"),
                "Permissions" : 1
            },
            "NextPage" : -1,
            "Resources" : [ 
                {
                    "Name" : "803cf84b-3e92-4851-88ba-eecc6929db2d",
                    "Grant" : {
                        "Key" : "temp-kym/upload/201378ff-dd89-41da-b9bb-856cfd31a075/803cf84b-3e92-4851-88ba-eecc6929db2d",
                        "ExpiredDate" : ISODate("2022-12-15T05:35:12.375Z"),
                        "Permissions" : 1
                    }
                }
            ]
        },
        "ApprovedKym" : {
            "Mode" : "http",
            "HostFqdn" : "fileapi-devmaster.onmana.space",
            "Path" : "kym/data/kym/370829497991177/basic",
            "Grant" : {
                "Key" : "kym/data/kym/370829497991177/basic",
                "ExpiredDate" : ISODate("2022-12-22T05:06:01.961Z"),
                "Permissions" : 1
            },
            "NextPage" : -1,
            "Resources" : [ 
                {
                    "Name" : "803cf84b-3e92-4851-88ba-eecc6929db2d",
                    "Grant" : {
                        "Key" : "kym/data/kym/370829497991177/basic/803cf84b-3e92-4851-88ba-eecc6929db2d",
                        "ExpiredDate" : ISODate("2022-12-22T05:06:02.079Z"),
                        "Permissions" : 1
                    }
                }
            ]
        },
        "RiskLevel" : "low"
    }
  }
  ```
</details>

<details>
  <summary>Wallet</summary>
  
  - ที่ Wallets.LogoUrl เปลี่ยน manadevmaster เป็นของ ring ปลายทาง
  ```json
  {
    "_id" : "638066775620981972",
    "_t" : "Wallet",
    "UserId" : "370829497991177",
    "Wallets" : [ 
        {
            "_id" : "370829497991177",
            "Name" : "Main",
            "LogoUrl" : "https://manadevmaster.blob.core.windows.net/images/serwall%403x.png",
            "Balance" : NumberLong(0),
            "Security" : null,
            "CreatedDate" : ISODate("2022-12-15T05:06:02.098Z"),
            "DeletedDate" : null,
            "Currency" : "THB"
        }
    ],
    "DefaultWalletId" : "370829497991177",
    "NewWalletId" : "370829497991177"
  }
  ```
</details>

<details>
  <summary>BackOfficeKym</summary>
  
  - เปลี่ยน ManaUser เป็น operator ที่มีจริงใน ring ปลายทาง
  - เปลี่ยน Logo ตาม BizAccount
  ```json
  {
    "_id" : "370829497991177",
    "_t" : "BackOfficeKym",
    "CreateDate" : ISODate("2022-12-15T05:05:16.300Z"),
    "DeletedDate" : null,
    "Operator" : null,
    "ManaUser" : {
        "DisplayId" : "301005069615105",
        "DisplayName" : "Tachapong Khumkom aaa",
        "ProfileImageUrl" : "https://fileapi-deva.onmana.space/profile/data/account/container/folder/7138573d-5cbe-487f-9754-bf6eec776fce",
        "IsOnline" : false,
        "MarkedMail" : "ma**@g***.com",
        "MarkedPhoneNumber" : "081*****23"
    },
    "Permission" : null,
    "CompleteDate" : ISODate("2022-12-15T05:06:01.888Z"),
    "Logo" : "https://manadevmaster.blob.core.windows.net/images/dfshop.png",
    "ShopName" : "MTM",
    "Risk" : "low"
  }
  ```
</details>

<details>
  <summary>BackOfficeKymRequest</summary>
  
  - ไม่ต้องเปลี่ยนอะไร
  ```json
  {
    "_id" : "638066775173905219",
    "_t" : "BackOfficeKymRequest",
    "CreateDate" : ISODate("2022-12-15T05:05:16.300Z"),
    "DeletedDate" : null,
    "ParentId" : "370829497991177",
    "Number" : "KYM0093",
    "Type" : "Basic",
    "Detail" : "สินค้าและบริการ",
    "CompleteDate" : null,
    "CompleteBy" : "m10",
    "KycRequestId" : "637950330066519449",
    "AccessInfo" : {
        "Mode" : "http",
        "HostFqdn" : "fileapi-devmaster.onmana.space",
        "Path" : "kymtemp/data/temp-kym/upload/201378ff-dd89-41da-b9bb-856cfd31a075",
        "Grant" : {
            "Key" : "temp-kym/upload/201378ff-dd89-41da-b9bb-856cfd31a075",
            "ExpiredDate" : ISODate("2022-12-15T05:35:12.375Z"),
            "Permissions" : 1
        },
        "NextPage" : -1,
        "Resources" : [ 
            {
                "Name" : "803cf84b-3e92-4851-88ba-eecc6929db2d",
                "Grant" : {
                    "Key" : "temp-kym/upload/201378ff-dd89-41da-b9bb-856cfd31a075/803cf84b-3e92-4851-88ba-eecc6929db2d",
                    "ExpiredDate" : ISODate("2022-12-15T05:35:12.375Z"),
                    "Permissions" : 1
                }
            }
        ]
    },
    "InfoFileUrl" : "aHR0cHM6Ly9maWxlYXBpLWRldm1hc3Rlci5vbm1hbmEuc3BhY2Uva3ltdGVtcC9kYXRhL3RlbXAta3ltL3VwbG9hZC8yMDEzNzhmZi1kZDg5LTQxZGEtYjliYi04NTZjZmQzMWEwNzUvODAzY2Y4NGItM2U5Mi00ODUxLTg4YmEtZWVjYzY5MjlkYjJk",
    "RiskLevel" : "low",
    "ApproveDate" : ISODate("2022-12-15T05:06:01.888Z"),
    "RejectDate" : null
  }
  ```
</details>

## 🏪 MTM BA (MMK)

- ID: 370828626624517
- เอาไว้ รับ/จ่าย (ถอน/ถอนแล้ว reject) เงินจาก mana-mm ใน flow ถอนเงิน MTM
<details>
  <summary>BizAccount</summary>
  
  - download รูปจาก url ใน field 3 ตัวด้านล่างไป upload เข้า blob ของ ring ปลายทาง แล้วเปลี่ยน url ให้เป็น ring ปลายทาง
    - Logo
    - PaymentQrImageUrl
    - CustomPaymentQrImageUrl
  - เปลี่ยน OwnerPaId ให้เป็นคนที่มีอยู่ใน ring ปลายทาง
  ```json
  {
      "_id" : "370828626624517",
      "Name" : "mtmSlip",
      "Logo" : "manadevmaster.blob.core.windows.net/images/dfshop.png",
      "BannerUrl" : null,
      "RefCode" : "c88f2",
      "Address" : null,
      "ContactNos" : [],
      "OpeningSchedule" : null,
      "Tier" : "Free",
      "Type" : "Shop",
      "LogisticType" : "",
      "CreatedDate" : ISODate("2022-12-15T04:51:21.226Z"),
      "ApprovedDateTime" : ISODate("2022-12-15T05:00:52.013Z"),
      "SuspendedDateTime" : null,
      "OwnerPaId" : "301005069615105",
      "IsUseAdvanceMenu" : false,
      "PaymentQrImageUrl" : "https://manadevmaster.blob.core.windows.net/ppayqr/bfe443e7-d7f4-4e9a-9611-181d6ca1a6a9.png",
      "CustomPaymentQrImageUrl" : "https://manadevmaster.blob.core.windows.net/ppayqrcustom/6c2f1f22-dfd8-4160-8999-a03c3457274a.png",
      "OperationRadius" : 10,
      "WalletId" : "370828626624517",
      "KymStatus" : {
          "BasicStatus" : "Approved",
          "AdvanceStatus" : "No",
          "RejectedNote" : null,
          "RequestDate" : ISODate("2022-12-15T04:51:21.226Z"),
          "ResubmitDate" : null,
          "RequestKym" : {
              "Mode" : "http",
              "HostFqdn" : "fileapi-devmaster.onmana.space",
              "Path" : "kymtemp/data/temp-kym/upload/edee7f7d-4568-4384-9e1a-012253805cf5",
              "Grant" : {
                  "Key" : "temp-kym/upload/edee7f7d-4568-4384-9e1a-012253805cf5",
                  "ExpiredDate" : ISODate("2022-12-15T05:21:23.118Z"),
                  "Permissions" : 1
              },
              "NextPage" : -1,
              "Resources" : [ 
                  {
                      "Name" : "30ecb06a-fa86-471c-b176-32c41a686444",
                      "Grant" : {
                          "Key" : "temp-kym/upload/edee7f7d-4568-4384-9e1a-012253805cf5/30ecb06a-fa86-471c-b176-32c41a686444",
                          "ExpiredDate" : ISODate("2022-12-15T05:21:23.119Z"),
                          "Permissions" : 1
                      }
                  }
              ]
          },
          "ApprovedKym" : {
              "Mode" : "http",
              "HostFqdn" : "fileapi-devmaster.onmana.space",
              "Path" : "kym/data/kym/370828626624517/basic",
              "Grant" : {
                  "Key" : "kym/data/kym/370828626624517/basic",
                  "ExpiredDate" : ISODate("2022-12-22T05:00:52.201Z"),
                  "Permissions" : 1
              },
              "NextPage" : -1,
              "Resources" : [ 
                  {
                      "Name" : "30ecb06a-fa86-471c-b176-32c41a686444",
                      "Grant" : {
                          "Key" : "kym/data/kym/370828626624517/basic/30ecb06a-fa86-471c-b176-32c41a686444",
                          "ExpiredDate" : ISODate("2022-12-22T05:00:52.367Z"),
                          "Permissions" : 1
                      }
                  }
              ]
          },
          "RiskLevel" : "low"
      }
  }
  ```
</details>

<details>
  <summary>Wallet</summary>
  
  - ที่ Wallets.LogoUrl เปลี่ยน manadevmaster เป็นของ ring ปลายทาง
  ```json
  {
    "_id" : "638066772524382868",
    "_t" : "Wallet",
    "UserId" : "370828626624517",
    "Wallets" : [ 
        {
            "_id" : "370828626624517",
            "Name" : "Main",
            "LogoUrl" : "https://manadevmaster.blob.core.windows.net/images/serwall%403x.png",
            "Balance" : NumberLong(0),
            "Security" : null,
            "CreatedDate" : ISODate("2022-12-15T05:00:52.438Z"),
            "DeletedDate" : null,
            "Currency" : "MMK"
        }
    ],
    "DefaultWalletId" : "370828626624517",
    "NewWalletId" : "370828626624517"
  }
  ```
</details>

<details>
  <summary>BackOfficeKym</summary>
  
  - เปลี่ยน ManaUser เป็น operator ที่มีจริงใน ring ปลายทาง
  - เปลี่ยน Logo ตาม BizAccount
  ```json
  {
    "_id" : "370828626624517",
    "_t" : "BackOfficeKym",
    "CreateDate" : ISODate("2022-12-15T04:51:24.199Z"),
    "DeletedDate" : null,
    "Operator" : null,
    "ManaUser" : {
        "DisplayId" : "301005069615105",
        "DisplayName" : "Tachapong Khumkom aaa",
        "ProfileImageUrl" : "https://fileapi-deva.onmana.space/profile/data/account/container/folder/7138573d-5cbe-487f-9754-bf6eec776fce",
        "IsOnline" : false,
        "MarkedMail" : "ma**@g***.com",
        "MarkedPhoneNumber" : "081*****23"
    },
    "Permission" : null,
    "CompleteDate" : ISODate("2022-12-15T05:00:51.994Z"),
    "Logo" : "https://manadevmaster.blob.core.windows.net/images/dfshop.png",
    "ShopName" : "mtmSlip",
    "Risk" : "low"
  }
  ```
</details>

<details>
  <summary>BackOfficeKymRequest</summary>
  
  - ไม่ต้องเปลี่ยนอะไร
  ```json
  {
      "_id" : "638066766864780510",
      "_t" : "BackOfficeKymRequest",
      "CreateDate" : ISODate("2022-12-15T04:51:24.199Z"),
      "DeletedDate" : null,
      "ParentId" : "370828626624517",
      "Number" : "KYM0091",
      "Type" : "Basic",
      "Detail" : "สินค้าและบริการ",
      "CompleteDate" : null,
      "CompleteBy" : "m10",
      "KycRequestId" : "637950330066519449",
      "AccessInfo" : {
          "Mode" : "http",
          "HostFqdn" : "fileapi-devmaster.onmana.space",
          "Path" : "kymtemp/data/temp-kym/upload/edee7f7d-4568-4384-9e1a-012253805cf5",
          "Grant" : {
              "Key" : "temp-kym/upload/edee7f7d-4568-4384-9e1a-012253805cf5",
              "ExpiredDate" : ISODate("2022-12-15T05:21:23.118Z"),
              "Permissions" : 1
          },
          "NextPage" : -1,
          "Resources" : [ 
              {
                  "Name" : "30ecb06a-fa86-471c-b176-32c41a686444",
                  "Grant" : {
                      "Key" : "temp-kym/upload/edee7f7d-4568-4384-9e1a-012253805cf5/30ecb06a-fa86-471c-b176-32c41a686444",
                      "ExpiredDate" : ISODate("2022-12-15T05:21:23.119Z"),
                      "Permissions" : 1
                  }
              }
          ]
      },
      "InfoFileUrl" : "aHR0cHM6Ly9maWxlYXBpLWRldm1hc3Rlci5vbm1hbmEuc3BhY2Uva3ltdGVtcC9kYXRhL3RlbXAta3ltL3VwbG9hZC9lZGVlN2Y3ZC00NTY4LTQzODQtOWUxYS0wMTIyNTM4MDVjZjUvMzBlY2IwNmEtZmE4Ni00NzFjLWIxNzYtMzJjNDFhNjg2NDQ0",
      "RiskLevel" : "low",
      "ApproveDate" : ISODate("2022-12-15T05:00:51.994Z"),
      "RejectDate" : null
  }
  ```
</details>
