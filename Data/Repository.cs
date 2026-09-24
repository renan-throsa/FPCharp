using Domain.Extentions;
using Domain.Interfaces;
using Domain.Models;

namespace Data
{
    public class Repository : IRepository<AccountState>
    {
        private Dictionary<string, AccountState> _db;
        public Repository()
        {
            _db = new Dictionary<string, AccountState>();
        }
        public Option<AccountState> Get(string id)
        {
            return _db.Lookup(id);
        }

        public void Save(AccountState t)
        {
            _db.Lookup(t.Id).ForEach(account => _db[account.Id] = account);
        }

    }
}
