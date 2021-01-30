using aliniyor.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aliniyor.Models.Request
{
    public class FilterFileChangeRequest
    {
        [Required]
        public FileTypeEnum Name { get; set; }
    }
}
