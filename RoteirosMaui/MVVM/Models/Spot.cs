using RoteirosMaui.Abstractions;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoteirosMaui.MVVM.Models
{
    public class Spot : TableData
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Adress { get; set; }

        public bool IsVisited { get; set; } = false;

        [ForeignKey(typeof(Trip))]
        public int TripId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Trip? Trip { get; set; }

    }
}
