using System;
using System.Collections.Generic;

namespace AIRE_DB.Models;

/// <summary>
/// 掲載賃貸物件
/// </summary>
public partial class ValidRental
{
    /// <summary>
    /// 賃貸物件ID
    /// </summary>
    public string RentalId { get; set; }

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
    /// エリアID
    /// </summary>
    public string AreaId { get; set; }

    /// <summary>
    /// 物件タイプ
    /// </summary>
    public string PropertyType { get; set; }

    /// <summary>
    /// 取引態様
    /// </summary>
    public string Toritai { get; set; }

    /// <summary>
    /// 他社付け
    /// </summary>
    public string Tasya { get; set; }

    /// <summary>
    /// 家賃、価格
    /// </summary>
    public decimal Yachin { get; set; }

    /// <summary>
    /// 消費税
    /// </summary>
    public string Syohizei { get; set; }

    /// <summary>
    /// 管理費
    /// </summary>
    public decimal? Kanrihi { get; set; }

    /// <summary>
    /// 所在地（何丁目まで）
    /// </summary>
    public string Chimei { get; set; }

    /// <summary>
    /// 所在地（何番から）
    /// </summary>
    public string Syozai { get; set; }

    /// <summary>
    /// 所在地詳細公開
    /// </summary>
    public string Jusyokoukai { get; set; }

    /// <summary>
    /// 小学校区１
    /// </summary>
    public string Shougakku1 { get; set; }

    /// <summary>
    /// 小学校区２
    /// </summary>
    public string Shougakku2 { get; set; }

    /// <summary>
    /// 中学校区１
    /// </summary>
    public string Chuugakku1 { get; set; }

    /// <summary>
    /// 中学校区２
    /// </summary>
    public string Chuugakku2 { get; set; }

    /// <summary>
    /// 駅数
    /// </summary>
    public string Ekisu { get; set; }

    /// <summary>
    /// 駅1のID
    /// </summary>
    public string Ekiid1 { get; set; }

    /// <summary>
    /// 駅1までの所要時間（バス）
    /// </summary>
    public short? Busac1 { get; set; }

    /// <summary>
    /// 駅1までの所要時間（徒歩）
    /// </summary>
    public short? Toho1 { get; set; }

    /// <summary>
    /// 駅1までの所要時間（車）
    /// </summary>
    public short? Kuruma1 { get; set; }

    /// <summary>
    /// 駅1までのバス停名
    /// </summary>
    public string Bustei1 { get; set; }

    /// <summary>
    /// 駅2のID
    /// </summary>
    public string Ekiid2 { get; set; }

    /// <summary>
    /// 駅2までの所要時間（バス）
    /// </summary>
    public short? Busac2 { get; set; }

    /// <summary>
    /// 駅2までの所要時間（徒歩）
    /// </summary>
    public short? Toho2 { get; set; }

    /// <summary>
    /// 駅2までの所要時間（車）
    /// </summary>
    public short? Kuruma2 { get; set; }

    /// <summary>
    /// 駅2までのバス停名
    /// </summary>
    public string Bustei2 { get; set; }

    /// <summary>
    /// 駅3のID
    /// </summary>
    public string Ekiid3 { get; set; }

    /// <summary>
    /// 駅3までの所要時間（バス）
    /// </summary>
    public short? Busac3 { get; set; }

    /// <summary>
    /// 駅3までの所要時間（徒歩）
    /// </summary>
    public short? Toho3 { get; set; }

    /// <summary>
    /// 駅3までの所要時間（車）
    /// </summary>
    public short? Kuruma3 { get; set; }

    /// <summary>
    /// 駅3までのバス停名
    /// </summary>
    public string Bustei3 { get; set; }

    /// <summary>
    /// 交通情報
    /// </summary>
    public string Kotsu { get; set; }

    /// <summary>
    /// 入居時期
    /// </summary>
    public string Hikiziki { get; set; }

    /// <summary>
    /// 期日指定時（年）
    /// </summary>
    public short? Hiki { get; set; }

    /// <summary>
    /// 期日指定時（月）
    /// </summary>
    public short? Hikitsuki { get; set; }

    /// <summary>
    /// 期日指定時（旬）
    /// </summary>
    public string Hikijun { get; set; }

    /// <summary>
    /// 契約期間（年）
    /// </summary>
    public short Kynen { get; set; }

    /// <summary>
    /// 契約期間（月）
    /// </summary>
    public short Kytsuki { get; set; }

