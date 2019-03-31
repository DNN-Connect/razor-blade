using System;
using System.Net;

namespace Connect.Razor.Internals
{
    internal class Html
    {
        /// <summary>
        /// Internal string-based commands to keep data simple till ready for output
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static string Encode(string value)
            => WebUtility.HtmlEncode(value)
                ?.Replace("&#39;", "&apos;");


        /// <summary>
        /// Internal string-based commands to keep data simple till ready for output
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static string Decode(string value)
            => WebUtility.HtmlDecode(value);

        internal static string ToJson(object jsonObject)
        {
#if NET40
            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(jsonObject);
#else
            throw new NotImplementedException(
                "Serialization for .net core hasn't been implemented yet, feel free to add this; " +
                "just make sure that the project still compiles and doesn't have new dependencies for the .net40 release");
#endif
        }

        internal const string SerializationErrorIntro = "Error: could not convert object to json - ";

        internal static string ToJsonOrErrorMessage(object jsonObject)
        {
            try
            {
                return ToJson(jsonObject);
            }
            catch (Exception e)
            {
                return SerializationErrorIntro + e.Message;
            }
        }
    }
}
