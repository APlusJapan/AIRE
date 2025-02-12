using System;
using System.Collections.Generic;

namespace EFCore.Models;

/// <summary>
/// 権限
/// </summary>
public partial class Permission
{
    /// <summary>
    /// ロールID
    /// </summary>
    public string RoleId { get; set; }

    /// <summary>
    /// アクションID
    /// </summary>
    public string ActionId { get; set; }

    /// <summary>
    /// 権限レベル
    /// </summary>
    public short Level { get; set; }
}
