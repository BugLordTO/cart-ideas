# App insights

## features
- ✅ trace
- ✅ custom metrics
    - up to mana features
- ✅ alert rule
    - default on kubernetes
    - up to mana features
- ✅ across azure services
    - on app service
    - on kubernetes
    - on apim
    - on function app
- ✅ developer mode
- ❌ snapshot debugger
    - [not support on kubernetes](https://docs.microsoft.com/th-th/azure/azure-monitor/app/snapshot-debugger#enable-application-insights-snapshot-debugger-for-your-application)

## instance scopes

- เรื่องที่พิจารณา
    - inbound
    - outbound
    - across app insights
- across app insights rings
    - apim
    - manaidp
- แต่ละ ring มี app insights ของตัวเอง
    - pros & cons
        - ✅ ตอน monitor ไม่ต้อง filter เยอะ
        - ❌ ถ้ามี alert rule จะเปลือง เพราะมีหลายอัน
            - อาจจะ setup ถาวรแค่ devmaster ขึ้นไป นอกนั้น dev เสร็จให้ลบออก
    - 15 rings
        - ✅ deva
        - ✅ devb
        - ✅ devc
        - ✅ devd
        - ✅ devx
        - ✅ devmaster
        - ✅ devtesting
        - ✅ testflight
        - ✅ release
        - staging
        - prod
        - testflight-sand
        - release-sand
        - staging-sand
        - sandbox

![](out/app-insight/Application%20Insights.png)

## work

- create app insights (Log Analytics workspace)
    - ✅ dev ring
    - release ring
        - ✅ mana
        - sandbox
    - production ring
- configuration
    - azure app configuration
        - ✅ ApplicationInsights:DeveloperMode
        - ✅ ApplicationInsights:InstrumentationKey
    - apim
    - idp
- setup code
- custom metrics
    - up to mana features
- alert rule
    - default on kubernetes
    - up to mana features
- update team
