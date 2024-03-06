using System;
using OF.Dto.NRFDto;

namespace OF.Services.NRFService
{
    public interface INRFService
    {
        public Task<Guid> RegisterNF(string token, IncomeNFDto incomeNFDto);
        public IncomeNFDto ConformNFDto();
    }
}

