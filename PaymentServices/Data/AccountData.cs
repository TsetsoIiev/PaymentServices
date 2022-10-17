using PaymentServices.Types;

namespace PaymentServices.Data
{
    public static class AccountData
    {
        public static Dictionary<string, Account> GetAccounts()
        {
            return new Dictionary<string, Account>()
            {
                { "1", new Account{ AccountNumber = "1", AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs, Balance = 100, Status = AccountStatus.Live } },
                { "2", new Account{ AccountNumber = "2", AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps, Balance = 100, Status = AccountStatus.Live } },
                { "3", new Account{ AccountNumber = "3", AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments, Balance = 100, Status = AccountStatus.Live } },
                { "4", new Account{ AccountNumber = "4", AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments, Balance = 10, Status = AccountStatus.Live } },
                { "5", new Account{ AccountNumber = "5", AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps, Balance = 100, Status = AccountStatus.InboundPaymentsOnly } }
            };
        }
    }
}
