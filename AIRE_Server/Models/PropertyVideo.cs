using System;
using System.Collections.Generic;

namespace AIRE_DB.Models;

/// <summary>
/// 掲載物件動画
/// </summary>
public partial class PropertyVideo
{
    /// <summary>
    /// 物件ID
    /// </summary>
    public string PropertyId { get; set; }

    /// <summary>
    /// 動画ID
    /// </summary>
    public short VideoId { get; set; }

    /// <summary>
    /// 物件タイプ
    /// </summary>
    public string PropertyType { get; set; }

    /// <summary>
    /// 動画URI
    /// </summary>
    public string VideoUri { get; set; }

    /// <summary>
    /// 動画名
    /// </summary>
    public string DougafName { get; set; }

    /// <summary>
    /// キャプション
    /// </summary>
    public string DougafCaption { get; set; }
}
