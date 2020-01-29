
using EFinancialPurchase.AspNet.Common.Enums;
using EFinancialPurchase.AspNet.Common.Interfaces;
using System.Net;

namespace EFinancialPurchase.AspNet.Common.CommandResult
{
    internal class Message : IMessage
    {
        public MessageType Type { get; private set; }
        public string Property { get; private set; }
        public string Text { get; private set; }
        public HttpStatusCode Code { get; private set; }

        public Message(MessageType type, string propert, string text, HttpStatusCode code)
        {
            Type = type;
            Property = propert;
            Text = text;
            Code = code;
        }
    }
}