    /// <summary>
    /// 定期借家
    /// </summary>
    public bool Teisyaku { get; set; }

    /// <summary>
    /// 駐車場
    /// </summary>
    public string Tyuzaihi { get; set; }

    /// <summary>
    /// 駐車場（台）
    /// </summary>
    public short? Tyudaisu { get; set; }

    /// <summary>
    /// 駐車場（円/月）
    /// </summary>
    public decimal? Tyunedan { get; set; }

    /// <summary>
    /// 駐車場まで（m）
    /// </summary>
    public int? Tyukinrinmade { get; set; }

    /// <summary>
    /// 現況
    /// </summary>
    public string Genkyou { get; set; }

    /// <summary>
    /// 元付会社TEL
    /// </summary>
    public string Denwaba { get; set; }

    /// <summary>
    /// 元付会社名
    /// </summary>
    public string Kaiinmei { get; set; }

    /// <summary>
    /// 元付担当者
    /// </summary>
    public string Toitan { get; set; }

    /// <summary>
    /// 元付メモ
    /// </summary>
    public string Motomemo { get; set; }

    /// <summary>
    /// 業者向けコメント
    /// </summary>
    public string Gyosyamemo { get; set; }

    /// <summary>
    /// （元付会社の）広告転載
    /// </summary>
    public string Koukoku { get; set; }

    /// <summary>
    /// 名目
    /// </summary>
    public string Kinkum1 { get; set; }

    /// <summary>
    /// 料金
    /// </summary>
    public decimal? Kinkagetu1 { get; set; }

    /// <summary>
    /// 単位
    /// </summary>
    public string Kinku1 { get; set; }

    /// <summary>
    /// 名目
    /// </summary>
    public string Kinkum2 { get; set; }

    /// <summary>
    /// 料金
    /// </summary>
    public decimal? Kinkagetu2 { get; set; }

    /// <summary>
    /// 単位
    /// </summary>
    public string Kinku2 { get; set; }

    /// <summary>
    /// 更新料種類
    /// </summary>
    public string Kousinkbn { get; set; }

    /// <summary>
    /// 更新料
    /// </summary>
    public decimal? Kousinryo { get; set; }

    /// <summary>
    /// 更新料単位
    /// </summary>
    public string Kousinkbm { get; set; }

    /// <summary>
    /// 更新手数料
    /// </summary>
    public decimal? Kousintryo { get; set; }

    /// <summary>
    /// 更新手数料単位
    /// </summary>
    public string Kousintkbn { get; set; }

    /// <summary>
    /// 更新手数料無し
    /// </summary>
    public bool Koutenasi { get; set; }

    /// <summary>
    /// 賃貸保証料必須
    /// </summary>
    public bool Hosyouhissu { get; set; }

    /// <summary>
    /// 賃貸保証料（円）
    /// </summary>
    public decimal? Chintaihosyou { get; set; }

    /// <summary>
    /// 賃貸保証料詳細
    /// </summary>
    public string Chintaihsbikou { get; set; }

    /// <summary>
    /// 火災保険必須
    /// </summary>
    public bool Kasaihissu { get; set; }

    /// <summary>
    /// 火災保険（円）
    /// </summary>
    public decimal? Kasaihoken { get; set; }

    /// <summary>
    /// 火災保険（年）
    /// </summary>
    public short? Kasainen { get; set; }

    /// <summary>
    /// 鍵保管場所
    /// </summary>
    public string Kagi { get; set; }

    /// <summary>
    /// 預託先会社
    /// </summary>
    public string Kagiitaku { get; set; }

    /// <summary>
    /// 鍵備考
    /// </summary>
    public string Kagibikou { get; set; }

    /// <summary>
    /// 金額（仲介手数料）
    /// </summary>
    public decimal Tyuutekin { get; set; }

    /// <summary>
    /// 単位（仲介手数料）
    /// </summary>
    public string Tyutetani { get; set; }

    /// <summary>
    /// 貸主負担比率%（仲介手数料）
    /// </summary>
    public short TyuutehutanKasi { get; set; }

    /// <summary>
    /// 借主負担比率%（仲介手数料）
    /// </summary>
    public short Tyuutehutan { get; set; }

    /// <summary>
    /// 物件種目
    /// </summary>
    public string Bukkmoku { get; set; }

    /// <summary>
    /// 用途地域
    /// </summary>
    public string Youchi { get; set; }

