# 1. Analyze your Azure infrastructure by using Azure Monitor logs
- In the Azure portal, select Monitor in the left pane.
- Query & Analyze Logs. 
- Write queries by using the Kusto language

# 2. Instrument server-side web application code with Application Insights
- setup environment
    - create app service & app insights
    - config at portal
- create aspnetcore web app
    - setup app insights
    - create api and track event
    ```c#
    this.aiClient.TrackEvent("CommentSubmitted");
    ```
    - try telemetry
    ```c#
    Metric userResponse = this.aiClient.GetMetric("UserResponses", "Kind");
    userResponse.TrackValue(24, "Likes");
    userResponse.TrackValue(5, "Loves");
    ```

# 3. Design a holistic monitoring strategy on Azure
[Design a holistic monitoring strategy on Azure](3.txt)

# 4. Improve incident response with alerting on Azure
Composition of an alert rule
 - RESOURCE
 - CONDITION
 - ACTIONS
 - ALERT DETAILS
    0: Critical
    1: Error
    2: Warning
    3: Informational
    4: Verbose

# 5. QUESTION เราจะทำ Monitoring สำหรับ Mana อย่างไรจึงจะมี Reliability วิเคราะห์และแก้ปัญหาได้
- application map
- monitor
- SLI/SLO
- actionable alert

# 6. Pilot tools
## K9
- manual https://k6.io/blog/running-distributed-tests-on-k8s/
    - Cloning the repository >> clone to kube
    - Deploying the operator >> deploy to kube
    - Writing our test script >> write js
    - Deploying our test script >> cmd: kubectl create configmap
    - Creating our custom resource >> .yaml
    - Deploying our Custom Resource >> apply
    - Check the logs
- pipeline
    - DockerFile
    - mainbuild.yaml
    - kube manifest file
    - release pipeline

## wiremock
