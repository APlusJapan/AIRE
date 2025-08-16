using System;
using System.Collections.Generic;

namespace AIRE_DB.Models;

/// <summary>
/// 賃貸物件画像
/// </summary>
public partial class RentalImage
{
    /// <summary>
    /// 賃貸物件ID
    /// </summary>
    public string RentalId { get; set; }

    /// <summary>
    /// 画像ID
    /// </summary>
    public short ImageId { get; set; }

    /// <summary>
    /// 作成日時
    /// </summary>
    public DateTime? CreationTime { get; set; }

    /// <summary>
    /// 変更日時
    /// </summary>
    public DateTime? ModificationTime { get; set; }

    /// <summary>
    /// 画像URI
    /// </summary>
    public string ImageUri { get; set; }

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
