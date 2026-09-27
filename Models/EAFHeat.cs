using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSC02.Models
{
    public class EAFHeat:BaseEntity
    {
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set;}

        public int Duration {  get; set;}
        public int Sequence { get; set;}

        [ForeignKey("HeatId")]
        public string HeatId {  get; set; }
        public Heat Heats {  get; set; }
    }
}
