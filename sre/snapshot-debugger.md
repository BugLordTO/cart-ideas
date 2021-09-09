https://docs.microsoft.com/en-us/azure/azure-monitor/app/snapshot-debugger
https://docs.microsoft.com/en-us/azure/azure-monitor/app/snapshot-debugger-vm
https://corebts.com/blog/azure-application-insights-snapshot-debugger/

- สร้าง app service & app insight
  - set app insight > https://portal.azure.com/#@perfenterprise.com/resource/subscriptions/7874dd6f-3591-4b3a-84d8-9f42a96ccddd/resourcegroups/somsor/providers/Microsoft.Web/sites/testsnap2/monitoringSettings
    - [on] Snapshot debugger
    - [on] Show local variables
- สร้าง project
  - nuget Microsoft.ApplicationInsights.SnapshotCollector
  - Startup.cs
    - services.AddSnapshotCollector((configuration) => Configuration.Bind(nameof(SnapshotCollectorConfiguration), configuration));
  - ทำ api ที่ thrown error
  - publish
  - ยิง api ที่ error
- เช็ค Failures >> download snapshot << ติด step นี้ มันไม่มีปุ่มให้ download เหมือนใน doc
