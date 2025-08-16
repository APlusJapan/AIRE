using System;
using System.Collections.Generic;

namespace AIRE_DB.Models;

/// <summary>
/// 鉄道情報
/// </summary>
public partial class RailwayInfo
{
    /// <summary>
    /// 路線名
    /// </summary>
    public string RailwayName { get; set; }

    /// <summary>
    /// 運営会社
    /// </summary>
    public string RailwayCompany { get; set; }

    /// <summary>
    /// 都道府県ID
    /// </summary>
    public string PrefectureId { get; set; }

    /// <summary>
    /// 作成日時
    /// </summary>
    public DateTime? CreationTime { get; set; }

    /// <summary>
    /// 変更日時
    /// </summary>
    public DateTime? ModificationTime { get; set; }
}
