using System;
using System.Collections.Generic;

namespace AIRE_DB.Models;

/// <summary>
/// 賃貸物件概要
/// </summary>
public partial class RentalSummary
{
    /// <summary>
    /// 賃貸物件ID
    /// </summary>
    public string RentalId { get; set; }

    /// <summary>
    /// 都道府県名
    /// </summary>
    public string PrefectureName { get; set; }

    /// <summary>
    /// エリア名
    /// </summary>
    public string AreaName { get; set; }

    /// <summary>
    /// 物件タイプ
    /// </summary>
    public string PropertyType { get; set; }

    /// <summary>
    /// 家賃、価格
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// 管理費
    /// </summary>
    public decimal? ManagementFee { get; set; }

    /// <summary>
    /// 敷金
    /// </summary>
    public decimal SecurityDeposit { get; set; }

    /// <summary>
    /// 礼金
    /// </summary>
    public decimal KeyMoney { get; set; }

    /// <summary>
    /// 所在地（何丁目まで）
    /// </summary>
    public string AddressStreetPart { get; set; }

    /// <summary>
    /// 所在地（何番から）
    /// </summary>
    public string AddressNumberPart { get; set; }

    /// <summary>
    /// 駅1の名前
    /// </summary>
    public string Station1Name { get; set; }

    /// <summary>
    /// 駅1までの所要時間（バス）
    /// </summary>
    public short? Station1BusMin { get; set; }

    /// <summary>
    /// 駅1までの所要時間（徒歩）
    /// </summary>
    public short? Station1WalkMin { get; set; }

    /// <summary>
    /// 駅1までの所要時間（車）
    /// </summary>
    public short? Station1CarTime { get; set; }

    /// <summary>
    /// 駅2の名前
    /// </summary>
    public string Station2Name { get; set; }

    /// <summary>
    /// 駅2までの所要時間（バス）
    /// </summary>
    public short? Station2BusMin { get; set; }

    /// <summary>
    /// 駅2までの所要時間（徒歩）
    /// </summary>
    public short? Station2WalkMin { get; set; }

    /// <summary>
    /// 駅2までの所要時間（車）
    /// </summary>
    public short? Station2CarTime { get; set; }

    /// <summary>
    /// 駅3の名前
    /// </summary>
    public string Station3Name { get; set; }

    /// <summary>
    /// 駅3までの所要時間（バス）
    /// </summary>
    public short? Station3BusMin { get; set; }

    /// <summary>
    /// 駅3までの所要時間（徒歩）
    /// </summary>
    public short? Station3WalkMin { get; set; }

    /// <summary>
    /// 駅3までの所要時間（車）
    /// </summary>
    public short? Station3CarTime { get; set; }

    /// <summary>
    /// 物件種目
    /// </summary>
    public string PropertyCategory { get; set; }

    /// <summary>
    /// 構造・材質
    /// </summary>
    public string StructureMaterial { get; set; }

    /// <summary>
    /// 間取り
    /// </summary>
    public string FloorPlanType { get; set; }

    /// <summary>
    /// 階層（地上）
    /// </summary>
    public short? AboveGroundFloors { get; set; }

    /// <summary>
    /// 階層（地下）
    /// </summary>
    public short? BelowGroundFloors { get; set; }

    /// <summary>
    /// 所在階
    /// </summary>
    public short? CurrentFloor { get; set; }

    /// <summary>
    /// 築年月
    /// </summary>
    public DateOnly ConstructionDate { get; set; }

    /// <summary>
    /// 専有面積
    /// </summary>
    public decimal ExclusiveArea { get; set; }

    /// <summary>
    /// 建物名
    /// </summary>
    public string BuildingName { get; set; }

    /// <summary>
    /// 建物外観画像（URL）
    /// </summary>
    public string ExteriorPhoto { get; set; }

    /// <summary>
    /// 間取り図面（URL）
    /// </summary>
    public string FloorPlanImage { get; set; }

    /// <summary>
    /// 推薦物件
    /// </summary>
    public bool Recommend { get; set; }
}
