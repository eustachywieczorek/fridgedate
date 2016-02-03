using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeDate.Core.Requests
{
    public class SetPasswordRequest
    {
        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
