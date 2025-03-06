using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.Security;

public static class ImageValidator
{
	// Checks the file is type of image or not
	public static bool IsImage(this IFormFile file)
	{
		if (file == null || file.Length == 0)
			return false;

		using (var stream = file.OpenReadStream())
		{
			var headers = new Dictionary<string, byte[]>
				{
					{ ".jpg", new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 } },
					{ ".png", new byte[] { 0x89, 0x50, 0x4E, 0x47 } },
					{ ".bmp", new byte[] { 0x42, 0x4D } },
					{ ".gif", new byte[] { 0x47, 0x49, 0x46, 0x38 } },
					{ ".svg", Encoding.UTF8.GetBytes("<svg") }
				};

			var fileExtension = Path.GetExtension(file.FileName).ToLower();
			if (!headers.ContainsKey(fileExtension))
				return false;

			var header = headers[fileExtension];
			var buffer = new byte[header.Length];
			stream.Read(buffer, 0, buffer.Length);

			return buffer.SequenceEqual(header);
		}
	}
}
