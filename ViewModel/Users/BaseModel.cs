using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndocPM.WebAPI
{
    public class BaseModel
    {
        public BaseModel()
        {
            this.Status = 0;
            this.StatusMessage = "";
        }

        public int Status { get; set; }

        public string StatusMessage { get; set; }
        public object Result { get; set; }

    }
}
