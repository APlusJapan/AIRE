using System;
using System.Collections.Generic;

namespace AIRE_DB.Models;

/// <summary>
/// 賃貸物件検索履歴
/// </summary>
public partial class RentalSearchHistory
{
    /// <summary>
    /// デバイス一意ID
    /// </summary>
    public string DeviceUniqueId { get; set; }

    /// <summary>
    /// 操作時間
    /// </summary>
    public DateTime OperationTime { get; set; }

    /// <summary>
    /// ユーザーID
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// 論理削除
    /// </summary>
    public bool LogicalDelete { get; set; }

    /// <summary>
    /// お気に入り
    /// </summary>
    public bool Favorite { get; set; }

    /// <summary>
    /// 賃料下限
    /// </summary>
    public int? MinYachin { get; set; }

    /// <summary>
    /// 賃料上限
    /// </summary>
    public int? MaxYachin { get; set; }

    /// <summary>
    /// 管理費・共益費込み
    /// </summary>
    public bool IncludeKanrihi { get; set; }

    /// <summary>
    /// 駐車場代込み
    /// </summary>
    public bool IncludeTyunedan { get; set; }

    /// <summary>
    /// 礼金なし
    /// </summary>
    public bool NoReikin { get; set; }

    /// <summary>
    /// 敷金・保証金なし
    /// </summary>
    public bool NoShikikin { get; set; }

    /// <summary>
    /// 初期費用カード決済可
    /// </summary>
    public bool SyokihiyoCreditCard { get; set; }

    /// <summary>
    /// 家賃カード決済可
    /// </summary>
    public bool YachinCreditCard { get; set; }

    /// <summary>
    /// フリーレント
    /// </summary>
    public bool Freerent { get; set; }

    /// <summary>
    /// 特定優良賃貸住宅
    /// </summary>
    public bool Tokuteiyuryou { get; set; }

    /// <summary>
    /// ワンルーム
    /// </summary>
    public bool Oneroom { get; set; }

    /// <summary>
    /// 1K
    /// </summary>
    public bool Room1k { get; set; }

    /// <summary>
    /// 1DK
    /// </summary>
    public bool Room1dk { get; set; }

    /// <summary>
    /// 1LDK
    /// </summary>
    public bool Room1ldk { get; set; }

    /// <summary>
    /// 2K
    /// </summary>
    public bool Room2k { get; set; }

    /// <summary>
    /// 2DK
    /// </summary>
    public bool Room2dk { get; set; }

    /// <summary>
    /// 2LDK
    /// </summary>
    public bool Room2ldk { get; set; }

    /// <summary>
    /// 3K
    /// </summary>
    public bool Room3k { get; set; }

    /// <summary>
    /// 3DK
    /// </summary>
    public bool Room3dk { get; set; }

    /// <summary>
    /// 3LDK
    /// </summary>
    public bool Room3ldk { get; set; }

    /// <summary>
    /// 4K
    /// </summary>
    public bool Room4k { get; set; }

    /// <summary>
    /// 4DK
    /// </summary>
    public bool Room4dk { get; set; }

    /// <summary>
    /// 4LDK
    /// </summary>
    public bool Room4ldk { get; set; }

    /// <summary>
    /// 5K以上
    /// </summary>
    public bool Room5k { get; set; }

    /// <summary>
    /// マンション
    /// </summary>
    public bool Mansion { get; set; }

    /// <summary>
    /// アパート
    /// </summary>
    public bool Apartment { get; set; }

    /// <summary>
    /// 一戸建て・その他
    /// </summary>
    public bool DetachedHouse { get; set; }

    /// <summary>
    /// 鉄筋系
    /// </summary>
    public bool Rebar { get; set; }

    /// <summary>
    /// 鉄骨系
    /// </summary>
    public bool Steel { get; set; }

    /// <summary>
    /// 木造
    /// </summary>
    public bool Wooden { get; set; }

    /// <summary>
    /// ブロック・その他
    /// </summary>
    public bool Block { get; set; }

    /// <summary>
    /// 駅徒歩
    /// </summary>
    public short? Toho { get; set; }

    /// <summary>
    /// 面積下限
    /// </summary>
    public short? MinMen { get; set; }

    /// <summary>
    /// 面積上限
    /// </summary>
    public short? MaxMen { get; set; }

    /// <summary>
    /// 築後年数
    /// </summary>
    public short? Chikunensu { get; set; }

    /// <summary>
    /// 北
    /// </summary>
    public bool North { get; set; }

    /// <summary>
    /// 北東
    /// </summary>
    public bool Northeast { get; set; }

    /// <summary>
    /// 東
    /// </summary>
    public bool East { get; set; }

