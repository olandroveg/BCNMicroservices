using System.Linq;
using UDRF.Data;
using UDRF.Models;

namespace UDRF.Services.IdNRFService
{
    public class IdNRFService : IIdNRFService
    {
        private readonly ApplicationDbContext _context;
        public IdNRFService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Guid GetNF_IDinNRF()
        {
            var idInNRF = _context.IDinNRF;
            return idInNRF != null && idInNRF.Count() > 0 ? (Guid) idInNRF.FirstOrDefault().Id : Guid.Empty;
        }
        public async Task<Guid> AddOrUpdate(IDinNRF idInNRF)
        {
            if (idInNRF == null)
                throw new ArgumentNullException(nameof(idInNRF));
            if (idInNRF.Id == Guid.Empty)
                await _context.IDinNRF.AddAsync(idInNRF);
            else
                _context.IDinNRF.Update(idInNRF);
            await _context.SaveChangesAsync();
            return idInNRF.Id ?? Guid.Empty;
        }
    }
    
}