    /// <summary>
    /// 構造・材質
    /// </summary>
    public string Kouzai { get; set; }

    /// <summary>
    /// その他（構造・材質）
    /// </summary>
    public string Kouzaisonota { get; set; }

    /// <summary>
    /// 部屋数（間取り）
    /// </summary>
    public short? Madoheya { get; set; }

    /// <summary>
    /// タイプ（間取り）
    /// </summary>
    public string Madotaipu { get; set; }

    /// <summary>
    /// 詳細1（間取り）
    /// </summary>
    public string Situtaipu1 { get; set; }

    /// <summary>
    /// 畳1（間取り）
    /// </summary>
    public decimal? Situhiro1 { get; set; }

    /// <summary>
    /// 詳細2（間取り）
    /// </summary>
    public string Situtaipu2 { get; set; }

    /// <summary>
    /// 畳2（間取り）
    /// </summary>
    public decimal? Situhiro2 { get; set; }

    /// <summary>
    /// 詳細3（間取り）
    /// </summary>
    public string Situtaipu3 { get; set; }

    /// <summary>
    /// 畳3（間取り）
    /// </summary>
    public decimal? Situhiro3 { get; set; }

    /// <summary>
    /// 詳細4（間取り）
    /// </summary>
    public string Situtaipu4 { get; set; }

    /// <summary>
    /// 畳4（間取り）
    /// </summary>
    public decimal? Situhiro4 { get; set; }

    /// <summary>
    /// 詳細5（間取り）
    /// </summary>
    public string Situtaipu5 { get; set; }

    /// <summary>
    /// 畳5（間取り）
    /// </summary>
    public decimal? Situhiro5 { get; set; }

    /// <summary>
    /// 詳細6（間取り）
    /// </summary>
    public string Situtaipu6 { get; set; }

    /// <summary>
    /// 畳6（間取り）
    /// </summary>
    public decimal? Situhiro6 { get; set; }

    /// <summary>
    /// 詳細7（間取り）
    /// </summary>
    public string Situtaipu7 { get; set; }

    /// <summary>
    /// 畳7（間取り）
    /// </summary>
    public decimal? Situhiro7 { get; set; }

    /// <summary>
    /// 階層（地上）
    /// </summary>
    public short? Chijou { get; set; }

    /// <summary>
    /// 階層（地下）
    /// </summary>
    public short? Chika { get; set; }

    /// <summary>
    /// 所在地下
    /// </summary>
    public bool SyokaiChika { get; set; }

    /// <summary>
    /// 所在階
    /// </summary>
    public short? Syokai { get; set; }

    /// <summary>
    /// 築年月（年）
    /// </summary>
    public short? Chikunen { get; set; }

    /// <summary>
    /// 築年月（月）
    /// </summary>
    public short? Chikutsuki { get; set; }

    /// <summary>
    /// 新築
    /// </summary>
    public bool Sintiku { get; set; }

    /// <summary>
    /// 専有面積
    /// </summary>
    public decimal Tatemen { get; set; }

    /// <summary>
    /// バルコニー（方向）
    /// </summary>
    public string Baruhou { get; set; }

    /// <summary>
    /// バルコニー（面積）
    /// </summary>
    public decimal? Shimen { get; set; }

    /// <summary>
    /// 建物名
    /// </summary>
    public string Manmei { get; set; }

    /// <summary>
    /// 物件名を公開する
    /// </summary>
    public bool Manmeikoukai { get; set; }

    /// <summary>
    /// 部屋番号
    /// </summary>
    public string Roomno { get; set; }

    /// <summary>
    /// 管理（方式）
    /// </summary>
    public string Kanrike { get; set; }

    /// <summary>
    /// 管理（形態）
    /// </summary>
    public string Kanrinin { get; set; }

    /// <summary>
    /// 管理（会社）
    /// </summary>
    public string Kanrikai { get; set; }

    /// <summary>
    /// 棟総戸数
    /// </summary>
    public short? Tousouko { get; set; }

    /// <summary>
    /// 施工会社
    /// </summary>
    public string Sekoukaisya { get; set; }

    /// <summary>
    /// メゾネット階（から）
    /// </summary>
    public short? Mezofrom { get; set; }

    /// <summary>
    /// メゾネット階（まで）
    /// </summary>
    public short? Mezoto { get; set; }

    /// <summary>
    /// リフォーム実施年
    /// </summary>
    public short? ReNen { get; set; }

