using System;
using System.Collections.Generic;

namespace AIRE_DB.Models;

/// <summary>
/// 都道府県
/// </summary>
public partial class Prefecture
{
    /// <summary>
    /// 都道府県ID
    /// </summary>
    public string PrefectureId { get; set; }

    /// <summary>
    /// 都道府県名
    /// </summary>
    public string PrefectureName { get; set; }
}
