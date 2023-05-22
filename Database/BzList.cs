using System;
using System.Collections.Generic;

namespace VinaOfficeWebsite.Database;

public partial class BzList
{
    public long ListId { get; set; }

    public string? TitleVn { get; set; }

    public string? TitleEn { get; set; }

    public string? DesVn { get; set; }

    public string? DesEn { get; set; }

    public string? ContentVn { get; set; }

    public string? ContentEn { get; set; }

    public string? PicThumb { get; set; }

    public string? PicFull { get; set; }

    public string? NoteVn { get; set; }

    public string? NoteEn { get; set; }

    public short? HotList { get; set; }

    public DateTime? PostedDate { get; set; }

    public short? Enabled { get; set; }

    public long? Views { get; set; }

    public long? CateId { get; set; }

    public long? Order { get; set; }

    public short? IsPicture { get; set; }

    public DateTime? ActiveDate { get; set; }

    public string? Code { get; set; }

    public short? IsDes { get; set; }

    public string? TitleLink { get; set; }

    public short? Level { get; set; }

    public long? ParentId { get; set; }
}
