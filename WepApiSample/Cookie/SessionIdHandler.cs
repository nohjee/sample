using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WepApiSample.Cookie
{
    public class SessionIdHandler : DelegatingHandler
    {
        static public string SessionIdToken = "session-id";

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string sessionId;

            // 요청에서 세션 ID를 가져오려고 시도하고, 없으면 새 ID를 생성한다.
            var cookie = request.Headers.GetCookies(SessionIdToken).FirstOrDefault();
            if (cookie == null)
            {
                sessionId = Guid.NewGuid().ToString();
            }
            else
            {
                sessionId = cookie[SessionIdToken].Value;
                try
                {
                    Guid guid = Guid.Parse(sessionId);
                }
                catch (FormatException)
                {
                    // 유효하지 않은 세션 ID. 새로운 ID를 생성한다.
                    sessionId = Guid.NewGuid().ToString();
                }
            }

            // 세션 ID를 요청의 프로퍼티 백에 저장한다.
            request.Properties[SessionIdToken] = sessionId;

            // HTTP 요청을 계속 처리한다.
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            // 응답 메시지에 세션 ID를 쿠키로 추가한다.
            response.Headers.AddCookies(new CookieHeaderValue[] {
                new CookieHeaderValue(SessionIdToken, sessionId)
            });

            return response;
        }
    }
}