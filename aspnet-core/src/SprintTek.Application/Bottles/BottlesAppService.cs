

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using SprintTek.Bottles.Exporting;
using SprintTek.Bottles.Dtos;
using SprintTek.Dto;
using Abp.Application.Services.Dto;
using SprintTek.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;

namespace SprintTek.Bottles
{
	[AbpAuthorize(AppPermissions.Pages_Administration_Bottles)]
    public class BottlesAppService : SprintTekAppServiceBase, IBottlesAppService
    {
		 private readonly IRepository<Bottle> _bottleRepository;
		 private readonly IBottlesExcelExporter _bottlesExcelExporter;
		 

		  public BottlesAppService(IRepository<Bottle> bottleRepository, IBottlesExcelExporter bottlesExcelExporter ) 
		  {
			_bottleRepository = bottleRepository;
			_bottlesExcelExporter = bottlesExcelExporter;
			
		  }

		 public async Task<PagedResultDto<GetBottleForViewDto>> GetAll(GetAllBottlesInput input)
         {
			
			var filteredBottles = _bottleRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Name.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter),  e => e.Name == input.NameFilter)
						.WhereIf(input.ActiveFilter.HasValue && input.ActiveFilter > -1,  e => (input.ActiveFilter == 1 && e.Active) || (input.ActiveFilter == 0 && !e.Active) );

			var pagedAndFilteredBottles = filteredBottles
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

			var bottles = from o in pagedAndFilteredBottles
                         select new GetBottleForViewDto() {
							Bottle = new BottleDto
							{
                                Name = o.Name,
                                Active = o.Active,
                                Id = o.Id
							}
						};

            var totalCount = await filteredBottles.CountAsync();

            return new PagedResultDto<GetBottleForViewDto>(
                totalCount,
                await bottles.ToListAsync()
            );
         }
		 
		 public async Task<GetBottleForViewDto> GetBottleForView(int id)
         {
            var bottle = await _bottleRepository.GetAsync(id);

            var output = new GetBottleForViewDto { Bottle = ObjectMapper.Map<BottleDto>(bottle) };
			
            return output;
         }
		 
		 [AbpAuthorize(AppPermissions.Pages_Administration_Bottles_Edit)]
		 public async Task<GetBottleForEditOutput> GetBottleForEdit(EntityDto input)
         {
            var bottle = await _bottleRepository.FirstOrDefaultAsync(input.Id);
           
		    var output = new GetBottleForEditOutput {Bottle = ObjectMapper.Map<CreateOrEditBottleDto>(bottle)};
			
            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditBottleDto input)
         {
            if(input.Id == null){
				await Create(input);
			}
			else{
				await Update(input);
			}
         }

		 [AbpAuthorize(AppPermissions.Pages_Administration_Bottles_Create)]
		 protected virtual async Task Create(CreateOrEditBottleDto input)
         {
            var bottle = ObjectMapper.Map<Bottle>(input);

			
			if (AbpSession.TenantId != null)
			{
				bottle.TenantId = (int?) AbpSession.TenantId;
			}
		

            await _bottleRepository.InsertAsync(bottle);
         }

		 [AbpAuthorize(AppPermissions.Pages_Administration_Bottles_Edit)]
		 protected virtual async Task Update(CreateOrEditBottleDto input)
         {
            var bottle = await _bottleRepository.FirstOrDefaultAsync((int)input.Id);
             ObjectMapper.Map(input, bottle);
         }

		 [AbpAuthorize(AppPermissions.Pages_Administration_Bottles_Delete)]
         public async Task Delete(EntityDto input)
         {
            await _bottleRepository.DeleteAsync(input.Id);
         } 

		public async Task<FileDto> GetBottlesToExcel(GetAllBottlesForExcelInput input)
         {
			
			var filteredBottles = _bottleRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Name.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter),  e => e.Name == input.NameFilter)
						.WhereIf(input.ActiveFilter.HasValue && input.ActiveFilter > -1,  e => (input.ActiveFilter == 1 && e.Active) || (input.ActiveFilter == 0 && !e.Active) );

			var query = (from o in filteredBottles
                         select new GetBottleForViewDto() { 
							Bottle = new BottleDto
							{
                                Name = o.Name,
                                Active = o.Active,
                                Id = o.Id
							}
						 });


            var bottleListDtos = await query.ToListAsync();

            return _bottlesExcelExporter.ExportToFile(bottleListDtos);
         }


    }
}