using Aminimanesh.Core.Generators;
using Microsoft.AspNetCore.Http;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.Tools
{
    public class FileTools
    {
        public static string SaveFile(IFormFile file, string saveFolderPath, bool deletePreviousFile = false, string prevFileName = "")
        {
            if (deletePreviousFile)
            {
                DeletePreviousFile(saveFolderPath, prevFileName);
            }

            string fileName = TextGenerator.GenerateUniqeCode() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), saveFolderPath, fileName);
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), saveFolderPath);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return fileName;
        }

        // Save the file with out changing its name to a unique code (save the file with its own name)
        public static void SaveFileWithItsName(IFormFile file, string saveFolderPath, bool deletePreviousFile = false, string prevFileName = "")
        {
            if (deletePreviousFile)
            {
                DeletePreviousFile(saveFolderPath, prevFileName);
            }

            string fileName = file.FileName;
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), saveFolderPath, fileName);
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), saveFolderPath);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }

        public static void SaveFileWithCustomName(IFormFile file, string fileName, string saveFolderPath, bool deletePreviousFile = false, string prevFileName = "")
        {
            if (deletePreviousFile)
            {
                DeletePreviousFile(saveFolderPath, prevFileName);
            }

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), saveFolderPath, fileName);
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), saveFolderPath);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }

        // Check the file is exists or not
        public static bool IsFileExists(IFormFile file, string saveFolderPath)
        {
            string fileName = file.FileName;
            string checkPath = Path.Combine(Directory.GetCurrentDirectory(), saveFolderPath, fileName);
            return File.Exists(checkPath);
        }

        // Check the file path is exists or not
        public static bool IsFileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public static void DeletePreviousFile(string saveFolderPath, string prevFileName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), saveFolderPath, prevFileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static async Task SaveThumbnailAsync(string imagePath, string saveThumbnailPath)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (Image image = Image.FromFile(imagePath))
                    {
                        int thumbnailWidth = 400;
                        int thumbnailHeight = 400;

                        int newWidth, newHeight;
                        if (image.Width > image.Height)
                        {
                            newWidth = thumbnailWidth;
                            newHeight = (int)(image.Height * ((float)thumbnailWidth / image.Width));
                        }
                        else
                        {
                            newWidth = (int)(image.Width * ((float)thumbnailHeight / image.Height));
                            newHeight = thumbnailHeight;
                        }

                        using (Image thumbnail = image.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero))
                        {
                            // Estimate thumbnail size after compression
                            long estimatedThumbnailSize = EstimateImageSize(thumbnail);

                            // Get original image size
                            long originalSize = new FileInfo(imagePath).Length;

                            // set quality based on estimated size
                            int quality = 100; // Starting quality
                            while (estimatedThumbnailSize > originalSize && quality > 10) // You can adjust the minimum quality as needed
                            {
                                // Decrease quality and re-encode thumbnail
                                quality -= 10;
                                var encoder = ImageCodecInfo.GetImageEncoders().FirstOrDefault(enc => enc.FormatID == ImageFormat.Jpeg.Guid);
                                var encoderParams = new EncoderParameters(1);
                                encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

                                using (MemoryStream ms = new MemoryStream())
                                {
                                    thumbnail.Save(ms, encoder, encoderParams);
                                    estimatedThumbnailSize = ms.Length;
                                }
                            }
                           
                            // Save the final thumbnail
                            thumbnail.Save(saveThumbnailPath, ImageFormat.Jpeg);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error generating thumbnail: {ex.Message}");
                }
            });
        }

        public static async Task SaveThumbnailCustomWidthAsync(string imagePath, string saveThumbnailPath, int width)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (Image image = Image.FromFile(imagePath))
                    {
                        int thumbnailWidth = width;
                        int thumbnailHeight = width;

                        int newWidth, newHeight;
                        if (image.Width > image.Height)
                        {
                            newWidth = thumbnailWidth;
                            newHeight = (int)(image.Height * ((float)thumbnailWidth / image.Width));
                        }
                        else
                        {
                            newWidth = (int)(image.Width * ((float)thumbnailHeight / image.Height));
                            newHeight = thumbnailHeight;
                        }

                        using (Image thumbnail = image.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero))
                        {
                            // Estimate thumbnail size after compression
                            long estimatedThumbnailSize = EstimateImageSize(thumbnail);

                            // Get original image size
                            long originalSize = new FileInfo(imagePath).Length;

                            // set quality based on estimated size
                            int quality = 100; // Starting quality
                            while (estimatedThumbnailSize > originalSize && quality > 10) // You can adjust the minimum quality as needed
                            {
                                // Decrease quality and re-encode thumbnail
                                quality -= 10;
                                var encoder = ImageCodecInfo.GetImageEncoders().FirstOrDefault(enc => enc.FormatID == ImageFormat.Jpeg.Guid);
                                var encoderParams = new EncoderParameters(1);
                                encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

                                using (MemoryStream ms = new MemoryStream())
                                {
                                    thumbnail.Save(ms, encoder, encoderParams);
                                    estimatedThumbnailSize = ms.Length;
                                }
                            }

                            // Save the final thumbnail
                            thumbnail.Save(saveThumbnailPath, ImageFormat.Jpeg);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error generating thumbnail: {ex.Message}");
                }
            });
        }

        private static long EstimateImageSize(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                return ms.Length;
            }
        }

        public static void ExtractFile(string rarPath, string fileName, string extractPath)
        {
            if (File.Exists(rarPath))
            {
                using (Stream stream = File.OpenRead(rarPath))
                {
                    var reader = RarArchive.Open(stream);
                    foreach (var entry in reader.Entries)
                    {
                        if (!entry.IsDirectory && entry.Key.Equals(fileName))
                        {
                            if (!Directory.Exists(extractPath))
                            {
                                Directory.CreateDirectory(extractPath);
                            }
                            entry.WriteToDirectory(extractPath, new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
                            break;
                        }
                    }
                }
            }
        }

    }
}
