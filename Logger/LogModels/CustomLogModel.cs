using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.LogModels
{
    public class CustomLogModel : Base.BaseLogModel
    {
        public int State { get; set; }

        public object Entity { get; set; }
    }
}
