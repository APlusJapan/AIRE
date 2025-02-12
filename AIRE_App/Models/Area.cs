using System;
using System.Collections.Generic;

namespace EFCore.Models;

/// <summary>
/// エリア
/// </summary>
public partial class Area
{
    /// <summary>
    /// エリアID
    /// </summary>
    public string AreaId { get; set; }

    /// <summary>
    /// 都道府県ID
    /// </summary>
    public string PrefectureId { get; set; }

    /// <summary>
    /// エリア名
    /// </summary>
    public string AreaName { get; set; }

    /// <summary>
    /// 親エリアID
    /// </summary>
    public string ParentAreaId { get; set; }

    /// <summary>
    /// 改訂エリアID
    /// </summary>
    public string RevisedAreaId { get; set; }
}
