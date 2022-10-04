using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EFCoreDemoAPI60DBFirst.Models
{
    public partial class EmailAddress
    {
        public int Id { get; set; }
        public string EmailAddress1 { get; set; } = null!;
        public int? CustomerId { get; set; }

        //Dies wird ignoriert, damit in der Customerclass die Address in Json angezeigt wird
        [JsonIgnore]
        public virtual Customer? Customer { get; set; }
    }
}
