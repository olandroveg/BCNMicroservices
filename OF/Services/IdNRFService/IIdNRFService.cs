using System;
using OF.Models;

namespace OF.Services.IdNRFService
{
    public interface IIdNRFService
    {
        public IDinNRF GetNF_IDinNRF();
        public Task<Guid> AddOrUpdate(IDinNRF idInNRF);
    }
}

