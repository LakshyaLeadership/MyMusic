using System;
using MyMusic.ViewModels;

namespace MyMusic.ApiContracts
{
    public class GetAlbumDetailsResponse : ApiResponse
    {
        public Album Album { get; set; }
    }

    public class ApiResponse
    {
        public ApiResponse()
        {
            MarkSuccess();
        }
        public ApiResult ApiResult { get; set; }
        public int StatusCode { get; set; }

        public static ApiResponse CreateException(string message)
        {
            ApiResponse resp = new ApiResponse
            {
                ApiResult = ApiResult.CreateNew(ResultType.Error, message)
            };
            return resp;
        }

        public void Err(Exception ex)
        {
            ApiResult = ApiResult.CreateNew(ResultType.Error, ex.Message);
        }

        public void Err(string message)
        {
            ApiResult = ApiResult.CreateNew(ResultType.Error, message);
        }
       


        public void MarkSuccess()
        {
            if (ApiResult == null)
            {
                ApiResult = ApiResult.CreateNew(ResultType.Success);
            }
        }

        public static ApiResponse Success()
        {
            return new ApiResponse
            {
                ApiResult = ApiResult.CreateNew(ResultType.Success),
            };
        }
    }
}