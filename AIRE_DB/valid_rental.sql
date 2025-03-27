CREATE TABLE valid_rental
(
    rental_id varchar(40) Not Null,
    rental_common_id varchar(40),
    company_id varchar(40) Not Null,
    staff_id varchar(20) Not Null,
    area_id char(5) Not Null,
    property_type varchar(32) Not Null DEFAULT 1,
    toritai varchar(32) DEFAULT FALSE,
    tasya varchar(32),
    yachin Decimal(15, 2) Not Null,
    syohizei varchar(32) Not Null,
    kanrihi Decimal(10, 2) DEFAULT 0,
    chimei varchar(40) Not Null,
    syozai varchar(40) Not Null,
    jusyokoukai varchar(32),
    shougakku1 varchar(40),
    shougakku2 varchar(40),
    chuugakku1 varchar(40),
    chuugakku2 varchar(40),
    ekisu varchar(32) DEFAULT FALSE,
    ekiid1 char(6),
    busac1 smallint,
    toho1 smallint,
    kuruma1 smallint,
    bustei1 varchar(20),
    ekiid2 char(6),
    busac2 smallint,
    toho2 smallint,
    kuruma2 smallint,
    bustei2 varchar(20),
    ekiid3 char(6),
    busac3 smallint,
    toho3 smallint,
    kuruma3 smallint,
    bustei3 varchar(20),
    kotsu varchar(40),
    hikiziki varchar(32),
    hiki smallint,
    hikitsuki smallint DEFAULT 0,
    hikijun varchar(32) DEFAULT FALSE,
    kynen smallint Not Null DEFAULT 2,
    kytsuki smallint Not Null DEFAULT 0,
    teisyaku boolean Not Null DEFAULT FALSE,
    tyuzaihi varchar(32) DEFAULT FALSE,
    tyudaisu smallint,
    tyunedan Decimal(10, 2),
    tyukinrinmade int,
    genkyou varchar(32) DEFAULT FALSE,
    denwaba varchar(20),
    kaiinmei varchar(40),
    toitan varchar(20),
    motomemo varchar(255),
    gyosyamemo varchar(255),
    koukoku varchar(32) DEFAULT FALSE,
    kinkum1 varchar(32),
    kinkagetu1 Decimal(10, 2),
    kinku1 varchar(32),
    kinkum2 varchar(32),
    kinkagetu2 Decimal(10, 2),
    kinku2 varchar(32),
    kousinkbn varchar(32),
    kousinryo Decimal(10, 2),
    kousinkbm varchar(32) DEFAULT FALSE,
    kousintryo Decimal(10, 2),
    kousintkbn varchar(32) DEFAULT FALSE,
    koutenasi boolean Not Null DEFAULT FALSE,
    hosyouhissu boolean Not Null DEFAULT FALSE,
    chintaihosyou Decimal(10, 2),
    chintaihsbikou varchar(80),
    kasaihissu boolean Not Null DEFAULT FALSE,
    kasaihoken Decimal(10, 2),
    kasainen smallint DEFAULT 2,
    kagi varchar(32),
    kagiitaku varchar(40),
    kagibikou varchar(255),
    tyuutekin Decimal(10, 2) Not Null,
    tyutetani varchar(32) Not Null DEFAULT FALSE,
    tyuutehutan_kasi smallint Not Null DEFAULT 2,
    tyuutehutan smallint Not Null DEFAULT 2,
    bukkmoku varchar(32),
    youchi varchar(32) DEFAULT FALSE,
    kouzai varchar(32) DEFAULT FALSE,
    kouzaisonota varchar(20),
    madoheya smallint,
    madotaipu varchar(32) DEFAULT FALSE,
    situtaipu1 varchar(32) DEFAULT FALSE,
    situhiro1 Decimal(5, 2),
    situtaipu2 varchar(32) DEFAULT FALSE,
    situhiro2 Decimal(5, 2),
    situtaipu3 varchar(32) DEFAULT FALSE,
    situhiro3 Decimal(5, 2),
    situtaipu4 varchar(32) DEFAULT FALSE,
    situhiro4 Decimal(5, 2),
    situtaipu5 varchar(32) DEFAULT FALSE,
    situhiro5 Decimal(5, 2),
    situtaipu6 varchar(32) DEFAULT FALSE,
    situhiro6 Decimal(5, 2),
    situtaipu7 varchar(32) DEFAULT FALSE,
    situhiro7 Decimal(5, 2),
    chijou smallint,
    chika smallint,
    syokai_chika boolean Not Null DEFAULT FALSE,
    syokai smallint,
    chikunen smallint,
    chikutsuki smallint DEFAULT 0,
    sintiku boolean Not Null DEFAULT FALSE,
    tatemen Decimal(5, 2) Not Null,
    baruhou varchar(32) DEFAULT FALSE,
    shimen Decimal(5, 2),
    manmei varchar(40),
    manmeikoukai boolean Not Null DEFAULT FALSE,
    roomno varchar(20),
    kanrike varchar(32) DEFAULT FALSE,
    kanrinin varchar(32) DEFAULT FALSE,
    kanrikai varchar(40),
    tousouko smallint,
    sekoukaisya varchar(40),
    mezofrom smallint,
    mezoto smallint,
    re_nen smallint,
    re_tsuki smallint DEFAULT 0,
    naiso_reform_01 boolean Not Null DEFAULT FALSE,
    naiso_reform_02 boolean Not Null DEFAULT FALSE,
    naiso_reform_03 boolean Not Null DEFAULT FALSE,
    naiso_reform_04 boolean Not Null DEFAULT FALSE,
    naiso_reform_05 boolean Not Null DEFAULT FALSE,
    naiso_reform_07 boolean Not Null DEFAULT FALSE,
    naiso_reform_09 boolean Not Null DEFAULT FALSE,
    naiso_reform_10 boolean Not Null DEFAULT FALSE,
    naiso_reform_11 boolean Not Null DEFAULT FALSE,
    naiso_reform_12 boolean Not Null DEFAULT FALSE,
    naiso_reform_06 boolean Not Null DEFAULT FALSE,
    gaiso_reform_01 boolean Not Null DEFAULT FALSE,
    gaiso_reform_02 boolean Not Null DEFAULT FALSE,
    gaiso_reform_03 boolean Not Null DEFAULT FALSE,
    reformbikou varchar(255),
    renova boolean Not Null DEFAULT FALSE,
    reno_nen smallint,
    reno_tsuki smallint DEFAULT 0,
    renovabikou varchar(255),
    saiene varchar(32) DEFAULT FALSE,
    eneseinou varchar(32) DEFAULT FALSE,
    dannetu smallint,
    kounetuhi Decimal(10, 2),
    jyousui varchar(32) DEFAULT FALSE,
    zappaisui varchar(32) DEFAULT FALSE,
    gasu varchar(32) DEFAULT FALSE,
    gaskonro varchar(32) DEFAULT FALSE,
    ih boolean Not Null DEFAULT FALSE,
    sisukit boolean Not Null DEFAULT FALSE,
    ckittin boolean Not Null DEFAULT FALSE,
    denka boolean Not Null DEFAULT FALSE,
    syokkiarai boolean Not Null DEFAULT FALSE,
    kyuutou boolean Not Null DEFAULT FALSE,
    dhisupoza boolean Not Null DEFAULT FALSE,
    jyousuiki boolean Not Null DEFAULT FALSE,
    ikittin boolean Not Null DEFAULT FALSE,
    furo varchar(32) DEFAULT FALSE,
    toire varchar(32) DEFAULT FALSE,
    gesui varchar(32) DEFAULT FALSE,
    yokuhiro varchar(32) DEFAULT FALSE,
    outobasu boolean Not Null DEFAULT FALSE,
    btbetu boolean Not Null DEFAULT FALSE,
    senjoub boolean Not Null DEFAULT FALSE,
    danboubenza boolean Not Null DEFAULT FALSE,
    oidaki boolean Not Null DEFAULT FALSE,
    syanpudore boolean Not Null DEFAULT FALSE,
    yokushitudan boolean Not Null DEFAULT FALSE,
    ykansouki boolean Not Null DEFAULT FALSE,
    sennmenn boolean Not Null DEFAULT FALSE,
    senmennomi boolean Not Null DEFAULT FALSE,
    toire2kasyo boolean Not Null DEFAULT FALSE,
    yokusitumado boolean Not Null DEFAULT FALSE,
    syawaaroom boolean Not Null DEFAULT FALSE,
    intanet boolean Not Null DEFAULT FALSE,
    hikarif boolean Not Null DEFAULT FALSE,
    bs boolean Not Null DEFAULT FALSE,
    cs boolean Not Null DEFAULT FALSE,
    catv boolean Not Null DEFAULT FALSE,
    inetmuryou boolean Not Null DEFAULT FALSE,
    zensitumuki varchar(32) DEFAULT FALSE,
    eakon boolean Not Null DEFAULT FALSE,
    eakondaisu smallint,
    all_eakon boolean Not Null DEFAULT FALSE,
    touyudan boolean Not Null DEFAULT FALSE,
    gasdan boolean Not Null DEFAULT FALSE,
    rofuto boolean Not Null DEFAULT FALSE,
    furoringu boolean Not Null DEFAULT FALSE,
    all_furoringu boolean Not Null DEFAULT FALSE,
    itibu_furoringu boolean Not Null DEFAULT FALSE,
    yukadan boolean Not Null DEFAULT FALSE,
    ysyuunou boolean Not Null DEFAULT FALSE,
    syuunou boolean Not Null DEFAULT FALSE,
    situsentaku boolean Not Null DEFAULT FALSE,
    kurozet boolean Not Null DEFAULT FALSE,
    wkurozet boolean Not Null DEFAULT FALSE,
    bed boolean Not Null DEFAULT FALSE,
    fakusesu boolean Not Null DEFAULT FALSE,
    kutsubako boolean Not Null DEFAULT FALSE,
    bouon boolean Not Null DEFAULT FALSE,
    shoes_ic boolean Not Null DEFAULT FALSE,
    kanki24h boolean Not Null DEFAULT FALSE,
    all_syuunou boolean Not Null DEFAULT FALSE,
    situmonohosi boolean Not Null DEFAULT FALSE,
    pantori boolean Not Null DEFAULT FALSE,
    yaneurasyuunou boolean Not Null DEFAULT FALSE,
    ribingukaidan boolean Not Null DEFAULT FALSE,
    fukinuke boolean Not Null DEFAULT FALSE,
    nando boolean Not Null DEFAULT FALSE,
    all_6jou boolean Not Null DEFAULT FALSE,
    saikoumen varchar(32) DEFAULT FALSE,
    all_saikoumen2 boolean Not Null DEFAULT FALSE,
    hukusougarasu boolean Not Null DEFAULT FALSE,
    all_hukusougarasu boolean Not Null DEFAULT FALSE,
    jinkansyoumei boolean Not Null DEFAULT FALSE,
    tyuurin boolean Not Null DEFAULT FALSE,
    baiku boolean Not Null DEFAULT FALSE,
    erebeta boolean Not Null DEFAULT FALSE,
    bfree boolean Not Null DEFAULT FALSE,
    torankur boolean Not Null DEFAULT FALSE,
    niwa boolean Not Null DEFAULT FALSE,
    takuhaib boolean Not Null DEFAULT FALSE,
    monooki boolean Not Null DEFAULT FALSE,
    gomiokiba boolean Not Null DEFAULT FALSE,
    tyusyousetsu boolean Not Null DEFAULT FALSE,
    barukoni boolean Not Null DEFAULT FALSE,
    rbarukoni boolean Not Null DEFAULT FALSE,
    beranda boolean Not Null DEFAULT FALSE,
    terasu boolean Not Null DEFAULT FALSE,
    dendousyatta boolean Not Null DEFAULT FALSE,
    hiatariryoko boolean Not Null DEFAULT FALSE,
    minamibaru boolean Not Null DEFAULT FALSE,
    tenjou25 boolean Not Null DEFAULT FALSE,
    komitukodan boolean Not Null DEFAULT FALSE,
    gaikantairu boolean Not Null DEFAULT FALSE,
    taiyouhatuden boolean Not Null DEFAULT FALSE,
    wbarukoni boolean Not Null DEFAULT FALSE,
    niwa10tubo boolean Not Null DEFAULT FALSE,
    uddodekki boolean Not Null DEFAULT FALSE,
    minaminiwa boolean Not Null DEFAULT FALSE,
    chikashitsu boolean Not Null DEFAULT FALSE,
    tvdoahon boolean Not Null DEFAULT FALSE,
    outorok boolean Not Null DEFAULT FALSE,
    sekyurithi boolean Not Null DEFAULT FALSE,
    bouhan_camera boolean Not Null DEFAULT FALSE,
    cardkey boolean Not Null DEFAULT FALSE,
    densikey boolean Not Null DEFAULT FALSE,
    yujin24h boolean Not Null DEFAULT FALSE,
    sekyurithikaisya boolean Not Null DEFAULT FALSE,
    petka boolean Not Null DEFAULT FALSE,
    gakki boolean Not Null DEFAULT FALSE,
    roomshare boolean Not Null DEFAULT FALSE,
    koureisya boolean Not Null DEFAULT FALSE,
    kofuka boolean Not Null DEFAULT FALSE,
    jimusyoriyou boolean Not Null DEFAULT FALSE,
    houjin boolean Not Null DEFAULT FALSE,
    hosyounin boolean Not Null DEFAULT FALSE,
    jyosei boolean Not Null DEFAULT FALSE,
    dansei boolean Not Null DEFAULT FALSE,
    nyukyoka varchar(32) DEFAULT FALSE,
    freerent varchar(32) DEFAULT FALSE,
    syokihiyo varchar(32) DEFAULT FALSE,
    kseinouhyouka varchar(32) DEFAULT FALSE,
    sseinouhyouka boolean Not Null DEFAULT FALSE,
    sihatu boolean Not Null DEFAULT FALSE,
    kadobeya boolean Not Null DEFAULT FALSE,
    bunjou boolean Not Null DEFAULT FALSE,
    nisetai boolean Not Null DEFAULT FALSE,
    dezaina boolean Not Null DEFAULT FALSE,
    kagutsuki boolean Not Null DEFAULT FALSE,
    kadentsuki boolean Not Null DEFAULT FALSE,
    tokuteiyuryou boolean Not Null DEFAULT FALSE,
    mezonetto boolean Not Null DEFAULT FALSE,
    lgbt boolean Not Null DEFAULT FALSE,
    crecard1 boolean Not Null DEFAULT FALSE,
    crecard2 boolean Not Null DEFAULT FALSE,
    itjusetu boolean Not Null DEFAULT FALSE,
    tyutemuryou boolean Not Null DEFAULT FALSE,
    tyutehangaku boolean Not Null DEFAULT FALSE,
    takadai boolean Not Null DEFAULT FALSE,
    kansei boolean Not Null DEFAULT FALSE,
    zenmentounasi boolean Not Null DEFAULT FALSE,
    taishinkijun boolean Not Null DEFAULT FALSE,
    taishin boolean Not Null DEFAULT FALSE,
    menshin boolean Not Null DEFAULT FALSE,
    seishin boolean Not Null DEFAULT FALSE,
    gomika24h boolean Not Null DEFAULT FALSE,
    customizeka boolean Not Null DEFAULT FALSE,
    diyka boolean Not Null DEFAULT FALSE,
    tochimen Decimal(10, 2),
    setusyu1 varchar(32) DEFAULT FALSE,
    setuhou1 varchar(32) DEFAULT FALSE,
    setuhaba1 Decimal(5, 2),
    setusetu1 Decimal(5, 2),
    situzai varchar(32) DEFAULT FALSE,
    heitanchi boolean Not Null DEFAULT FALSE,
    seikeichi boolean Not Null DEFAULT FALSE,
    chimoku varchar(32) DEFAULT FALSE,
    tokei varchar(32) DEFAULT FALSE,
    kenpei smallint,
    youseki smallint,
    tokenri varchar(32) DEFAULT FALSE,
    bikou varchar(255),
    midasi varchar(255),
    dougaurl1 varchar(255),
    douga_w1 smallint,
    douga_y1 smallint,
    dougaurl2 varchar(255),
    douga_w2 smallint,
    douga_y2 smallint,
    gporder1 varchar(255),
    gporder2 varchar(255),
    gporder3 varchar(255),
    kakutyouk1 boolean Not Null DEFAULT FALSE,
    kakutyouk2 boolean Not Null DEFAULT FALSE,
    kakutyouk3 boolean Not Null DEFAULT FALSE,
    kakutyouk4 boolean Not Null DEFAULT FALSE,
    kakutyouk5 boolean Not Null DEFAULT FALSE,
    kakutyouk6 boolean Not Null DEFAULT FALSE,
    kakutyouk7 boolean Not Null DEFAULT FALSE,
    kakutyouk8 boolean Not Null DEFAULT FALSE,
    PRIMARY KEY (rental_id)
);

