CREATE TABLE rental_summary
(
    rental_id varchar(40) Not Null,
    creation_time timestamp,
    modification_time timestamp,
    prefecture_name varchar(10) Not Null,
    area_name varchar(10) Not Null,
    property_type varchar(32) Not Null,
    price decimal(15, 2) Not Null,
    management_fee decimal(10, 2) DEFAULT 0,
    security_deposit decimal(10, 2) Not Null,
    key_money decimal(10, 2) Not Null,
    address varchar(40) Not Null,
    station1_name varchar(40),
    station1_walk_min smallint,
    station2_name varchar(40),
    station2_walk_min smallint,
    station3_name varchar(40),
    station3_walk_min smallint,
    property_category varchar(32),
    structure_material varchar(32),
    floor_plan_type varchar(32),
    above_ground_floors smallint,
    below_ground_floors smallint,
    current_floor smallint,
    construction_date date Not Null,
    exclusive_area decimal(5, 2) Not Null,
    building_name varchar(40),
    exterior_photo varchar(255),
    floor_plan_image varchar(255),
    effective_start_date date,
    effective_end_date date,
    PRIMARY KEY (rental_id)
);

COMMENT ON TABLE rental_summary IS '賃貸物件概要';
COMMENT ON COLUMN rental_summary.rental_id IS '賃貸物件ID';
COMMENT ON COLUMN rental_summary.creation_time IS '作成日時';
COMMENT ON COLUMN rental_summary.modification_time IS '変更日時';
COMMENT ON COLUMN rental_summary.prefecture_name IS '都道府県名';
COMMENT ON COLUMN rental_summary.area_name IS 'エリア名';
COMMENT ON COLUMN rental_summary.property_type IS '物件タイプ';
COMMENT ON COLUMN rental_summary.price IS '家賃、価格';
COMMENT ON COLUMN rental_summary.management_fee IS '管理費';
COMMENT ON COLUMN rental_summary.security_deposit IS '敷金';
COMMENT ON COLUMN rental_summary.key_money IS '礼金';
COMMENT ON COLUMN rental_summary.address IS '所在地';
COMMENT ON COLUMN rental_summary.station1_name IS '駅1の名前';
COMMENT ON COLUMN rental_summary.station1_walk_min IS '駅1までの所要時間（徒歩）';
COMMENT ON COLUMN rental_summary.station2_name IS '駅2の名前';
COMMENT ON COLUMN rental_summary.station2_walk_min IS '駅2までの所要時間（徒歩）';
COMMENT ON COLUMN rental_summary.station3_name IS '駅3の名前';
COMMENT ON COLUMN rental_summary.station3_walk_min IS '駅3までの所要時間（徒歩）';
COMMENT ON COLUMN rental_summary.property_category IS '物件種目';
COMMENT ON COLUMN rental_summary.structure_material IS '構造・材質';
COMMENT ON COLUMN rental_summary.floor_plan_type IS '間取り';
COMMENT ON COLUMN rental_summary.above_ground_floors IS '階層（地上）';
COMMENT ON COLUMN rental_summary.below_ground_floors IS '階層（地下）';
COMMENT ON COLUMN rental_summary.current_floor IS '所在階';
COMMENT ON COLUMN rental_summary.construction_date IS '築年月';
COMMENT ON COLUMN rental_summary.exclusive_area IS '専有面積';
COMMENT ON COLUMN rental_summary.building_name IS '建物名';
COMMENT ON COLUMN rental_summary.exterior_photo IS '建物外観画像';
COMMENT ON COLUMN rental_summary.floor_plan_image IS '間取り図面';
COMMENT ON COLUMN rental_summary.creation_time IS '有効開始日';
COMMENT ON COLUMN rental_summary.modification_time IS '有効終了日';