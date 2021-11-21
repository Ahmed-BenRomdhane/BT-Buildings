using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_BuildingsMODELS
{
    public class APIResult
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
