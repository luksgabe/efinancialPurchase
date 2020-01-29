using EFinancialPurchase.AspNet.Common.Enums;
using System.Net;

namespace EFinancialPurchase.AspNet.Common.Interfaces
{
    public interface IMessage
    {
        MessageType Type { get; }
        string Property { get; }
        string Text { get; }
        HttpStatusCode Code { get; }
    }
}
