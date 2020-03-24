using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdemiyNLayerProject.API.DTOs
{
    public class ProductDto
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="{0 } name alanı fereklidir")]
        public string Name { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage ="{0} alanı gerekkklidir")]
        public int Stock { get; set; }

        public decimal Price { get; set; }
        public int CategoryId { get; set; }

       

    }
}
