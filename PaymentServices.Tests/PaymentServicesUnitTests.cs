namespace PaymentServices.Tests
{
    public class PaymentServicesUnitTests
    {
        [Fact]
        public void TestMakePayment_NullAccount_UnssuccessfulPayment()
        {
            //Arrange
            var request = new MakePaymentRequest
            {
                Amount = 20,
                CreditorAccountNumber = "123123",
                DebtorAccountNumber = "0",
                PaymentDate = DateTime.Now,
                PaymentScheme = PaymentScheme.Bacs
            };

            var paymentService = new PaymentService(new AccountDataStore());

            //Act
            var result = paymentService.MakePayment(request);

            //Assert
            result.Success.Should().BeFalse();
        }

        [Fact]
        public void TestMakePayment_PaymentSchemeBacs_SuccessfulPayment()
        {
            //Arrange
            var request = new MakePaymentRequest
            {
                Amount = 20,
                CreditorAccountNumber = "123123",
                DebtorAccountNumber = "1",
                PaymentDate = DateTime.Now,
                PaymentScheme = PaymentScheme.Bacs
            };

            var paymentService = new PaymentService(new AccountDataStore());

            //Act
            var result = paymentService.MakePayment(request);

            //Assert
            result.Success.Should().BeTrue();
        }

        [Fact]
        public void TestMakePayment_PaymentSchemeBacs_UnsuccessfulPayment()
        {
            //Arrange
            var request = new MakePaymentRequest
            {
                Amount = 20,
                CreditorAccountNumber = "123123",
                DebtorAccountNumber = "2",
                PaymentDate = DateTime.Now,
                PaymentScheme = PaymentScheme.Bacs
            };

            var paymentService = new PaymentService(new AccountDataStore());

            //Act
            var result = paymentService.MakePayment(request);

            //Assert
            result.Success.Should().BeFalse();
        }

        [Fact]
        public void TestMakePayment_PaymentSchemeFasterPayments_SuccessfulPayment()
        {
            //Arrange
            var request = new MakePaymentRequest
            {
                Amount = 20,
                CreditorAccountNumber = "123123",
                DebtorAccountNumber = "3",
                PaymentDate = DateTime.Now,
                PaymentScheme = PaymentScheme.FasterPayments
            };

            var paymentService = new PaymentService(new AccountDataStore());

            //Act
            var result = paymentService.MakePayment(request);

            //Assert
            result.Success.Should().BeTrue();
        }

        [Fact]
        public void TestMakePayment_PaymentSchemeFasterPayments_UnsuccessfulPayment()
        {
            //Arrange
            var request = new MakePaymentRequest
            {
                Amount = 200,
                CreditorAccountNumber = "123123",
                DebtorAccountNumber = "4",
                PaymentDate = DateTime.Now,
                PaymentScheme = PaymentScheme.FasterPayments
            };

            var paymentService = new PaymentService(new AccountDataStore());

            //Act
            var result = paymentService.MakePayment(request);

            //Assert
            result.Success.Should().BeFalse();
        }

        [Fact]
        public void TestMakePayment_PaymentSchemeChaps_SuccessfulPayment()
        {
            //Arrange
            var request = new MakePaymentRequest
            {
                Amount = 200,
                CreditorAccountNumber = "123123",
                DebtorAccountNumber = "2",
                PaymentDate = DateTime.Now,
                PaymentScheme = PaymentScheme.Chaps
            };

            var paymentService = new PaymentService(new AccountDataStore());

            //Act
            var result = paymentService.MakePayment(request);

            //Assert
            result.Success.Should().BeTrue();
        }

        [Fact]
        public void TestMakePayment_PaymentSchemeChaps_UnsuccessfulPayment()
        {
            //Arrange
            var request = new MakePaymentRequest
            {
                Amount = 200,
                CreditorAccountNumber = "123123",
                DebtorAccountNumber = "5",
                PaymentDate = DateTime.Now,
                PaymentScheme = PaymentScheme.Chaps
            };

            var paymentService = new PaymentService(new AccountDataStore());

            //Act
            var result = paymentService.MakePayment(request);

            //Assert
            result.Success.Should().BeFalse();
        }
    }
}