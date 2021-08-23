using TheS.Mana.WebFacing.Models.Services;

namespace ProfileFileApi.Services.Impl
{
    public class ProfileFileService : FileServiceBase
    {
        /// <summary>
        /// register account
        /// </summary>
        /// <returns>instance fullaccess AccessInfo</returns>
        public async Task<AccessInfo> RegisterAccount() => throw new NotImplementException();
        /// <summary>
        /// request instance AccessInfo by specify instance name
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="request"></param>
        /// <param name="accessKey"></param>
        /// <returns>containers AccessInfo</returns>
        public async Task<AccessInfo> InstanceAccess(string instance, [FromBody] AccessInfoRequest request, [FromHeader] string accessKey) => throw new NotImplementException();

        /// <summary>
        /// request container AccessInfo
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="request"></param>
        /// <param name="accessKey"></param>
        /// <returns>containers AccessInfo</returns>
        public async Task<AccessInfo> ContainerAccess(string instance, [FromBody] AccessInfoRequest request, [FromHeader] string accessKey) => throw new NotImplementException();
        /// <summary>
        /// request container AccessInfo by specify container name
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="request"></param>
        /// <param name="accessKey"></param>
        /// <returns>containers AccessInfo</returns>
        public async Task<AccessInfo> ContainerAccess(string instance, string container, [FromBody] AccessInfoRequest request, [FromHeader] string accessKey) => throw new NotImplementException();
        /// <summary>
        /// delete single container
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="accessKey"></param>
        /// <returns></returns>
        public async Task<bool> DeleteContainer(string instance, string container, [FromHeader] string accessKey) => throw new NotImplementException();

        /// <summary>
        /// request folder AccessInfo
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="request"></param>
        /// <param name="accessKey"></param>
        /// <returns>folders AccessInfo</returns>
        public async Task<AccessInfo> FolderAccess(string instance, string container, [FromBody] AccessInfoRequest request, [FromHeader] string accessKey) => throw new NotImplementException();
        /// <summary>
        /// request files AccessInfo from specify folder name
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="request"></param>
        /// <param name="accessKey"></param>
        /// <returns>files AccessInfo AzBlob mode</returns>
        public async Task<AccessInfo> StartFolderUpload(string instance, string container, string folder, [FromBody] AccessInfoRequest request, [FromHeader] string accessKey) => throw new NotImplementException();
        /// <summary>
        /// delete single folder
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="accessKey"></param>
        /// <returns></returns>
        public async Task<bool> DeleteFolder(string instance, string container, string folder, [FromHeader] string accessKey) => throw new NotImplementException();
        /// <summary>
        /// delete single file
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="file"></param>
        /// <param name="accessKey"></param>
        /// <returns></returns>
        public async Task<bool> DeleteFile(string instance, string container, string folder, string file, [FromHeader] string accessKey) => throw new NotImplementException();

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
        public async Task<AccessInfo> WriteFileContent(string instance, string container, string folder, string file, Stream content, [FromHeader] string accessKey) => throw new NotImplementException();
        /// <summary>
        /// commit resource in AccessInfo or copy resource from other instance
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="accessInfo"></param>
        /// <param name="accessKey"></param>
        /// <returns>files AccessInfo</returns>
        public async Task<AccessInfo> CopyFolderData(string instance, string container, string folder, AccessInfo accessInfo, [FromHeader] string accessKey) => throw new NotImplementException();

        /// <summary>
        /// list containers AccessInfo
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="accessKey"></param>
        /// <returns>containers AccessInfo</returns>
        public async Task<AccessInfo> GetContainers(string instance, [FromHeader] string accessKey) => throw new NotImplementException();
        /// <summary>
        /// list folders AccessInfo
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="accessKey"></param>
        /// <returns>file content</returns>
        public async Task<AccessInfo> GetFolders(string instance, string container, [FromHeader] string accessKey) => throw new NotImplementException();
        /// <summary>
        /// list files AccessInfo
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="accessKey"></param>
        /// <returns>file content</returns>
        public async Task<AccessInfo> GetFiles(string instance, string container, string folder, [FromHeader] string accessKey) => throw new NotImplementException();
        /// <summary>
        /// get file content
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="file"></param>
        /// <param name="accessKey"></param>
        /// <returns>file content</returns>
        public async Task<Stream> GetFileContent(string instance, string container, string folder, string file, [FromHeader] string accessKey) => throw new NotImplementException();
    }
}


namespace ProfileFileApi.Controllers
{
    using ProfileFileApi.Services.Impl;

    [Route("manage")]
    public class ProfileFileController
    {
        private readonly ProfileFileService svc;

        public ProfileFileController(ProfileFileService svc)
        {
            this.svc = svc;
        }

        /// <summary>
        /// register account
        /// </summary>
        /// <returns>instance fullaccess AccessInfo</returns>
        [HttpPost]
        public async Task<AccessInfo> RegisterAccount()
            => svc.RegisterAccount();

