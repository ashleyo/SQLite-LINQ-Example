using System;
using System.Collections.Generic;

namespace Tuesday;

public partial class Constituency
{
    public string OnsId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string CountyName { get; set; } = null!;

    public string ConstituencyType { get; set; } = null!;

    public virtual ICollection<Candidate> Candidates { get; } = new List<Candidate>();

    public virtual County CountyNameNavigation { get; set; } = null!;
}
