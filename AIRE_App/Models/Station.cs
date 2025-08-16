using System;
using System.Collections.Generic;

namespace AIRE_DB.Models;

/// <summary>
/// 駅
/// </summary>
public partial class Station
{
    /// <summary>
    /// 駅ID
    /// </summary>
    public string StationId { get; set; }

    /// <summary>
    /// 作成日時
    /// </summary>
    public DateTime? CreationTime { get; set; }

    /// <summary>
    /// 変更日時
    /// </summary>
    public DateTime? ModificationTime { get; set; }

    /// <summary>
    /// 路線名
    /// </summary>
    public string RailwayName { get; set; }

    /// <summary>
    /// 運営会社
    /// </summary>
    public string RailwayCompany { get; set; }

    /// <summary>
    /// 駅名
    /// </summary>
    public string StationName { get; set; }
}
