using System;
using System.Collections.Generic;

namespace ImdbRandomMovie.Entity;

public partial class TitleRatingsFiltered
{
    public string Tconst { get; set; } = null!;

    public double? AverageRating { get; set; }

    public int? NumVotes { get; set; }
}
