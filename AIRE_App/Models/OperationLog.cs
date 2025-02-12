using System;
using System.Collections.Generic;

namespace EFCore.Models;

/// <summary>
/// 操作ログ
/// </summary>
public partial class OperationLog
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
    /// ログタイプ 
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// ログタイトル 
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// ログ内容
    /// </summary>
    public string Content { get; set; }
}