    /// <summary>
    /// リフォーム実施月
    /// </summary>
    public short? ReTsuki { get; set; }

    /// <summary>
    /// 内装（キッチン）
    /// </summary>
    public bool NaisoReform01 { get; set; }

    /// <summary>
    /// 内装（浴室）
    /// </summary>
    public bool NaisoReform02 { get; set; }

    /// <summary>
    /// 内装（トイレ）
    /// </summary>
    public bool NaisoReform03 { get; set; }

    /// <summary>
    /// 内装（クロス張替）
    /// </summary>
    public bool NaisoReform04 { get; set; }

    /// <summary>
    /// 内装（床）
    /// </summary>
    public bool NaisoReform05 { get; set; }

    /// <summary>
    /// 内装（洗面）
    /// </summary>
    public bool NaisoReform07 { get; set; }

    /// <summary>
    /// 内装（給湯器）
    /// </summary>
    public bool NaisoReform09 { get; set; }

    /// <summary>
    /// 内装（給排水管）
    /// </summary>
    public bool NaisoReform10 { get; set; }

    /// <summary>
    /// 内装（建具）
    /// </summary>
    public bool NaisoReform11 { get; set; }

    /// <summary>
    /// 内装（サッシ）
    /// </summary>
    public bool NaisoReform12 { get; set; }

    /// <summary>
    /// 内装（内装全面）
    /// </summary>
    public bool NaisoReform06 { get; set; }

    /// <summary>
    /// 外装（外装全面）
    /// </summary>
    public bool GaisoReform01 { get; set; }

    /// <summary>
    /// 外装（屋根）
    /// </summary>
    public bool GaisoReform02 { get; set; }

    /// <summary>
    /// 外装（外装その他）
    /// </summary>
    public bool GaisoReform03 { get; set; }

    /// <summary>
    /// リフォーム備考
    /// </summary>
    public string Reformbikou { get; set; }

    /// <summary>
    /// リノベーション済み
    /// </summary>
    public bool Renova { get; set; }

    /// <summary>
    /// 実施年（リノベーション）
    /// </summary>
    public short? RenoNen { get; set; }

    /// <summary>
    /// 実施月（リノベーション）
    /// </summary>
    public short? RenoTsuki { get; set; }

    /// <summary>
    /// 内容（リノベーション）
    /// </summary>
    public string Renovabikou { get; set; }

    /// <summary>
    /// 再エネ（省エネ性能）
    /// </summary>
    public string Saiene { get; set; }

    /// <summary>
    /// エネルギー消費性能
    /// </summary>
    public string Eneseinou { get; set; }

    /// <summary>
    /// 断熱性能
    /// </summary>
    public short? Dannetu { get; set; }

    /// <summary>
    /// 目安光熱費
    /// </summary>
    public decimal? Kounetuhi { get; set; }

    /// <summary>
    /// 水道
    /// </summary>
    public string Jyousui { get; set; }

    /// <summary>
    /// 雑排水
    /// </summary>
    public string Zappaisui { get; set; }

    /// <summary>
    /// ガス
    /// </summary>
    public string Gasu { get; set; }

    /// <summary>
    /// コンロ
    /// </summary>
    public string Gaskonro { get; set; }

    /// <summary>
    /// ＩＨクッキングヒーター
    /// </summary>
    public bool Ih { get; set; }

    /// <summary>
    /// システムキッチン
    /// </summary>
    public bool Sisukit { get; set; }

    /// <summary>
    /// カウンターキッチン
    /// </summary>
    public bool Ckittin { get; set; }

    /// <summary>
    /// オール電化
    /// </summary>
    public bool Denka { get; set; }

    /// <summary>
    /// 食器洗浄機
    /// </summary>
    public bool Syokkiarai { get; set; }

    /// <summary>
    /// 給湯器
    /// </summary>
    public bool Kyuutou { get; set; }

    /// <summary>
    /// ディスポーザー
    /// </summary>
    public bool Dhisupoza { get; set; }

    /// <summary>
    /// 浄水器
    /// </summary>
    public bool Jyousuiki { get; set; }

    /// <summary>
    /// アイランドキッチン
    /// </summary>
    public bool Ikittin { get; set; }

    /// <summary>
    /// 風呂
    /// </summary>
    public string Furo { get; set; }

    /// <summary>
    /// トイレ
    /// </summary>
    public string Toire { get; set; }

