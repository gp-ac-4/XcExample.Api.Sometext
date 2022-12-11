using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.StaticFiles;

namespace XcExample.Api.Sometext.System
{
    /// <summary>
    /// container class for static file configurations
    /// </summary>
    public class StaticFileConfiguration
    {
        /// <summary>
        /// create static file options for nex files
        /// </summary>
        /// <returns></returns>
        public static StaticFileOptions Get()
        {
            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".nex"] = "application/octect-stream";
            provider.Mappings[".yaml"] = "application/json";

            return new StaticFileOptions { ContentTypeProvider = provider };
        }

    }
}
