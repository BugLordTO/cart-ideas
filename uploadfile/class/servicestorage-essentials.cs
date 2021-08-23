namespace TheS.Mana.Essentials.FileService
{
    public class AccessInfo
    {
        /// <summary>
        /// AzBlob | AwsStorage | Http
        /// </summary>
        public string Mode { get; set; }
        /// <summary>
        /// file service host
        /// </summary>
        public string HostFqdn { get; set; }
        /// <summary>
        /// parent path
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// parent grant
        /// </summary>
        public AccessKey Grant { get; set; }
        /// <summary>
        /// has next page
        /// </summary>
        public int NextPage { get; set; }
        /// <summary>
        /// list of resources
        /// </summary>
        public IEnumerable<AccessResource> Resources { get; set; }
    }

    public class AccessResource
    {
        /// <summary>
        /// resource name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// resource grant
        /// </summary>
        public AccessKey Grant { get; set; }
    }

    public class AccessKey
    {
        /// <summary>
        /// access key
        /// </summary>
        public string AccessKey { get; set; }
        /// <summary>
        /// access key expired date
        /// </summary>
        public DateTime ExpiredDate { get; set; }
        /// <summary>
        /// access key permissions
        /// </summary>
        public Permission Permissions { get; set; }
    }

    public class AccessInfoRequest
    {
        /// <summary>
        /// request operation
        /// </summary>
        public Operation Operation { get; set; }
        /// <summary>
        /// request data type
        /// </summary>
        public AllowDataType DataType { get; set; }
        /// <summary>
        /// request new resource count
        /// </summary>
        public int? Count { get; set; }
        /// <summary>
        /// request permissions
        /// </summary>
        public Permission Permissions { get; set; }
    }

    public enum Operation
    {
        Create = 1,
        ParentAccess = 2,
        ResourceAccess = 4,
        RequestUpload = 8,
    }

    public enum Permission
    {
        Read = 1,
        Upload = 2,
        Delete = 4,
        Edit = 8,
    }

    public enum AllowedDataType
    {
        Image,
        Text,
        Pfd,
    }
}