COMMENT ON TABLE valid_rental IS '掲載賃貸物件';
COMMENT ON COLUMN valid_rental.rental_id IS '賃貸物件ID';
COMMENT ON COLUMN valid_rental.rental_common_id IS '賃貸物件共通ID';
COMMENT ON COLUMN valid_rental.company_id IS '会社ID';
COMMENT ON COLUMN valid_rental.staff_id IS '担当社員ID';
COMMENT ON COLUMN valid_rental.area_id IS 'エリアID';
COMMENT ON COLUMN valid_rental.property_type IS '物件タイプ';
COMMENT ON COLUMN valid_rental.toritai IS '取引態様';
COMMENT ON COLUMN valid_rental.tasya IS '他社付け';
COMMENT ON COLUMN valid_rental.yachin IS '家賃、価格';
COMMENT ON COLUMN valid_rental.syohizei IS '消費税';
COMMENT ON COLUMN valid_rental.kanrihi IS '管理費';
COMMENT ON COLUMN valid_rental.chimei IS '所在地（何丁目まで）';
COMMENT ON COLUMN valid_rental.syozai IS '所在地（何番から）';
COMMENT ON COLUMN valid_rental.jusyokoukai IS '所在地詳細公開';
COMMENT ON COLUMN valid_rental.shougakku1 IS '小学校区１';
COMMENT ON COLUMN valid_rental.shougakku2 IS '小学校区２';
COMMENT ON COLUMN valid_rental.chuugakku1 IS '中学校区１';
COMMENT ON COLUMN valid_rental.chuugakku2 IS '中学校区２';
COMMENT ON COLUMN valid_rental.ekisu IS '駅数';
COMMENT ON COLUMN valid_rental.ekiid1 IS '駅1のID';
COMMENT ON COLUMN valid_rental.busac1 IS '駅1までの所要時間（バス）';
COMMENT ON COLUMN valid_rental.toho1 IS '駅1までの所要時間（徒歩）';
COMMENT ON COLUMN valid_rental.kuruma1 IS '駅1までの所要時間（車）';
COMMENT ON COLUMN valid_rental.bustei1 IS '駅1までのバス停名';
COMMENT ON COLUMN valid_rental.ekiid2 IS '駅2のID';
COMMENT ON COLUMN valid_rental.busac2 IS '駅2までの所要時間（バス）';
COMMENT ON COLUMN valid_rental.toho2 IS '駅2までの所要時間（徒歩）';
COMMENT ON COLUMN valid_rental.kuruma2 IS '駅2までの所要時間（車）';
COMMENT ON COLUMN valid_rental.bustei2 IS '駅2までのバス停名';
COMMENT ON COLUMN valid_rental.ekiid3 IS '駅3のID';
COMMENT ON COLUMN valid_rental.busac3 IS '駅3までの所要時間（バス）';
COMMENT ON COLUMN valid_rental.toho3 IS '駅3までの所要時間（徒歩）';
COMMENT ON COLUMN valid_rental.kuruma3 IS '駅3までの所要時間（車）';
COMMENT ON COLUMN valid_rental.bustei3 IS '駅3までのバス停名';
COMMENT ON COLUMN valid_rental.kotsu IS '交通情報';
COMMENT ON COLUMN valid_rental.hikiziki IS '入居時期';
COMMENT ON COLUMN valid_rental.hiki IS '期日指定時（年）';
COMMENT ON COLUMN valid_rental.hikitsuki IS '期日指定時（月）';
COMMENT ON COLUMN valid_rental.hikijun IS '期日指定時（旬）';
COMMENT ON COLUMN valid_rental.kynen IS '契約期間（年）';
COMMENT ON COLUMN valid_rental.kytsuki IS '契約期間（月）';
COMMENT ON COLUMN valid_rental.teisyaku IS '定期借家';
COMMENT ON COLUMN valid_rental.tyuzaihi IS '駐車場';
COMMENT ON COLUMN valid_rental.tyudaisu IS '駐車場（台）';
COMMENT ON COLUMN valid_rental.tyunedan IS '駐車場（円/月）';
COMMENT ON COLUMN valid_rental.tyukinrinmade IS '駐車場まで（m）';
COMMENT ON COLUMN valid_rental.genkyou IS '現況';
COMMENT ON COLUMN valid_rental.denwaba IS '元付会社TEL';
COMMENT ON COLUMN valid_rental.kaiinmei IS '元付会社名';
COMMENT ON COLUMN valid_rental.toitan IS '元付担当者';
COMMENT ON COLUMN valid_rental.motomemo IS '元付メモ';
COMMENT ON COLUMN valid_rental.gyosyamemo IS '業者向けコメント';
COMMENT ON COLUMN valid_rental.koukoku IS '（元付会社の）広告転載';
COMMENT ON COLUMN valid_rental.kinkum1 IS '名目';
COMMENT ON COLUMN valid_rental.kinkagetu1 IS '料金';
COMMENT ON COLUMN valid_rental.kinku1 IS '単位';
COMMENT ON COLUMN valid_rental.kinkum2 IS '名目';
COMMENT ON COLUMN valid_rental.kinkagetu2 IS '料金';
COMMENT ON COLUMN valid_rental.kinku2 IS '単位';
COMMENT ON COLUMN valid_rental.kousinkbn IS '更新料種類';
COMMENT ON COLUMN valid_rental.kousinryo IS '更新料';
COMMENT ON COLUMN valid_rental.kousinkbm IS '更新料単位';
COMMENT ON COLUMN valid_rental.kousintryo IS '更新手数料';
COMMENT ON COLUMN valid_rental.kousintkbn IS '更新手数料単位';
COMMENT ON COLUMN valid_rental.koutenasi IS '更新手数料無し';
COMMENT ON COLUMN valid_rental.hosyouhissu IS '賃貸保証料必須';
COMMENT ON COLUMN valid_rental.chintaihosyou IS '賃貸保証料（円）';
COMMENT ON COLUMN valid_rental.chintaihsbikou IS '賃貸保証料詳細';
COMMENT ON COLUMN valid_rental.kasaihissu IS '火災保険必須';
COMMENT ON COLUMN valid_rental.kasaihoken IS '火災保険（円）';
COMMENT ON COLUMN valid_rental.kasainen IS '火災保険（年）';
COMMENT ON COLUMN valid_rental.kagi IS '鍵保管場所';
COMMENT ON COLUMN valid_rental.kagiitaku IS '預託先会社';
COMMENT ON COLUMN valid_rental.kagibikou IS '鍵備考';
COMMENT ON COLUMN valid_rental.tyuutekin IS '金額（仲介手数料）';
COMMENT ON COLUMN valid_rental.tyutetani IS '単位（仲介手数料）';
COMMENT ON COLUMN valid_rental.tyuutehutan_kasi IS '貸主負担比率%（仲介手数料）';
COMMENT ON COLUMN valid_rental.tyuutehutan IS '借主負担比率%（仲介手数料）';
COMMENT ON COLUMN valid_rental.bukkmoku IS '物件種目';
COMMENT ON COLUMN valid_rental.youchi IS '用途地域';
COMMENT ON COLUMN valid_rental.kouzai IS '構造・材質';
COMMENT ON COLUMN valid_rental.kouzaisonota IS 'その他（構造・材質）';
COMMENT ON COLUMN valid_rental.madoheya IS '部屋数（間取り）';
COMMENT ON COLUMN valid_rental.madotaipu IS 'タイプ（間取り）';
COMMENT ON COLUMN valid_rental.situtaipu1 IS '詳細1（間取り）';
COMMENT ON COLUMN valid_rental.situhiro1 IS '畳1（間取り）';
COMMENT ON COLUMN valid_rental.situtaipu2 IS '詳細2（間取り）';
COMMENT ON COLUMN valid_rental.situhiro2 IS '畳2（間取り）';
COMMENT ON COLUMN valid_rental.situtaipu3 IS '詳細3（間取り）';
COMMENT ON COLUMN valid_rental.situhiro3 IS '畳3（間取り）';
COMMENT ON COLUMN valid_rental.situtaipu4 IS '詳細4（間取り）';
COMMENT ON COLUMN valid_rental.situhiro4 IS '畳4（間取り）';
COMMENT ON COLUMN valid_rental.situtaipu5 IS '詳細5（間取り）';
COMMENT ON COLUMN valid_rental.situhiro5 IS '畳5（間取り）';
COMMENT ON COLUMN valid_rental.situtaipu6 IS '詳細6（間取り）';
COMMENT ON COLUMN valid_rental.situhiro6 IS '畳6（間取り）';
COMMENT ON COLUMN valid_rental.situtaipu7 IS '詳細7（間取り）';
COMMENT ON COLUMN valid_rental.situhiro7 IS '畳7（間取り）';
COMMENT ON COLUMN valid_rental.chijou IS '階層（地上）';
COMMENT ON COLUMN valid_rental.chika IS '階層（地下）';
COMMENT ON COLUMN valid_rental.syokai_chika IS '所在地下';
COMMENT ON COLUMN valid_rental.syokai IS '所在階';
COMMENT ON COLUMN valid_rental.chikunen IS '築年月（年）';
COMMENT ON COLUMN valid_rental.chikutsuki IS '築年月（月）';
COMMENT ON COLUMN valid_rental.sintiku IS '新築';
COMMENT ON COLUMN valid_rental.tatemen IS '専有面積';
COMMENT ON COLUMN valid_rental.baruhou IS 'バルコニー（方向）';
COMMENT ON COLUMN valid_rental.shimen IS 'バルコニー（面積）';
COMMENT ON COLUMN valid_rental.manmei IS '建物名';
COMMENT ON COLUMN valid_rental.manmeikoukai IS '物件名を公開する';
COMMENT ON COLUMN valid_rental.roomno IS '部屋番号';
COMMENT ON COLUMN valid_rental.kanrike IS '管理（方式）';
COMMENT ON COLUMN valid_rental.kanrinin IS '管理（形態）';
COMMENT ON COLUMN valid_rental.kanrikai IS '管理（会社）';
COMMENT ON COLUMN valid_rental.tousouko IS '棟総戸数';
COMMENT ON COLUMN valid_rental.sekoukaisya IS '施工会社';
COMMENT ON COLUMN valid_rental.mezofrom IS 'メゾネット階（から）';
COMMENT ON COLUMN valid_rental.mezoto IS 'メゾネット階（まで）';
COMMENT ON COLUMN valid_rental.re_nen IS 'リフォーム実施年';
COMMENT ON COLUMN valid_rental.re_tsuki IS 'リフォーム実施月';
COMMENT ON COLUMN valid_rental.naiso_reform_01 IS '内装（キッチン）';
COMMENT ON COLUMN valid_rental.naiso_reform_02 IS '内装（浴室）';
COMMENT ON COLUMN valid_rental.naiso_reform_03 IS '内装（トイレ）';
COMMENT ON COLUMN valid_rental.naiso_reform_04 IS '内装（クロス張替）';
COMMENT ON COLUMN valid_rental.naiso_reform_05 IS '内装（床）';
COMMENT ON COLUMN valid_rental.naiso_reform_07 IS '内装（洗面）';
COMMENT ON COLUMN valid_rental.naiso_reform_09 IS '内装（給湯器）';
COMMENT ON COLUMN valid_rental.naiso_reform_10 IS '内装（給排水管）';
COMMENT ON COLUMN valid_rental.naiso_reform_11 IS '内装（建具）';
COMMENT ON COLUMN valid_rental.naiso_reform_12 IS '内装（サッシ）';
COMMENT ON COLUMN valid_rental.naiso_reform_06 IS '内装（内装全面）';
COMMENT ON COLUMN valid_rental.gaiso_reform_01 IS '外装（外装全面）';
COMMENT ON COLUMN valid_rental.gaiso_reform_02 IS '外装（屋根）';
COMMENT ON COLUMN valid_rental.gaiso_reform_03 IS '外装（外装その他）';
COMMENT ON COLUMN valid_rental.reformbikou IS 'リフォーム備考';
COMMENT ON COLUMN valid_rental.renova IS 'リノベーション済み';
COMMENT ON COLUMN valid_rental.reno_nen IS '実施年（リノベーション）';
COMMENT ON COLUMN valid_rental.reno_tsuki IS '実施月（リノベーション）';
COMMENT ON COLUMN valid_rental.renovabikou IS '内容（リノベーション）';
COMMENT ON COLUMN valid_rental.saiene IS '再エネ（省エネ性能）';
COMMENT ON COLUMN valid_rental.eneseinou IS 'エネルギー消費性能';
COMMENT ON COLUMN valid_rental.dannetu IS '断熱性能';
COMMENT ON COLUMN valid_rental.kounetuhi IS '目安光熱費';
COMMENT ON COLUMN valid_rental.jyousui IS '水道';
COMMENT ON COLUMN valid_rental.zappaisui IS '雑排水';
COMMENT ON COLUMN valid_rental.gasu IS 'ガス';
COMMENT ON COLUMN valid_rental.gaskonro IS 'コンロ';
COMMENT ON COLUMN valid_rental.ih IS 'ＩＨクッキングヒーター';
COMMENT ON COLUMN valid_rental.sisukit IS 'システムキッチン';
COMMENT ON COLUMN valid_rental.ckittin IS 'カウンターキッチン';
COMMENT ON COLUMN valid_rental.denka IS 'オール電化';
COMMENT ON COLUMN valid_rental.syokkiarai IS '食器洗浄機';
COMMENT ON COLUMN valid_rental.kyuutou IS '給湯器';
COMMENT ON COLUMN valid_rental.dhisupoza IS 'ディスポーザー';
COMMENT ON COLUMN valid_rental.jyousuiki IS '浄水器';
COMMENT ON COLUMN valid_rental.ikittin IS 'アイランドキッチン';
COMMENT ON COLUMN valid_rental.furo IS '風呂';
COMMENT ON COLUMN valid_rental.toire IS 'トイレ';
COMMENT ON COLUMN valid_rental.gesui IS '下水';
COMMENT ON COLUMN valid_rental.yokuhiro IS '浴室広さ';
COMMENT ON COLUMN valid_rental.outobasu IS 'オートバス';
COMMENT ON COLUMN valid_rental.btbetu IS 'バストイレ別';
COMMENT ON COLUMN valid_rental.senjoub IS 'ウォッシュレット';
COMMENT ON COLUMN valid_rental.danboubenza IS '暖房便座';
COMMENT ON COLUMN valid_rental.oidaki IS '追焚き可';
COMMENT ON COLUMN valid_rental.syanpudore IS 'シャンプードレッサー';
COMMENT ON COLUMN valid_rental.yokushitudan IS '浴室暖房';
COMMENT ON COLUMN valid_rental.ykansouki IS '浴室乾燥機';
COMMENT ON COLUMN valid_rental.sennmenn IS '洗面化粧台';
COMMENT ON COLUMN valid_rental.senmennomi IS '洗面所独立';
COMMENT ON COLUMN valid_rental.toire2kasyo IS 'トイレ2ヶ所';
COMMENT ON COLUMN valid_rental.yokusitumado IS '浴室に窓';
COMMENT ON COLUMN valid_rental.syawaaroom IS 'シャワールーム';
COMMENT ON COLUMN valid_rental.intanet IS 'インターネット接続可';
COMMENT ON COLUMN valid_rental.hikarif IS '光ファイバー';
COMMENT ON COLUMN valid_rental.bs IS 'ＢＳ受信可';
COMMENT ON COLUMN valid_rental.cs IS 'ＣＳ受信可';
COMMENT ON COLUMN valid_rental.catv IS 'ＣＡＴＶ';
COMMENT ON COLUMN valid_rental.inetmuryou IS 'インターネット無料';
COMMENT ON COLUMN valid_rental.zensitumuki IS '全室向き';
COMMENT ON COLUMN valid_rental.eakon IS 'エアコン';
COMMENT ON COLUMN valid_rental.eakondaisu IS '台（エアコン）';
COMMENT ON COLUMN valid_rental.all_eakon IS '全居室エアコン';
COMMENT ON COLUMN valid_rental.touyudan IS '灯油暖房';
COMMENT ON COLUMN valid_rental.gasdan IS 'ガス暖房';
COMMENT ON COLUMN valid_rental.rofuto IS 'ロフト';
COMMENT ON COLUMN valid_rental.furoringu IS 'フローリング';
COMMENT ON COLUMN valid_rental.all_furoringu IS '全居室フローリング';
COMMENT ON COLUMN valid_rental.itibu_furoringu IS '一部フローリング';
COMMENT ON COLUMN valid_rental.yukadan IS '床暖房';
COMMENT ON COLUMN valid_rental.ysyuunou IS '床下収納';
COMMENT ON COLUMN valid_rental.syuunou IS '収納';
COMMENT ON COLUMN valid_rental.situsentaku IS '室内洗濯機置場';
COMMENT ON COLUMN valid_rental.kurozet IS 'クローゼット';
COMMENT ON COLUMN valid_rental.wkurozet IS 'ウォークインクローゼット';
COMMENT ON COLUMN valid_rental.bed IS 'ベッド';
COMMENT ON COLUMN valid_rental.fakusesu IS 'フリーアクセス';
COMMENT ON COLUMN valid_rental.kutsubako IS 'シューズボックス';
COMMENT ON COLUMN valid_rental.bouon IS '防音室';
COMMENT ON COLUMN valid_rental.shoes_ic IS 'シューズインクローク';
COMMENT ON COLUMN valid_rental.kanki24h IS '24時間換気';
COMMENT ON COLUMN valid_rental.all_syuunou IS '全居室収納';
COMMENT ON COLUMN valid_rental.situmonohosi IS '室内物干し';
COMMENT ON COLUMN valid_rental.pantori IS 'パントリー';
COMMENT ON COLUMN valid_rental.yaneurasyuunou IS '屋根裏収納';
COMMENT ON COLUMN valid_rental.ribingukaidan IS 'リビング階段';
COMMENT ON COLUMN valid_rental.fukinuke IS '吹抜け';
COMMENT ON COLUMN valid_rental.nando IS '納戸';
COMMENT ON COLUMN valid_rental.all_6jou IS '全居室６畳以上';
COMMENT ON COLUMN valid_rental.saikoumen IS '採光面';
COMMENT ON COLUMN valid_rental.all_saikoumen2 IS '全室2面採光';
COMMENT ON COLUMN valid_rental.hukusougarasu IS '複層ガラス';
COMMENT ON COLUMN valid_rental.all_hukusougarasu IS '全居室複層ガラス';
COMMENT ON COLUMN valid_rental.jinkansyoumei IS '人感センサー付照明';
COMMENT ON COLUMN valid_rental.tyuurin IS '駐輪場';
COMMENT ON COLUMN valid_rental.baiku IS 'バイク置き場';
COMMENT ON COLUMN valid_rental.erebeta IS 'エレベーター';
COMMENT ON COLUMN valid_rental.bfree IS 'バリアフリー';
COMMENT ON COLUMN valid_rental.torankur IS 'トランクルーム';
COMMENT ON COLUMN valid_rental.niwa IS '専用庭';
COMMENT ON COLUMN valid_rental.takuhaib IS '宅配ボックス';
COMMENT ON COLUMN valid_rental.monooki IS '物置';
COMMENT ON COLUMN valid_rental.gomiokiba IS '敷地内ゴミ置場';
COMMENT ON COLUMN valid_rental.tyusyousetsu IS '駐車場消雪設備';
COMMENT ON COLUMN valid_rental.barukoni IS 'バルコニー';
COMMENT ON COLUMN valid_rental.rbarukoni IS 'ルーフバルコニー';
COMMENT ON COLUMN valid_rental.beranda IS 'ベランダ';
COMMENT ON COLUMN valid_rental.terasu IS 'テラス';
COMMENT ON COLUMN valid_rental.dendousyatta IS '電動シャッター';
COMMENT ON COLUMN valid_rental.hiatariryoko IS '日当たり良好';
COMMENT ON COLUMN valid_rental.minamibaru IS '南面バルコニー';
COMMENT ON COLUMN valid_rental.tenjou25 IS '天井高2.5m以上';
COMMENT ON COLUMN valid_rental.komitukodan IS '高気密高断熱住宅';
COMMENT ON COLUMN valid_rental.gaikantairu IS '外観タイル張り';
COMMENT ON COLUMN valid_rental.taiyouhatuden IS '太陽光発電システム';
COMMENT ON COLUMN valid_rental.wbarukoni IS 'ワイドバルコニー';
COMMENT ON COLUMN valid_rental.niwa10tubo IS '庭10坪以上';
COMMENT ON COLUMN valid_rental.uddodekki IS 'ウッドデッキ';
COMMENT ON COLUMN valid_rental.minaminiwa IS '南庭';
COMMENT ON COLUMN valid_rental.chikashitsu IS '地下室';
COMMENT ON COLUMN valid_rental.tvdoahon IS 'ＴＶドアホン';
COMMENT ON COLUMN valid_rental.outorok IS 'オートロック';
COMMENT ON COLUMN valid_rental.sekyurithi IS 'セキュリティーシステム';
COMMENT ON COLUMN valid_rental.bouhan_camera IS '防犯カメラ';
COMMENT ON COLUMN valid_rental.cardkey IS 'カードキー';
COMMENT ON COLUMN valid_rental.densikey IS '電子キー';
COMMENT ON COLUMN valid_rental.yujin24h IS '24時間有人管理';
COMMENT ON COLUMN valid_rental.sekyurithikaisya IS 'セキュリティ会社加入済';
COMMENT ON COLUMN valid_rental.petka IS 'ペット可';
COMMENT ON COLUMN valid_rental.gakki IS '楽器相談';
COMMENT ON COLUMN valid_rental.roomshare IS 'ルームシェア可';
COMMENT ON COLUMN valid_rental.koureisya IS '50歳以上可';
COMMENT ON COLUMN valid_rental.kofuka IS '子供不可';
COMMENT ON COLUMN valid_rental.jimusyoriyou IS '事務所利用可';
COMMENT ON COLUMN valid_rental.houjin IS '法人限定';
COMMENT ON COLUMN valid_rental.hosyounin IS '保証人不要/代行';
COMMENT ON COLUMN valid_rental.jyosei IS '女性限定';
COMMENT ON COLUMN valid_rental.dansei IS '男性限定';
COMMENT ON COLUMN valid_rental.nyukyoka IS '入居可能';
COMMENT ON COLUMN valid_rental.freerent IS 'フリーレント';
COMMENT ON COLUMN valid_rental.syokihiyo IS '初期費用';
COMMENT ON COLUMN valid_rental.kseinouhyouka IS '建設住宅性能評価付';
COMMENT ON COLUMN valid_rental.sseinouhyouka IS '設計住宅性能評価付';
COMMENT ON COLUMN valid_rental.sihatu IS '始発駅';
COMMENT ON COLUMN valid_rental.kadobeya IS '角部屋';
COMMENT ON COLUMN valid_rental.bunjou IS '分譲タイプ';
COMMENT ON COLUMN valid_rental.nisetai IS '二世帯住宅';
COMMENT ON COLUMN valid_rental.dezaina IS 'デザイナーズ';
COMMENT ON COLUMN valid_rental.kagutsuki IS '家具付き';
COMMENT ON COLUMN valid_rental.kadentsuki IS '家電付き';
COMMENT ON COLUMN valid_rental.tokuteiyuryou IS '特定優良賃貸住宅';
COMMENT ON COLUMN valid_rental.mezonetto IS 'メゾネット';
COMMENT ON COLUMN valid_rental.lgbt IS 'LGBTフレンドリー';
COMMENT ON COLUMN valid_rental.crecard1 IS '初期費用クレジット決済可';
COMMENT ON COLUMN valid_rental.crecard2 IS '賃料クレジット決済可';
COMMENT ON COLUMN valid_rental.itjusetu IS 'IT重説対応物件';
COMMENT ON COLUMN valid_rental.tyutemuryou IS '仲介手数料無料';
COMMENT ON COLUMN valid_rental.tyutehangaku IS '仲介手数料半額';
COMMENT ON COLUMN valid_rental.takadai IS '高台に立地';
COMMENT ON COLUMN valid_rental.kansei IS '閑静な住宅街';
COMMENT ON COLUMN valid_rental.zenmentounasi IS '前面棟無';
COMMENT ON COLUMN valid_rental.taishinkijun IS '耐震基準適合証明書';
COMMENT ON COLUMN valid_rental.taishin IS '耐震構造';
COMMENT ON COLUMN valid_rental.menshin IS '免震構造';
COMMENT ON COLUMN valid_rental.seishin IS '制震構造';
COMMENT ON COLUMN valid_rental.gomika24h IS '24時間ゴミ出し可';
COMMENT ON COLUMN valid_rental.customizeka IS 'カスタマイズ可';
COMMENT ON COLUMN valid_rental.diyka IS 'DIY可';
COMMENT ON COLUMN valid_rental.tochimen IS '土地面積';
COMMENT ON COLUMN valid_rental.setusyu1 IS '接道１（種類）';
COMMENT ON COLUMN valid_rental.setuhou1 IS '接道１（方向）';
COMMENT ON COLUMN valid_rental.setuhaba1 IS '接道１（幅員）';
COMMENT ON COLUMN valid_rental.setusetu1 IS '接道１（接面）';
COMMENT ON COLUMN valid_rental.situzai IS '最適用途（貸地用）';
COMMENT ON COLUMN valid_rental.heitanchi IS '平坦地';
COMMENT ON COLUMN valid_rental.seikeichi IS '整形地';
COMMENT ON COLUMN valid_rental.chimoku IS '地目';
COMMENT ON COLUMN valid_rental.tokei IS '都市計画';
COMMENT ON COLUMN valid_rental.kenpei IS '建ペイ率';
COMMENT ON COLUMN valid_rental.youseki IS '容積率';
COMMENT ON COLUMN valid_rental.tokenri IS '借地権種類';
COMMENT ON COLUMN valid_rental.bikou IS '備考';
COMMENT ON COLUMN valid_rental.midasi IS 'セールスポイント';
COMMENT ON COLUMN valid_rental.dougaurl1 IS '動画1の埋込用URL';
COMMENT ON COLUMN valid_rental.douga_w1 IS '動画1の表示サイズの横';
COMMENT ON COLUMN valid_rental.douga_y1 IS '動画1の表示サイズの縦';
COMMENT ON COLUMN valid_rental.dougaurl2 IS '動画2の埋込用URL';
COMMENT ON COLUMN valid_rental.douga_w2 IS '動画2の表示サイズの横';
COMMENT ON COLUMN valid_rental.douga_y2 IS '動画2の表示サイズの縦';
COMMENT ON COLUMN valid_rental.gporder1 IS '優先画像1';
COMMENT ON COLUMN valid_rental.gporder2 IS '優先画像2';
COMMENT ON COLUMN valid_rental.gporder3 IS '優先画像3';
COMMENT ON COLUMN valid_rental.kakutyouk1 IS 'スグ借りバーゲン';
COMMENT ON COLUMN valid_rental.kakutyouk2 IS 'ルームズくん';
COMMENT ON COLUMN valid_rental.kakutyouk3 IS 'シャレ部屋';
COMMENT ON COLUMN valid_rental.kakutyouk4 IS 'おしゃれな物件';
COMMENT ON COLUMN valid_rental.kakutyouk5 IS 'ハウスメーカー';
COMMENT ON COLUMN valid_rental.kakutyouk6 IS '無職可';
COMMENT ON COLUMN valid_rental.kakutyouk7 IS 'トリプルゼロ';
COMMENT ON COLUMN valid_rental.kakutyouk8 IS '保証人無し可';