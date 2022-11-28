using Domain.Entities.Utils;
using HelpHome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class WindowsCleaningPreferenceDto
    {

        public List<WindowsType>? windowsType = new List<WindowsType>(); // kazdy typ okna ma swoja cene => jako słownik?
        public int PriceOffer { get; set; }
       
    }
}
