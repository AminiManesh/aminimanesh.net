using Aminimanesh.Core.DTOs.AttachmentDTOs;
using Aminimanesh.Core.DTOs.ProjectDTOs;
using Aminimanesh.Core.Generators;
using Aminimanesh.Core.Security;
using Aminimanesh.Core.Services.Interfaces;
using Aminimanesh.Core.Tools;
using Aminimanesh.DataLayer.Entities.Owner;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using Newtonsoft.Json;

namespace Aminimanesh.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [Route("projects-list")]
        public async Task<IActionResult> Index()
        {
            var projects = await _projectService.GetProjectsAsync();
            return View(projects);
        }

        [Route("create-project")]
        public async Task<IActionResult> CreateProject()
        {
            var categories = (await _projectService.GetAllCategoriesForSelectAsync()).Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.Title });
            var list = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Select category..." }
            };
            list.AddRange(categories);
            ViewData["Categories"] = new SelectList(list, "Value", "Text", 0);

            return View();
        }

        [HttpPost]
        [Route("create-project")]
        public async Task<IActionResult> CreateProject(CreateProjectDTO project)
        {
            if (!ModelState.IsValid)
            {
                var categories = (await _projectService.GetAllCategoriesForSelectAsync()).Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.Title });
                var list = new List<SelectListItem>()
                {
                    new SelectListItem { Value = "0", Text = "Select category..." }
                };
                list.AddRange(categories);
                ViewData["Categories"] = new SelectList(list, "Value", "Text", project.CategoryId);
                return View(project);
            }

            if (await _projectService.CheckProjectNameExists(project.Title))
            {
                var categories = (await _projectService.GetAllCategoriesForSelectAsync()).Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.Title });
                var list = new List<SelectListItem>()
                {
                    new SelectListItem { Value = "0", Text = "Select category..." }
                };
                list.AddRange(categories);
                ViewData["Categories"] = new SelectList(list, "Value", "Text", project.CategoryId);
                ModelState.AddModelError("Title", "نام پروژه قبلا استفاده شده است.");
                return View(project);
            }

            var projectId = await _projectService.AddProjectAsync(project);

            if (project.Thumbnail != null && project.Thumbnail.Length > 0)
            {
                if (ImageValidator.IsImage(project.Thumbnail))
                {
                    var savePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/owner/projects/{projectId}/cover/");
                    FileTools.SaveFileWithItsName(project.Thumbnail, savePath);

                    var saveThumbPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/owner/projects/{projectId}/cover/thumbnail/");
                    var saveThumbPathFull = Path.Combine(saveThumbPath, project.Thumbnail.FileName);

                    if (!Directory.Exists(saveThumbPath))
                    {
                        Directory.CreateDirectory(saveThumbPath);
                    }

                    await FileTools.SaveThumbnailAsync(Path.Combine(savePath, project.Thumbnail.FileName), saveThumbPathFull);
                }
                else
                {
                    var categories = (await _projectService.GetAllCategoriesForSelectAsync()).Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.Title });
                    var list = new List<SelectListItem>()
                    {
                        new SelectListItem { Value = "0", Text = "Select category..." }
                    };
                    list.AddRange(categories);
                    ViewData["Categories"] = new SelectList(list, "Value", "Text", project.CategoryId);
                    ModelState.AddModelError("Thumbnail", "فایلی که برای کاور پروژه انتخاب می‌کنید باید از نوع عکس باشد.");
                    return View(project);
                }
            }

            return RedirectToAction("Index");
        }

        [Route("edit-project")]
        public async Task<IActionResult> EditProject(int id)
        {
            var project = await _projectService.GetProjectByIdForEditAsync(id);
            var categories = (await _projectService.GetAllCategoriesForSelectAsync()).Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.Title });
            var list = new List<SelectListItem>()
            {
                new SelectListItem { Value = "0", Text = "Select category..." }
            };
            list.AddRange(categories);
            ViewData["Categories"] = new SelectList(list, "Value", "Text", project.CategoryId);

            return View(project);
        }

        [HttpPost]
        [Route("edit-project")]
        public async Task<IActionResult> EditProject(EditProjectDTO project, IFormFile? cover)
        {
            if (!ModelState.IsValid)
            {
                var categories = (await _projectService.GetAllCategoriesForSelectAsync()).Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.Title });
                var list = new List<SelectListItem>()
                {
                    new SelectListItem { Value = "0", Text = "Select category..." }
                };
                list.AddRange(categories);
                ViewData["Categories"] = new SelectList(list, "Value", "Text", project.CategoryId);
                return View(project);
            }

            if (cover != null && cover.Length > 0)
            {
                if (ImageValidator.IsImage(cover))
                {
                    var savePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/owner/projects/{project.ProjectId}/cover/");
                    FileTools.SaveFileWithItsName(cover, savePath, true, project.Thumbnail);

                    var saveThumbPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/owner/projects/{project.ProjectId}/cover/thumbnail/");
                    var saveThumbPathFull = Path.Combine(saveThumbPath, cover.FileName);

                    if (!Directory.Exists(saveThumbPath))
                    {
                        Directory.CreateDirectory(saveThumbPath);
                    }

                    FileTools.DeletePreviousFile(saveThumbPath, project.Thumbnail);
                    await FileTools.SaveThumbnailAsync(Path.Combine(savePath, cover.FileName), saveThumbPathFull);
                   
                    project.Thumbnail = cover.FileName;
                }
                else
                {
                    var categories = (await _projectService.GetAllCategoriesForSelectAsync()).Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.Title });
                    var list = new List<SelectListItem>()
                    {
                        new SelectListItem { Value = "0", Text = "Select category..." }
                    };
                    list.AddRange(categories);
                    ViewData["Categories"] = new SelectList(list, "Value", "Text", project.CategoryId);
                    ModelState.AddModelError("Thumbnail", "فایلی که برای کاور پروژه انتخاب می‌کنید باید از نوع عکس باشد.");
                    return View(project);
                }
            }

            await _projectService.UpdateProjectAsync(project);

            return RedirectToAction("Index");
        }

        [Route("delete-project")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _projectService.RemoveProjectByIdAsync(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("upload-attachment")]
        public async Task<IActionResult> UploadAttachment([FromForm] List<IFormFile> files, int projectId)
        {
            if (files != null && files.Any() && projectId > 0)
            {
                foreach (var file in files)
                {
                    bool isImage = false;
                    string fileName = TextGenerator.GenerateUniqeCode() + Path.GetExtension(file.FileName);
                    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/owner/projects/{projectId}/attachments/");

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    var fullPath = Path.Combine(path, fileName);

                    FileTools.SaveFileWithCustomName(file, fileName, path, true, fileName);

                    if (ImageValidator.IsImage(file))
                    {
                        isImage = true;
                        string thumbnailPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/owner/projects/{projectId}/attachments/thumbnails/");

                        if (!Directory.Exists(thumbnailPath))
                        {
                            Directory.CreateDirectory(thumbnailPath);
                        }

                        var fullThumbnailPath = Path.Combine(thumbnailPath, fileName);

                        await FileTools.SaveThumbnailAsync(fullPath, fullThumbnailPath);
                    }

                    CreateAttachmentDTO attachmentDTO = new CreateAttachmentDTO()
                    {
                        FileName = fileName,
                        IsImage = isImage,
                        ProjectId = projectId,
                        ShowName = file.FileName,
                        ShortDescription = ""
                    };

                    await _projectService.AddAttachmentToProjectAsync(attachmentDTO);

                    var response = JsonConvert.SerializeObject(new { info = $"{file.FileName} uploaded successfully." });
                    return new JsonResult(response);
                }
            }

            return new JsonResult(new { info = "There was a problem uploading the file!" });
        }

        [Route("delete-attachment")]
        public async Task<IActionResult> DeleteAttachment(int id)
        {
            var attachment = await _projectService.GetAttachmentById(id);
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/owner/projects/{attachment.ProjectId}/attachments/");
            var thumbPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/owner/projects/{attachment.ProjectId}/attachments/thumbnails/");
            FileTools.DeletePreviousFile(path, attachment.FileName);
            FileTools.DeletePreviousFile(thumbPath, attachment.FileName);

            await _projectService.RemoveAttachmentByIdAsync(id);
            return new JsonResult(new { success = true, message = "Attachment removed successfuly." });
        }

        [Route("download-attachment")]
        public async Task<IActionResult> DownloadAttachment(int id)
        {
            try
            {
                var attachment = await _projectService.GetAttachmentById(id);
                var fileName = attachment.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/owner/projects/{attachment.ProjectId}/attachments/");

                var fullPath = Path.Combine(path, fileName);

                // Check if the file exists
                if (!System.IO.File.Exists(fullPath))
                {
                    return NotFound(); // Return 404 Not Found if the file does not exist
                }

                var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true);
                return File(stream, "application/force-download", attachment.ShowName);
            }
            catch (Exception ex)
            {
                // Log any exceptions
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Route("edit-attachment")]
        public async Task<IActionResult> EditAttachment(int attachmentId, string attachmentName, string shortDescription, int priority)
        {
            await _projectService.UpdateAttachment(attachmentId, attachmentName, shortDescription, priority);
            return new JsonResult(new { success = true });
        }

        [Route("categories")]
        public async Task<IActionResult> Categories()
        {
            var model = await _projectService.GetAllCategoriesAsync();
            return View(model);
        }

        [Route("create-category")]
        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [Route("create-category")]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            await _projectService.AddCategoryAsync(category);

            return RedirectToAction("Categories");
        }

        [Route("edit-category")]
        public async Task<IActionResult> EditCategory(int id)
        {
            var model = await _projectService.GetCategoryByIdAsync(id);
            return View(model);
        }

        [HttpPost]
        [Route("edit-category")]
        public async Task<IActionResult> EditCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            await _projectService.UpdateCategoryAsync(category);

            return RedirectToAction("Categories");
        }

        [Route("delete-category")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _projectService.RemoveCategoryByIdAsync(id);
            return RedirectToAction("Categories");
        }
    }
}
