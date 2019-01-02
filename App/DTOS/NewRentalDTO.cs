using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.DTOS
{
    public class NewRentalDTO
    {
        public int CustomerID { get; set; }
        public List<int> MovieIds { get; set; }
    }
}