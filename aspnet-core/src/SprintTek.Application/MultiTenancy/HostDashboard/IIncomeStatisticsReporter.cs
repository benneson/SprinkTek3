using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SprintTek.MultiTenancy.HostDashboard.Dto;

namespace SprintTek.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}