using System;
using System.Collections.Generic;

namespace Rusada.DBModels
{
    public partial class AircraftDetail
    {
        public int Id { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Registration { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime Time { get; set; }
    }
}
