using System;
using System.Collections.Generic;

namespace EFCore.Models;

/// <summary>
/// 掲載物件資料
/// </summary>
public partial class PropertyDocument
{
    /// <summary>
    /// 物件ID
    /// </summary>
    public string PropertyId { get; set; }

    /// <summary>
    /// 資料ID
    /// </summary>
    public short DocumentId { get; set; }

    /// <summary>
    /// 物件タイプ
    /// </summary>
    public string PropertyType { get; set; }

    /// <summary>
    /// 資料URI
    /// </summary>
    public string DocumentUri { get; set; }

    /// <summary>
    /// コメント
    /// </summary>
    public string Siryoucaption { get; set; }
}
