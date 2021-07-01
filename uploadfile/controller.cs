[Route("[controller]")]
public class TempUploadController : Controller
{
    /// <summary>
    /// Get Upload File Blob SaS
    /// </summary>
    /// <param name="mcontentId"></param>
    /// <param name="endpointId"></param>
    /// <param name="fileCount">default is 1</param>
    /// <returns></returns>
    [HttpGet("{mcontentId}/{endpointId}/upload/sas")]
    public async Task<ActionResult<IEnumerable<FileBlobSaS>>> GetUploadFileBlobSaS(string mcontentId, string endpointId, int? fileCount = 1);
}

[Route("dev/{daId}/service/{svcId}/[controller]")]
public class TempUploadController : Controller
{
    /// <summary>
    /// Get Read File Blob SaSs >> for partner
    /// </summary>
    /// <param name="daId"></param>
    /// <param name="svcId"></param>
    /// <param name="mcontentId"></param>
    /// <param name="endpointId"></param>
    /// <param name="fileIds">fileIds seperate by comma(,)</param>
    /// <returns>Blob reference url with SaSs</returns>
    [HttpGet("{mcontentId}/{endpointId}/read/sas")]
    Task<IEnumerable<ReadFileBlobSaS>> GetReadBlobSaSs(string daId, string svcId, string mcontentId, string endpointId, string fileIds);
    /// <summary>
    /// Get Allowed File Content >> for partner
    /// </summary>
    /// <param name="daId"></param>
    /// <param name="svcId"></param>
    /// <param name="fileId"></param>
    /// <returns></returns>
    [HttpGet("{*fileId}")]
    public async Task<IActionResult> FileContent(string daId, string svcId, string fileId)
}

public interface IFileUploadService
{
    /// <summary>
    /// Get Upload Temp File Blob SaSs
    /// </summary>
    /// <param name="folder"></param>
    /// <param name="fileCount"></param>
    /// <returns>File Blob SaSs</returns>
    Task<IEnumerable<FileBlobSaS>> GetUploadTempBlobSaSs(string folder, int? fileCount = 1);
        // /// <summary>
        // /// Get Upload Temp File Blob SaSs
        // /// </summary>
        // /// <param name="folder"></param>
        // /// <param name="fileIds">If fileId is not set, it will generate one from GUID</param>
        // /// <returns>File Blob SaSs</returns>
        // Task<IEnumerable<FileBlobSaS>> GetUploadTempBlobSaSs(string folder, params string[] fileIds = null);
    /// <summary>
    /// Get Read Temp File Blob SaSs
    /// </summary>
    /// <param name="folder"></param>
    /// <param name="fileIds"></param>
    /// <returns>Blob reference url with SaSs</returns>
    Task<IEnumerable<ReadFileBlobSaS>> GetReadTempBlobSaSs(string folder, params string[] fileIds = null);
    /// <summary>
    /// Check temp uploaded file
    /// </summary>
    /// <param name="fileId"></param>
    /// <returns>Allow file</returns>
    Task<bool> CheckTempBlob(string fileId);
        // /// <summary>
        // /// Get temp file content
        // /// </summary>
        // /// <param name="folder"></param>
        // /// <param name="fileId"></param>
        // /// <returns>Temp file content stream</returns>
        // Task<Stream> GetTempBlobContent(string folder, string fileId);
}

/// <summary>
/// File Blob url and id >> https://mystroageaccount.blob.core.windows.net/temp-upload/nxxxyyy-123/mconten-data/637496437873887939?sv=2018-03-28&sr=b&sig=ixgds4
/// </summary>
public class FileBlobSaS
{
    /// <summary>
    /// https://mystroageaccount.blob.core.windows.net/temp-upload/nxxxyyy-123/mconten-data
    /// </summary>
    public string Url { get; set; }
    /// <summary>
    /// 637496437873887939
    /// </summary>
    public string FileName { get; set; }
    /// <summary>
    /// temp-upload/nxxxyyy-123/mconten-data/637496437873887939
    /// </summary>
    public string FileId { get; set; }
    /// <summary>
    /// ?sv=2018-03-28&sr=b&sig=ixgds4
    /// </summary>
    public string SaS { get; set; }
}

public class ReadFileBlobSaS : FileBlobSaS
{
    public bool IsAllowFile { get; set; }
}