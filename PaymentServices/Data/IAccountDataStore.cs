using PaymentServices.Types;

namespace PaymentServices.Data
{
    public interface IAccountDataStore
    {
        Account GetAcount(string accountNumber);

        void UpdateAccount(Account account);
    }
}
