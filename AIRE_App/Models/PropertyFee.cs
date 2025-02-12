using System;
using System.Collections.Generic;

namespace EFCore.Models;

/// <summary>
/// 掲載物件費用
/// </summary>
public partial class PropertyFee
{
    /// <summary>
    /// 物件ID
    /// </summary>
    public string PropertyId { get; set; }

    /// <summary>
    /// 費用ID
    /// </summary>
    public short FeeId { get; set; }

    /// <summary>
    /// 物件タイプ
    /// </summary>
    public string PropertyType { get; set; }

    /// <summary>
    /// 名目
    /// </summary>
    public string Sonotakinnai { get; set; }

    /// <summary>
    /// 区分
    /// </summary>
    public string Sonotakinkbn { get; set; }

    /// <summary>
    /// 金額
    /// </summary>
    public decimal Sonotakin { get; set; }

    /// <summary>
    /// 単位
    /// </summary>
    public string Sonotakinkikankbn { get; set; }

    /// <summary>
    /// 日割
    /// </summary>
    public bool Sonotakinhiwarikbn { get; set; }

    /// <summary>
    /// 時期
    /// </summary>
    public string Sonotakinjikikbn { get; set; }
}
