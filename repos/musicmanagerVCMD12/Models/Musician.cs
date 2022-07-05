using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;

namespace musicmanagerVCMD12.Models
{
    public class Musician : TableEntity
    {
        public Musician() { }

        public string FilePath { get; set; }

        public string MusicianName { get; set; }

        public string Genre { get; set; }

        public Double BookingFee { get; set; }
    }
}