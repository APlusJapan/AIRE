using System;
using System.Collections.Generic;

namespace AIRE_DB.Models;

/// <summary>
/// 役割
/// </summary>
public partial class Role
{
    /// <summary>
    /// ユーザーID
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// 役割ID
    /// </summary>
    public string RoleId { get; set; }
}
