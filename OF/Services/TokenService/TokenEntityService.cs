using System;
using OF.Data;
using OF.Models;
namespace OF.Services.TokenService
{
    public class TokenEntityService : ITokenEntityService
    {
        private readonly ApplicationDbContext _context;

        public TokenEntityService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Models.Token> AddOrUpdate(Models.Token token)
        {
            if (string.IsNullOrEmpty(token.Value))
                throw new ArgumentNullException("fields cannot be null");
            var formerToken = _context.Token.FirstOrDefault();
            if (formerToken != null && formerToken.Id != Guid.Empty)
            {
                formerToken.Value = token.Value;
                formerToken.DateTime = token.DateTime;
                _context.Token.Update(formerToken);
                await _context.SaveChangesAsync();
                return formerToken;
            }
            else
                await _context.Token.AddAsync(token);
            await _context.SaveChangesAsync();
            return token;
        }
        public void Delete(Models.Token token)
        {
            if (token.Id == Guid.Empty)
                throw new ArgumentNullException("token does not exist");
            _context.Token.Remove(token);
        }
        public bool TokenAvailability()
        {
            // set token renewal as 30 min interval.
            var formerToken = _context.Token.FirstOrDefault();
            if (formerToken != null && formerToken.Id != Guid.Empty && (((DateTime.Now - formerToken.DateTime).TotalMinutes) < 30))
                return true;
            return false;
        }
        public Token GetToken()
        {
            var token = _context.Token.Count() > 0 ? _context.Token.FirstOrDefault() : null;
            if (token != null)
                return token;

            return null;
        }
    }
}

