

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using SprintTek.Docs.Exporting;
using SprintTek.Docs.Dtos;
using SprintTek.Dto;
using Abp.Application.Services.Dto;
using SprintTek.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;

namespace SprintTek.Docs
{
	[AbpAuthorize(AppPermissions.Pages_Administration_Docs)]
    public class DocsAppService : SprintTekAppServiceBase, IDocsAppService
    {
		 private readonly IRepository<Doc> _docRepository;
		 private readonly IDocsExcelExporter _docsExcelExporter;
		 

		  public DocsAppService(IRepository<Doc> docRepository, IDocsExcelExporter docsExcelExporter ) 
		  {
			_docRepository = docRepository;
			_docsExcelExporter = docsExcelExporter;
			
		  }

		 public async Task<PagedResultDto<GetDocForViewDto>> GetAll(GetAllDocsInput input)
         {
			
			var filteredDocs = _docRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.name.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.nameFilter),  e => e.name == input.nameFilter)
						.WhereIf(input.ActiveFilter.HasValue && input.ActiveFilter > -1,  e => (input.ActiveFilter == 1 && e.Active) || (input.ActiveFilter == 0 && !e.Active) );

			var pagedAndFilteredDocs = filteredDocs
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

			var docs = from o in pagedAndFilteredDocs
                         select new GetDocForViewDto() {
							Doc = new DocDto
							{
                                name = o.name,
                                Active = o.Active,
                                Id = o.Id
							}
						};

            var totalCount = await filteredDocs.CountAsync();

            return new PagedResultDto<GetDocForViewDto>(
                totalCount,
                await docs.ToListAsync()
            );
         }
		 
		 public async Task<GetDocForViewDto> GetDocForView(int id)
         {
            var doc = await _docRepository.GetAsync(id);

            var output = new GetDocForViewDto { Doc = ObjectMapper.Map<DocDto>(doc) };
			
            return output;
         }
		 
		 [AbpAuthorize(AppPermissions.Pages_Administration_Docs_Edit)]
		 public async Task<GetDocForEditOutput> GetDocForEdit(EntityDto input)
         {
            var doc = await _docRepository.FirstOrDefaultAsync(input.Id);
           
		    var output = new GetDocForEditOutput {Doc = ObjectMapper.Map<CreateOrEditDocDto>(doc)};
			
            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditDocDto input)
         {
            if(input.Id == null){
				await Create(input);
			}
			else{
				await Update(input);
			}
         }

		 [AbpAuthorize(AppPermissions.Pages_Administration_Docs_Create)]
		 protected virtual async Task Create(CreateOrEditDocDto input)
         {
            var doc = ObjectMapper.Map<Doc>(input);

			
			if (AbpSession.TenantId != null)
			{
				doc.TenantId = (int?) AbpSession.TenantId;
			}
		

            await _docRepository.InsertAsync(doc);
         }

		 [AbpAuthorize(AppPermissions.Pages_Administration_Docs_Edit)]
		 protected virtual async Task Update(CreateOrEditDocDto input)
         {
            var doc = await _docRepository.FirstOrDefaultAsync((int)input.Id);
             ObjectMapper.Map(input, doc);
         }

		 [AbpAuthorize(AppPermissions.Pages_Administration_Docs_Delete)]
         public async Task Delete(EntityDto input)
         {
            await _docRepository.DeleteAsync(input.Id);
         } 

		public async Task<FileDto> GetDocsToExcel(GetAllDocsForExcelInput input)
         {
			
			var filteredDocs = _docRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.name.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.nameFilter),  e => e.name == input.nameFilter)
						.WhereIf(input.ActiveFilter.HasValue && input.ActiveFilter > -1,  e => (input.ActiveFilter == 1 && e.Active) || (input.ActiveFilter == 0 && !e.Active) );

			var query = (from o in filteredDocs
                         select new GetDocForViewDto() { 
							Doc = new DocDto
							{
                                name = o.name,
                                Active = o.Active,
                                Id = o.Id
							}
						 });


            var docListDtos = await query.ToListAsync();

            return _docsExcelExporter.ExportToFile(docListDtos);
         }


    }
}