    /// <summary>
    /// 下水
    /// </summary>
    public string Gesui { get; set; }

    /// <summary>
    /// 浴室広さ
    /// </summary>
    public string Yokuhiro { get; set; }

    /// <summary>
    /// オートバス
    /// </summary>
    public bool Outobasu { get; set; }

    /// <summary>
    /// バストイレ別
    /// </summary>
    public bool Btbetu { get; set; }

    /// <summary>
    /// ウォッシュレット
    /// </summary>
    public bool Senjoub { get; set; }

    /// <summary>
    /// 暖房便座
    /// </summary>
    public bool Danboubenza { get; set; }

    /// <summary>
    /// 追焚き可
    /// </summary>
    public bool Oidaki { get; set; }

    /// <summary>
    /// シャンプードレッサー
    /// </summary>
    public bool Syanpudore { get; set; }

    /// <summary>
    /// 浴室暖房
    /// </summary>
    public bool Yokushitudan { get; set; }

    /// <summary>
    /// 浴室乾燥機
    /// </summary>
    public bool Ykansouki { get; set; }

    /// <summary>
    /// 洗面化粧台
    /// </summary>
    public bool Sennmenn { get; set; }

    /// <summary>
    /// 洗面所独立
    /// </summary>
    public bool Senmennomi { get; set; }

    /// <summary>
    /// トイレ2ヶ所
    /// </summary>
    public bool Toire2kasyo { get; set; }

    /// <summary>
    /// 浴室に窓
    /// </summary>
    public bool Yokusitumado { get; set; }

    /// <summary>
    /// シャワールーム
    /// </summary>
    public bool Syawaaroom { get; set; }

    /// <summary>
    /// インターネット接続可
    /// </summary>
    public bool Intanet { get; set; }

    /// <summary>
    /// 光ファイバー
    /// </summary>
    public bool Hikarif { get; set; }

    /// <summary>
    /// ＢＳ受信可
    /// </summary>
    public bool Bs { get; set; }

    /// <summary>
    /// ＣＳ受信可
    /// </summary>
    public bool Cs { get; set; }

    /// <summary>
    /// ＣＡＴＶ
    /// </summary>
    public bool Catv { get; set; }

    /// <summary>
    /// インターネット無料
    /// </summary>
    public bool Inetmuryou { get; set; }

    /// <summary>
    /// 全室向き
    /// </summary>
    public string Zensitumuki { get; set; }

    /// <summary>
    /// エアコン
    /// </summary>
    public bool Eakon { get; set; }

    /// <summary>
    /// 台（エアコン）
    /// </summary>
    public short? Eakondaisu { get; set; }

    /// <summary>
    /// 全居室エアコン
    /// </summary>
    public bool AllEakon { get; set; }

    /// <summary>
    /// 灯油暖房
    /// </summary>
    public bool Touyudan { get; set; }

    /// <summary>
    /// ガス暖房
    /// </summary>
    public bool Gasdan { get; set; }

    /// <summary>
    /// ロフト
    /// </summary>
    public bool Rofuto { get; set; }

    /// <summary>
    /// フローリング
    /// </summary>
    public bool Furoringu { get; set; }

    /// <summary>
    /// 全居室フローリング
    /// </summary>
    public bool AllFuroringu { get; set; }

    /// <summary>
    /// 一部フローリング
    /// </summary>
    public bool ItibuFuroringu { get; set; }

    /// <summary>
    /// 床暖房
    /// </summary>
    public bool Yukadan { get; set; }

    /// <summary>
    /// 床下収納
    /// </summary>
    public bool Ysyuunou { get; set; }

    /// <summary>
    /// 収納
    /// </summary>
    public bool Syuunou { get; set; }

    /// <summary>
    /// 室内洗濯機置場
    /// </summary>
    public bool Situsentaku { get; set; }

    /// <summary>
    /// クローゼット
    /// </summary>
    public bool Kurozet { get; set; }

    /// <summary>
    /// ウォークインクローゼット
    /// </summary>
    public bool Wkurozet { get; set; }

    /// <summary>
    /// ベッド
    /// </summary>
    public bool Bed { get; set; }

    /// <summary>
    /// フリーアクセス
    /// </summary>
    public bool Fakusesu { get; set; }

    /// <summary>
    /// シューズボックス
    /// </summary>
    public bool Kutsubako { get; set; }

    /// <summary>
    /// 防音室
    /// </summary>
    public bool Bouon { get; set; }

