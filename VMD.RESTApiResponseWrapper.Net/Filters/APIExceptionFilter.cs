using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using VMD.RESTApiResponseWrapper.Net.Enums;
using VMD.RESTApiResponseWrapper.Net.Extensions;
using VMD.RESTApiResponseWrapper.Net.Wrappers;

namespace VMD.RESTApiResponseWrapper.Net.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            ApiError apiError = null;
            APIResponse apiResponse = null;
            int code = 0;

            if (context.Exception is ApiException)
            {
                // handle explicit 'known' API errors
                var ex = context.Exception as ApiException;
                apiError = new ApiError(ex.Message);
                apiError.ValidationErrors = ex.Errors;
                apiError.ReferenceErrorCode = ex.ReferenceErrorCode;
                apiError.ReferenceDocumentLink = ex.ReferenceDocumentLink;
                code = ex.StatusCode;
                
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                apiError = new ApiError("Unauthorized Access");
                code = (int)HttpStatusCode.Unauthorized;
                // handle logging here
            }
            else
            {
                // Unhandled errors
#if !DEBUG
                    var msg = "An unhandled error occurred.";                
                    string stack = null;
#else
                var msg = context.Exception.GetBaseException().Message;
                string stack = context.Exception.StackTrace;
#endif

                apiError = new ApiError(msg);
                apiError.Details = stack;
                code = (int)HttpStatusCode.InternalServerError;
               

                // handle logging here
            }

            apiResponse = new APIResponse(code, ResponseMessageEnum.Exception.GetDescription(), null, apiError);

            // always return a JSON result
            HttpStatusCode  c = (HttpStatusCode)code;

            context.Response = context.Request.CreateResponse(c, apiResponse);

            //base.OnException(context);
        }
    }
}
