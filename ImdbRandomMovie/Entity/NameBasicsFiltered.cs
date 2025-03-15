using System;
using System.Collections.Generic;

namespace ImdbRandomMovie.Entity;

public partial class NameBasicsFiltered
{
    public string Nconst { get; set; } = null!;

    public string? PrimaryName { get; set; }

    public string? BirthYear { get; set; }

    public string? DeathYear { get; set; }

    public string? PrimaryProfession { get; set; }

    public string? KnownForTitles { get; set; }
}