    /// <summary>
    /// シューズインクローク
    /// </summary>
    public bool ShoesIc { get; set; }

    /// <summary>
    /// 24時間換気
    /// </summary>
    public bool Kanki24h { get; set; }

    /// <summary>
    /// 全居室収納
    /// </summary>
    public bool AllSyuunou { get; set; }

    /// <summary>
    /// 室内物干し
    /// </summary>
    public bool Situmonohosi { get; set; }

    /// <summary>
    /// パントリー
    /// </summary>
    public bool Pantori { get; set; }

    /// <summary>
    /// 屋根裏収納
    /// </summary>
    public bool Yaneurasyuunou { get; set; }

    /// <summary>
    /// リビング階段
    /// </summary>
    public bool Ribingukaidan { get; set; }

    /// <summary>
    /// 吹抜け
    /// </summary>
    public bool Fukinuke { get; set; }

    /// <summary>
    /// 納戸
    /// </summary>
    public bool Nando { get; set; }

    /// <summary>
    /// 全居室６畳以上
    /// </summary>
    public bool All6jou { get; set; }

    /// <summary>
    /// 採光面
    /// </summary>
    public string Saikoumen { get; set; }

    /// <summary>
    /// 全室2面採光
    /// </summary>
    public bool AllSaikoumen2 { get; set; }

    /// <summary>
    /// 複層ガラス
    /// </summary>
    public bool Hukusougarasu { get; set; }

    /// <summary>
    /// 全居室複層ガラス
    /// </summary>
    public bool AllHukusougarasu { get; set; }

    /// <summary>
    /// 人感センサー付照明
    /// </summary>
    public bool Jinkansyoumei { get; set; }

    /// <summary>
    /// 駐輪場
    /// </summary>
    public bool Tyuurin { get; set; }

    /// <summary>
    /// バイク置き場
    /// </summary>
    public bool Baiku { get; set; }

    /// <summary>
    /// エレベーター
    /// </summary>
    public bool Erebeta { get; set; }

    /// <summary>
    /// バリアフリー
    /// </summary>
    public bool Bfree { get; set; }

    /// <summary>
    /// トランクルーム
    /// </summary>
    public bool Torankur { get; set; }

    /// <summary>
    /// 専用庭
    /// </summary>
    public bool Niwa { get; set; }

    /// <summary>
    /// 宅配ボックス
    /// </summary>
    public bool Takuhaib { get; set; }

    /// <summary>
    /// 物置
    /// </summary>
    public bool Monooki { get; set; }

    /// <summary>
    /// 敷地内ゴミ置場
    /// </summary>
    public bool Gomiokiba { get; set; }

    /// <summary>
    /// 駐車場消雪設備
    /// </summary>
    public bool Tyusyousetsu { get; set; }

    /// <summary>
    /// バルコニー
    /// </summary>
    public bool Barukoni { get; set; }

    /// <summary>
    /// ルーフバルコニー
    /// </summary>
    public bool Rbarukoni { get; set; }

    /// <summary>
    /// ベランダ
    /// </summary>
    public bool Beranda { get; set; }

    /// <summary>
    /// テラス
    /// </summary>
    public bool Terasu { get; set; }

    /// <summary>
    /// 電動シャッター
    /// </summary>
    public bool Dendousyatta { get; set; }

    /// <summary>
    /// 日当たり良好
    /// </summary>
    public bool Hiatariryoko { get; set; }

    /// <summary>
    /// 南面バルコニー
    /// </summary>
    public bool Minamibaru { get; set; }

    /// <summary>
    /// 天井高2.5m以上
    /// </summary>
    public bool Tenjou25 { get; set; }

    /// <summary>
    /// 高気密高断熱住宅
    /// </summary>
    public bool Komitukodan { get; set; }

    /// <summary>
    /// 外観タイル張り
    /// </summary>
    public bool Gaikantairu { get; set; }

    /// <summary>
    /// 太陽光発電システム
    /// </summary>
    public bool Taiyouhatuden { get; set; }

    /// <summary>
    /// ワイドバルコニー
    /// </summary>
    public bool Wbarukoni { get; set; }

    /// <summary>
    /// 庭10坪以上
    /// </summary>
    public bool Niwa10tubo { get; set; }

    /// <summary>
    /// ウッドデッキ
    /// </summary>
    public bool Uddodekki { get; set; }

