using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FridgeDate.Core.Responses
{
    public class ExternalLoginsResponse: HttpResponseMessage
    {
        public new IEnumerable<ExternalLogin> Content { get; set; }

}
}
