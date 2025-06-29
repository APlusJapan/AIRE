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

    public virtual DbSet<GeneralUser> GeneralUsers { get; set; }

    public virtual DbSet<OperationLog> OperationLogs { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Prefecture> Prefectures { get; set; }

    public virtual DbSet<PromptMaster> PromptMasters { get; set; }

    public virtual DbSet<PropertyDocument> PropertyDocuments { get; set; }

    public virtual DbSet<PropertyFee> PropertyFees { get; set; }

    public virtual DbSet<PropertyImage> PropertyImages { get; set; }

    public virtual DbSet<PropertyPanorama> PropertyPanoramas { get; set; }

    public virtual DbSet<PropertyVideo> PropertyVideos { get; set; }

    public virtual DbSet<RailwayInfo> RailwayInfos { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<RentalBrowsingHistory> RentalBrowsingHistories { get; set; }

    public virtual DbSet<RentalSearchHistory> RentalSearchHistories { get; set; }

    public virtual DbSet<RentalStatistic> RentalStatistics { get; set; }

    public virtual DbSet<RentalSummary> RentalSummaries { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

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

        modelBuilder.Entity<GeneralUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("general_user_pkey");

            entity.ToTable("general_user", tb => tb.HasComment("一般ユーザー"));

            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .HasComment("ユーザーID")
                .HasColumnName("user_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(40)
                .HasComment("ユーザー名")
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<OperationLog>(entity =>
        {
            entity.HasKey(e => new { e.DeviceUniqueId, e.OperationTime }).HasName("operation_log_pkey");

            entity.ToTable("operation_log", tb => tb.HasComment("操作ログ"));

            entity.Property(e => e.DeviceUniqueId)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasComment("デバイス一意ID ")
                .HasColumnName("device_unique_id");
            entity.Property(e => e.OperationTime)
                .HasComment("操作時間 ")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("operation_time");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasComment("ログ内容")
                .HasColumnName("content");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255)
                .HasComment("ログタイトル ")
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("ログタイプ ")
                .HasColumnName("type");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .HasComment("ユーザーID ")
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => new { e.RoleId, e.ActionId }).HasName("permission_pkey");

            entity.ToTable("permission", tb => tb.HasComment("権限"));

            entity.Property(e => e.RoleId)
                .HasMaxLength(20)
                .HasComment("ロールID")
                .HasColumnName("role_id");
            entity.Property(e => e.ActionId)
                .HasMaxLength(20)
                .HasComment("アクションID")
                .HasColumnName("action_id");
            entity.Property(e => e.Level)
                .HasComment("権限レベル")
                .HasColumnName("level");
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
            entity.Property(e => e.PromptValue)
                .IsRequired()
                .HasComment("プロンプト値")
                .HasColumnName("prompt_value");
        });

        modelBuilder.Entity<PropertyDocument>(entity =>
        {
            entity.HasKey(e => new { e.PropertyId, e.DocumentId, e.PropertyType }).HasName("property_document_pkey");

            entity.ToTable("property_document", tb => tb.HasComment("掲載物件資料"));

            entity.Property(e => e.PropertyId)
                .HasMaxLength(40)
                .HasComment("物件ID")
                .HasColumnName("property_id");
            entity.Property(e => e.DocumentId)
                .HasComment("資料ID")
                .HasColumnName("document_id");
            entity.Property(e => e.PropertyType)
                .HasMaxLength(32)
                .HasComment("物件タイプ")
                .HasColumnName("property_type");
            entity.Property(e => e.DocumentUri)
                .IsRequired()
                .HasMaxLength(255)
                .HasComment("資料URI")
                .HasColumnName("document_uri");
            entity.Property(e => e.Siryoucaption)
                .HasMaxLength(80)
                .HasComment("コメント")
                .HasColumnName("siryoucaption");
        });

        modelBuilder.Entity<PropertyFee>(entity =>
        {
            entity.HasKey(e => new { e.PropertyId, e.FeeId, e.PropertyType }).HasName("property_fee_pkey");

            entity.ToTable("property_fee", tb => tb.HasComment("掲載物件費用"));

            entity.Property(e => e.PropertyId)
                .HasMaxLength(40)
                .HasComment("物件ID")
                .HasColumnName("property_id");
            entity.Property(e => e.FeeId)
                .HasComment("費用ID")
                .HasColumnName("fee_id");
            entity.Property(e => e.PropertyType)
                .HasMaxLength(32)
                .HasComment("物件タイプ")
                .HasColumnName("property_type");
            entity.Property(e => e.Sonotakin)
                .HasPrecision(10, 2)
                .HasComment("金額")
                .HasColumnName("sonotakin");
            entity.Property(e => e.Sonotakinhiwarikbn)
                .HasDefaultValue(false)
                .HasComment("日割")
                .HasColumnName("sonotakinhiwarikbn");
            entity.Property(e => e.Sonotakinjikikbn)
                .HasMaxLength(32)
                .HasDefaultValueSql("0")
                .HasComment("時期")
                .HasColumnName("sonotakinjikikbn");
            entity.Property(e => e.Sonotakinkbn)
                .HasMaxLength(32)
                .HasDefaultValueSql("0")
                .HasComment("区分")
                .HasColumnName("sonotakinkbn");
            entity.Property(e => e.Sonotakinkikankbn)
                .HasMaxLength(32)
                .HasDefaultValueSql("0")
                .HasComment("単位")
                .HasColumnName("sonotakinkikankbn");
            entity.Property(e => e.Sonotakinnai)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("名目")
                .HasColumnName("sonotakinnai");
        });

        modelBuilder.Entity<PropertyImage>(entity =>
        {
            entity.HasKey(e => new { e.PropertyId, e.ImageId, e.PropertyType }).HasName("property_image_pkey");

            entity.ToTable("property_image", tb => tb.HasComment("掲載物件画像"));

            entity.Property(e => e.PropertyId)
                .HasMaxLength(40)
                .HasComment("物件ID")
                .HasColumnName("property_id");
            entity.Property(e => e.ImageId)
                .HasComment("画像ID")
                .HasColumnName("image_id");
            entity.Property(e => e.PropertyType)
                .HasMaxLength(32)
                .HasComment("物件タイプ")
                .HasColumnName("property_type");
            entity.Property(e => e.GpcaptionS)
                .HasMaxLength(40)
                .HasComment("コメント")
                .HasColumnName("gpcaption_s");
            entity.Property(e => e.Gpcategory)
                .HasMaxLength(32)
                .HasDefaultValueSql("0")
                .HasComment("カテゴリ")
                .HasColumnName("gpcategory");
            entity.Property(e => e.ImageUri)
                .IsRequired()
                .HasMaxLength(255)
                .HasComment("画像URI")
                .HasColumnName("image_uri");
            entity.Property(e => e.Shuhenkyori)
                .HasComment("周辺施設まで")
                .HasColumnName("shuhenkyori");
            entity.Property(e => e.Shuhenmei)
                .HasMaxLength(80)
                .HasComment("施設名")
                .HasColumnName("shuhenmei");
        });

        modelBuilder.Entity<PropertyPanorama>(entity =>
        {
            entity.HasKey(e => new { e.PropertyId, e.PanoramaId, e.PropertyType }).HasName("property_panorama_pkey");

            entity.ToTable("property_panorama", tb => tb.HasComment("掲載物件パノラマ"));

            entity.Property(e => e.PropertyId)
                .HasMaxLength(40)
                .HasComment("物件ID")
                .HasColumnName("property_id");
            entity.Property(e => e.PanoramaId)
                .HasComment("パノラマID")
                .HasColumnName("panorama_id");
            entity.Property(e => e.PropertyType)
                .HasMaxLength(32)
                .HasComment("物件タイプ")
                .HasColumnName("property_type");
            entity.Property(e => e.PanoramaUri)
                .IsRequired()
                .HasMaxLength(255)
                .HasComment("パノラマURI")
                .HasColumnName("panorama_uri");
            entity.Property(e => e.Panoramacaption)
                .HasMaxLength(32)
                .HasDefaultValueSql("0")
                .HasComment("カメラ種類")
                .HasColumnName("panoramacaption");
            entity.Property(e => e.Panoramacategory)
                .HasMaxLength(32)
                .HasDefaultValueSql("0")
                .HasComment("カテゴリ")
                .HasColumnName("panoramacategory");
        });

        modelBuilder.Entity<PropertyVideo>(entity =>
        {
            entity.HasKey(e => new { e.PropertyId, e.VideoId, e.PropertyType }).HasName("property_video_pkey");

            entity.ToTable("property_video", tb => tb.HasComment("掲載物件動画"));

            entity.Property(e => e.PropertyId)
                .HasMaxLength(40)
                .HasComment("物件ID")
                .HasColumnName("property_id");
            entity.Property(e => e.VideoId)
                .HasComment("動画ID")
                .HasColumnName("video_id");
            entity.Property(e => e.PropertyType)
                .HasMaxLength(32)
                .HasComment("物件タイプ")
                .HasColumnName("property_type");
            entity.Property(e => e.DougafCaption)
                .HasMaxLength(255)
                .HasComment("キャプション")
                .HasColumnName("dougaf_caption");
            entity.Property(e => e.DougafName)
                .HasMaxLength(255)
                .HasComment("動画名")
                .HasColumnName("dougaf_name");
            entity.Property(e => e.VideoUri)
                .IsRequired()
                .HasMaxLength(255)
                .HasComment("動画URI")
                .HasColumnName("video_uri");
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
            entity.Property(e => e.CurrentCondition)
                .HasMaxLength(20)
                .HasComment("現況")
                .HasColumnName("current_condition");
            entity.Property(e => e.DepositDeduction)
                .HasMaxLength(10)
                .HasDefaultValueSql("'-'::character varying")
                .HasComment("敷引・償却金")
                .HasColumnName("deposit_deduction");
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

        modelBuilder.Entity<RentalBrowsingHistory>(entity =>
        {
            entity.HasKey(e => new { e.DeviceUniqueId, e.OperationTime }).HasName("rental_browsing_history_pkey");

            entity.ToTable("rental_browsing_history", tb => tb.HasComment("賃貸物件閲覧履歴"));

            entity.Property(e => e.DeviceUniqueId)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasComment("デバイス一意ID")
                .HasColumnName("device_unique_id");
            entity.Property(e => e.OperationTime)
                .HasComment("操作時間")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("operation_time");
            entity.Property(e => e.Favorite)
                .HasDefaultValue(false)
                .HasComment("お気に入り")
                .HasColumnName("favorite");
            entity.Property(e => e.LogicalDelete)
                .HasDefaultValue(false)
                .HasComment("論理削除")
                .HasColumnName("logical_delete");
            entity.Property(e => e.RentalId)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("物件ID")
                .HasColumnName("rental_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .HasComment("ユーザーID")
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<RentalSearchHistory>(entity =>
        {
            entity.HasKey(e => new { e.DeviceUniqueId, e.OperationTime }).HasName("rental_search_history_pkey");

            entity.ToTable("rental_search_history", tb => tb.HasComment("賃貸物件検索履歴"));

            entity.Property(e => e.DeviceUniqueId)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasComment("デバイス一意ID")
                .HasColumnName("device_unique_id");
            entity.Property(e => e.OperationTime)
                .HasComment("操作時間")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("operation_time");
            entity.Property(e => e.Apartment)
                .HasDefaultValue(false)
                .HasComment("アパート")
                .HasColumnName("apartment");
            entity.Property(e => e.Baiku)
                .HasDefaultValue(false)
                .HasComment("バイク置場あり")
                .HasColumnName("baiku");
            entity.Property(e => e.Barukoni)
                .HasDefaultValue(false)
                .HasComment("バルコニー付")
                .HasColumnName("barukoni");
            entity.Property(e => e.Bfree)
                .HasDefaultValue(false)
                .HasComment("バリアフリー")
                .HasColumnName("bfree");
            entity.Property(e => e.Block)
                .HasDefaultValue(false)
                .HasComment("ブロック・その他")
                .HasColumnName("block");
            entity.Property(e => e.BouhanCamera)
                .HasDefaultValue(false)
                .HasComment("防犯カメラ")
                .HasColumnName("bouhan_camera");
            entity.Property(e => e.Bouon)
                .HasDefaultValue(false)
                .HasComment("防音室")
                .HasColumnName("bouon");
            entity.Property(e => e.Bs)
                .HasDefaultValue(false)
                .HasComment("BSアンテナ")
                .HasColumnName("bs");
            entity.Property(e => e.Btbetu)
                .HasDefaultValue(false)
                .HasComment("バス・トイレ別")
                .HasColumnName("btbetu");
            entity.Property(e => e.Bunjou)
                .HasDefaultValue(false)
                .HasComment("分譲賃貸")
                .HasColumnName("bunjou");
            entity.Property(e => e.Catv)
                .HasDefaultValue(false)
                .HasComment("ケーブルテレビ")
                .HasColumnName("catv");
            entity.Property(e => e.Chikashitsu)
                .HasDefaultValue(false)
                .HasComment("地下室")
                .HasColumnName("chikashitsu");
            entity.Property(e => e.Chikunensu)
                .HasComment("築後年数")
                .HasColumnName("chikunensu");
            entity.Property(e => e.CityGas)
                .HasDefaultValue(false)
                .HasComment("都市ガス")
                .HasColumnName("city_gas");
            entity.Property(e => e.Ckittin)
                .HasDefaultValue(false)
                .HasComment("カウンターキッチン")
                .HasColumnName("ckittin");
            entity.Property(e => e.Cs)
                .HasDefaultValue(false)
                .HasComment("CSアンテナ")
                .HasColumnName("cs");
            entity.Property(e => e.Customizeka)
                .HasDefaultValue(false)
                .HasComment("カスタマイズ可")
                .HasColumnName("customizeka");
            entity.Property(e => e.Denka)
                .HasDefaultValue(false)
                .HasComment("オール電化")
                .HasColumnName("denka");
            entity.Property(e => e.DetachedHouse)
                .HasDefaultValue(false)
                .HasComment("一戸建て・その他")
                .HasColumnName("detached_house");
            entity.Property(e => e.Dezaina)
                .HasDefaultValue(false)
                .HasComment("デザイナーズ物件")
                .HasColumnName("dezaina");
            entity.Property(e => e.Diyka)
                .HasDefaultValue(false)
                .HasComment("DIY可")
                .HasColumnName("diyka");
            entity.Property(e => e.Eakon)
                .HasDefaultValue(false)
                .HasComment("エアコン付き")
                .HasColumnName("eakon");
            entity.Property(e => e.East)
                .HasDefaultValue(false)
                .HasComment("東")
                .HasColumnName("east");
            entity.Property(e => e.Erebeta)
                .HasDefaultValue(false)
                .HasComment("エレベーター")
                .HasColumnName("erebeta");
            entity.Property(e => e.Favorite)
                .HasDefaultValue(false)
                .HasComment("お気に入り")
                .HasColumnName("favorite");
            entity.Property(e => e.FirstFloor)
                .HasDefaultValue(false)
                .HasComment("1 階の物件")
                .HasColumnName("first_floor");
            entity.Property(e => e.Freerent)
                .HasDefaultValue(false)
                .HasComment("フリーレント")
                .HasColumnName("freerent");
            entity.Property(e => e.Furoringu)
                .HasDefaultValue(false)
                .HasComment("フローリング")
                .HasColumnName("furoringu");
            entity.Property(e => e.Gakki)
                .HasDefaultValue(false)
                .HasComment("楽器相談可")
                .HasColumnName("gakki");
            entity.Property(e => e.Gasdan)
                .HasDefaultValue(false)
                .HasComment("ガス暖房")
                .HasColumnName("gasdan");
            entity.Property(e => e.Gomiokiba)
                .HasDefaultValue(false)
                .HasComment("敷地内ゴミ置場")
                .HasColumnName("gomiokiba");
            entity.Property(e => e.Has2Gaskonro)
                .HasDefaultValue(false)
                .HasComment("コンロ2口以上")
                .HasColumnName("has_2_gaskonro");
            entity.Property(e => e.HasGaskonro)
                .HasDefaultValue(false)
                .HasComment("ガスコンロ対応")
                .HasColumnName("has_gaskonro");
            entity.Property(e => e.Hosyounin)
                .HasDefaultValue(false)
                .HasComment("保証人不要")
                .HasColumnName("hosyounin");
            entity.Property(e => e.Ih)
                .HasDefaultValue(false)
                .HasComment("IHコンロ")
                .HasColumnName("ih");
            entity.Property(e => e.IncludeKanrihi)
                .HasDefaultValue(false)
                .HasComment("管理費・共益費込み")
                .HasColumnName("include_kanrihi");
            entity.Property(e => e.IncludeTyunedan)
                .HasDefaultValue(false)
                .HasComment("駐車場代込み")
                .HasColumnName("include_tyunedan");
            entity.Property(e => e.Inetmuryou)
                .HasDefaultValue(false)
                .HasComment("インターネット無料")
                .HasColumnName("inetmuryou");
            entity.Property(e => e.Intanet)
                .HasDefaultValue(false)
                .HasComment("インターネット接続可")
                .HasColumnName("intanet");
            entity.Property(e => e.Itjusetu)
                .HasDefaultValue(false)
                .HasComment("IT重説 対応物件")
                .HasColumnName("itjusetu");
            entity.Property(e => e.Jimusyoriyou)
                .HasDefaultValue(false)
                .HasComment("事務所利用可")
                .HasColumnName("jimusyoriyou");
            entity.Property(e => e.Jyosei)
                .HasDefaultValue(false)
                .HasComment("女性限定")
                .HasColumnName("jyosei");
            entity.Property(e => e.Kadentsuki)
                .HasDefaultValue(false)
                .HasComment("家電付")
                .HasColumnName("kadentsuki");
            entity.Property(e => e.Kadobeya)
                .HasDefaultValue(false)
                .HasComment("角部屋")
                .HasColumnName("kadobeya");
            entity.Property(e => e.Kagutsuki)
                .HasDefaultValue(false)
                .HasComment("家具付")
                .HasColumnName("kagutsuki");
            entity.Property(e => e.Koureisya)
                .HasDefaultValue(false)
                .HasComment("高齢者歓迎")
                .HasColumnName("koureisya");
            entity.Property(e => e.Kutsubako)
                .HasDefaultValue(false)
                .HasComment("シューズボックス")
                .HasColumnName("kutsubako");
            entity.Property(e => e.Lgbt)
                .HasDefaultValue(false)
                .HasComment("LGBTフレンドリー")
                .HasColumnName("lgbt");
            entity.Property(e => e.LogicalDelete)
                .HasDefaultValue(false)
                .HasComment("論理削除")
                .HasColumnName("logical_delete");
            entity.Property(e => e.LpGas)
                .HasDefaultValue(false)
                .HasComment("プロパンガス")
                .HasColumnName("lp_gas");
            entity.Property(e => e.Mansion)
                .HasDefaultValue(false)
                .HasComment("マンション")
                .HasColumnName("mansion");
            entity.Property(e => e.MaxMen)
                .HasComment("面積上限")
                .HasColumnName("max_men");
            entity.Property(e => e.MaxYachin)
                .HasComment("賃料上限")
                .HasColumnName("max_yachin");
            entity.Property(e => e.Mezonetto)
                .HasDefaultValue(false)
                .HasComment("メゾネット")
                .HasColumnName("mezonetto");
            entity.Property(e => e.MinMen)
                .HasComment("面積下限")
                .HasColumnName("min_men");
            entity.Property(e => e.MinYachin)
                .HasComment("賃料下限")
                .HasColumnName("min_yachin");
            entity.Property(e => e.Minamimuki)
                .HasDefaultValue(false)
                .HasComment("南向き")
                .HasColumnName("minamimuki");
            entity.Property(e => e.NewLastWeek)
                .HasDefaultValue(false)
                .HasComment("新着（2～7日前）")
                .HasColumnName("new_last_week");
            entity.Property(e => e.NewToday)
                .HasDefaultValue(false)
                .HasComment("本日の新着物件")
                .HasColumnName("new_today");
            entity.Property(e => e.Niwa)
                .HasDefaultValue(false)
                .HasComment("専用庭")
                .HasColumnName("niwa");
            entity.Property(e => e.NoReikin)
                .HasDefaultValue(false)
                .HasComment("礼金なし")
                .HasColumnName("no_reikin");
            entity.Property(e => e.NoShikikin)
                .HasDefaultValue(false)
                .HasComment("敷金・保証金なし")
                .HasColumnName("no_shikikin");
            entity.Property(e => e.NoTeisyaku)
                .HasDefaultValue(false)
                .HasComment("定期借家を含まない")
                .HasColumnName("no_teisyaku");
            entity.Property(e => e.North)
                .HasDefaultValue(false)
                .HasComment("北")
                .HasColumnName("north");
            entity.Property(e => e.Northeast)
                .HasDefaultValue(false)
                .HasComment("北東")
                .HasColumnName("northeast");
            entity.Property(e => e.Northwest)
                .HasDefaultValue(false)
                .HasComment("北西")
                .HasColumnName("northwest");
            entity.Property(e => e.Oidaki)
                .HasDefaultValue(false)
                .HasComment("追い焚き風呂")
                .HasColumnName("oidaki");
            entity.Property(e => e.Oneroom)
                .HasDefaultValue(false)
                .HasComment("ワンルーム")
                .HasColumnName("oneroom");
            entity.Property(e => e.Outorok)
                .HasDefaultValue(false)
                .HasComment("オートロック")
                .HasColumnName("outorok");
            entity.Property(e => e.Petka)
                .HasDefaultValue(false)
                .HasComment("ペット相談可")
                .HasColumnName("petka");
            entity.Property(e => e.Rbarukoni)
                .HasDefaultValue(false)
                .HasComment("ルーフバルコニー付")
                .HasColumnName("rbarukoni");
            entity.Property(e => e.Rebar)
                .HasDefaultValue(false)
                .HasComment("鉄筋系")
                .HasColumnName("rebar");
            entity.Property(e => e.Reform)
                .HasDefaultValue(false)
                .HasComment("リフォーム済み")
                .HasColumnName("reform");
            entity.Property(e => e.Renova)
                .HasDefaultValue(false)
                .HasComment("リノベーション物件")
                .HasColumnName("renova");
            entity.Property(e => e.Rofuto)
                .HasDefaultValue(false)
                .HasComment("ロフト")
                .HasColumnName("rofuto");
            entity.Property(e => e.Room1dk)
                .HasDefaultValue(false)
                .HasComment("1DK")
                .HasColumnName("room_1dk");
            entity.Property(e => e.Room1k)
                .HasDefaultValue(false)
                .HasComment("1K")
                .HasColumnName("room_1k");
            entity.Property(e => e.Room1ldk)
                .HasDefaultValue(false)
                .HasComment("1LDK")
                .HasColumnName("room_1ldk");
            entity.Property(e => e.Room2dk)
                .HasDefaultValue(false)
                .HasComment("2DK")
                .HasColumnName("room_2dk");
            entity.Property(e => e.Room2k)
                .HasDefaultValue(false)
                .HasComment("2K")
                .HasColumnName("room_2k");
            entity.Property(e => e.Room2ldk)
                .HasDefaultValue(false)
                .HasComment("2LDK")
                .HasColumnName("room_2ldk");
            entity.Property(e => e.Room3dk)
                .HasDefaultValue(false)
                .HasComment("3DK")
                .HasColumnName("room_3dk");
            entity.Property(e => e.Room3k)
                .HasDefaultValue(false)
                .HasComment("3K")
                .HasColumnName("room_3k");
            entity.Property(e => e.Room3ldk)
                .HasDefaultValue(false)
                .HasComment("3LDK")
                .HasColumnName("room_3ldk");
            entity.Property(e => e.Room4dk)
                .HasDefaultValue(false)
                .HasComment("4DK")
                .HasColumnName("room_4dk");
            entity.Property(e => e.Room4k)
                .HasDefaultValue(false)
                .HasComment("4K")
                .HasColumnName("room_4k");
            entity.Property(e => e.Room4ldk)
                .HasDefaultValue(false)
                .HasComment("4LDK")
                .HasColumnName("room_4ldk");
            entity.Property(e => e.Room5k)
                .HasDefaultValue(false)
                .HasComment("5K以上")
                .HasColumnName("room_5k");
            entity.Property(e => e.Roomshare)
                .HasDefaultValue(false)
                .HasComment("ルームシェア可")
                .HasColumnName("roomshare");
            entity.Property(e => e.SecondFloor)
                .HasDefaultValue(false)
                .HasComment("2 階以上")
                .HasColumnName("second_floor");
            entity.Property(e => e.Sekyurithikaisya)
                .HasDefaultValue(false)
                .HasComment("セキュリティ会社加入済")
                .HasColumnName("sekyurithikaisya");
            entity.Property(e => e.Senjoub)
                .HasDefaultValue(false)
                .HasComment("温水洗浄便座")
                .HasColumnName("senjoub");
            entity.Property(e => e.Senmennomi)
                .HasDefaultValue(false)
                .HasComment("洗面所独立")
                .HasColumnName("senmennomi");
            entity.Property(e => e.Shikichityuusya)
                .HasDefaultValue(false)
                .HasComment("敷地内駐車場")
                .HasColumnName("shikichityuusya");
            entity.Property(e => e.Sisukit)
                .HasDefaultValue(false)
                .HasComment("システムキッチン")
                .HasColumnName("sisukit");
            entity.Property(e => e.Situsentaku)
                .HasDefaultValue(false)
                .HasComment("室内洗濯機置場")
                .HasColumnName("situsentaku");
            entity.Property(e => e.Sokujihiki)
                .HasDefaultValue(false)
                .HasComment("即入居可")
                .HasColumnName("sokujihiki");
            entity.Property(e => e.South)
                .HasDefaultValue(false)
                .HasComment("南")
                .HasColumnName("south");
            entity.Property(e => e.Southeast)
                .HasDefaultValue(false)
                .HasComment("南東")
                .HasColumnName("southeast");
            entity.Property(e => e.Southwest)
                .HasDefaultValue(false)
                .HasComment("南西")
                .HasColumnName("southwest");
            entity.Property(e => e.Steel)
                .HasDefaultValue(false)
                .HasComment("鉄骨系")
                .HasColumnName("steel");
            entity.Property(e => e.Syawaaroom)
                .HasDefaultValue(false)
                .HasComment("シャワールーム")
                .HasColumnName("syawaaroom");
            entity.Property(e => e.SyokihiyoCreditCard)
                .HasDefaultValue(false)
                .HasComment("初期費用カード決済可")
                .HasColumnName("syokihiyo_credit_card");
            entity.Property(e => e.Takuhaib)
                .HasDefaultValue(false)
                .HasComment("宅配ボックス")
                .HasColumnName("takuhaib");
            entity.Property(e => e.Tawaman)
                .HasDefaultValue(false)
                .HasComment("タワーマンション")
                .HasColumnName("tawaman");
            entity.Property(e => e.Toho)
                .HasComment("駅徒歩")
                .HasColumnName("toho");
            entity.Property(e => e.Tokuteiyuryou)
                .HasDefaultValue(false)
                .HasComment("特定優良賃貸住宅")
                .HasColumnName("tokuteiyuryou");
            entity.Property(e => e.TopFloor)
                .HasDefaultValue(false)
                .HasComment("最上階")
                .HasColumnName("top_floor");
            entity.Property(e => e.Torankur)
                .HasDefaultValue(false)
                .HasComment("トランクルーム")
                .HasColumnName("torankur");
            entity.Property(e => e.Touyudan)
                .HasDefaultValue(false)
                .HasComment("灯油暖房")
                .HasColumnName("touyudan");
            entity.Property(e => e.Tvdoahon)
                .HasDefaultValue(false)
                .HasComment("TVモニタ付きインタホン")
                .HasColumnName("tvdoahon");
            entity.Property(e => e.Tyuurin)
                .HasDefaultValue(false)
                .HasComment("駐輪場あり")
                .HasColumnName("tyuurin");
            entity.Property(e => e.Tyuusya)
                .HasDefaultValue(false)
                .HasComment("駐車場あり")
                .HasColumnName("tyuusya");
            entity.Property(e => e.Tyuusya2dai)
                .HasDefaultValue(false)
                .HasComment("駐車場2台以上")
                .HasColumnName("tyuusya2dai");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .HasComment("ユーザーID")
                .HasColumnName("user_id");
            entity.Property(e => e.West)
                .HasDefaultValue(false)
                .HasComment("西")
                .HasColumnName("west");
            entity.Property(e => e.WithFloorPlan)
                .HasDefaultValue(false)
                .HasComment("間取り図付き")
                .HasColumnName("with_floor_plan");
            entity.Property(e => e.WithPanorama)
                .HasDefaultValue(false)
                .HasComment("パノラマ付き")
                .HasColumnName("with_panorama");
            entity.Property(e => e.WithPhoto)
                .HasDefaultValue(false)
                .HasComment("写真付き")
                .HasColumnName("with_photo");
            entity.Property(e => e.WithVideo)
                .HasDefaultValue(false)
                .HasComment("物件動画付き")
                .HasColumnName("with_video");
            entity.Property(e => e.Wkurozet)
                .HasDefaultValue(false)
                .HasComment("ウォークインクローゼット")
                .HasColumnName("wkurozet");
            entity.Property(e => e.Wooden)
                .HasDefaultValue(false)
                .HasComment("木造")
                .HasColumnName("wooden");
            entity.Property(e => e.YachinCreditCard)
                .HasDefaultValue(false)
                .HasComment("家賃カード決済可")
                .HasColumnName("yachin_credit_card");
            entity.Property(e => e.Ykansouki)
                .HasDefaultValue(false)
                .HasComment("浴室乾燥機")
                .HasColumnName("ykansouki");
            entity.Property(e => e.Ysyuunou)
                .HasDefaultValue(false)
                .HasComment("床下収納")
                .HasColumnName("ysyuunou");
            entity.Property(e => e.Yujin)
                .HasDefaultValue(false)
                .HasComment("管理人有り")
                .HasColumnName("yujin");
            entity.Property(e => e.Yukadan)
                .HasDefaultValue(false)
                .HasComment("床暖房")
                .HasColumnName("yukadan");
        });

        modelBuilder.Entity<RentalStatistic>(entity =>
        {
            entity.HasKey(e => e.StatisticId).HasName("rental_statistic_pkey");

            entity.ToTable("rental_statistic", tb => tb.HasComment("賃貸物件統計"));

            entity.Property(e => e.StatisticId)
                .HasMaxLength(6)
                .HasComment("統計ID")
                .HasColumnName("statistic_id");
            entity.Property(e => e.PropertyCount)
                .HasComment("物件数")
                .HasColumnName("property_count");
            entity.Property(e => e.UpdateTime)
                .HasComment("更新時間")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_time");
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
            entity.Property(e => e.AddressNumberPart)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("所在地（何番から）")
                .HasColumnName("address_number_part");
            entity.Property(e => e.AddressStreetPart)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("所在地（何丁目まで）")
                .HasColumnName("address_street_part");
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
            entity.Property(e => e.CurrentFloor)
                .HasComment("所在階")
                .HasColumnName("current_floor");
            entity.Property(e => e.ExclusiveArea)
                .HasPrecision(5, 2)
                .HasComment("専有面積")
                .HasColumnName("exclusive_area");
            entity.Property(e => e.ExteriorPhoto)
                .HasMaxLength(255)
                .HasComment("建物外観画像（URL）")
                .HasColumnName("exterior_photo");
            entity.Property(e => e.FloorPlanImage)
                .HasMaxLength(255)
                .HasComment("間取り図面（URL）")
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
            entity.Property(e => e.Recommend)
                .HasDefaultValue(false)
                .HasComment("推薦物件")
                .HasColumnName("recommend");
            entity.Property(e => e.SecurityDeposit)
                .HasPrecision(10, 2)
                .HasComment("敷金")
                .HasColumnName("security_deposit");
            entity.Property(e => e.Station1BusMin)
                .HasComment("駅1までの所要時間（バス）")
                .HasColumnName("station1_bus_min");
            entity.Property(e => e.Station1CarTime)
                .HasComment("駅1までの所要時間（車）")
                .HasColumnName("station1_car_time");
            entity.Property(e => e.Station1Name)
                .HasMaxLength(40)
                .HasComment("駅1の名前")
                .HasColumnName("station1_name");
            entity.Property(e => e.Station1WalkMin)
                .HasComment("駅1までの所要時間（徒歩）")
                .HasColumnName("station1_walk_min");
            entity.Property(e => e.Station2BusMin)
                .HasComment("駅2までの所要時間（バス）")
                .HasColumnName("station2_bus_min");
            entity.Property(e => e.Station2CarTime)
                .HasComment("駅2までの所要時間（車）")
                .HasColumnName("station2_car_time");
            entity.Property(e => e.Station2Name)
                .HasMaxLength(40)
                .HasComment("駅2の名前")
                .HasColumnName("station2_name");
            entity.Property(e => e.Station2WalkMin)
                .HasComment("駅2までの所要時間（徒歩）")
                .HasColumnName("station2_walk_min");
            entity.Property(e => e.Station3BusMin)
                .HasComment("駅3までの所要時間（バス）")
                .HasColumnName("station3_bus_min");
            entity.Property(e => e.Station3CarTime)
                .HasComment("駅3までの所要時間（車）")
                .HasColumnName("station3_car_time");
            entity.Property(e => e.Station3Name)
                .HasMaxLength(40)
                .HasComment("駅3の名前")
                .HasColumnName("station3_name");
            entity.Property(e => e.Station3WalkMin)
                .HasComment("駅3までの所要時間（徒歩）")
                .HasColumnName("station3_walk_min");
            entity.Property(e => e.StructureMaterial)
                .HasMaxLength(32)
                .HasDefaultValueSql("'不明'::character varying")
                .HasComment("構造・材質")
                .HasColumnName("structure_material");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId }).HasName("role_pkey");

            entity.ToTable("role", tb => tb.HasComment("役割"));

            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .HasComment("ユーザーID")
                .HasColumnName("user_id");
            entity.Property(e => e.RoleId)
                .HasMaxLength(20)
                .HasComment("役割ID")
                .HasColumnName("role_id");
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
            entity.Property(e => e.GroupId)
                .IsRequired()
                .HasMaxLength(6)
                .IsFixedLength()
                .HasComment("グループID")
                .HasColumnName("group_id");
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
