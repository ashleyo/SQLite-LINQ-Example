using System;
using System.Collections.Generic;

namespace Tuesday;

public partial class Candidate
{
    public string OnsId { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string? PartyId { get; set; }

    public string SittingMp { get; set; } = null!;

    public string FormerMp { get; set; } = null!;

    public long Votes { get; set; }

    public double Share { get; set; }

    public double? Change { get; set; }

    public virtual Constituency Ons { get; set; } = null!;

    public virtual Party? Party { get; set; }
}
