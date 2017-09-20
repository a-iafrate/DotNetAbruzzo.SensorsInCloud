using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Models.Ef
{
    public class SensorLine
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime Timestamp { get; set; }

        public decimal? Value1 { get; set; }
        public decimal? Value2 { get; set; }
    }
}