    /// <summary>
    /// 南東
    /// </summary>
    public bool Southeast { get; set; }

    /// <summary>
    /// 南
    /// </summary>
    public bool South { get; set; }

    /// <summary>
    /// 南西
    /// </summary>
    public bool Southwest { get; set; }

    /// <summary>
    /// 西
    /// </summary>
    public bool West { get; set; }

    /// <summary>
    /// 北西
    /// </summary>
    public bool Northwest { get; set; }

    /// <summary>
    /// 本日の新着物件
    /// </summary>
    public bool NewToday { get; set; }

    /// <summary>
    /// 新着（2～7日前）
    /// </summary>
    public bool NewLastWeek { get; set; }

    /// <summary>
    /// 物件動画付き
    /// </summary>
    public bool WithVideo { get; set; }

    /// <summary>
    /// パノラマ付き
    /// </summary>
    public bool WithPanorama { get; set; }

    /// <summary>
    /// 間取り図付き
    /// </summary>
    public bool WithFloorPlan { get; set; }

    /// <summary>
    /// 写真付き
    /// </summary>
    public bool WithPhoto { get; set; }

    /// <summary>
    /// 1 階の物件
    /// </summary>
    public bool FirstFloor { get; set; }

    /// <summary>
    /// 2 階以上
    /// </summary>
    public bool SecondFloor { get; set; }

    /// <summary>
    /// 最上階
    /// </summary>
    public bool TopFloor { get; set; }

    /// <summary>
    /// 角部屋
    /// </summary>
    public bool Kadobeya { get; set; }

    /// <summary>
    /// 南向き
    /// </summary>
    public bool Minamimuki { get; set; }

    /// <summary>
    /// ガスコンロ対応
    /// </summary>
    public bool HasGaskonro { get; set; }

    /// <summary>
    /// IHコンロ
    /// </summary>
    public bool Ih { get; set; }

    /// <summary>
    /// コンロ2口以上
    /// </summary>
    public bool Has2Gaskonro { get; set; }

    /// <summary>
    /// オール電化
    /// </summary>
    public bool Denka { get; set; }

    /// <summary>
    /// システムキッチン
    /// </summary>
    public bool Sisukit { get; set; }

    /// <summary>
    /// カウンターキッチン
    /// </summary>
    public bool Ckittin { get; set; }

    /// <summary>
    /// バス・トイレ別
    /// </summary>
    public bool Btbetu { get; set; }

    /// <summary>
    /// 温水洗浄便座
    /// </summary>
    public bool Senjoub { get; set; }

    /// <summary>
    /// 浴室乾燥機
    /// </summary>
    public bool Ykansouki { get; set; }

    /// <summary>
    /// 追い焚き風呂
    /// </summary>
    public bool Oidaki { get; set; }

    /// <summary>
    /// シャワールーム
    /// </summary>
    public bool Syawaaroom { get; set; }

    /// <summary>
    /// インターネット接続可
    /// </summary>
    public bool Intanet { get; set; }

    /// <summary>
    /// BSアンテナ
    /// </summary>
    public bool Bs { get; set; }

    /// <summary>
    /// CSアンテナ
    /// </summary>
    public bool Cs { get; set; }

    /// <summary>
    /// ケーブルテレビ
    /// </summary>
    public bool Catv { get; set; }

    /// <summary>
    /// インターネット無料
    /// </summary>
    public bool Inetmuryou { get; set; }

    /// <summary>
    /// 室内洗濯機置場
    /// </summary>
    public bool Situsentaku { get; set; }

    /// <summary>
    /// 洗面所独立
    /// </summary>
    public bool Senmennomi { get; set; }

    /// <summary>
    /// フローリング
    /// </summary>
    public bool Furoringu { get; set; }

    /// <summary>
    /// メゾネット
    /// </summary>
    public bool Mezonetto { get; set; }

    /// <summary>
    /// ロフト
    /// </summary>
    public bool Rofuto { get; set; }

    /// <summary>
    /// 防音室
    /// </summary>
    public bool Bouon { get; set; }

    /// <summary>
    /// 地下室
    /// </summary>
    public bool Chikashitsu { get; set; }

    /// <summary>
    /// 家具付
    /// </summary>
    public bool Kagutsuki { get; set; }

    /// <summary>
    /// 家電付
    /// </summary>
    public bool Kadentsuki { get; set; }

    /// <summary>
    /// エアコン付き
    /// </summary>
    public bool Eakon { get; set; }

    /// <summary>
    /// 床暖房
    /// </summary>
    public bool Yukadan { get; set; }

    /// <summary>
    /// 灯油暖房
    /// </summary>
    public bool Touyudan { get; set; }

