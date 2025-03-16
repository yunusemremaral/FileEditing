using System;
using System.Collections.Generic;

namespace ImdbRandomMovie.Entity;

public partial class TitleAkasFiltered
{
    public string Tconst { get; set; } = null!;

    public byte? Ordering { get; set; }

    public string? Title { get; set; }

    public string? Region { get; set; }

    public string? Language { get; set; }

    public string? Types { get; set; }

    public string? Attributes { get; set; }

    public bool? IsOriginalTitle { get; set; }

}
