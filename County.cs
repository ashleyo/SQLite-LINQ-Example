using System;
using System.Collections.Generic;

namespace Tuesday;

public partial class County
{
    public string CountyName { get; set; } = null!;

    public string OnsRegionId { get; set; } = null!;

    public virtual ICollection<Constituency> Constituencies { get; } = new List<Constituency>();

    public virtual Region OnsRegion { get; set; } = null!;
}
