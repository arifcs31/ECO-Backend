using Shopex.Domain.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopex.Application.Extensions
{
    public  static class StringExtensions
    {
        public static string SaveFile(this string resourcerBase64, MediaConfiguration mediaConfiguration)
        {
            if (string.IsNullOrEmpty(resourcerBase64) || resourcerBase64.Contains("http"))
                return resourcerBase64;
            string imageExtension = "png";
            Guid fileId = Guid.NewGuid();
            string fileName = fileId + "." + imageExtension;
            string filePath = $"{mediaConfiguration.FtpPath}/banners/{fileName}";
            string[] image = resourcerBase64.Split(',');
            File.WriteAllBytes(filePath, Convert.FromBase64String(image[1]));

            return $"{mediaConfiguration.HostingPath}/banners/{fileName}";
        }
    }
}
