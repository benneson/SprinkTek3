using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using SprintTek.MultiTenancy.Accounting.Dto;

namespace SprintTek.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
