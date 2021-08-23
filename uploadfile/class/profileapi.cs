using TheS.Mana.WebFacing.Models.Services;

namespace ProfileApi.Services.Impl
{
    public class ProfileFileService : FileServiceBase
    {
        private readonly HttpClient httpClient = new HttpClient();

        public ProfileFileService(Config config)
        {
            httpClient.Host = config.HostUrl;
        }

        /// <summary>
        /// register account
        /// </summary>
        /// <returns>instance fullaccess AccessInfo</returns>
        public async Task<AccessInfo> RegisterAccount()
            => httpClient.Post($"manage", null);

        /// <summary>
        /// request instance AccessInfo by specify instance name
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="request"></param>
        /// <param name="accessKey"></param>
        /// <returns>containers AccessInfo</returns>
        public async Task<AccessInfo> InstanceAccess(string instance, [FromBody] AccessInfoRequest request, [FromHeader] string accessKey)
            => httpClient.Put($"manage/{instance}", request);

        /// <summary>
        /// request container AccessInfo
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="request"></param>
        /// <param name="accessKey"></param>
        /// <returns>containers AccessInfo</returns>
        public async Task<AccessInfo> ContainerAccess(string instance, [FromBody] AccessInfoRequest request, [FromHeader] string accessKey)
            => httpClient.Post($"manage/{instance}", request);

        /// <summary>
        /// request container AccessInfo by specify container name
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="request"></param>
        /// <param name="accessKey"></param>
        /// <returns>containers AccessInfo</returns>
        public async Task<AccessInfo> ContainerAccess(string instance, string container, [FromBody] AccessInfoRequest request, [FromHeader] string accessKey);

        /// <summary>
        /// delete single container
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="accessKey"></param>
        /// <returns></returns>
        public async Task<bool> DeleteContainer(string instance, string container, [FromHeader] string accessKey);

        /// <summary>
        /// request folder AccessInfo
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="request"></param>
        /// <param name="accessKey"></param>
        /// <returns>folders AccessInfo</returns>
        public async Task<AccessInfo> FolderAccess(string instance, string container, [FromBody] AccessInfoRequest request, [FromHeader] string accessKey);

        /// <summary>
        /// request files AccessInfo from specify folder name
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="request"></param>
        /// <param name="accessKey"></param>
        /// <returns>files AccessInfo AzBlob mode</returns>
        public async Task<AccessInfo> StartFolderUpload(string instance, string container, string folder, [FromBody] AccessInfoRequest request, [FromHeader] string accessKey);

        /// <summary>
        /// delete single folder
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="accessKey"></param>
        /// <returns></returns>
        public async Task<bool> DeleteFolder(string instance, string container, string folder, [FromHeader] string accessKey);

        /// <summary>
        /// delete single file
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="file"></param>
        /// <param name="accessKey"></param>
        /// <returns></returns>
        public async Task<bool> DeleteFile(string instance, string container, string folder, string file, [FromHeader] string accessKey);

        /// <summary>
        /// create or update file
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="file"></param>
        /// <param name="content"></param>
        /// <param name="accessKey"></param>
        /// <returns>file AccessInfo</returns>
        public async Task<AccessInfo> WriteFileContent(string instance, string container, string folder, string file, Stream content, [FromHeader] string accessKey);

        /// <summary>
        /// commit resource in AccessInfo or copy resource from other instance
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="accessInfo"></param>
        /// <param name="accessKey"></param>
        /// <returns>files AccessInfo</returns>
        public async Task<AccessInfo> CopyFolderData(string instance, string container, string folder, AccessInfo accessInfo, [FromHeader] string accessKey);

        /// <summary>
        /// list containers AccessInfo
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="accessKey"></param>
        /// <returns>containers AccessInfo</returns>
        public async Task<AccessInfo> GetContainers(string instance, [FromHeader] string accessKey);

        /// <summary>
        /// list folders AccessInfo
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="accessKey"></param>
        /// <returns>file content</returns>
        public async Task<AccessInfo> GetFolders(string instance, string container, [FromHeader] string accessKey);

        /// <summary>
        /// list files AccessInfo
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="accessKey"></param>
        /// <returns>file content</returns>
        public async Task<AccessInfo> GetFiles(string instance, string container, string folder, [FromHeader] string accessKey);

        /// <summary>
        /// get file content
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="file"></param>
        /// <param name="accessKey"></param>
        /// <returns>file content</returns>
        public async Task<Stream> GetFileContent(string instance, string container, string folder, string file, [FromHeader] string accessKey);
    }
}

namespace ProfileApi.Controllers
{
    using ProfileApi.Services.Impl;

    [Route("manage")]
    public class ProfileController
    {
        private readonly ProfileFileService svc;

        public ProfileFileController(ProfileFileService svc)
        {
            this.svc = svc;
        }

        // Visit()
        // Submit()
        // StartFolderUpload()
    }
}
