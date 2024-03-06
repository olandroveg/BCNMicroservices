using UDRF.Dto.NRFDto;

namespace UDRF.Services.NRFService
{
    public interface INRFService
    {
        public Task<Guid> RegisterNF(string token, IncomeNFDto incomeNFDto);
        public IncomeNFDto ConformNFDto();
    }
}
