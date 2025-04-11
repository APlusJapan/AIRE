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

    public virtual DbSet<PropertyDocument> PropertyDocuments { get; set; }

    public virtual DbSet<PropertyFee> PropertyFees { get; set; }

    public virtual DbSet<PropertyImage> PropertyImages { get; set; }

    public virtual DbSet<PropertyPanorama> PropertyPanoramas { get; set; }

    public virtual DbSet<PropertyVideo> PropertyVideos { get; set; }

    public virtual DbSet<RailwayInfo> RailwayInfos { get; set; }

    public virtual DbSet<RentalBrowsingHistory> RentalBrowsingHistories { get; set; }

    public virtual DbSet<RentalSearchHistory> RentalSearchHistories { get; set; }

    public virtual DbSet<RentalStatistic> RentalStatistics { get; set; }

    public virtual DbSet<RentalSummary> RentalSummaries { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<ValidRental> ValidRentals { get; set; }

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
                .HasMaxLength(10)
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

        modelBuilder.Entity<ValidRental>(entity =>
        {
            entity.HasKey(e => e.RentalId).HasName("valid_rental_pkey");

            entity.ToTable("valid_rental", tb => tb.HasComment("掲載賃貸物件"));

            entity.Property(e => e.RentalId)
                .HasMaxLength(40)
                .HasComment("賃貸物件ID")
                .HasColumnName("rental_id");
            entity.Property(e => e.All6jou)
                .HasDefaultValue(false)
                .HasComment("全居室６畳以上")
                .HasColumnName("all_6jou");
            entity.Property(e => e.AllEakon)
                .HasDefaultValue(false)
                .HasComment("全居室エアコン")
                .HasColumnName("all_eakon");
            entity.Property(e => e.AllFuroringu)
                .HasDefaultValue(false)
                .HasComment("全居室フローリング")
                .HasColumnName("all_furoringu");
            entity.Property(e => e.AllHukusougarasu)
                .HasDefaultValue(false)
                .HasComment("全居室複層ガラス")
                .HasColumnName("all_hukusougarasu");
            entity.Property(e => e.AllSaikoumen2)
                .HasDefaultValue(false)
                .HasComment("全室2面採光")
                .HasColumnName("all_saikoumen2");
            entity.Property(e => e.AllSyuunou)
                .HasDefaultValue(false)
                .HasComment("全居室収納")
                .HasColumnName("all_syuunou");
            entity.Property(e => e.AreaId)
                .IsRequired()
                .HasMaxLength(5)
                .IsFixedLength()
                .HasComment("エリアID")
                .HasColumnName("area_id");
            entity.Property(e => e.Baiku)
                .HasDefaultValue(false)
                .HasComment("バイク置き場")
                .HasColumnName("baiku");
            entity.Property(e => e.Baruhou)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("バルコニー（方向）")
                .HasColumnName("baruhou");
            entity.Property(e => e.Barukoni)
                .HasDefaultValue(false)
                .HasComment("バルコニー")
                .HasColumnName("barukoni");
            entity.Property(e => e.Bed)
                .HasDefaultValue(false)
                .HasComment("ベッド")
                .HasColumnName("bed");
            entity.Property(e => e.Beranda)
                .HasDefaultValue(false)
                .HasComment("ベランダ")
                .HasColumnName("beranda");
            entity.Property(e => e.Bfree)
                .HasDefaultValue(false)
                .HasComment("バリアフリー")
                .HasColumnName("bfree");
            entity.Property(e => e.Bikou)
                .HasMaxLength(255)
                .HasComment("備考")
                .HasColumnName("bikou");
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
                .HasComment("ＢＳ受信可")
                .HasColumnName("bs");
            entity.Property(e => e.Btbetu)
                .HasDefaultValue(false)
                .HasComment("バストイレ別")
                .HasColumnName("btbetu");
            entity.Property(e => e.Bukkmoku)
                .HasMaxLength(32)
                .HasComment("物件種目")
                .HasColumnName("bukkmoku");
            entity.Property(e => e.Bunjou)
                .HasDefaultValue(false)
                .HasComment("分譲タイプ")
                .HasColumnName("bunjou");
            entity.Property(e => e.Busac1)
                .HasComment("駅1までの所要時間（バス）")
                .HasColumnName("busac1");
            entity.Property(e => e.Busac2)
                .HasComment("駅2までの所要時間（バス）")
                .HasColumnName("busac2");
            entity.Property(e => e.Busac3)
                .HasComment("駅3までの所要時間（バス）")
                .HasColumnName("busac3");
            entity.Property(e => e.Bustei1)
                .HasMaxLength(20)
                .HasComment("駅1までのバス停名")
                .HasColumnName("bustei1");
            entity.Property(e => e.Bustei2)
                .HasMaxLength(20)
                .HasComment("駅2までのバス停名")
                .HasColumnName("bustei2");
            entity.Property(e => e.Bustei3)
                .HasMaxLength(20)
                .HasComment("駅3までのバス停名")
                .HasColumnName("bustei3");
            entity.Property(e => e.Cardkey)
                .HasDefaultValue(false)
                .HasComment("カードキー")
                .HasColumnName("cardkey");
            entity.Property(e => e.Catv)
                .HasDefaultValue(false)
                .HasComment("ＣＡＴＶ")
                .HasColumnName("catv");
            entity.Property(e => e.Chijou)
                .HasComment("階層（地上）")
                .HasColumnName("chijou");
            entity.Property(e => e.Chika)
                .HasComment("階層（地下）")
                .HasColumnName("chika");
            entity.Property(e => e.Chikashitsu)
                .HasDefaultValue(false)
                .HasComment("地下室")
                .HasColumnName("chikashitsu");
            entity.Property(e => e.Chikunen)
                .HasComment("築年月（年）")
                .HasColumnName("chikunen");
            entity.Property(e => e.Chikutsuki)
                .HasDefaultValue((short)0)
                .HasComment("築年月（月）")
                .HasColumnName("chikutsuki");
            entity.Property(e => e.Chimei)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("所在地（何丁目まで）")
                .HasColumnName("chimei");
            entity.Property(e => e.Chimoku)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("地目")
                .HasColumnName("chimoku");
            entity.Property(e => e.Chintaihosyou)
                .HasPrecision(10, 2)
                .HasComment("賃貸保証料（円）")
                .HasColumnName("chintaihosyou");
            entity.Property(e => e.Chintaihsbikou)
                .HasMaxLength(80)
                .HasComment("賃貸保証料詳細")
                .HasColumnName("chintaihsbikou");
            entity.Property(e => e.Chuugakku1)
                .HasMaxLength(40)
                .HasComment("中学校区１")
                .HasColumnName("chuugakku1");
            entity.Property(e => e.Chuugakku2)
                .HasMaxLength(40)
                .HasComment("中学校区２")
                .HasColumnName("chuugakku2");
            entity.Property(e => e.Ckittin)
                .HasDefaultValue(false)
                .HasComment("カウンターキッチン")
                .HasColumnName("ckittin");
            entity.Property(e => e.CompanyId)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("会社ID")
                .HasColumnName("company_id");
            entity.Property(e => e.Crecard1)
                .HasDefaultValue(false)
                .HasComment("初期費用クレジット決済可")
                .HasColumnName("crecard1");
            entity.Property(e => e.Crecard2)
                .HasDefaultValue(false)
                .HasComment("賃料クレジット決済可")
                .HasColumnName("crecard2");
            entity.Property(e => e.Cs)
                .HasDefaultValue(false)
                .HasComment("ＣＳ受信可")
                .HasColumnName("cs");
            entity.Property(e => e.Customizeka)
                .HasDefaultValue(false)
                .HasComment("カスタマイズ可")
                .HasColumnName("customizeka");
            entity.Property(e => e.Danboubenza)
                .HasDefaultValue(false)
                .HasComment("暖房便座")
                .HasColumnName("danboubenza");
            entity.Property(e => e.Dannetu)
                .HasComment("断熱性能")
                .HasColumnName("dannetu");
            entity.Property(e => e.Dansei)
                .HasDefaultValue(false)
                .HasComment("男性限定")
                .HasColumnName("dansei");
            entity.Property(e => e.Dendousyatta)
                .HasDefaultValue(false)
                .HasComment("電動シャッター")
                .HasColumnName("dendousyatta");
            entity.Property(e => e.Denka)
                .HasDefaultValue(false)
                .HasComment("オール電化")
                .HasColumnName("denka");
            entity.Property(e => e.Densikey)
                .HasDefaultValue(false)
                .HasComment("電子キー")
                .HasColumnName("densikey");
            entity.Property(e => e.Denwaba)
                .HasMaxLength(20)
                .HasComment("元付会社TEL")
                .HasColumnName("denwaba");
            entity.Property(e => e.Dezaina)
                .HasDefaultValue(false)
                .HasComment("デザイナーズ")
                .HasColumnName("dezaina");
            entity.Property(e => e.Dhisupoza)
                .HasDefaultValue(false)
                .HasComment("ディスポーザー")
                .HasColumnName("dhisupoza");
            entity.Property(e => e.Diyka)
                .HasDefaultValue(false)
                .HasComment("DIY可")
                .HasColumnName("diyka");
            entity.Property(e => e.DougaW1)
                .HasComment("動画1の表示サイズの横")
                .HasColumnName("douga_w1");
            entity.Property(e => e.DougaW2)
                .HasComment("動画2の表示サイズの横")
                .HasColumnName("douga_w2");
            entity.Property(e => e.DougaY1)
                .HasComment("動画1の表示サイズの縦")
                .HasColumnName("douga_y1");
            entity.Property(e => e.DougaY2)
                .HasComment("動画2の表示サイズの縦")
                .HasColumnName("douga_y2");
            entity.Property(e => e.Dougaurl1)
                .HasMaxLength(255)
                .HasComment("動画1の埋込用URL")
                .HasColumnName("dougaurl1");
            entity.Property(e => e.Dougaurl2)
                .HasMaxLength(255)
                .HasComment("動画2の埋込用URL")
                .HasColumnName("dougaurl2");
            entity.Property(e => e.Eakon)
                .HasDefaultValue(false)
                .HasComment("エアコン")
                .HasColumnName("eakon");
            entity.Property(e => e.Eakondaisu)
                .HasComment("台（エアコン）")
                .HasColumnName("eakondaisu");
            entity.Property(e => e.Ekiid1)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasComment("駅1のID")
                .HasColumnName("ekiid1");
            entity.Property(e => e.Ekiid2)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasComment("駅2のID")
                .HasColumnName("ekiid2");
            entity.Property(e => e.Ekiid3)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasComment("駅3のID")
                .HasColumnName("ekiid3");
            entity.Property(e => e.Ekisu)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("駅数")
                .HasColumnName("ekisu");
            entity.Property(e => e.Eneseinou)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("エネルギー消費性能")
                .HasColumnName("eneseinou");
            entity.Property(e => e.Erebeta)
                .HasDefaultValue(false)
                .HasComment("エレベーター")
                .HasColumnName("erebeta");
            entity.Property(e => e.Fakusesu)
                .HasDefaultValue(false)
                .HasComment("フリーアクセス")
                .HasColumnName("fakusesu");
            entity.Property(e => e.Freerent)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("フリーレント")
                .HasColumnName("freerent");
            entity.Property(e => e.Fukinuke)
                .HasDefaultValue(false)
                .HasComment("吹抜け")
                .HasColumnName("fukinuke");
            entity.Property(e => e.Furo)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("風呂")
                .HasColumnName("furo");
            entity.Property(e => e.Furoringu)
                .HasDefaultValue(false)
                .HasComment("フローリング")
                .HasColumnName("furoringu");
            entity.Property(e => e.Gaikantairu)
                .HasDefaultValue(false)
                .HasComment("外観タイル張り")
                .HasColumnName("gaikantairu");
            entity.Property(e => e.GaisoReform01)
                .HasDefaultValue(false)
                .HasComment("外装（外装全面）")
                .HasColumnName("gaiso_reform_01");
            entity.Property(e => e.GaisoReform02)
                .HasDefaultValue(false)
                .HasComment("外装（屋根）")
                .HasColumnName("gaiso_reform_02");
            entity.Property(e => e.GaisoReform03)
                .HasDefaultValue(false)
                .HasComment("外装（外装その他）")
                .HasColumnName("gaiso_reform_03");
            entity.Property(e => e.Gakki)
                .HasDefaultValue(false)
                .HasComment("楽器相談")
                .HasColumnName("gakki");
            entity.Property(e => e.Gasdan)
                .HasDefaultValue(false)
                .HasComment("ガス暖房")
                .HasColumnName("gasdan");
            entity.Property(e => e.Gaskonro)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("コンロ")
                .HasColumnName("gaskonro");
            entity.Property(e => e.Gasu)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("ガス")
                .HasColumnName("gasu");
            entity.Property(e => e.Genkyou)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("現況")
                .HasColumnName("genkyou");
            entity.Property(e => e.Gesui)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("下水")
                .HasColumnName("gesui");
            entity.Property(e => e.Gomika24h)
                .HasDefaultValue(false)
                .HasComment("24時間ゴミ出し可")
                .HasColumnName("gomika24h");
            entity.Property(e => e.Gomiokiba)
                .HasDefaultValue(false)
                .HasComment("敷地内ゴミ置場")
                .HasColumnName("gomiokiba");
            entity.Property(e => e.Gporder1)
                .HasMaxLength(255)
                .HasComment("優先画像1")
                .HasColumnName("gporder1");
            entity.Property(e => e.Gporder2)
                .HasMaxLength(255)
                .HasComment("優先画像2")
                .HasColumnName("gporder2");
            entity.Property(e => e.Gporder3)
                .HasMaxLength(255)
                .HasComment("優先画像3")
                .HasColumnName("gporder3");
            entity.Property(e => e.Gyosyamemo)
                .HasMaxLength(255)
                .HasComment("業者向けコメント")
                .HasColumnName("gyosyamemo");
            entity.Property(e => e.Heitanchi)
                .HasDefaultValue(false)
                .HasComment("平坦地")
                .HasColumnName("heitanchi");
            entity.Property(e => e.Hiatariryoko)
                .HasDefaultValue(false)
                .HasComment("日当たり良好")
                .HasColumnName("hiatariryoko");
            entity.Property(e => e.Hikarif)
                .HasDefaultValue(false)
                .HasComment("光ファイバー")
                .HasColumnName("hikarif");
            entity.Property(e => e.Hiki)
                .HasComment("期日指定時（年）")
                .HasColumnName("hiki");
            entity.Property(e => e.Hikijun)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("期日指定時（旬）")
                .HasColumnName("hikijun");
            entity.Property(e => e.Hikitsuki)
                .HasDefaultValue((short)0)
                .HasComment("期日指定時（月）")
                .HasColumnName("hikitsuki");
            entity.Property(e => e.Hikiziki)
                .HasMaxLength(32)
                .HasComment("入居時期")
                .HasColumnName("hikiziki");
            entity.Property(e => e.Hosyouhissu)
                .HasDefaultValue(false)
                .HasComment("賃貸保証料必須")
                .HasColumnName("hosyouhissu");
            entity.Property(e => e.Hosyounin)
                .HasDefaultValue(false)
                .HasComment("保証人不要/代行")
                .HasColumnName("hosyounin");
            entity.Property(e => e.Houjin)
                .HasDefaultValue(false)
                .HasComment("法人限定")
                .HasColumnName("houjin");
            entity.Property(e => e.Hukusougarasu)
                .HasDefaultValue(false)
                .HasComment("複層ガラス")
                .HasColumnName("hukusougarasu");
            entity.Property(e => e.Ih)
                .HasDefaultValue(false)
                .HasComment("ＩＨクッキングヒーター")
                .HasColumnName("ih");
            entity.Property(e => e.Ikittin)
                .HasDefaultValue(false)
                .HasComment("アイランドキッチン")
                .HasColumnName("ikittin");
            entity.Property(e => e.Inetmuryou)
                .HasDefaultValue(false)
                .HasComment("インターネット無料")
                .HasColumnName("inetmuryou");
            entity.Property(e => e.Intanet)
                .HasDefaultValue(false)
                .HasComment("インターネット接続可")
                .HasColumnName("intanet");
            entity.Property(e => e.ItibuFuroringu)
                .HasDefaultValue(false)
                .HasComment("一部フローリング")
                .HasColumnName("itibu_furoringu");
            entity.Property(e => e.Itjusetu)
                .HasDefaultValue(false)
                .HasComment("IT重説対応物件")
                .HasColumnName("itjusetu");
            entity.Property(e => e.Jimusyoriyou)
                .HasDefaultValue(false)
                .HasComment("事務所利用可")
                .HasColumnName("jimusyoriyou");
            entity.Property(e => e.Jinkansyoumei)
                .HasDefaultValue(false)
                .HasComment("人感センサー付照明")
                .HasColumnName("jinkansyoumei");
            entity.Property(e => e.Jusyokoukai)
                .HasMaxLength(32)
                .HasComment("所在地詳細公開")
                .HasColumnName("jusyokoukai");
            entity.Property(e => e.Jyosei)
                .HasDefaultValue(false)
                .HasComment("女性限定")
                .HasColumnName("jyosei");
            entity.Property(e => e.Jyousui)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("水道")
                .HasColumnName("jyousui");
            entity.Property(e => e.Jyousuiki)
                .HasDefaultValue(false)
                .HasComment("浄水器")
                .HasColumnName("jyousuiki");
            entity.Property(e => e.Kadentsuki)
                .HasDefaultValue(false)
                .HasComment("家電付き")
                .HasColumnName("kadentsuki");
            entity.Property(e => e.Kadobeya)
                .HasDefaultValue(false)
                .HasComment("角部屋")
                .HasColumnName("kadobeya");
            entity.Property(e => e.Kagi)
                .HasMaxLength(32)
                .HasComment("鍵保管場所")
                .HasColumnName("kagi");
            entity.Property(e => e.Kagibikou)
                .HasMaxLength(255)
                .HasComment("鍵備考")
                .HasColumnName("kagibikou");
            entity.Property(e => e.Kagiitaku)
                .HasMaxLength(40)
                .HasComment("預託先会社")
                .HasColumnName("kagiitaku");
            entity.Property(e => e.Kagutsuki)
                .HasDefaultValue(false)
                .HasComment("家具付き")
                .HasColumnName("kagutsuki");
            entity.Property(e => e.Kaiinmei)
                .HasMaxLength(40)
                .HasComment("元付会社名")
                .HasColumnName("kaiinmei");
            entity.Property(e => e.Kakutyouk1)
                .HasDefaultValue(false)
                .HasComment("スグ借りバーゲン")
                .HasColumnName("kakutyouk1");
            entity.Property(e => e.Kakutyouk2)
                .HasDefaultValue(false)
                .HasComment("ルームズくん")
                .HasColumnName("kakutyouk2");
            entity.Property(e => e.Kakutyouk3)
                .HasDefaultValue(false)
                .HasComment("シャレ部屋")
                .HasColumnName("kakutyouk3");
            entity.Property(e => e.Kakutyouk4)
                .HasDefaultValue(false)
                .HasComment("おしゃれな物件")
                .HasColumnName("kakutyouk4");
            entity.Property(e => e.Kakutyouk5)
                .HasDefaultValue(false)
                .HasComment("ハウスメーカー")
                .HasColumnName("kakutyouk5");
            entity.Property(e => e.Kakutyouk6)
                .HasDefaultValue(false)
                .HasComment("無職可")
                .HasColumnName("kakutyouk6");
            entity.Property(e => e.Kakutyouk7)
                .HasDefaultValue(false)
                .HasComment("トリプルゼロ")
                .HasColumnName("kakutyouk7");
            entity.Property(e => e.Kakutyouk8)
                .HasDefaultValue(false)
                .HasComment("保証人無し可")
                .HasColumnName("kakutyouk8");
            entity.Property(e => e.Kanki24h)
                .HasDefaultValue(false)
                .HasComment("24時間換気")
                .HasColumnName("kanki24h");
            entity.Property(e => e.Kanrihi)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("0")
                .HasComment("管理費")
                .HasColumnName("kanrihi");
            entity.Property(e => e.Kanrikai)
                .HasMaxLength(40)
                .HasComment("管理（会社）")
                .HasColumnName("kanrikai");
            entity.Property(e => e.Kanrike)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("管理（方式）")
                .HasColumnName("kanrike");
            entity.Property(e => e.Kanrinin)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("管理（形態）")
                .HasColumnName("kanrinin");
            entity.Property(e => e.Kansei)
                .HasDefaultValue(false)
                .HasComment("閑静な住宅街")
                .HasColumnName("kansei");
            entity.Property(e => e.Kasaihissu)
                .HasDefaultValue(false)
                .HasComment("火災保険必須")
                .HasColumnName("kasaihissu");
            entity.Property(e => e.Kasaihoken)
                .HasPrecision(10, 2)
                .HasComment("火災保険（円）")
                .HasColumnName("kasaihoken");
            entity.Property(e => e.Kasainen)
                .HasDefaultValue((short)2)
                .HasComment("火災保険（年）")
                .HasColumnName("kasainen");
            entity.Property(e => e.Kenpei)
                .HasComment("建ペイ率")
                .HasColumnName("kenpei");
            entity.Property(e => e.Kinkagetu1)
                .HasPrecision(10, 2)
                .HasComment("料金")
                .HasColumnName("kinkagetu1");
            entity.Property(e => e.Kinkagetu2)
                .HasPrecision(10, 2)
                .HasComment("料金")
                .HasColumnName("kinkagetu2");
            entity.Property(e => e.Kinku1)
                .HasMaxLength(32)
                .HasComment("単位")
                .HasColumnName("kinku1");
            entity.Property(e => e.Kinku2)
                .HasMaxLength(32)
                .HasComment("単位")
                .HasColumnName("kinku2");
            entity.Property(e => e.Kinkum1)
                .HasMaxLength(32)
                .HasComment("名目")
                .HasColumnName("kinkum1");
            entity.Property(e => e.Kinkum2)
                .HasMaxLength(32)
                .HasComment("名目")
                .HasColumnName("kinkum2");
            entity.Property(e => e.Kofuka)
                .HasDefaultValue(false)
                .HasComment("子供不可")
                .HasColumnName("kofuka");
            entity.Property(e => e.Komitukodan)
                .HasDefaultValue(false)
                .HasComment("高気密高断熱住宅")
                .HasColumnName("komitukodan");
            entity.Property(e => e.Kotsu)
                .HasMaxLength(40)
                .HasComment("交通情報")
                .HasColumnName("kotsu");
            entity.Property(e => e.Koukoku)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("（元付会社の）広告転載")
                .HasColumnName("koukoku");
            entity.Property(e => e.Kounetuhi)
                .HasPrecision(10, 2)
                .HasComment("目安光熱費")
                .HasColumnName("kounetuhi");
            entity.Property(e => e.Koureisya)
                .HasDefaultValue(false)
                .HasComment("50歳以上可")
                .HasColumnName("koureisya");
            entity.Property(e => e.Kousinkbm)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("更新料単位")
                .HasColumnName("kousinkbm");
            entity.Property(e => e.Kousinkbn)
                .HasMaxLength(32)
                .HasComment("更新料種類")
                .HasColumnName("kousinkbn");
            entity.Property(e => e.Kousinryo)
                .HasPrecision(10, 2)
                .HasComment("更新料")
                .HasColumnName("kousinryo");
            entity.Property(e => e.Kousintkbn)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("更新手数料単位")
                .HasColumnName("kousintkbn");
            entity.Property(e => e.Kousintryo)
                .HasPrecision(10, 2)
                .HasComment("更新手数料")
                .HasColumnName("kousintryo");
            entity.Property(e => e.Koutenasi)
                .HasDefaultValue(false)
                .HasComment("更新手数料無し")
                .HasColumnName("koutenasi");
            entity.Property(e => e.Kouzai)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("構造・材質")
                .HasColumnName("kouzai");
            entity.Property(e => e.Kouzaisonota)
                .HasMaxLength(20)
                .HasComment("その他（構造・材質）")
                .HasColumnName("kouzaisonota");
            entity.Property(e => e.Kseinouhyouka)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("建設住宅性能評価付")
                .HasColumnName("kseinouhyouka");
            entity.Property(e => e.Kurozet)
                .HasDefaultValue(false)
                .HasComment("クローゼット")
                .HasColumnName("kurozet");
            entity.Property(e => e.Kuruma1)
                .HasComment("駅1までの所要時間（車）")
                .HasColumnName("kuruma1");
            entity.Property(e => e.Kuruma2)
                .HasComment("駅2までの所要時間（車）")
                .HasColumnName("kuruma2");
            entity.Property(e => e.Kuruma3)
                .HasComment("駅3までの所要時間（車）")
                .HasColumnName("kuruma3");
            entity.Property(e => e.Kutsubako)
                .HasDefaultValue(false)
                .HasComment("シューズボックス")
                .HasColumnName("kutsubako");
            entity.Property(e => e.Kynen)
                .HasDefaultValue((short)2)
                .HasComment("契約期間（年）")
                .HasColumnName("kynen");
            entity.Property(e => e.Kytsuki)
                .HasDefaultValue((short)0)
                .HasComment("契約期間（月）")
                .HasColumnName("kytsuki");
            entity.Property(e => e.Kyuutou)
                .HasDefaultValue(false)
                .HasComment("給湯器")
                .HasColumnName("kyuutou");
            entity.Property(e => e.Lgbt)
                .HasDefaultValue(false)
                .HasComment("LGBTフレンドリー")
                .HasColumnName("lgbt");
            entity.Property(e => e.Madoheya)
                .HasComment("部屋数（間取り）")
                .HasColumnName("madoheya");
            entity.Property(e => e.Madotaipu)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("タイプ（間取り）")
                .HasColumnName("madotaipu");
            entity.Property(e => e.Manmei)
                .HasMaxLength(40)
                .HasComment("建物名")
                .HasColumnName("manmei");
            entity.Property(e => e.Manmeikoukai)
                .HasDefaultValue(false)
                .HasComment("物件名を公開する")
                .HasColumnName("manmeikoukai");
            entity.Property(e => e.Menshin)
                .HasDefaultValue(false)
                .HasComment("免震構造")
                .HasColumnName("menshin");
            entity.Property(e => e.Mezofrom)
                .HasComment("メゾネット階（から）")
                .HasColumnName("mezofrom");
            entity.Property(e => e.Mezonetto)
                .HasDefaultValue(false)
                .HasComment("メゾネット")
                .HasColumnName("mezonetto");
            entity.Property(e => e.Mezoto)
                .HasComment("メゾネット階（まで）")
                .HasColumnName("mezoto");
            entity.Property(e => e.Midasi)
                .HasMaxLength(255)
                .HasComment("セールスポイント")
                .HasColumnName("midasi");
            entity.Property(e => e.Minamibaru)
                .HasDefaultValue(false)
                .HasComment("南面バルコニー")
                .HasColumnName("minamibaru");
            entity.Property(e => e.Minaminiwa)
                .HasDefaultValue(false)
                .HasComment("南庭")
                .HasColumnName("minaminiwa");
            entity.Property(e => e.Monooki)
                .HasDefaultValue(false)
                .HasComment("物置")
                .HasColumnName("monooki");
            entity.Property(e => e.Motomemo)
                .HasMaxLength(255)
                .HasComment("元付メモ")
                .HasColumnName("motomemo");
            entity.Property(e => e.NaisoReform01)
                .HasDefaultValue(false)
                .HasComment("内装（キッチン）")
                .HasColumnName("naiso_reform_01");
            entity.Property(e => e.NaisoReform02)
                .HasDefaultValue(false)
                .HasComment("内装（浴室）")
                .HasColumnName("naiso_reform_02");
            entity.Property(e => e.NaisoReform03)
                .HasDefaultValue(false)
                .HasComment("内装（トイレ）")
                .HasColumnName("naiso_reform_03");
            entity.Property(e => e.NaisoReform04)
                .HasDefaultValue(false)
                .HasComment("内装（クロス張替）")
                .HasColumnName("naiso_reform_04");
            entity.Property(e => e.NaisoReform05)
                .HasDefaultValue(false)
                .HasComment("内装（床）")
                .HasColumnName("naiso_reform_05");
            entity.Property(e => e.NaisoReform06)
                .HasDefaultValue(false)
                .HasComment("内装（内装全面）")
                .HasColumnName("naiso_reform_06");
            entity.Property(e => e.NaisoReform07)
                .HasDefaultValue(false)
                .HasComment("内装（洗面）")
                .HasColumnName("naiso_reform_07");
            entity.Property(e => e.NaisoReform09)
                .HasDefaultValue(false)
                .HasComment("内装（給湯器）")
                .HasColumnName("naiso_reform_09");
            entity.Property(e => e.NaisoReform10)
                .HasDefaultValue(false)
                .HasComment("内装（給排水管）")
                .HasColumnName("naiso_reform_10");
            entity.Property(e => e.NaisoReform11)
                .HasDefaultValue(false)
                .HasComment("内装（建具）")
                .HasColumnName("naiso_reform_11");
            entity.Property(e => e.NaisoReform12)
                .HasDefaultValue(false)
                .HasComment("内装（サッシ）")
                .HasColumnName("naiso_reform_12");
            entity.Property(e => e.Nando)
                .HasDefaultValue(false)
                .HasComment("納戸")
                .HasColumnName("nando");
            entity.Property(e => e.Nisetai)
                .HasDefaultValue(false)
                .HasComment("二世帯住宅")
                .HasColumnName("nisetai");
            entity.Property(e => e.Niwa)
                .HasDefaultValue(false)
                .HasComment("専用庭")
                .HasColumnName("niwa");
            entity.Property(e => e.Niwa10tubo)
                .HasDefaultValue(false)
                .HasComment("庭10坪以上")
                .HasColumnName("niwa10tubo");
            entity.Property(e => e.Nyukyoka)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("入居可能")
                .HasColumnName("nyukyoka");
            entity.Property(e => e.Oidaki)
                .HasDefaultValue(false)
                .HasComment("追焚き可")
                .HasColumnName("oidaki");
            entity.Property(e => e.Outobasu)
                .HasDefaultValue(false)
                .HasComment("オートバス")
                .HasColumnName("outobasu");
            entity.Property(e => e.Outorok)
                .HasDefaultValue(false)
                .HasComment("オートロック")
                .HasColumnName("outorok");
            entity.Property(e => e.Pantori)
                .HasDefaultValue(false)
                .HasComment("パントリー")
                .HasColumnName("pantori");
            entity.Property(e => e.Petka)
                .HasDefaultValue(false)
                .HasComment("ペット可")
                .HasColumnName("petka");
            entity.Property(e => e.PropertyType)
                .IsRequired()
                .HasMaxLength(32)
                .HasDefaultValueSql("1")
                .HasComment("物件タイプ")
                .HasColumnName("property_type");
            entity.Property(e => e.Rbarukoni)
                .HasDefaultValue(false)
                .HasComment("ルーフバルコニー")
                .HasColumnName("rbarukoni");
            entity.Property(e => e.ReNen)
                .HasComment("リフォーム実施年")
                .HasColumnName("re_nen");
            entity.Property(e => e.ReTsuki)
                .HasDefaultValue((short)0)
                .HasComment("リフォーム実施月")
                .HasColumnName("re_tsuki");
            entity.Property(e => e.Reformbikou)
                .HasMaxLength(255)
                .HasComment("リフォーム備考")
                .HasColumnName("reformbikou");
            entity.Property(e => e.RenoNen)
                .HasComment("実施年（リノベーション）")
                .HasColumnName("reno_nen");
            entity.Property(e => e.RenoTsuki)
                .HasDefaultValue((short)0)
                .HasComment("実施月（リノベーション）")
                .HasColumnName("reno_tsuki");
            entity.Property(e => e.Renova)
                .HasDefaultValue(false)
                .HasComment("リノベーション済み")
                .HasColumnName("renova");
            entity.Property(e => e.Renovabikou)
                .HasMaxLength(255)
                .HasComment("内容（リノベーション）")
                .HasColumnName("renovabikou");
            entity.Property(e => e.RentalCommonId)
                .HasMaxLength(40)
                .HasComment("賃貸物件共通ID")
                .HasColumnName("rental_common_id");
            entity.Property(e => e.Ribingukaidan)
                .HasDefaultValue(false)
                .HasComment("リビング階段")
                .HasColumnName("ribingukaidan");
            entity.Property(e => e.Rofuto)
                .HasDefaultValue(false)
                .HasComment("ロフト")
                .HasColumnName("rofuto");
            entity.Property(e => e.Roomno)
                .HasMaxLength(20)
                .HasComment("部屋番号")
                .HasColumnName("roomno");
            entity.Property(e => e.Roomshare)
                .HasDefaultValue(false)
                .HasComment("ルームシェア可")
                .HasColumnName("roomshare");
            entity.Property(e => e.Saiene)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("再エネ（省エネ性能）")
                .HasColumnName("saiene");
            entity.Property(e => e.Saikoumen)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("採光面")
                .HasColumnName("saikoumen");
            entity.Property(e => e.Seikeichi)
                .HasDefaultValue(false)
                .HasComment("整形地")
                .HasColumnName("seikeichi");
            entity.Property(e => e.Seishin)
                .HasDefaultValue(false)
                .HasComment("制震構造")
                .HasColumnName("seishin");
            entity.Property(e => e.Sekoukaisya)
                .HasMaxLength(40)
                .HasComment("施工会社")
                .HasColumnName("sekoukaisya");
            entity.Property(e => e.Sekyurithi)
                .HasDefaultValue(false)
                .HasComment("セキュリティーシステム")
                .HasColumnName("sekyurithi");
            entity.Property(e => e.Sekyurithikaisya)
                .HasDefaultValue(false)
                .HasComment("セキュリティ会社加入済")
                .HasColumnName("sekyurithikaisya");
            entity.Property(e => e.Senjoub)
                .HasDefaultValue(false)
                .HasComment("ウォッシュレット")
                .HasColumnName("senjoub");
            entity.Property(e => e.Senmennomi)
                .HasDefaultValue(false)
                .HasComment("洗面所独立")
                .HasColumnName("senmennomi");
            entity.Property(e => e.Sennmenn)
                .HasDefaultValue(false)
                .HasComment("洗面化粧台")
                .HasColumnName("sennmenn");
            entity.Property(e => e.Setuhaba1)
                .HasPrecision(5, 2)
                .HasComment("接道１（幅員）")
                .HasColumnName("setuhaba1");
            entity.Property(e => e.Setuhou1)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("接道１（方向）")
                .HasColumnName("setuhou1");
            entity.Property(e => e.Setusetu1)
                .HasPrecision(5, 2)
                .HasComment("接道１（接面）")
                .HasColumnName("setusetu1");
            entity.Property(e => e.Setusyu1)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("接道１（種類）")
                .HasColumnName("setusyu1");
            entity.Property(e => e.Shimen)
                .HasPrecision(5, 2)
                .HasComment("バルコニー（面積）")
                .HasColumnName("shimen");
            entity.Property(e => e.ShoesIc)
                .HasDefaultValue(false)
                .HasComment("シューズインクローク")
                .HasColumnName("shoes_ic");
            entity.Property(e => e.Shougakku1)
                .HasMaxLength(40)
                .HasComment("小学校区１")
                .HasColumnName("shougakku1");
            entity.Property(e => e.Shougakku2)
                .HasMaxLength(40)
                .HasComment("小学校区２")
                .HasColumnName("shougakku2");
            entity.Property(e => e.Sihatu)
                .HasDefaultValue(false)
                .HasComment("始発駅")
                .HasColumnName("sihatu");
            entity.Property(e => e.Sintiku)
                .HasDefaultValue(false)
                .HasComment("新築")
                .HasColumnName("sintiku");
            entity.Property(e => e.Sisukit)
                .HasDefaultValue(false)
                .HasComment("システムキッチン")
                .HasColumnName("sisukit");
            entity.Property(e => e.Situhiro1)
                .HasPrecision(5, 2)
                .HasComment("畳1（間取り）")
                .HasColumnName("situhiro1");
            entity.Property(e => e.Situhiro2)
                .HasPrecision(5, 2)
                .HasComment("畳2（間取り）")
                .HasColumnName("situhiro2");
            entity.Property(e => e.Situhiro3)
                .HasPrecision(5, 2)
                .HasComment("畳3（間取り）")
                .HasColumnName("situhiro3");
            entity.Property(e => e.Situhiro4)
                .HasPrecision(5, 2)
                .HasComment("畳4（間取り）")
                .HasColumnName("situhiro4");
            entity.Property(e => e.Situhiro5)
                .HasPrecision(5, 2)
                .HasComment("畳5（間取り）")
                .HasColumnName("situhiro5");
            entity.Property(e => e.Situhiro6)
                .HasPrecision(5, 2)
                .HasComment("畳6（間取り）")
                .HasColumnName("situhiro6");
            entity.Property(e => e.Situhiro7)
                .HasPrecision(5, 2)
                .HasComment("畳7（間取り）")
                .HasColumnName("situhiro7");
            entity.Property(e => e.Situmonohosi)
                .HasDefaultValue(false)
                .HasComment("室内物干し")
                .HasColumnName("situmonohosi");
            entity.Property(e => e.Situsentaku)
                .HasDefaultValue(false)
                .HasComment("室内洗濯機置場")
                .HasColumnName("situsentaku");
            entity.Property(e => e.Situtaipu1)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("詳細1（間取り）")
                .HasColumnName("situtaipu1");
            entity.Property(e => e.Situtaipu2)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("詳細2（間取り）")
                .HasColumnName("situtaipu2");
            entity.Property(e => e.Situtaipu3)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("詳細3（間取り）")
                .HasColumnName("situtaipu3");
            entity.Property(e => e.Situtaipu4)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("詳細4（間取り）")
                .HasColumnName("situtaipu4");
            entity.Property(e => e.Situtaipu5)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("詳細5（間取り）")
                .HasColumnName("situtaipu5");
            entity.Property(e => e.Situtaipu6)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("詳細6（間取り）")
                .HasColumnName("situtaipu6");
            entity.Property(e => e.Situtaipu7)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("詳細7（間取り）")
                .HasColumnName("situtaipu7");
            entity.Property(e => e.Situzai)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("最適用途（貸地用）")
                .HasColumnName("situzai");
            entity.Property(e => e.Sseinouhyouka)
                .HasDefaultValue(false)
                .HasComment("設計住宅性能評価付")
                .HasColumnName("sseinouhyouka");
            entity.Property(e => e.StaffId)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("担当社員ID")
                .HasColumnName("staff_id");
            entity.Property(e => e.Syanpudore)
                .HasDefaultValue(false)
                .HasComment("シャンプードレッサー")
                .HasColumnName("syanpudore");
            entity.Property(e => e.Syawaaroom)
                .HasDefaultValue(false)
                .HasComment("シャワールーム")
                .HasColumnName("syawaaroom");
            entity.Property(e => e.Syohizei)
                .IsRequired()
                .HasMaxLength(32)
                .HasComment("消費税")
                .HasColumnName("syohizei");
            entity.Property(e => e.Syokai)
                .HasComment("所在階")
                .HasColumnName("syokai");
            entity.Property(e => e.SyokaiChika)
                .HasDefaultValue(false)
                .HasComment("所在地下")
                .HasColumnName("syokai_chika");
            entity.Property(e => e.Syokihiyo)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("初期費用")
                .HasColumnName("syokihiyo");
            entity.Property(e => e.Syokkiarai)
                .HasDefaultValue(false)
                .HasComment("食器洗浄機")
                .HasColumnName("syokkiarai");
            entity.Property(e => e.Syozai)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("所在地（何番から）")
                .HasColumnName("syozai");
            entity.Property(e => e.Syuunou)
                .HasDefaultValue(false)
                .HasComment("収納")
                .HasColumnName("syuunou");
            entity.Property(e => e.Taishin)
                .HasDefaultValue(false)
                .HasComment("耐震構造")
                .HasColumnName("taishin");
            entity.Property(e => e.Taishinkijun)
                .HasDefaultValue(false)
                .HasComment("耐震基準適合証明書")
                .HasColumnName("taishinkijun");
            entity.Property(e => e.Taiyouhatuden)
                .HasDefaultValue(false)
                .HasComment("太陽光発電システム")
                .HasColumnName("taiyouhatuden");
            entity.Property(e => e.Takadai)
                .HasDefaultValue(false)
                .HasComment("高台に立地")
                .HasColumnName("takadai");
            entity.Property(e => e.Takuhaib)
                .HasDefaultValue(false)
                .HasComment("宅配ボックス")
                .HasColumnName("takuhaib");
            entity.Property(e => e.Tasya)
                .HasMaxLength(32)
                .HasComment("他社付け")
                .HasColumnName("tasya");
            entity.Property(e => e.Tatemen)
                .HasPrecision(5, 2)
                .HasComment("専有面積")
                .HasColumnName("tatemen");
            entity.Property(e => e.Teisyaku)
                .HasDefaultValue(false)
                .HasComment("定期借家")
                .HasColumnName("teisyaku");
            entity.Property(e => e.Tenjou25)
                .HasDefaultValue(false)
                .HasComment("天井高2.5m以上")
                .HasColumnName("tenjou25");
            entity.Property(e => e.Terasu)
                .HasDefaultValue(false)
                .HasComment("テラス")
                .HasColumnName("terasu");
            entity.Property(e => e.Tochimen)
                .HasPrecision(10, 2)
                .HasComment("土地面積")
                .HasColumnName("tochimen");
            entity.Property(e => e.Toho1)
                .HasComment("駅1までの所要時間（徒歩）")
                .HasColumnName("toho1");
            entity.Property(e => e.Toho2)
                .HasComment("駅2までの所要時間（徒歩）")
                .HasColumnName("toho2");
            entity.Property(e => e.Toho3)
                .HasComment("駅3までの所要時間（徒歩）")
                .HasColumnName("toho3");
            entity.Property(e => e.Toire)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("トイレ")
                .HasColumnName("toire");
            entity.Property(e => e.Toire2kasyo)
                .HasDefaultValue(false)
                .HasComment("トイレ2ヶ所")
                .HasColumnName("toire2kasyo");
            entity.Property(e => e.Toitan)
                .HasMaxLength(20)
                .HasComment("元付担当者")
                .HasColumnName("toitan");
            entity.Property(e => e.Tokei)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("都市計画")
                .HasColumnName("tokei");
            entity.Property(e => e.Tokenri)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("借地権種類")
                .HasColumnName("tokenri");
            entity.Property(e => e.Tokuteiyuryou)
                .HasDefaultValue(false)
                .HasComment("特定優良賃貸住宅")
                .HasColumnName("tokuteiyuryou");
            entity.Property(e => e.Torankur)
                .HasDefaultValue(false)
                .HasComment("トランクルーム")
                .HasColumnName("torankur");
            entity.Property(e => e.Toritai)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("取引態様")
                .HasColumnName("toritai");
            entity.Property(e => e.Tousouko)
                .HasComment("棟総戸数")
                .HasColumnName("tousouko");
            entity.Property(e => e.Touyudan)
                .HasDefaultValue(false)
                .HasComment("灯油暖房")
                .HasColumnName("touyudan");
            entity.Property(e => e.Tvdoahon)
                .HasDefaultValue(false)
                .HasComment("ＴＶドアホン")
                .HasColumnName("tvdoahon");
            entity.Property(e => e.Tyudaisu)
                .HasComment("駐車場（台）")
                .HasColumnName("tyudaisu");
            entity.Property(e => e.Tyukinrinmade)
                .HasComment("駐車場まで（m）")
                .HasColumnName("tyukinrinmade");
            entity.Property(e => e.Tyunedan)
                .HasPrecision(10, 2)
                .HasComment("駐車場（円/月）")
                .HasColumnName("tyunedan");
            entity.Property(e => e.Tyusyousetsu)
                .HasDefaultValue(false)
                .HasComment("駐車場消雪設備")
                .HasColumnName("tyusyousetsu");
            entity.Property(e => e.Tyutehangaku)
                .HasDefaultValue(false)
                .HasComment("仲介手数料半額")
                .HasColumnName("tyutehangaku");
            entity.Property(e => e.Tyutemuryou)
                .HasDefaultValue(false)
                .HasComment("仲介手数料無料")
                .HasColumnName("tyutemuryou");
            entity.Property(e => e.Tyutetani)
                .IsRequired()
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("単位（仲介手数料）")
                .HasColumnName("tyutetani");
            entity.Property(e => e.Tyuurin)
                .HasDefaultValue(false)
                .HasComment("駐輪場")
                .HasColumnName("tyuurin");
            entity.Property(e => e.Tyuutehutan)
                .HasDefaultValue((short)2)
                .HasComment("借主負担比率%（仲介手数料）")
                .HasColumnName("tyuutehutan");
            entity.Property(e => e.TyuutehutanKasi)
                .HasDefaultValue((short)2)
                .HasComment("貸主負担比率%（仲介手数料）")
                .HasColumnName("tyuutehutan_kasi");
            entity.Property(e => e.Tyuutekin)
                .HasPrecision(10, 2)
                .HasComment("金額（仲介手数料）")
                .HasColumnName("tyuutekin");
            entity.Property(e => e.Tyuzaihi)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("駐車場")
                .HasColumnName("tyuzaihi");
            entity.Property(e => e.Uddodekki)
                .HasDefaultValue(false)
                .HasComment("ウッドデッキ")
                .HasColumnName("uddodekki");
            entity.Property(e => e.Wbarukoni)
                .HasDefaultValue(false)
                .HasComment("ワイドバルコニー")
                .HasColumnName("wbarukoni");
            entity.Property(e => e.Wkurozet)
                .HasDefaultValue(false)
                .HasComment("ウォークインクローゼット")
                .HasColumnName("wkurozet");
            entity.Property(e => e.Yachin)
                .HasPrecision(15, 2)
                .HasComment("家賃、価格")
                .HasColumnName("yachin");
            entity.Property(e => e.Yaneurasyuunou)
                .HasDefaultValue(false)
                .HasComment("屋根裏収納")
                .HasColumnName("yaneurasyuunou");
            entity.Property(e => e.Ykansouki)
                .HasDefaultValue(false)
                .HasComment("浴室乾燥機")
                .HasColumnName("ykansouki");
            entity.Property(e => e.Yokuhiro)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("浴室広さ")
                .HasColumnName("yokuhiro");
            entity.Property(e => e.Yokushitudan)
                .HasDefaultValue(false)
                .HasComment("浴室暖房")
                .HasColumnName("yokushitudan");
            entity.Property(e => e.Yokusitumado)
                .HasDefaultValue(false)
                .HasComment("浴室に窓")
                .HasColumnName("yokusitumado");
            entity.Property(e => e.Youchi)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("用途地域")
                .HasColumnName("youchi");
            entity.Property(e => e.Youseki)
                .HasComment("容積率")
                .HasColumnName("youseki");
            entity.Property(e => e.Ysyuunou)
                .HasDefaultValue(false)
                .HasComment("床下収納")
                .HasColumnName("ysyuunou");
            entity.Property(e => e.Yujin24h)
                .HasDefaultValue(false)
                .HasComment("24時間有人管理")
                .HasColumnName("yujin24h");
            entity.Property(e => e.Yukadan)
                .HasDefaultValue(false)
                .HasComment("床暖房")
                .HasColumnName("yukadan");
            entity.Property(e => e.Zappaisui)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("雑排水")
                .HasColumnName("zappaisui");
            entity.Property(e => e.Zenmentounasi)
                .HasDefaultValue(false)
                .HasComment("前面棟無")
                .HasColumnName("zenmentounasi");
            entity.Property(e => e.Zensitumuki)
                .HasMaxLength(32)
                .HasDefaultValueSql("false")
                .HasComment("全室向き")
                .HasColumnName("zensitumuki");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