    /// <summary>
    /// ガス暖房
    /// </summary>
    public bool Gasdan { get; set; }

    /// <summary>
    /// 床下収納
    /// </summary>
    public bool Ysyuunou { get; set; }

    /// <summary>
    /// シューズボックス
    /// </summary>
    public bool Kutsubako { get; set; }

    /// <summary>
    /// トランクルーム
    /// </summary>
    public bool Torankur { get; set; }

    /// <summary>
    /// ウォークインクローゼット
    /// </summary>
    public bool Wkurozet { get; set; }

    /// <summary>
    /// オートロック
    /// </summary>
    public bool Outorok { get; set; }

    /// <summary>
    /// 管理人有り
    /// </summary>
    public bool Yujin { get; set; }

    /// <summary>
    /// TVモニタ付きインタホン
    /// </summary>
    public bool Tvdoahon { get; set; }

    /// <summary>
    /// 防犯カメラ
    /// </summary>
    public bool BouhanCamera { get; set; }

    /// <summary>
    /// セキュリティ会社加入済
    /// </summary>
    public bool Sekyurithikaisya { get; set; }

    /// <summary>
    /// 駐車場あり
    /// </summary>
    public bool Tyuusya { get; set; }

    /// <summary>
    /// 駐車場2台以上
    /// </summary>
    public bool Tyuusya2dai { get; set; }

    /// <summary>
    /// 敷地内駐車場
    /// </summary>
    public bool Shikichityuusya { get; set; }

    /// <summary>
    /// 駐輪場あり
    /// </summary>
    public bool Tyuurin { get; set; }

    /// <summary>
    /// バイク置場あり
    /// </summary>
    public bool Baiku { get; set; }

    /// <summary>
    /// エレベーター
    /// </summary>
    public bool Erebeta { get; set; }

    /// <summary>
    /// 宅配ボックス
    /// </summary>
    public bool Takuhaib { get; set; }

    /// <summary>
    /// 敷地内ゴミ置場
    /// </summary>
    public bool Gomiokiba { get; set; }

    /// <summary>
    /// バルコニー付
    /// </summary>
    public bool Barukoni { get; set; }

    /// <summary>
    /// ルーフバルコニー付
    /// </summary>
    public bool Rbarukoni { get; set; }

    /// <summary>
    /// 専用庭
    /// </summary>
    public bool Niwa { get; set; }

    /// <summary>
    /// 都市ガス
    /// </summary>
    public bool CityGas { get; set; }

    /// <summary>
    /// プロパンガス
    /// </summary>
    public bool LpGas { get; set; }

    /// <summary>
    /// バリアフリー
    /// </summary>
    public bool Bfree { get; set; }

    /// <summary>
    /// デザイナーズ物件
    /// </summary>
    public bool Dezaina { get; set; }

    /// <summary>
    /// IT重説 対応物件
    /// </summary>
    public bool Itjusetu { get; set; }

    /// <summary>
    /// 分譲賃貸
    /// </summary>
    public bool Bunjou { get; set; }

    /// <summary>
    /// 保証人不要
    /// </summary>
    public bool Hosyounin { get; set; }

    /// <summary>
    /// タワーマンション
    /// </summary>
    public bool Tawaman { get; set; }

    /// <summary>
    /// リフォーム済み
    /// </summary>
    public bool Reform { get; set; }

    /// <summary>
    /// リノベーション物件
    /// </summary>
    public bool Renova { get; set; }

    /// <summary>
    /// 即入居可
    /// </summary>
    public bool Sokujihiki { get; set; }

    /// <summary>
    /// 女性限定
    /// </summary>
    public bool Jyosei { get; set; }

    /// <summary>
    /// 高齢者歓迎
    /// </summary>
    public bool Koureisya { get; set; }

    /// <summary>
    /// LGBTフレンドリー
    /// </summary>
    public bool Lgbt { get; set; }

    /// <summary>
    /// ペット相談可
    /// </summary>
    public bool Petka { get; set; }

    /// <summary>
    /// 楽器相談可
    /// </summary>
    public bool Gakki { get; set; }

    /// <summary>
    /// 事務所利用可
    /// </summary>
    public bool Jimusyoriyou { get; set; }

    /// <summary>
    /// ルームシェア可
    /// </summary>
    public bool Roomshare { get; set; }

    /// <summary>
    /// カスタマイズ可
    /// </summary>
    public bool Customizeka { get; set; }

    /// <summary>
    /// DIY可
    /// </summary>
    public bool Diyka { get; set; }

    /// <summary>
    /// 定期借家を含まない
    /// </summary>
    public bool NoTeisyaku { get; set; }
}
