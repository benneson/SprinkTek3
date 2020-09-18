using SprintTek.Phonebook;


using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using SprintTek.Phonebook.Phonebook.Exporting;
using SprintTek.Phonebook.Phonebook.Dtos;
using SprintTek.Dto;
using Abp.Application.Services.Dto;
using SprintTek.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;

namespace SprintTek.Phonebook.Phonebook
{
	[AbpAuthorize(AppPermissions.Pages_Administration_Phonebooks)]
    public class PhonebooksAppService : SprintTekAppServiceBase, IPhonebooksAppService
    {
		 private readonly IRepository<Phonebook> _phonebookRepository;
		 private readonly IPhonebooksExcelExporter _phonebooksExcelExporter;
		 private readonly IRepository<Person,int> _lookup_personRepository;
		 

		  public PhonebooksAppService(IRepository<Phonebook> phonebookRepository, IPhonebooksExcelExporter phonebooksExcelExporter , IRepository<Person, int> lookup_personRepository) 
		  {
			_phonebookRepository = phonebookRepository;
			_phonebooksExcelExporter = phonebooksExcelExporter;
			_lookup_personRepository = lookup_personRepository;
		
		  }

		 public async Task<PagedResultDto<GetPhonebookForViewDto>> GetAll(GetAllPhonebooksInput input)
         {
			
			var filteredPhonebooks = _phonebookRepository.GetAll()
						.Include( e => e.PersonFk)
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Name.Contains(input.Filter) || e.Surname.Contains(input.Filter) || e.Email.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter),  e => e.Name == input.NameFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.SurnameFilter),  e => e.Surname == input.SurnameFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.EmailFilter),  e => e.Email == input.EmailFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.PersonNameFilter), e => e.PersonFk != null && e.PersonFk.Name == input.PersonNameFilter);

			var pagedAndFilteredPhonebooks = filteredPhonebooks
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

			var phonebooks = from o in pagedAndFilteredPhonebooks
                         join o1 in _lookup_personRepository.GetAll() on o.PersonId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()
                         
                         select new GetPhonebookForViewDto() {
							Phonebook = new PhonebookDto
							{
                                Name = o.Name,
                                Surname = o.Surname,
                                Email = o.Email,
                                Id = o.Id
							},
                         	PersonName = s1 == null || s1.Name == null ? "" : s1.Name.ToString()
						};

            var totalCount = await filteredPhonebooks.CountAsync();

            return new PagedResultDto<GetPhonebookForViewDto>(
                totalCount,
                await phonebooks.ToListAsync()
            );
         }
		 
		 public async Task<GetPhonebookForViewDto> GetPhonebookForView(int id)
         {
            var phonebook = await _phonebookRepository.GetAsync(id);

            var output = new GetPhonebookForViewDto { Phonebook = ObjectMapper.Map<PhonebookDto>(phonebook) };

		    if (output.Phonebook.PersonId != null)
            {
                var _lookupPerson = await _lookup_personRepository.FirstOrDefaultAsync((int)output.Phonebook.PersonId);
                output.PersonName = _lookupPerson?.Name?.ToString();
            }
			
            return output;
         }
		 
		 [AbpAuthorize(AppPermissions.Pages_Administration_Phonebooks_Edit)]
		 public async Task<GetPhonebookForEditOutput> GetPhonebookForEdit(EntityDto input)
         {
            var phonebook = await _phonebookRepository.FirstOrDefaultAsync(input.Id);
           
		    var output = new GetPhonebookForEditOutput {Phonebook = ObjectMapper.Map<CreateOrEditPhonebookDto>(phonebook)};

		    if (output.Phonebook.PersonId != null)
            {
                var _lookupPerson = await _lookup_personRepository.FirstOrDefaultAsync((int)output.Phonebook.PersonId);
                output.PersonName = _lookupPerson?.Name?.ToString();
            }
			
            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditPhonebookDto input)
         {
            if(input.Id == null){
				await Create(input);
			}
			else{
				await Update(input);
			}
         }

		 [AbpAuthorize(AppPermissions.Pages_Administration_Phonebooks_Create)]
		 protected virtual async Task Create(CreateOrEditPhonebookDto input)
         {
            var phonebook = ObjectMapper.Map<Phonebook>(input);

			
			if (AbpSession.TenantId != null)
			{
				phonebook.TenantId = (int?) AbpSession.TenantId;
			}
		

            await _phonebookRepository.InsertAsync(phonebook);
         }

		 [AbpAuthorize(AppPermissions.Pages_Administration_Phonebooks_Edit)]
		 protected virtual async Task Update(CreateOrEditPhonebookDto input)
         {
            var phonebook = await _phonebookRepository.FirstOrDefaultAsync((int)input.Id);
             ObjectMapper.Map(input, phonebook);
         }

		 [AbpAuthorize(AppPermissions.Pages_Administration_Phonebooks_Delete)]
         public async Task Delete(EntityDto input)
         {
            await _phonebookRepository.DeleteAsync(input.Id);
         } 

		public async Task<FileDto> GetPhonebooksToExcel(GetAllPhonebooksForExcelInput input)
         {
			
			var filteredPhonebooks = _phonebookRepository.GetAll()
						.Include( e => e.PersonFk)
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Name.Contains(input.Filter) || e.Surname.Contains(input.Filter) || e.Email.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter),  e => e.Name == input.NameFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.SurnameFilter),  e => e.Surname == input.SurnameFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.EmailFilter),  e => e.Email == input.EmailFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.PersonNameFilter), e => e.PersonFk != null && e.PersonFk.Name == input.PersonNameFilter);

			var query = (from o in filteredPhonebooks
                         join o1 in _lookup_personRepository.GetAll() on o.PersonId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()
                         
                         select new GetPhonebookForViewDto() { 
							Phonebook = new PhonebookDto
							{
                                Name = o.Name,
                                Surname = o.Surname,
                                Email = o.Email,
                                Id = o.Id
							},
                         	PersonName = s1 == null || s1.Name == null ? "" : s1.Name.ToString()
						 });


            var phonebookListDtos = await query.ToListAsync();

            return _phonebooksExcelExporter.ExportToFile(phonebookListDtos);
         }



		[AbpAuthorize(AppPermissions.Pages_Administration_Phonebooks)]
         public async Task<PagedResultDto<PhonebookPersonLookupTableDto>> GetAllPersonForLookupTable(GetAllForLookupTableInput input)
         {
             var query = _lookup_personRepository.GetAll().WhereIf(
                    !string.IsNullOrWhiteSpace(input.Filter),
                   e=> e.Name != null && e.Name.Contains(input.Filter)
                );

            var totalCount = await query.CountAsync();

            var personList = await query
                .PageBy(input)
                .ToListAsync();

			var lookupTableDtoList = new List<PhonebookPersonLookupTableDto>();
			foreach(var person in personList){
				lookupTableDtoList.Add(new PhonebookPersonLookupTableDto
				{
					Id = person.Id,
					DisplayName = person.Name?.ToString()
				});
			}

            return new PagedResultDto<PhonebookPersonLookupTableDto>(
                totalCount,
                lookupTableDtoList
            );
         }
    }
}