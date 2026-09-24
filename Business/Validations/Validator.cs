namespace Domain.Models
{
    public static class Validator
    {
        public static bool IsValid(MakeTransfer transfer) => transfer.amount > 0;
    }

}
