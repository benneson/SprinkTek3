﻿using System.Threading.Tasks;
using Abp.Application.Services;

namespace SprintTek.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task DisableRecurringPayments();

        Task EnableRecurringPayments();
    }
}
