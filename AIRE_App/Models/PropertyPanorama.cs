using System;
using System.Collections.Generic;

namespace EFCore.Models;

/// <summary>
/// 掲載物件パノラマ
/// </summary>
public partial class PropertyPanorama
{
    /// <summary>
    /// 物件ID
    /// </summary>
    public string PropertyId { get; set; }

    /// <summary>
    /// パノラマID
    /// </summary>
    public short PanoramaId { get; set; }

    /// <summary>
    /// 物件タイプ
    /// </summary>
    public string PropertyType { get; set; }

    /// <summary>
    /// パノラマURI
    /// </summary>
    public string PanoramaUri { get; set; }

    /// <summary>
    /// カテゴリ
    /// </summary>
    public string Panoramacategory { get; set; }

    /// <summary>
    /// カメラ種類
    /// </summary>
    public string Panoramacaption { get; set; }
}
