using PaymentServices.Data;
using PaymentServices.Types;

namespace PaymentServices.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountDataStore _accountDataStore;

        public PaymentService(IAccountDataStore accountDataStore)
        {
            _accountDataStore = accountDataStore ?? throw new ArgumentNullException(nameof(accountDataStore));
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var account = _accountDataStore.GetAcount(request.DebtorAccountNumber);
            var result = new MakePaymentResult();

            if (account is null)
            {
                return result;
            }

            var paymentScheme = Enum.Parse<AllowedPaymentSchemes>(request.PaymentScheme.ToString());
            if (!account.AllowedPaymentSchemes.HasFlag(paymentScheme))
            {
                return result;
            }

            result.Success = request.PaymentScheme switch
            {
                PaymentScheme.Bacs => true,
                PaymentScheme.FasterPayments => account.Balance > request.Amount,
                PaymentScheme.Chaps => account.Status == AccountStatus.Live,
                _ => false
            };

            if (!result.Success)
            {
                return result;
            }

            account.Balance -= request.Amount;
            _accountDataStore.UpdateAccount(account);

            return result;
        }
    }
}
