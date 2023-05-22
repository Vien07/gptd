using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzSeo
{
    public long Seoid { get; set; }

    public string? TitleVn { get; set; }

    public string? TitleEn { get; set; }

    public long? CateId { get; set; }

    public long? Level { get; set; }

    public short? Enabled { get; set; }

    public string? DescriptionVn { get; set; }

    public string? DescriptionEn { get; set; }

    public string? KeywordsVn { get; set; }

    public string? KeywordsEn { get; set; }
}
