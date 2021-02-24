class ServiceController
{
    ServicesList GetServices();
    Service GetService(string id);
    void CreateService(ServiceCreateRequest request);
    void UpdateService(string id, ServiceUpdateRequest request);
    void DeleteService(string id);

    ServiceSubscriptionsList GetServiceSubscriptions(string serviceId);
    ServiceSubscription GetServiceSubscription(string id, string subscriptionid);
}
