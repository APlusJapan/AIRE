using System;
using System.Collections.Generic;

namespace AIRE_DB.Models;

/// <summary>
/// 会社グループ
/// </summary>
public partial class CompanyGroup
{
    /// <summary>
    /// 会社ID
    /// </summary>
    public string CompanyId { get; set; }

    /// <summary>
    /// 会社名
    /// </summary>
    public string CompanyName { get; set; }

    /// <summary>
    /// 会社概要
    /// </summary>
    public string CompanyOverview { get; set; }
}
