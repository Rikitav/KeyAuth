namespace KeyAuth.Requests
{
    /// <summary>
    /// Запрос загрузки файла
    /// </summary>
    public class DownloadRequest : RequestBase<Responses.DownloadResponse>
    {
        public override string Type => "file";

        [ApiParameter("fileid")]
        public string? FileId { get; set; }
    }
}

