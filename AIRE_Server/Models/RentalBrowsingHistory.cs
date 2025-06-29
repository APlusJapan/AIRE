using System;
using System.Collections.Generic;

namespace AIRE_DB.Models;

/// <summary>
/// 賃貸物件閲覧履歴
/// </summary>
public partial class RentalBrowsingHistory
{
    /// <summary>
    /// デバイス一意ID
    /// </summary>
    public string DeviceUniqueId { get; set; }

    /// <summary>
    /// 操作時間
    /// </summary>
    public DateTime OperationTime { get; set; }

    /// <summary>
    /// ユーザーID
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// 論理削除
    /// </summary>
    public bool LogicalDelete { get; set; }

    /// <summary>
    /// お気に入り
    /// </summary>
    public bool Favorite { get; set; }

    /// <summary>
    /// 物件ID
    /// </summary>
    public string RentalId { get; set; }
}
