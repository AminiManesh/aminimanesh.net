using Aminimanesh.Core.DTOs.AttachmentDTOs;
using Aminimanesh.Core.DTOs.CategoryDTOs;
using Aminimanesh.Core.DTOs.ProjectDTOs;
using Aminimanesh.Core.Services.Interfaces;
using Aminimanesh.DataLayer.Context;
using Aminimanesh.DataLayer.Entities.Owner;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly AminimaneshContext _context;
        private readonly IMapper _mapper;
        public ProjectService(AminimaneshContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task AddAttachmentToProjectAsync(CreateAttachmentDTO attachmentDTO)
        {
            var attachment = _mapper.Map<Attachment>(attachmentDTO);
            await _context.Attachments.AddAsync(attachment);
            await _context.SaveChangesAsync();
        }

        public async Task<int> AddCategoryAsync(Category category)
        {
            category.UrlTitle = category.Title.Trim().Replace(" ", "-");
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category.CategoryId;
        }

        public async Task<int> AddProjectAsync(CreateProjectDTO projectDTO)
        {
            var project = _mapper.Map<Project>(projectDTO);
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return project.ProjectId;
        }

        public async Task<bool> CheckProjectNameExists(string projectName)
        {
            bool exists = await _context.Projects.AnyAsync(p => p.UrlTitle == projectName);
            return exists;
        }

        public async Task<int> UpdateAttachment(int attachmentId, string attachmentName, string shortDescription, int priority)
        {
            var attachment = await _context.Attachments.FindAsync(attachmentId);
            attachment.ShowName = attachmentName;
            attachment.ShortDescription = shortDescription;
            attachment.Priority = priority;
            _context.Attachments.Update(attachment);
            await _context.SaveChangesAsync();
            return attachment.AttachmentId;
        }

        public async Task<List<CategoryListItemDTO>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.Include(c => c.Projects).ToListAsync();
            return _mapper.Map<List<CategoryListItemDTO>>(categories);
        }

        public async Task<List<CategoryListItemDTO>> GetAllCategoriesForSelectAsync()
        {
            var categories = await _context.Categories
                .IgnoreQueryFilters()
                .ToListAsync();
            return _mapper.Map<List<CategoryListItemDTO>>(categories);
        }

        public async Task<AttachmentListItemDTO> GetAttachmentById(int attachmentId)
        {
            var attachment = await _context.Attachments.FindAsync(attachmentId);
            return _mapper.Map<AttachmentListItemDTO>(attachment);
        }

        public async Task<Tuple<List<CategoryListItemDTO>, int>> GetCategoriesForFilter()
        {
            var categories = await _context.Categories.Include(c => c.Projects).ToListAsync();
            var categoriesDTO = _mapper.Map<List<CategoryListItemDTO>>(categories);

            var projectsCount = await _context.Projects.CountAsync();
            return Tuple.Create(categoriesDTO, projectsCount);
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }

        public async Task<ProjectGeneralDTO> GetProjectByIdAsync(int projectId)
        {
            var project = await _context.Projects
                .IgnoreQueryFilters()
                .Include(p => p.Category)
                .Include(p => p.Attachments)
                .SingleAsync(p => p.ProjectId == projectId);
            return _mapper.Map<ProjectGeneralDTO>(project);
        }

        public async Task<EditProjectDTO> GetProjectByIdForEditAsync(int projectId)
        {
            var proj = await _context.Projects.Include(p => p.Attachments.OrderBy(a => a.Priority)).SingleOrDefaultAsync(p => p.ProjectId == projectId);
            return _mapper.Map<EditProjectDTO>(proj);
        }

        public async Task<ProjectGeneralDTO> GetProjectByNameAsync(string projectName)
        {
            var project = await _context.Projects
                .IgnoreQueryFilters()
                .Include(p => p.Category)
                .Include(p => p.Attachments.OrderBy(a => a.Priority))
                .SingleAsync(p => p.UrlTitle == projectName && !p.IsDeleted);
            return _mapper.Map<ProjectGeneralDTO>(project);
        }

        public async Task<List<ProjectListItemDTO>> GetProjectsAsync(int categoryId = 0, string filter = "")
        {
            IQueryable<Project> result = _context.Projects
                .IgnoreQueryFilters()
                .Include(p => p.Category)
                .Where(p => !p.IsDeleted)
                .OrderBy(p => p.Priority);

            if (categoryId > 0)
            {
                result = result.Where(p => p.CategoryId == categoryId);
            }

            if (!string.IsNullOrEmpty(filter))
            {
                result = result
                    .Where
                        (
                            p =>
                            EF.Functions.Like(p.Title, $"%{filter}%") ||
                            EF.Functions.Like(p.Description, $"%{filter}%") ||
                            EF.Functions.Like(p.ShortDescription, $"%{filter}%")
                        );
            }

            return _mapper.Map<List<ProjectListItemDTO>>(await result.ToListAsync());
        }

        public async Task RemoveAttachmentByIdAsync(int attachmentId)
        {
            var attachment = await _context.Attachments.FindAsync(attachmentId);
            _context.Attachments.Remove(attachment);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCategoryByIdAsync(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            category.IsDeleted = true;
            await UpdateCategoryAsync(category);
        }

        public async Task RemoveProjectByIdAsync(int projectId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            project.IsDeleted = true;
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateCategoryAsync(Category category)
        {
            category.UrlTitle = category.Title.Trim().Replace(" ", "-");
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category.CategoryId;
        }

        public async Task<int> UpdateProjectAsync(EditProjectDTO projectDTO)
        {
            var project = _mapper.Map<Project>(projectDTO);
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return project.ProjectId;
        }
    }
}
