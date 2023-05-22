using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzListPic
{
    public long PicId { get; set; }

    public string? PicThumb { get; set; }

    public string? PicFull { get; set; }

    public long? ListId { get; set; }

    public short? Enabled { get; set; }

    public string? Note { get; set; }

    public long? Order { get; set; }
}
