using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemiyNLayerProject.Web.DTOs
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Erors = new List<string>();
        }

        public List<string> Erors { get; set; }

        public int Status { get; set; }
    }
}
