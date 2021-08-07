using System;

namespace GeekSeat.Common.ViewModels
{
    [Serializable]
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        protected BaseResponse()
        {

        }

        public BaseResponse(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public static class Factory
        {
            public static BaseResponse BuildSuccessResponse(string message)
            {
                return new BaseResponse(true, message);
            }


            public static BaseResponse BuildFailedResponse(string message)
            {
                return new BaseResponse(false, message);
            }
        }
    }
}