    /// <summary>
    /// 南庭
    /// </summary>
    public bool Minaminiwa { get; set; }

    /// <summary>
    /// 地下室
    /// </summary>
    public bool Chikashitsu { get; set; }

    /// <summary>
    /// ＴＶドアホン
    /// </summary>
    public bool Tvdoahon { get; set; }

    /// <summary>
    /// オートロック
    /// </summary>
    public bool Outorok { get; set; }

    /// <summary>
    /// セキュリティーシステム
    /// </summary>
    public bool Sekyurithi { get; set; }

    /// <summary>
    /// 防犯カメラ
    /// </summary>
    public bool BouhanCamera { get; set; }

    /// <summary>
    /// カードキー
    /// </summary>
    public bool Cardkey { get; set; }

    /// <summary>
    /// 電子キー
    /// </summary>
    public bool Densikey { get; set; }

    /// <summary>
    /// 24時間有人管理
    /// </summary>
    public bool Yujin24h { get; set; }

    /// <summary>
    /// セキュリティ会社加入済
    /// </summary>
    public bool Sekyurithikaisya { get; set; }

    /// <summary>
    /// ペット可
    /// </summary>
    public bool Petka { get; set; }

    /// <summary>
    /// 楽器相談
    /// </summary>
    public bool Gakki { get; set; }

    /// <summary>
    /// ルームシェア可
    /// </summary>
    public bool Roomshare { get; set; }

    /// <summary>
    /// 50歳以上可
    /// </summary>
    public bool Koureisya { get; set; }

    /// <summary>
    /// 子供不可
    /// </summary>
    public bool Kofuka { get; set; }

    /// <summary>
    /// 事務所利用可
    /// </summary>
    public bool Jimusyoriyou { get; set; }

    /// <summary>
    /// 法人限定
    /// </summary>
    public bool Houjin { get; set; }

    /// <summary>
    /// 保証人不要/代行
    /// </summary>
    public bool Hosyounin { get; set; }

    /// <summary>
    /// 女性限定
    /// </summary>
    public bool Jyosei { get; set; }

    /// <summary>
    /// 男性限定
    /// </summary>
    public bool Dansei { get; set; }

    /// <summary>
    /// 入居可能
    /// </summary>
    public string Nyukyoka { get; set; }

    /// <summary>
    /// フリーレント
    /// </summary>
    public string Freerent { get; set; }

    /// <summary>
    /// 初期費用
    /// </summary>
    public string Syokihiyo { get; set; }

    /// <summary>
    /// 建設住宅性能評価付
    /// </summary>
    public string Kseinouhyouka { get; set; }

    /// <summary>
    /// 設計住宅性能評価付
    /// </summary>
    public bool Sseinouhyouka { get; set; }

    /// <summary>
    /// 始発駅
    /// </summary>
    public bool Sihatu { get; set; }

    /// <summary>
    /// 角部屋
    /// </summary>
    public bool Kadobeya { get; set; }

    /// <summary>
    /// 分譲タイプ
    /// </summary>
    public bool Bunjou { get; set; }

    /// <summary>
    /// 二世帯住宅
    /// </summary>
    public bool Nisetai { get; set; }

    /// <summary>
    /// デザイナーズ
    /// </summary>
    public bool Dezaina { get; set; }

    /// <summary>
    /// 家具付き
    /// </summary>
    public bool Kagutsuki { get; set; }

    /// <summary>
    /// 家電付き
    /// </summary>
    public bool Kadentsuki { get; set; }

    /// <summary>
    /// 特定優良賃貸住宅
    /// </summary>
    public bool Tokuteiyuryou { get; set; }

    /// <summary>
    /// メゾネット
    /// </summary>
    public bool Mezonetto { get; set; }

    /// <summary>
    /// LGBTフレンドリー
    /// </summary>
    public bool Lgbt { get; set; }

    /// <summary>
    /// 初期費用クレジット決済可
    /// </summary>
    public bool Crecard1 { get; set; }

    /// <summary>
    /// 賃料クレジット決済可
    /// </summary>
    public bool Crecard2 { get; set; }

    /// <summary>
    /// IT重説対応物件
    /// </summary>
    public bool Itjusetu { get; set; }

    /// <summary>
    /// 仲介手数料無料
    /// </summary>
    public bool Tyutemuryou { get; set; }

    /// <summary>
    /// 仲介手数料半額
    /// </summary>
    public bool Tyutehangaku { get; set; }

