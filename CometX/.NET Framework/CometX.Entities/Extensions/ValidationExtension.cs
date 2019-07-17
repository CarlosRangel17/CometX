using System;

namespace CometX.Entities.Extensions
{
    public static class ValidationExtension
    {
        public static bool CheckURLValid(this string url)
        {
            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
