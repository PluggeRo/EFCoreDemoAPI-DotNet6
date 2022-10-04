using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EFCoreDemoAPI60DBFirst.Models
{
    public partial class Address
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; } = null!;
        public string HouseNumber { get; set; } = null!;
        public string City { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string Country { get; set; } = null!;
        public int? CustomerId { get; set; }

        //Dies wird ignoriert, damit in der Customerclass die Address in Json angezeigt wird
        [JsonIgnore]
        public virtual Customer? Customer { get; set; }
    }
}
