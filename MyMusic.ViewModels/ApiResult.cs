namespace MyMusic.ApiContracts
{
    public class ApiResult
    {
        public static ApiResult CreateException(string message)
        {
            return CreateNew(ApiContracts.ResultType.Error, message);
        }
        public static ApiResult CreateNew(ResultType resultType = ApiContracts.ResultType.Success, string message = "")
        {
            return new ApiResult
            {
                ResultTypeEnum = resultType,
                Message = message == "" ? resultType.ToString() : message,
                Data = ""
            };
        }
        public string Message { get; set; }
        public string Data { get; set; }
        public ResultType ResultTypeEnum { get; set; }
        public int ResultType => (int)ResultTypeEnum;
    }
}