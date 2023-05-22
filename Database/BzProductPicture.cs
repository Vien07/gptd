using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzProductPicture
{
    public long PictureId { get; set; }

    public string? PicThumb { get; set; }

    public string? PicFull { get; set; }

    public long? ProductId { get; set; }

    public long? Order { get; set; }
}
