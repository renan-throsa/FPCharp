using Domain.Extentions;
using Domain.Interfaces;
using Domain.Models;
using static Domain.Utils.F;

namespace Business.Services
{
    public class Service : IService<AccountState>
    {
        private IRepository<AccountState> _accounts;

        public Service(IRepository<AccountState> accounts)
        {
            _accounts = accounts;
        }

        public void Save(MakeTransfer transfer)
        {
            Some(transfer).Where(Validator.IsValid).ForEach(Book);
        }

        private void Book(MakeTransfer transfer)
        {
            _accounts.Get(transfer.From).Bind(account => account.Debit(transfer.Amount))
                .ForEach(account => _accounts.Save(account));
        }

        public Option<AccountState> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Option<AccountState> Save(AccountState t)
        {
            throw new NotImplementedException();
        }
    }
}
