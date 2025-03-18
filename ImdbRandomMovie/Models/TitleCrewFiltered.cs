using System;
using System.Collections.Generic;

namespace ImdbRandomMovie;

public partial class TitleCrewFiltered
{
    public string Tconst { get; set; } = null!;

    public string? Directors { get; set; }

    public string? Writers { get; set; }

    public virtual TitleBasicsFiltered TconstNavigation { get; set; } = null!;
}
