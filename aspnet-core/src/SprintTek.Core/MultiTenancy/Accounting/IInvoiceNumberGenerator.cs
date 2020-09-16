using System.Threading.Tasks;
using Abp.Dependency;

namespace SprintTek.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}