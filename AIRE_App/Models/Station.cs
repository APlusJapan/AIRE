using System;
using System.Collections.Generic;

namespace EFCore.Models;

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

    /// <summary>
    /// グループID
    /// </summary>
    public string GroupId { get; set; }
}
