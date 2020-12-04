/// <summary>
/// for general use - permanent store
/// </summary>
class FileController
{
    // ตัวอย่าง format url = $"{StorageUri}/file-upload/{ContainerName:type/bizAccountId/refId}/{fileId}{SaS}";
    // ตอนนี้ 3rd ใช้แบบนี้ => url = "https://blob.com/file-upload/productimage/img123456?SaS=xx=1&yy=2&token=A123d456f789==";
    // อนาคตจะเปลี่ยนไปใช้แบบนี้  => url = "https://blob.com/file-upload/productimage/b001/p001/img123456?SaS=xx=1&yy=2&token=A123d456f789==";

    /// <summary>
    /// ขอรายการ fileIds
    /// </summary>
    /// <param name="serviceId"></param>
    /// <param name="type">productimage, ฯ (mana กำหนด ต้องส่งมาให้ตรง)</param>
    /// <param name="bizAccountId"></param>
    /// <param name="refId">product refId</param>
    /// <return>fileIds</return>
    IEnumerable<string> GetUploaddFileId(string serviceId, string type, string bizAccountId, string refId);

    // /// <summary>
    // /// ขอ sas ไฟล์ใหม่ทีละไฟล์แบบให้ gen fileId ให้ด้วย
    // /// </summary>
    // /// <param name="serviceId"></param>
    // /// <param name="type">productimage, ฯ (mana กำหนด ต้องส่งมาให้ตรง)</param>
    // /// <param name="bizAccountId"></param>
    // /// <param name="refId">product refId</param>
    // /// <return>FileBlobSaS</return>
    // FileBlobSaS GetUploadFileBlobSaS(string serviceId, string type, string bizAccountId, string refId);

    /// <summary>
    /// ขอ sas ไฟล์ใหม่ทีละ"หลาย"ไฟล์แบบให้ gen fileId ให้ด้วย และกำหนดจำนวนไฟล์ที่จะอัพโหลด(default 1 file)
    /// </summary>
    /// <param name="serviceId"></param>
    /// <param name="type">productimage, ฯ (mana กำหนด ต้องส่งมาให้ตรง)</param>
    /// <param name="bizAccountId"></param>
    /// <param name="refId">product refId, ฯ</param>
    /// <param name="fileCount">จำนวนที่ขอ default = 1</param>
    /// <return>List<FileBlobSaS></return>
    IEnumerable<FileBlobSaS> GetUploadFileBlobSaS(string serviceId, string type, string bizAccountId, string refId, int? fileCount = 1);

    // /// <summary>
    // /// ขอ sas ทีละไฟล์แบบกำหนด fileId เอง
    // /// </summary>
    // /// <param name="serviceId"></param>
    // /// <param name="type">productimage, ฯ (mana กำหนด ต้องส่งมาให้ตรง)</param>
    // /// <param name="bizAccountId"></param>
    // /// <param name="refId">product refId, ฯ</param>
    // /// <param name="fileId">fileId ที่ขอ</param>
    // /// <return>FileBlobSaS</return>
    // FileBlobSaS GetUploadFileBlobSaS(string serviceId, string type, string bizAccountId, string refId, string fileId);

    /// <summary>
    /// ขอ sas ทีละ"หลาย"ไฟล์แบบกำหนด fileIds
    /// </summary>
    /// <param name="serviceId"></param>
    /// <param name="type">productimage, ฯ (mana กำหนด ต้องส่งมาให้ตรง)</param>
    /// <param name="bizAccountId"></param>
    /// <param name="refId">product refId, ฯ</param>
    /// <param name="fileIds">fileIds ที่ขอ</param>
    /// <return>List<FileBlobSaS></return>
    IEnumerable<FileBlobSaS> GetUploadFileBlobSaS(string serviceId, string type, string bizAccountId, string refId, IEnumerable<string> fileIds);

    /// <summary>
    /// https://host.azure.com/file/img123456
    /// </summary>
    /// <param name="fileId">file id include folder path</param>
    /// <return>File(stream, contentType);</return>
    [HttpGet("{*fileId}")]
    IActionResult FileContent(string fileId);
}

/// <summary>
/// for use via mana app - temporary store
/// </summary>
class TempUploadController
{
    // url = $"{StorageUri}/temp-upload/{ContainerName:mcontentId/endpointId}/{fileId}{SaS}";
    // url = "https://blob.com/temp-upload/635123456789/nptmck-635951357789/img123456?SaS=xx=1&yy=2&token=A123d456f789==";
    // FileBlobSaS GetUploadFileBlobSaS(string mcontentId, string endpointId);
    IEnumerable<FileBlobSaS> GetUploadFileBlobSaS(string mcontentId, string endpointId, int? fileCount = 1);
    // https://host.azure.com/635123456789/nptmck-635951357789/img123456
    // return File(stream, contentType);
    IActionResult FileContent(string mcontentId, string endpointId, string fileId);
}

/// <summary>
/// model ตอนนี้ 3rd ใช้แบบนี้
/// </summary>
class FileBlobSaS
{
    public string StorageUri { get; set; }
    public string ContainerName { get; set; }
    public string FileId { get; set; }
    public string SaS { get; set; }
}

/// <summary>
/// model ที่ควรจะเป็น
/// </summary>
class FileBlobSaS
{
    public string Url { get; set; }
    public string FileId { get; set; }
}

interface IFileUploadService
{
    // ContainerSaS GetUploadFileBlobSaS(string folder);
    // ContainerSaS GetReadFileBlobSaS(string folder);
    FileBlobSaS GetUploadFileBlobSaS(string folder, string fileId);
    FileBlobSaS GetReadFileBlobSaS(string folder, string fileId);
}