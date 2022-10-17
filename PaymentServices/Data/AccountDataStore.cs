using PaymentServices.Types;
using System.Collections.Concurrent;

namespace PaymentServices.Data
{
    public class AccountDataStore : IAccountDataStore
    {
        private static Dictionary<string, Account> _accounts = AccountData.GetAccounts();

        public Account? GetAcount(string accountNumber)
        {
            return _accounts.TryGetValue(accountNumber, out Account account)
                ? account
                : null;
        }

        public void UpdateAccount(Account _account)
        {
            if (!_accounts.ContainsKey(_account.AccountNumber))
            {
                return;
            }

            _accounts[_account.AccountNumber] = _account;
        }
    }
}
