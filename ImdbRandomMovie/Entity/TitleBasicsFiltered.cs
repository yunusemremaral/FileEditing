using System;
using System.Collections.Generic;

namespace ImdbRandomMovie.Entity;

public partial class TitleBasicsFiltered
{
    public string Tconst { get; set; } = null!;

    public string? PrimaryTitle { get; set; }

    public string? OriginalTitle { get; set; }

    public byte? IsAdult { get; set; }

    public short? StartYear { get; set; }

    public string? RuntimeMinutes { get; set; }

    public string? Genres { get; set; }

}
