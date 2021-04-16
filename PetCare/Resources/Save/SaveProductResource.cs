using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources.Save
{
    public class SaveProductResource
    {
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}
