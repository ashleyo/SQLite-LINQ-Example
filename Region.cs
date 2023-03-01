using System;
using System.Collections.Generic;

namespace Tuesday;

public partial class Region
{
    public string OnsRegionId { get; set; } = null!;

    public string? RegionName { get; set; }

    public string? CountryName { get; set; }

    public virtual ICollection<County> Counties { get; } = new List<County>();
}
