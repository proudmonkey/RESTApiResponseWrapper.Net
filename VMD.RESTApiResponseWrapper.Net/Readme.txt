STEPS TO USE THE RESTApiResponseWrapper.Net

1) Declare the following namespace within WebApiConfig.cs

using VMD.RESTApiResponseWrapper.Net;
using VMD.RESTApiResponseWrapper.Net.Filters;

2) Register the following within WebApiConfig.cs

  config.Filters.Add(new ApiExceptionFilter());
  config.MessageHandlers.Add(new WrappingHandler());

3) Done.

TO USE THE Custom API Exception, you could do:

throw new ApiException("Your Message",401, ModelStateExtension.AllErrors(ModelState));

The ApiException has the following parameters:

```````````````````````
ApiException(string message,
             int statusCode = 500,
             IEnumerable<ValidationError> errors = null, 
             string errorCode = "", 
             string refLink = "")
``````````````````````