    /// <summary>
    /// 高台に立地
    /// </summary>
    public bool Takadai { get; set; }

    /// <summary>
    /// 閑静な住宅街
    /// </summary>
    public bool Kansei { get; set; }

    /// <summary>
    /// 前面棟無
    /// </summary>
    public bool Zenmentounasi { get; set; }

    /// <summary>
    /// 耐震基準適合証明書
    /// </summary>
    public bool Taishinkijun { get; set; }

    /// <summary>
    /// 耐震構造
    /// </summary>
    public bool Taishin { get; set; }

    /// <summary>
    /// 免震構造
    /// </summary>
    public bool Menshin { get; set; }

    /// <summary>
    /// 制震構造
    /// </summary>
    public bool Seishin { get; set; }

    /// <summary>
    /// 24時間ゴミ出し可
    /// </summary>
    public bool Gomika24h { get; set; }

    /// <summary>
    /// カスタマイズ可
    /// </summary>
    public bool Customizeka { get; set; }

    /// <summary>
    /// DIY可
    /// </summary>
    public bool Diyka { get; set; }

    /// <summary>
    /// 土地面積
    /// </summary>
    public decimal? Tochimen { get; set; }

    /// <summary>
    /// 接道１（種類）
    /// </summary>
    public string Setusyu1 { get; set; }

    /// <summary>
    /// 接道１（方向）
    /// </summary>
    public string Setuhou1 { get; set; }

    /// <summary>
    /// 接道１（幅員）
    /// </summary>
    public decimal? Setuhaba1 { get; set; }

    /// <summary>
    /// 接道１（接面）
    /// </summary>
    public decimal? Setusetu1 { get; set; }

    /// <summary>
    /// 最適用途（貸地用）
    /// </summary>
    public string Situzai { get; set; }

    /// <summary>
    /// 平坦地
    /// </summary>
    public bool Heitanchi { get; set; }

    /// <summary>
    /// 整形地
    /// </summary>
    public bool Seikeichi { get; set; }

    /// <summary>
    /// 地目
    /// </summary>
    public string Chimoku { get; set; }

    /// <summary>
    /// 都市計画
    /// </summary>
    public string Tokei { get; set; }

    /// <summary>
    /// 建ペイ率
    /// </summary>
    public short? Kenpei { get; set; }

    /// <summary>
    /// 容積率
    /// </summary>
    public short? Youseki { get; set; }

    /// <summary>
    /// 借地権種類
    /// </summary>
    public string Tokenri { get; set; }

    /// <summary>
    /// 備考
    /// </summary>
    public string Bikou { get; set; }

    /// <summary>
    /// セールスポイント
    /// </summary>
    public string Midasi { get; set; }

    /// <summary>
    /// 動画1の埋込用URL
    /// </summary>
    public string Dougaurl1 { get; set; }

    /// <summary>
    /// 動画1の表示サイズの横
    /// </summary>
    public short? DougaW1 { get; set; }

    /// <summary>
    /// 動画1の表示サイズの縦
    /// </summary>
    public short? DougaY1 { get; set; }

    /// <summary>
    /// 動画2の埋込用URL
    /// </summary>
    public string Dougaurl2 { get; set; }

    /// <summary>
    /// 動画2の表示サイズの横
    /// </summary>
    public short? DougaW2 { get; set; }

    /// <summary>
    /// 動画2の表示サイズの縦
    /// </summary>
    public short? DougaY2 { get; set; }

    /// <summary>
    /// スグ借りバーゲン
    /// </summary>
    public bool Kakutyouk1 { get; set; }

    /// <summary>
    /// ルームズくん
    /// </summary>
    public bool Kakutyouk2 { get; set; }

    /// <summary>
    /// シャレ部屋
    /// </summary>
    public bool Kakutyouk3 { get; set; }

    /// <summary>
    /// おしゃれな物件
    /// </summary>
    public bool Kakutyouk4 { get; set; }

    /// <summary>
    /// ハウスメーカー
    /// </summary>
    public bool Kakutyouk5 { get; set; }

    /// <summary>
    /// 無職可
    /// </summary>
    public bool Kakutyouk6 { get; set; }

    /// <summary>
    /// トリプルゼロ
    /// </summary>
    public bool Kakutyouk7 { get; set; }

    /// <summary>
    /// 保証人無し可
    /// </summary>
    public bool Kakutyouk8 { get; set; }
}
