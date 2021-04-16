using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources.Save
{
    public class SaveRequestResource
    {
       
        public string EndTime { get; set; }

        public int ProviderId { get; set; }
        public int ProductTypeId { get; set; }
        public int PetId { get; set; }

        public int PersonProfileId { get; set; }
        public int ProductId { get; set; }

        public string VeterinaryName { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductName { get; set; }
        public string PetName { get; set; }
        public DateTime DateReservation { get; set; }
        public string StartTime { get; set; }
        public int Status { get; set; }
        public string PersonName { get; set; }


    }
}
