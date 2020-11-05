using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using net_core_web.Model;

namespace net_core_web.ViewModels
{
    public class ViewDetails
    {
        public string Title { get; set; }

        public Friend Friend { get; set; }
    }
}