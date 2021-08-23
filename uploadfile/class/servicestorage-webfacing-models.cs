namespace TheS.Mana.WebFacing.Models.Services
{
    public abstract class FileServiceBase
    {
        public async Task<string> GetAccessKey() => throw new NotImplementException();
        public async Task<bool> ValidateAccessKey(string accessKey) => throw new NotImplementException();

        /// <summary>
        /// register account
        /// </summary>
        /// <returns>instance fullaccess AccessInfo</returns>
        Task<AccessInfo> RegisterAccount();
        /// <summary>
        /// request instance AccessInfo by specify instance name
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="request"></param>
        /// <param name="accessKey"></param>
        /// <returns>containers AccessInfo</returns>
        Task<AccessInfo> InstanceAccess(string instance, AccessInfoRequest request, string accessKey);

        /// <summary>
        /// request container AccessInfo
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="request"></param>
        /// <param name="accessKey"></param>
        /// <returns>containers AccessInfo</returns>
        Task<AccessInfo> ContainerAccess(string instance, AccessInfoRequest request, string accessKey);
        /// <summary>
        /// request container AccessInfo by specify container name
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="request"></param>
        /// <param name="accessKey"></param>
        /// <returns>containers AccessInfo</returns>
        Task<AccessInfo> ContainerAccess(string instance, string container, AccessInfoRequest request, string accessKey);
        /// <summary>
        /// delete single container
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="accessKey"></param>
        /// <returns></returns>
        Task<bool> DeleteContainer(string instance, string container, string accessKey);

        /// <summary>
        /// request folder AccessInfo
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="request"></param>
        /// <param name="accessKey"></param>
        /// <returns>folders AccessInfo</returns>
        Task<AccessInfo> FolderAccess(string instance, string container, AccessInfoRequest request, string accessKey);
        /// <summary>
        /// request files AccessInfo from specify folder name
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="request"></param>
        /// <param name="accessKey"></param>
        /// <returns>files AccessInfo AzBlob mode</returns>
        Task<AccessInfo> StartFolderUpload(string instance, string container, string folder, AccessInfoRequest request, string accessKey);
        /// <summary>
        /// delete single folder
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="accessKey"></param>
        /// <returns></returns>
        Task<bool> DeleteFolder(string instance, string container, string folder, string accessKey);
        /// <summary>
        /// delete single file
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="file"></param>
        /// <param name="accessKey"></param>
        /// <returns></returns>
        Task<bool> DeleteFile(string instance, string container, string folder, string file, string accessKey);

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
        Task<AccessInfo> WriteFileContent(string instance, string container, string folder, string file, Stream content, string accessKey);
        /// <summary>
        /// commit resource in AccessInfo or copy resource from other instance
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="accessInfo"></param>
        /// <param name="accessKey"></param>
        /// <returns>files AccessInfo</returns>
        Task<AccessInfo> CopyFolderData(string instance, string container, string folder, AccessInfo accessInfo, string accessKey);

        /// <summary>
        /// list containers AccessInfo
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="accessKey"></param>
        /// <returns>containers AccessInfo</returns>
        Task<AccessInfo> GetContainers(string instance, string accessKey);
        /// <summary>
        /// list folders AccessInfo
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="accessKey"></param>
        /// <returns>file content</returns>
        Task<AccessInfo> GetFolders(string instance, string container, string accessKey);
        /// <summary>
        /// list files AccessInfo
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="accessKey"></param>
        /// <returns>file content</returns>
        Task<AccessInfo> GetFiles(string instance, string container, string folder, string accessKey);
        /// <summary>
        /// get file content
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="container"></param>
        /// <param name="folder"></param>
        /// <param name="file"></param>
        /// <param name="accessKey"></param>
        /// <returns>file content</returns>
        Task<Stream> GetFileContent(string instance, string container, string folder, string file, string accessKey);
    }
}

namespace TheS.Mana.WebFacing.Models.Services.Configs
{
}

namespace TheS.Mana.WebFacing.Models.Services.Impl
{
}