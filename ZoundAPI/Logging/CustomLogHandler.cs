// using System;
// using System.Net.Http;
// using System.Threading;
// using System.Threading.Tasks;
// using ZoundAPI.DTOs;
//
// namespace ZoundAPI.Logging
// {
//     public class CustomLogHandler : DelegatingHandler
//     {
//         protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
//             CancellationToken cancellationToken)
//         {
//             var logMetadata = BuildRequestMetadata(request);
//             var response = await base.SendAsync(request, cancellationToken);
//             logMetadata = BuildResponseMetadata(logMetadata, response);
//             await SendToLog(logMetadata);
//             return response;
//         }
//         private LogMetadata BuildRequestMetadata(HttpRequestMessage request)
//         {
//             LogMetadata log = new LogMetadata
//             {
//                 RequestMethod = request.Method.Method,
//                 RequestTimestamp = DateTime.Now,
//                 RequestUri = request.RequestUri.ToString()
//             };
//             return log;
//         }
//         private LogMetadata BuildResponseMetadata(LogMetadata logMetadata, HttpResponseMessage response)
//         {
//             logMetadata.ResponseStatusCode = response.StatusCode;
//             logMetadata.ResponseTimestamp = DateTime.Now;
//             logMetadata.ResponseContentType = response.Content.Headers.ContentType.MediaType;
//             return logMetadata;
//         }
//         private async Task<bool> SendToLog(LogMetadata logMetadata)
//         {
//             
//             return true;
//         }
//     }
// }
