using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATXBSAPP.ViewModels
{
    public class NewsViewModel
    {
        public class ValueN
        {
            public string adx_name { get; set; }
            public string new_descripcion { get; set; }
            public DateTime adx_releasedate { get; set; }
            public string new_urlimagen { get; set; }
            public string new_linkpost { get; set; }
            public string createdby { get; set; }

            public string atx_name { get; set; }
            public string atx_descripcion { get; set; }
            public DateTime atx_validadesde { get; set; }
            public DateTime atx_validahasta { get; set; }

            public string atx_fechadeinicio { get; set; }
            public string atx_fechadefinalizacion { get; set; }
            public string atx_linkderegistro { get; set; }
            public string atx_respuesta { get; set; }
        }
        public class RootObject
        {
            public List<ValueN> value { get; set; }
        }
    }
}
