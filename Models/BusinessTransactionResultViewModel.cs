namespace LoggingLearning.Models
{
    public class BusinessTransactionResultViewModel
    {
        public string ErrorMessage { get; }

        public BusinessTransactionResultViewModel() { }

        public BusinessTransactionResultViewModel(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}