using System;
using System.Collections.Generic;
using System.Text;

namespace ATXBSAPP.ViewModels
{
    public class FrecuencyViewModel
    {
        public class ValueF
        {
            public string atx_name { get; set; }
            public string atx_respuesta { get; set; }
            public string new_url { get; set; }
        }
        public class RootObject
        {
            public List<ValueF> value { get; set; }
        }
    }
}
