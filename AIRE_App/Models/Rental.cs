using System;
using System.Collections.Generic;

namespace AIRE_DB.Models;

/// <summary>
/// 賃貸物件
/// </summary>
public partial class Rental
{
    /// <summary>
    /// 賃貸物件ID
    /// </summary>
    public string RentalId { get; set; }

    /// <summary>
    /// 作成日時
    /// </summary>
    public DateTime? CreationTime { get; set; }

    /// <summary>
    /// 変更日時
    /// </summary>
    public DateTime? ModificationTime { get; set; }

    /// <summary>
    /// 賃貸物件共通ID
    /// </summary>
    public string RentalCommonId { get; set; }

    /// <summary>
    /// 会社ID
    /// </summary>
    public string CompanyId { get; set; }

    /// <summary>
    /// 担当社員ID
    /// </summary>
    public string StaffId { get; set; }

    /// <summary>
    /// 物件タイプ
    /// </summary>
    public string PropertyType { get; set; }

    /// <summary>
    /// 建物名
    /// </summary>
    public string BuildingName { get; set; }

    /// <summary>
    /// 賃料
    /// </summary>
    public decimal Rent { get; set; }

    /// <summary>
    /// 管理費等
    /// </summary>
    public decimal ManagementFee { get; set; }

    /// <summary>
    /// 維持費等
    /// </summary>
    public decimal MaintenanceFee { get; set; }

    /// <summary>
    /// 敷金
    /// </summary>
    public string SecurityDeposit { get; set; }

    /// <summary>
    /// 礼金
    /// </summary>
    public string KeyMoney { get; set; }

    /// <summary>
    /// 保証金
    /// </summary>
    public string GuaranteeMoney { get; set; }

    /// <summary>
    /// 敷引・償却金
    /// </summary>
    public string DepositDeduction { get; set; }

    /// <summary>
    /// 所在地
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// 交通1
    /// </summary>
    public string Transportation1 { get; set; }

    /// <summary>
    /// 徒歩距離1
    /// </summary>
    public short WalkingDistance1 { get; set; }

    /// <summary>
    /// 交通2
    /// </summary>
    public string Transportation2 { get; set; }

    /// <summary>
    /// 徒歩距離2
    /// </summary>
    public short? WalkingDistance2 { get; set; }

    /// <summary>
    /// 交通3
    /// </summary>
    public string Transportation3 { get; set; }

    /// <summary>
    /// 徒歩距離3
    /// </summary>
    public short? WalkingDistance3 { get; set; }

    /// <summary>
    /// 間取り（番号）
    /// </summary>
    public short LayoutNumber { get; set; }

    /// <summary>
    /// 間取り（タイプ）
    /// </summary>
    public string LayoutType { get; set; }

    /// <summary>
    /// 間取り（詳細）
    /// </summary>
    public string LayoutDetails { get; set; }

    /// <summary>
    /// 専有面積
    /// </summary>
    public decimal ExclusiveArea { get; set; }

    /// <summary>
    /// バルコニー面積
    /// </summary>
    public decimal? BalconyArea { get; set; }

    /// <summary>
    /// 新築
    /// </summary>
    public bool NewConstruction { get; set; }

    /// <summary>
    /// 築年月
    /// </summary>
    public DateOnly BuiltYearMonth { get; set; }

    /// <summary>
    /// 所在階
    /// </summary>
    public string FloorNumber { get; set; }

    /// <summary>
    /// 階建
    /// </summary>
    public string TotalFloors { get; set; }

    /// <summary>
    /// 主要採光面
    /// </summary>
    public string MainLightDirection { get; set; }

    /// <summary>
    /// 建物種類
    /// </summary>
    public string BuildingType { get; set; }

    /// <summary>
    /// 建物構造・工法
    /// </summary>
    public string BuildingStructure { get; set; }

    /// <summary>
    /// エネルギー消費性能
    /// </summary>
    public string EnergyEfficiency { get; set; }

    /// <summary>
    /// 断熱性能
    /// </summary>
    public string InsulationPerformance { get; set; }

    /// <summary>
    /// 目安光熱費
    /// </summary>
    public string EstimatedUtilityCost { get; set; }

    /// <summary>
    /// 保険等
    /// </summary>
    public string Insurance { get; set; }

    /// <summary>
    /// 駐車場
    /// </summary>
    public string Parking { get; set; }

    /// <summary>
    /// 現況
    /// </summary>
    public string CurrentCondition { get; set; }

    /// <summary>
    /// 入居可能時期
    /// </summary>
    public string AvailableFrom { get; set; }

    /// <summary>
    /// 取引態様
    /// </summary>
    public string TransactionType { get; set; }

    /// <summary>
    /// 鍵タイプ
    /// </summary>
    public string KeyType { get; set; }

    /// <summary>
    /// 条件等
    /// </summary>
    public string RentalConditions { get; set; }

    /// <summary>
    /// 店舗・会社名
    /// </summary>
    public string ShopCompanyName { get; set; }

    /// <summary>
    /// 店舗・会社番号
    /// </summary>
    public string ShopCompanyId { get; set; }

    /// <summary>
    /// 管理システム番号
    /// </summary>
    public string ManagementSystemId { get; set; }

    /// <summary>
    /// 総戸数
    /// </summary>
    public string TotalUnits { get; set; }

    /// <summary>
    /// 情報公開日
    /// </summary>
    public DateOnly? PublishedDate { get; set; }

    /// <summary>
    /// 情報更新日
    /// </summary>
    public DateOnly? UpdatedDate { get; set; }

    /// <summary>
    /// 次回更新予定日
    /// </summary>
    public string NextUpdateDate { get; set; }

    /// <summary>
    /// 契約期間
    /// </summary>
    public string ContractPeriod { get; set; }

    /// <summary>
    /// 更新料
    /// </summary>
    public string RenewalFee { get; set; }

    /// <summary>
    /// 保証会社
    /// </summary>
    public string GuarantorCompany { get; set; }

    /// <summary>
    /// その他初期費用
    /// </summary>
    public string OtherInitialCosts { get; set; }

    /// <summary>
    /// その他諸費用
    /// </summary>
    public string OtherAdditionalCosts { get; set; }

    /// <summary>
    /// 建物外観画像
    /// </summary>
    public string ExteriorPhoto { get; set; }

    /// <summary>
    /// 間取り図面
    /// </summary>
    public string LayoutImage { get; set; }

    /// <summary>
    /// 備考
    /// </summary>
    public string Remarks { get; set; }

    /// <summary>
    /// フリーキーワード
    /// </summary>
    public string FreeKeyword { get; set; }

    public DateOnly? EffectiveStartDate { get; set; }

    public DateOnly? EffectiveEndDate { get; set; }
}
