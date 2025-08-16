using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AIRE_DB.Models;

public partial class AireDbContext : DbContext
{
    public AireDbContext(DbContextOptions<AireDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<CodeMaster> CodeMasters { get; set; }

    public virtual DbSet<CompanyGroup> CompanyGroups { get; set; }

    public virtual DbSet<CompanyMember> CompanyMembers { get; set; }

    public virtual DbSet<Prefecture> Prefectures { get; set; }

    public virtual DbSet<PromptMaster> PromptMasters { get; set; }

    public virtual DbSet<RailwayInfo> RailwayInfos { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<RentalImage> RentalImages { get; set; }

    public virtual DbSet<RentalSummary> RentalSummaries { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("area_pkey");

            entity.ToTable("area", tb => tb.HasComment("エリア"));

            entity.Property(e => e.AreaId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasComment("エリアID")
                .HasColumnName("area_id");
            entity.Property(e => e.AreaName)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("エリア名")
                .HasColumnName("area_name");
            entity.Property(e => e.CreationTime)
                .HasComment("作成日時")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creation_time");
            entity.Property(e => e.ModificationTime)
                .HasComment("変更日時")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modification_time");
            entity.Property(e => e.ParentAreaId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasComment("親エリアID")
                .HasColumnName("parent_area_id");
            entity.Property(e => e.PrefectureId)
                .IsRequired()
                .HasMaxLength(5)
                .IsFixedLength()
                .HasComment("都道府県ID")
                .HasColumnName("prefecture_id");
            entity.Property(e => e.RevisedAreaId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasComment("改訂エリアID")
                .HasColumnName("revised_area_id");
        });

        modelBuilder.Entity<CodeMaster>(entity =>
        {
            entity.HasKey(e => new { e.CodeType, e.OptionValue }).HasName("code_master_pkey");

            entity.ToTable("code_master", tb => tb.HasComment("コードマスタ"));

            entity.Property(e => e.CodeType)
                .HasMaxLength(32)
                .HasComment("コードタイプ")
                .HasColumnName("code_type");
            entity.Property(e => e.OptionValue)
                .HasMaxLength(32)
                .HasComment("オプション値")
                .HasColumnName("option_value");
            entity.Property(e => e.CodeName)
                .HasMaxLength(32)
                .HasComment("コード名")
                .HasColumnName("code_name");
            entity.Property(e => e.CreationTime)
                .HasComment("作成日時")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creation_time");
            entity.Property(e => e.ModificationTime)
                .HasComment("変更日時")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modification_time");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasComment("備考")
                .HasColumnName("note");
            entity.Property(e => e.OptionName)
                .HasMaxLength(32)
                .HasComment("オプション名")
                .HasColumnName("option_name");
        });

        modelBuilder.Entity<CompanyGroup>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("company_group_pkey");

            entity.ToTable("company_group", tb => tb.HasComment("会社グループ"));

            entity.Property(e => e.CompanyId)
                .HasMaxLength(40)
                .HasComment("会社ID")
                .HasColumnName("company_id");
            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("会社名")
                .HasColumnName("company_name");
            entity.Property(e => e.CompanyOverview)
                .HasMaxLength(255)
                .HasComment("会社概要")
                .HasColumnName("company_overview");
            entity.Property(e => e.CreationTime)
                .HasComment("作成日時")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creation_time");
            entity.Property(e => e.ModificationTime)
                .HasComment("変更日時")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modification_time");
        });

        modelBuilder.Entity<CompanyMember>(entity =>
        {
            entity.HasKey(e => new { e.CompanyId, e.StaffId }).HasName("company_member_pkey");

            entity.ToTable("company_member", tb => tb.HasComment("会社メンバー"));

            entity.Property(e => e.CompanyId)
                .HasMaxLength(40)
                .HasComment("会社ID")
                .HasColumnName("company_id");
            entity.Property(e => e.StaffId)
                .HasMaxLength(20)
                .HasComment("社員ID")
                .HasColumnName("staff_id");
            entity.Property(e => e.CreationTime)
                .HasComment("作成日時")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creation_time");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .HasComment("Eメール")
                .HasColumnName("email");
            entity.Property(e => e.IsBusiness)
                .HasDefaultValue(true)
                .HasComment("ビジネスアカウント")
                .HasColumnName("is_business");
            entity.Property(e => e.LineId)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("Line ID")
                .HasColumnName("line_id");
            entity.Property(e => e.ModificationTime)
                .HasComment("変更日時")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modification_time");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasComment("電話番号")
                .HasColumnName("phone_number");
            entity.Property(e => e.RouteId)
                .HasMaxLength(20)
                .HasComment("追加経路ID")
                .HasColumnName("route_id");
            entity.Property(e => e.StaffName)
                .HasMaxLength(40)
                .HasComment("社員名")
                .HasColumnName("staff_name");
        });

        modelBuilder.Entity<Prefecture>(entity =>
        {
            entity.HasKey(e => e.PrefectureId).HasName("prefecture_pkey");

            entity.ToTable("prefecture", tb => tb.HasComment("都道府県"));

            entity.Property(e => e.PrefectureId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasComment("都道府県ID")
                .HasColumnName("prefecture_id");
            entity.Property(e => e.CreationTime)
                .HasComment("作成日時")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creation_time");
            entity.Property(e => e.ModificationTime)
                .HasComment("変更日時")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modification_time");
            entity.Property(e => e.PrefectureName)
                .IsRequired()
                .HasMaxLength(10)
                .HasComment("都道府県名")
                .HasColumnName("prefecture_name");
        });

        modelBuilder.Entity<PromptMaster>(entity =>
        {
            entity.HasKey(e => new { e.PromptName, e.PromptType }).HasName("prompt_master_pkey");

            entity.ToTable("prompt_master", tb => tb.HasComment("プロンプトマスタ"));

            entity.Property(e => e.PromptName)
                .HasMaxLength(32)
                .HasComment("プロンプト名")
                .HasColumnName("prompt_name");
            entity.Property(e => e.PromptType)
                .HasMaxLength(16)
                .HasComment("プロンプトタイプ")
                .HasColumnName("prompt_type");
            entity.Property(e => e.CreationTime)
                .HasComment("作成日時")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creation_time");
            entity.Property(e => e.ModificationTime)
                .HasComment("変更日時")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modification_time");
            entity.Property(e => e.PromptValue)
                .IsRequired()
                .HasComment("プロンプト値")
                .HasColumnName("prompt_value");
        });

        modelBuilder.Entity<RailwayInfo>(entity =>
        {
            entity.HasKey(e => new { e.RailwayName, e.RailwayCompany, e.PrefectureId }).HasName("railway_info_pkey");

            entity.ToTable("railway_info", tb => tb.HasComment("鉄道情報"));

            entity.Property(e => e.RailwayName)
                .HasMaxLength(20)
                .HasComment("路線名")
                .HasColumnName("railway_name");
            entity.Property(e => e.RailwayCompany)
                .HasMaxLength(20)
                .HasComment("運営会社")
                .HasColumnName("railway_company");
            entity.Property(e => e.PrefectureId)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasComment("都道府県ID")
                .HasColumnName("prefecture_id");
            entity.Property(e => e.CreationTime)
                .HasComment("作成日時")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creation_time");
            entity.Property(e => e.ModificationTime)
                .HasComment("変更日時")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modification_time");
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.RentalId).HasName("rental_pkey");

            entity.ToTable("rental", tb => tb.HasComment("賃貸物件"));

            entity.Property(e => e.RentalId)
                .HasMaxLength(40)
                .HasComment("賃貸物件ID")
                .HasColumnName("rental_id");
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("所在地")
                .HasColumnName("address");
            entity.Property(e => e.AvailableFrom)
                .HasMaxLength(20)
                .HasComment("入居可能時期")
                .HasColumnName("available_from");
            entity.Property(e => e.BalconyArea)
                .HasPrecision(5)
                .HasComment("バルコニー面積")
                .HasColumnName("balcony_area");
            entity.Property(e => e.BuildingName)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("建物名")
                .HasColumnName("building_name");
            entity.Property(e => e.BuildingStructure)
                .HasMaxLength(40)
                .HasComment("建物構造・工法")
                .HasColumnName("building_structure");
            entity.Property(e => e.BuildingType)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("建物種類")
                .HasColumnName("building_type");
            entity.Property(e => e.BuiltYearMonth)
                .HasComment("築年月")
                .HasColumnName("built_year_month");
            entity.Property(e => e.CompanyId)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("会社ID")
                .HasColumnName("company_id");
            entity.Property(e => e.ContractPeriod)
                .HasMaxLength(20)
                .HasComment("契約期間")
                .HasColumnName("contract_period");
            entity.Property(e => e.CreationTime)
                .HasComment("作成日時")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creation_time");
            entity.Property(e => e.CurrentCondition)
                .HasMaxLength(20)
                .HasComment("現況")
                .HasColumnName("current_condition");
            entity.Property(e => e.DepositDeduction)
                .HasMaxLength(10)
                .HasDefaultValueSql("'-'::character varying")
                .HasComment("敷引・償却金")
                .HasColumnName("deposit_deduction");
            entity.Property(e => e.EffectiveEndDate).HasColumnName("effective_end_date");
            entity.Property(e => e.EffectiveStartDate).HasColumnName("effective_start_date");
            entity.Property(e => e.EnergyEfficiency)
                .HasMaxLength(20)
                .HasComment("エネルギー消費性能")
                .HasColumnName("energy_efficiency");
            entity.Property(e => e.EstimatedUtilityCost)
                .HasMaxLength(20)
                .HasComment("目安光熱費")
                .HasColumnName("estimated_utility_cost");
            entity.Property(e => e.ExclusiveArea)
                .HasPrecision(5)
                .HasComment("専有面積")
                .HasColumnName("exclusive_area");
            entity.Property(e => e.ExteriorPhoto)
                .HasMaxLength(255)
                .HasComment("建物外観画像")
                .HasColumnName("exterior_photo");
            entity.Property(e => e.FloorNumber)
                .IsRequired()
                .HasMaxLength(10)
                .HasComment("所在階")
                .HasColumnName("floor_number");
            entity.Property(e => e.FreeKeyword)
                .HasComment("フリーキーワード")
                .HasColumnName("free_keyword");
            entity.Property(e => e.GuaranteeMoney)
                .HasMaxLength(10)
                .HasDefaultValueSql("'-'::character varying")
                .HasComment("保証金")
                .HasColumnName("guarantee_money");
            entity.Property(e => e.GuarantorCompany)
                .HasMaxLength(255)
                .HasComment("保証会社")
                .HasColumnName("guarantor_company");
            entity.Property(e => e.InsulationPerformance)
                .HasMaxLength(20)
                .HasComment("断熱性能")
                .HasColumnName("insulation_performance");
            entity.Property(e => e.Insurance)
                .HasMaxLength(40)
                .HasComment("保険等")
                .HasColumnName("insurance");
            entity.Property(e => e.KeyMoney)
                .HasMaxLength(10)
                .HasDefaultValueSql("'-'::character varying")
                .HasComment("礼金")
                .HasColumnName("key_money");
            entity.Property(e => e.KeyType)
                .HasMaxLength(20)
                .HasComment("鍵タイプ")
                .HasColumnName("key_type");
            entity.Property(e => e.LayoutDetails)
                .HasMaxLength(40)
                .HasComment("間取り（詳細）")
                .HasColumnName("layout_details");
            entity.Property(e => e.LayoutImage)
                .HasMaxLength(255)
                .HasComment("間取り図面")
                .HasColumnName("layout_image");
            entity.Property(e => e.LayoutNumber)
                .HasComment("間取り（番号）")
                .HasColumnName("layout_number");
            entity.Property(e => e.LayoutType)
                .IsRequired()
                .HasMaxLength(32)
                .HasComment("間取り（タイプ）")
                .HasColumnName("layout_type");
            entity.Property(e => e.MainLightDirection)
                .IsRequired()
                .HasMaxLength(10)
                .HasComment("主要採光面")
                .HasColumnName("main_light_direction");
            entity.Property(e => e.MaintenanceFee)
                .HasPrecision(10)
                .HasComment("維持費等")
                .HasColumnName("maintenance_fee");
            entity.Property(e => e.ManagementFee)
                .HasPrecision(10)
                .HasComment("管理費等")
                .HasColumnName("management_fee");
            entity.Property(e => e.ManagementSystemId)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("管理システム番号")
                .HasColumnName("management_system_id");
            entity.Property(e => e.ModificationTime)
                .HasComment("変更日時")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modification_time");
            entity.Property(e => e.NewConstruction)
                .HasDefaultValue(false)
                .HasComment("新築")
                .HasColumnName("new_construction");
            entity.Property(e => e.NextUpdateDate)
                .HasMaxLength(20)
                .HasComment("次回更新予定日")
                .HasColumnName("next_update_date");
            entity.Property(e => e.OtherAdditionalCosts)
                .HasMaxLength(255)
                .HasComment("その他諸費用")
                .HasColumnName("other_additional_costs");
            entity.Property(e => e.OtherInitialCosts)
                .HasMaxLength(255)
                .HasComment("その他初期費用")
                .HasColumnName("other_initial_costs");
            entity.Property(e => e.Parking)
                .HasMaxLength(40)
                .HasDefaultValueSql("'-'::character varying")
                .HasComment("駐車場")
                .HasColumnName("parking");
            entity.Property(e => e.PropertyType)
                .IsRequired()
                .HasMaxLength(32)
                .HasDefaultValueSql("1")
                .HasComment("物件タイプ")
                .HasColumnName("property_type");
            entity.Property(e => e.PublishedDate)
                .HasComment("情報公開日")
                .HasColumnName("published_date");
            entity.Property(e => e.Remarks)
                .HasComment("備考")
                .HasColumnName("remarks");
            entity.Property(e => e.RenewalFee)
                .HasMaxLength(40)
                .HasComment("更新料")
                .HasColumnName("renewal_fee");
            entity.Property(e => e.Rent)
                .HasPrecision(15)
                .HasComment("賃料")
                .HasColumnName("rent");
            entity.Property(e => e.RentalCommonId)
                .HasMaxLength(40)
                .HasComment("賃貸物件共通ID")
                .HasColumnName("rental_common_id");
            entity.Property(e => e.RentalConditions)
                .HasMaxLength(255)
                .HasComment("条件等")
                .HasColumnName("rental_conditions");
            entity.Property(e => e.SecurityDeposit)
                .HasMaxLength(10)
                .HasDefaultValueSql("'-'::character varying")
                .HasComment("敷金")
                .HasColumnName("security_deposit");
            entity.Property(e => e.ShopCompanyId)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("店舗・会社番号")
                .HasColumnName("shop_company_id");
            entity.Property(e => e.ShopCompanyName)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("店舗・会社名")
                .HasColumnName("shop_company_name");
            entity.Property(e => e.StaffId)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("担当社員ID")
                .HasColumnName("staff_id");
            entity.Property(e => e.TotalFloors)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("階建")
                .HasColumnName("total_floors");
            entity.Property(e => e.TotalUnits)
                .HasMaxLength(20)
                .HasComment("総戸数")
                .HasColumnName("total_units");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(10)
                .HasComment("取引態様")
                .HasColumnName("transaction_type");
            entity.Property(e => e.Transportation1)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("交通1")
                .HasColumnName("transportation1");
            entity.Property(e => e.Transportation2)
                .HasMaxLength(40)
                .HasComment("交通2")
                .HasColumnName("transportation2");
            entity.Property(e => e.Transportation3)
                .HasMaxLength(40)
                .HasComment("交通3")
                .HasColumnName("transportation3");
            entity.Property(e => e.UpdatedDate)
                .HasComment("情報更新日")
                .HasColumnName("updated_date");
            entity.Property(e => e.WalkingDistance1)
                .HasComment("徒歩距離1")
                .HasColumnName("walking_distance1");
            entity.Property(e => e.WalkingDistance2)
                .HasComment("徒歩距離2")
                .HasColumnName("walking_distance2");
            entity.Property(e => e.WalkingDistance3)
                .HasComment("徒歩距離3")
                .HasColumnName("walking_distance3");
        });

        modelBuilder.Entity<RentalImage>(entity =>
        {
            entity.HasKey(e => new { e.RentalId, e.ImageId }).HasName("rental_image_pkey");

            entity.ToTable("rental_image", tb => tb.HasComment("賃貸物件画像"));

            entity.Property(e => e.RentalId)
                .HasMaxLength(40)
                .HasComment("賃貸物件ID")
                .HasColumnName("rental_id");
            entity.Property(e => e.ImageId)
                .HasComment("画像ID")
                .HasColumnName("image_id");
            entity.Property(e => e.CreationTime)
                .HasComment("作成日時")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creation_time");
            entity.Property(e => e.GpcaptionS)
                .HasMaxLength(40)
                .HasComment("コメント")
                .HasColumnName("gpcaption_s");
            entity.Property(e => e.ImageUri)
                .IsRequired()
                .HasMaxLength(255)
                .HasComment("画像URI")
                .HasColumnName("image_uri");
            entity.Property(e => e.ModificationTime)
                .HasComment("変更日時")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modification_time");
            entity.Property(e => e.Shuhenkyori)
                .HasComment("周辺施設まで")
                .HasColumnName("shuhenkyori");
            entity.Property(e => e.Shuhenmei)
                .HasMaxLength(80)
                .HasComment("施設名")
                .HasColumnName("shuhenmei");
        });

        modelBuilder.Entity<RentalSummary>(entity =>
        {
            entity.HasKey(e => e.RentalId).HasName("rental_summary_pkey");

            entity.ToTable("rental_summary", tb => tb.HasComment("賃貸物件概要"));

            entity.Property(e => e.RentalId)
                .HasMaxLength(40)
                .HasComment("賃貸物件ID")
                .HasColumnName("rental_id");
            entity.Property(e => e.AboveGroundFloors)
                .HasComment("階層（地上）")
                .HasColumnName("above_ground_floors");
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("所在地")
                .HasColumnName("address");
            entity.Property(e => e.AreaName)
                .IsRequired()
                .HasMaxLength(10)
                .HasComment("エリア名")
                .HasColumnName("area_name");
            entity.Property(e => e.BelowGroundFloors)
                .HasComment("階層（地下）")
                .HasColumnName("below_ground_floors");
            entity.Property(e => e.BuildingName)
                .HasMaxLength(40)
                .HasComment("建物名")
                .HasColumnName("building_name");
            entity.Property(e => e.ConstructionDate)
                .HasComment("築年月")
                .HasColumnName("construction_date");
            entity.Property(e => e.CreationTime)
                .HasComment("有効開始日")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creation_time");
            entity.Property(e => e.CurrentFloor)
                .HasComment("所在階")
                .HasColumnName("current_floor");
            entity.Property(e => e.EffectiveEndDate).HasColumnName("effective_end_date");
            entity.Property(e => e.EffectiveStartDate).HasColumnName("effective_start_date");
            entity.Property(e => e.ExclusiveArea)
                .HasPrecision(5, 2)
                .HasComment("専有面積")
                .HasColumnName("exclusive_area");
            entity.Property(e => e.ExteriorPhoto)
                .HasMaxLength(255)
                .HasComment("建物外観画像")
                .HasColumnName("exterior_photo");
            entity.Property(e => e.FloorPlanImage)
                .HasMaxLength(255)
                .HasComment("間取り図面")
                .HasColumnName("floor_plan_image");
            entity.Property(e => e.FloorPlanType)
                .HasMaxLength(32)
                .HasComment("間取り")
                .HasColumnName("floor_plan_type");
            entity.Property(e => e.KeyMoney)
                .HasPrecision(10, 2)
                .HasComment("礼金")
                .HasColumnName("key_money");
            entity.Property(e => e.ManagementFee)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("0")
                .HasComment("管理費")
                .HasColumnName("management_fee");
            entity.Property(e => e.ModificationTime)
                .HasComment("有効終了日")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modification_time");
            entity.Property(e => e.PrefectureName)
                .IsRequired()
                .HasMaxLength(10)
                .HasComment("都道府県名")
                .HasColumnName("prefecture_name");
            entity.Property(e => e.Price)
                .HasPrecision(15, 2)
                .HasComment("家賃、価格")
                .HasColumnName("price");
            entity.Property(e => e.PropertyCategory)
                .HasMaxLength(32)
                .HasComment("物件種目")
                .HasColumnName("property_category");
            entity.Property(e => e.PropertyType)
                .IsRequired()
                .HasMaxLength(32)
                .HasComment("物件タイプ")
                .HasColumnName("property_type");
            entity.Property(e => e.SecurityDeposit)
                .HasPrecision(10, 2)
                .HasComment("敷金")
                .HasColumnName("security_deposit");
            entity.Property(e => e.Station1Name)
                .HasMaxLength(40)
                .HasComment("駅1の名前")
                .HasColumnName("station1_name");
            entity.Property(e => e.Station1WalkMin)
                .HasComment("駅1までの所要時間（徒歩）")
                .HasColumnName("station1_walk_min");
            entity.Property(e => e.Station2Name)
                .HasMaxLength(40)
                .HasComment("駅2の名前")
                .HasColumnName("station2_name");
            entity.Property(e => e.Station2WalkMin)
                .HasComment("駅2までの所要時間（徒歩）")
                .HasColumnName("station2_walk_min");
            entity.Property(e => e.Station3Name)
                .HasMaxLength(40)
                .HasComment("駅3の名前")
                .HasColumnName("station3_name");
            entity.Property(e => e.Station3WalkMin)
                .HasComment("駅3までの所要時間（徒歩）")
                .HasColumnName("station3_walk_min");
            entity.Property(e => e.StructureMaterial)
                .HasMaxLength(32)
                .HasComment("構造・材質")
                .HasColumnName("structure_material");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.StationId).HasName("station_pkey");

            entity.ToTable("station", tb => tb.HasComment("駅"));

            entity.Property(e => e.StationId)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasComment("駅ID")
                .HasColumnName("station_id");
            entity.Property(e => e.CreationTime)
                .HasComment("作成日時")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creation_time");
            entity.Property(e => e.ModificationTime)
                .HasComment("変更日時")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modification_time");
            entity.Property(e => e.RailwayCompany)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("運営会社")
                .HasColumnName("railway_company");
            entity.Property(e => e.RailwayName)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("路線名")
                .HasColumnName("railway_name");
            entity.Property(e => e.StationName)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("駅名")
                .HasColumnName("station_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
