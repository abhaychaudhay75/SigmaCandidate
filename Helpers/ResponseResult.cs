namespace JobCandidate.Helpers
{
    public class ResponseResult
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public dynamic Data { get; set; }
    }
}
