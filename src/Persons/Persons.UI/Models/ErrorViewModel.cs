using DotNetCore.Objects;
using EFinancialPurchase.AspNet.Common.Utils;
using Newtonsoft.Json;

namespace Persons.Ui.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);


        public static void ModelStateExtention(string errorSerialized)
        {
            errorSerialized = errorSerialized.SplitHttpCode();
            var result = JsonConvert.DeserializeObject<DataResult<string>>(errorSerialized);

        }
    }
}
