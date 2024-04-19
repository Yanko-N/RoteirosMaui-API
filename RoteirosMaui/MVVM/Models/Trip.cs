using RoteirosMaui.Abstractions;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoteirosMaui.MVVM.Models
{
    public class Trip : TableData
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [OneToMany( CascadeOperations = CascadeOperation.All)]
        public List<Spot> Spots { get; set; }


    }
}
