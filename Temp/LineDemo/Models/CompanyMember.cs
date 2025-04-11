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
