using System;
using System.Collections.Generic;

namespace Tuesday;

public partial class Party
{
    public string PartyId { get; set; } = null!;

    public string? PartyName { get; set; }

    public virtual ICollection<Candidate> Candidates { get; } = new List<Candidate>();
}
