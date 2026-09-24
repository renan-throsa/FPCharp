using static Domain.Utils.F;

namespace Domain.Models
{
    public record AccountState(string Id, decimal Balance);

    public record MakeTransfer(string From, string To, decimal Amount);

    public static class AccountBehavior
    {
        public static Option<AccountState> Debit(this AccountState current, decimal amount)
            => (current.Balance < amount) ? None : Some(new AccountState(current.Id, current.Balance - amount));

        public static Option<AccountState> Deposit(this AccountState current, decimal amount)
           => Some(new AccountState(current.Id, current.Balance + amount));

    }

}