        /// <summary>
        /// request instance AccessInfo by specify instance name
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="request"></param>
        /// <param name="accessKey"></param>
        /// <returns>containers AccessInfo</returns>
        [HttpPut("{instance}")]
        public async Task<AccessInfo> InstanceAccess(string instance, [FromBody] AccessInfoRequest request, [FromHeader] string accessKey)
            => svc.InstanceAccess(instance, request, accessKey);

        /// <summary>
        /// request container AccessInfo
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="request"></param>
        /// <param name="accessKey"></param>
        /// <returns>containers AccessInfo</returns>
        [HttpPost("{instance}")]
        public async Task<AccessInfo> ContainerAccess(string instance, [FromBody] AccessInfoRequest request, [FromHeader] string accessKey)
            => svc.ContainerAccess(instance, request, accessKey);

        /// <summary>
        /// request container AccessInfo by specify container name
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="request"></param>
        /// <param name="accessKey"></param>
        /// <returns>containers AccessInfo</returns>
        [HttpPut("{instance}/{container}")]
        public async Task<AccessInfo> ContainerAccess(string instance, string container, [FromBody] AccessInfoRequest request, [FromHeader] string accessKey)
            => svc.ContainerAccess(instance, container, request, accessKey);

        /// <summary>
        /// delete single container
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="accessKey"></param>
        /// <returns></returns>
        [HttpDelete("{instance}/{container}")]
        public async Task<bool> DeleteContainer(string instance, string container, [FromHeader] string accessKey)
            => svc.DeleteContainer(instance, container, accessKey);

        /// <summary>
        /// request folder AccessInfo
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="request"></param>
        /// <param name="accessKey"></param>
        /// <returns>folders AccessInfo</returns>
        [HttpPost("{instance}/{container}")]
        public async Task<AccessInfo> FolderAccess(string instance, string container, [FromBody] AccessInfoRequest request, [FromHeader] string accessKey)
            => svc.FolderAccess(instance, container, request, accessKey);

        /// <summary>
        /// request files AccessInfo from specify folder name
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="request"></param>
        /// <param name="accessKey"></param>
        /// <returns>files AccessInfo AzBlob mode</returns>
        [HttpPut("{instance}/{container}/{folder}")]
        public async Task<AccessInfo> StartFolderUpload(string instance, string container, string folder, [FromBody] AccessInfoRequest request, [FromHeader] string accessKey)
            => svc.StartFolderUpload(instance, container, folder, request, accessKey);

        /// <summary>
        /// delete single folder
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="accessKey"></param>
        /// <returns></returns>
        [HttpDelete("{instance}/{container}/{folder}")]
        public async Task<bool> DeleteFolder(string instance, string container, string folder, [FromHeader] string accessKey)
            => svc.DeleteFolder(instance, container, folder, accessKey);

        /// <summary>
        /// delete single file
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="file"></param>
        /// <param name="accessKey"></param>
        /// <returns></returns>
        [HttpDelete("{instance}/{container}/{folder}")]
        public async Task<bool> DeleteFile(string instance, string container, string folder, string file, [FromHeader] string accessKey)
            => svc.DeleteFile(instance, container, folder, file, accessKey);

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
        [HttpPost("{instance}/{container}/{folder}/{file}")]
        public async Task<AccessInfo> WriteFileContent(string instance, string container, string folder, string file, IFromFile content, [FromHeader] string accessKey)
            => svc.WriteFileContent(instance, container, folder, file, content.GetStream(), accessKey);

        /// <summary>
        /// commit resource in AccessInfo or copy resource from other instance
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="accessInfo"></param>
        /// <param name="accessKey"></param>
        /// <returns>files AccessInfo</returns>
        [HttpPut("{instance}/{container}/{folder}")]
        public async Task<AccessInfo> CopyFolderData(string instance, string container, string folder, [FromBody] AccessInfo accessInfo, [FromHeader] string accessKey)
            => svc.CopyFolderData(instance, container, folder, accessInfo, accessKey);

        /// <summary>
        /// list containers AccessInfo
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="accessKey"></param>
        /// <returns>containers AccessInfo</returns>
        [HttpGet("{instance}")]
        public async Task<AccessInfo> GetContainers(string instance, string accessKey)
            => svc.GetContainers(instance, accessKey);

        /// <summary>
        /// list folders AccessInfo
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="accessKey"></param>
        /// <returns>file content</returns>
        [HttpGet("{instance}/{container}")]
        public async Task<AccessInfo> GetFolders(string instance, string container, string accessKey)
            => svc.GetFolders(instance, container, accessKey);

        /// <summary>
        /// list files AccessInfo
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="accessKey"></param>
        /// <returns>file content</returns>
        [HttpGet("{instance}/{container}/{folder}")]
        public async Task<AccessInfo> GetFiles(string instance, string container, string folder, string accessKey)
            => svc.GetFiles(instance, container, folder, accessKey);

        /// <summary>
        /// get file content
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="file"></param>
        /// <param name="accessKey"></param>
        /// <returns>file content</returns>
        [HttpGet("{instance}/{container}/{folder}/{file}")]
        public async Task<Stream> GetFileContent(string instance, string container, string folder, string file, string accessKey)
            => svc.GetFileContent(instance, container, folder, file, accessKey);
    }
}
