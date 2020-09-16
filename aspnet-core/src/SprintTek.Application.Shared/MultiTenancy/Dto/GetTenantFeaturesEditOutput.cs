using System.Collections.Generic;
using Abp.Application.Services.Dto;
using SprintTek.Editions.Dto;

namespace SprintTek.MultiTenancy.Dto
{
    public class GetTenantFeaturesEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}