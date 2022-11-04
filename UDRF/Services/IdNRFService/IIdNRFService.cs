﻿using UDRF.Models;

namespace UDRF.Services.IdNRFService
{
    public interface IIdNRFService
    {
        public IDinNRF GetNF_IDinNRF();
        public Task<Guid> AddOrUpdate(IDinNRF idInNRF);
    }
}
