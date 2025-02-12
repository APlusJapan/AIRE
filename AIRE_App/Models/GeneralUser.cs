using System;
using System.Collections.Generic;

namespace EFCore.Models;

/// <summary>
/// 一般ユーザー
/// </summary>
public partial class GeneralUser
{
    /// <summary>
    /// ユーザーID
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// ユーザー名
    /// </summary>
    public string UserName { get; set; }
}
