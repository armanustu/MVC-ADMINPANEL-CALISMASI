using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public  class WriterLogin
    {
        [Key]
        public int WriterLoginID { get; set; }
        public string WriterName { get; set; }
        public string WriterPassword { get; set; }
    }
}
