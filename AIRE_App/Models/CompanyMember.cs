using System;
using System.Collections.Generic;

namespace AIRE_DB.Models;

/// <summary>
/// 会社メンバー
/// </summary>
public partial class CompanyMember
{
    /// <summary>
    /// 会社ID
    /// </summary>
    public string CompanyId { get; set; }

    /// <summary>
    /// 社員ID
    /// </summary>
    public string StaffId { get; set; }

    /// <summary>
    /// 作成日時
    /// </summary>
    public DateTime? CreationTime { get; set; }

    /// <summary>
    /// 変更日時
    /// </summary>
    public DateTime? ModificationTime { get; set; }

    /// <summary>
    /// 社員名
    /// </summary>
    public string StaffName { get; set; }

    /// <summary>
    /// 電話番号
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Eメール
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Line ID
    /// </summary>
    public string LineId { get; set; }

    /// <summary>
    /// 追加経路ID
    /// </summary>
    public string RouteId { get; set; }

    /// <summary>
    /// ビジネスアカウント
    /// </summary>
    public bool IsBusiness { get; set; }
}
