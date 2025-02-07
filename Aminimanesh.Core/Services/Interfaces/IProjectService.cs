using Aminimanesh.Core.DTOs.AttachmentDTOs;
using Aminimanesh.Core.DTOs.CategoryDTOs;
using Aminimanesh.Core.DTOs.ProjectDTOs;
using Aminimanesh.DataLayer.Entities.Owner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.Services.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectGeneralDTO> GetProjectByIdAsync(int projectId);
        Task<ProjectGeneralDTO> GetProjectByNameAsync(string projectName);
        Task<bool> CheckProjectNameExists(string projectName);
        Task<EditProjectDTO> GetProjectByIdForEditAsync(int projectId);

        Task<List<ProjectListItemDTO>> GetProjectsAsync(int categoryId = 0, string filter = "");

        Task<int> AddProjectAsync(CreateProjectDTO projectDTO);
        Task<int> UpdateProjectAsync(EditProjectDTO projectDTO);

        Task RemoveProjectByIdAsync(int projectId);

        Task AddAttachmentToProjectAsync(CreateAttachmentDTO attachmentDTO);

        Task<AttachmentListItemDTO> GetAttachmentById(int attachmentId);
        Task RemoveAttachmentByIdAsync(int attachmentId);

        Task<int> UpdateAttachment(int attachmentId, string attachmentName, string shortDescription, int priority);

        Task<Tuple<List<CategoryListItemDTO>, int>> GetCategoriesForFilter();

        #region Category
        Task<List<CategoryListItemDTO>> GetAllCategoriesForSelectAsync();
        Task<List<CategoryListItemDTO>> GetAllCategoriesAsync();

        Task<int> AddCategoryAsync(Category category);

        Task<int> UpdateCategoryAsync(Category category);

        Task<Category> GetCategoryByIdAsync(int categoryId);

        Task RemoveCategoryByIdAsync(int categoryId);
        #endregion
    }
}
