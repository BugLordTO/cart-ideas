class MContentController
{
    public async Task<ActionResult<IEnumerable<MContent>>> GetAllMContent();
    public async Task<ActionResult<IEnumerable<MContent>>> GetMContent(string serviceId);
    public async Task<ActionResult<MContent>> GetMContent(string id);
    public async Task<IActionResult> DeleteMContent(string id);
    public async Task<ActionResult<MContentResponse>> RegisterMContentPage(string serviceId, [FromBody] MContentPageRequest request);
    public async Task<ActionResult<MContentResponse>> EditMContentPage(string id, [FromBody] MContentPageRequest request);
    public async Task<ActionResult<MContentResponse>> RegisterMContentForm(string serviceId, [FromBody] MContentFormRequest request);
    public async Task<ActionResult<MContentResponse>> EditMContentForm(string id, [FromBody] MContentFormRequest request);
    public async Task<ActionResult<MContentResponse>> RegisterMContentOption(string serviceId, [FromBody]MContentOptionRequest request);
    public async Task<ActionResult<MContentResponse>> EditMContentOption(string id, [FromBody]MContentOptionRequest request);
    public async Task<ActionResult<MContentResponse>> MContentOptionBinding(string id, [FromBody]MContentOptionBind request);
}
