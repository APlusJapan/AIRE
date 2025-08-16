using System;
using System.Collections.Generic;

namespace AIRE_DB.Models;

/// <summary>
/// プロンプトマスタ
/// </summary>
public partial class PromptMaster
{
    /// <summary>
    /// プロンプト名
    /// </summary>
    public string PromptName { get; set; }

    /// <summary>
    /// プロンプトタイプ
    /// </summary>
    public string PromptType { get; set; }

    /// <summary>
    /// 作成日時
    /// </summary>
    public DateTime? CreationTime { get; set; }

    /// <summary>
    /// 変更日時
    /// </summary>
    public DateTime? ModificationTime { get; set; }

    /// <summary>
    /// プロンプト値
    /// </summary>
    public string PromptValue { get; set; }
}
