using System;
using System.Collections.Generic;

namespace AIRE_DB.Models;

/// <summary>
/// コードマスタ
/// </summary>
public partial class CodeMaster
{
    /// <summary>
    /// コードタイプ
    /// </summary>
    public string CodeType { get; set; }

    /// <summary>
    /// コード名
    /// </summary>
    public string CodeName { get; set; }

    /// <summary>
    /// オプション値
    /// </summary>
    public string OptionValue { get; set; }

    /// <summary>
    /// オプション名
    /// </summary>
    public string OptionName { get; set; }

    /// <summary>
    /// 備考
    /// </summary>
    public string Note { get; set; }
}
