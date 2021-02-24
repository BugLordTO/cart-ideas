class HookController
{
    void RegisterProductHook(string serviceId, HookCreateRequest request);
    void RegisterCartHook(string serviceId, HookCreateRequest request);
    void RegisterCheckoutHook(string serviceId, HookCreateRequest request);
    void RegisterOrderHook(string serviceId, HookCreateRequest request);

    IEnumerable<Hook> GetHook(string serviceId);
    Hook GetHook(string id);
    void CreateHook(string serviceId, HookCreateRequest request);
    void UpdateHook(string id, HookUpdateRequest request);
    void DeleteHook(string id);
}
