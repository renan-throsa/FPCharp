using Domain.Models;

namespace Domain.Interfaces
{
    interface ISwiftService
    {
        void Wire(MakeTransfer transfer, AccountState account);
    }

}
