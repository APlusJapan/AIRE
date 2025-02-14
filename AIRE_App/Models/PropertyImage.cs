using System;
using System.Collections.Generic;

namespace AIRE_DB.Models;

/// <summary>
/// 掲載物件画像
/// </summary>
public partial class PropertyImage
{
    /// <summary>
    /// 物件ID
    /// </summary>
    public string PropertyId { get; set; }

    /// <summary>
    /// 画像ID
    /// </summary>
    public short ImageId { get; set; }

    /// <summary>
    /// 物件タイプ
    /// </summary>
    public string PropertyType { get; set; }

    /// <summary>
    /// 画像URI
    /// </summary>
    public string ImageUri { get; set; }

    /// <summary>
    /// カテゴリ
    /// </summary>
    public string Gpcategory { get; set; }

    /// <summary>
    /// 施設名
    /// </summary>
    public string Shuhenmei { get; set; }

    /// <summary>
    /// コメント
    /// </summary>
    public string GpcaptionS { get; set; }

    /// <summary>
    /// 周辺施設まで
    /// </summary>
    public int? Shuhenkyori { get; set; }
}
