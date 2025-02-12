using System;
using System.Collections.Generic;

namespace EFCore.Models;

/// <summary>
/// 賃貸物件統計
/// </summary>
public partial class RentalStatistic
{
    /// <summary>
    /// 統計ID
    /// </summary>
    public string StatisticId { get; set; }

    /// <summary>
    /// 更新時間
    /// </summary>
    public DateTime UpdateTime { get; set; }

    /// <summary>
    /// 物件数
    /// </summary>
    public long? PropertyCount { get; set; }
}
