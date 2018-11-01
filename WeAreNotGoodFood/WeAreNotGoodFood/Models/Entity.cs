using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WeAreNotGoodFood.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
