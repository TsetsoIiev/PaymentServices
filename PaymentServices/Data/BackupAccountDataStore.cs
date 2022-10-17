using PaymentServices.Types;
using System.Collections.Concurrent;

namespace PaymentServices.Data
{
    public class BackupAccountDataStore : IAccountDataStore
    {
        private static Dictionary<string, Account> _accounts = AccountData.GetAccounts();

        public Account? GetAcount(string accountNumber)
        {
            return _accounts.TryGetValue(accountNumber, out Account account)
                ? account
                : null;
        }

        public void UpdateAccount(Account account)
        {
            if (!_accounts.ContainsKey(account.AccountNumber))
            {
                return;
            }

            _accounts[account.AccountNumber] = account;
        }
    }
}
