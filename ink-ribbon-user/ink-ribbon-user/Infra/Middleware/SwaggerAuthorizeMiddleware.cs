namespace ink_ribbon_user.Infra.Middleware
{
    public class SwaggerAuthorizeMiddleware
    {
        private readonly RequestDelegate _next;

        public SwaggerAuthorizeMiddleware(RequestDelegate next) { _next = next; }


        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                if (string.IsNullOrWhiteSpace(context.Request.Headers["Authorization"]))
                {
                    AuthHeader(context);
                }
            }
        }

        private void AuthHeader(HttpContext context)
        {
            var res = context.Response;
            res.StatusCode = 401;
            res.Headers.Append("WWW-Authenticate", "Basic realm=\"Way\"");
        }

    }
}