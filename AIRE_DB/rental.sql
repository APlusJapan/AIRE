CREATE TABLE rental
(
    rental_id varchar(40) Not Null,
    creation_time timestamp,
    modification_time timestamp,
    rental_common_id varchar(40),
    company_id varchar(40) Not Null,
    staff_id varchar(20) Not Null,
    property_type varchar(32) Not Null DEFAULT 1,
    building_name varchar(40) Not Null,
    rent decimal(15,0) Not Null,
    management_fee decimal(10,0) Not Null DEFAULT 0,
    maintenance_fee decimal(10,0) Not Null DEFAULT 0,
    security_deposit varchar(10) DEFAULT '-',
    key_money varchar(10) DEFAULT '-',
    guarantee_money varchar(10) DEFAULT '-',
    deposit_deduction varchar(10) DEFAULT '-',
    address varchar(40) Not Null,
    transportation1 varchar(40) Not Null,
    walking_distance1 smallint Not Null,
    transportation2 varchar(40),
    walking_distance2 smallint,
    transportation3 varchar(40),
    walking_distance3 smallint,
    layout_number smallint Not Null,
    layout_type varchar(32) Not Null,
    layout_details varchar(40),
    exclusive_area decimal(5) Not Null,
    balcony_area decimal(5),
    new_construction boolean Not Null DEFAULT False,
    built_year_month date Not Null,
    floor_number varchar(10) Not Null,
    total_floors varchar(20) Not Null,
    main_light_direction varchar(10) Not Null,
    building_type varchar(20) Not Null,
    building_structure varchar(40),
    energy_efficiency varchar(20),
    insulation_performance varchar(20),
    estimated_utility_cost varchar(20),
    insurance varchar(40),
    parking varchar(40) DEFAULT '-',
    current_condition varchar(20),
    available_from varchar(20),
    transaction_type varchar(10),
    key_type varchar(20),
    rental_conditions varchar(255),
    shop_company_name varchar(40) Not Null,
    shop_company_id varchar(40) Not Null,
    management_system_id varchar(40) Not Null,
    total_units varchar(20),
    published_date date,
    updated_date date,
    next_update_date varchar(20),
    contract_period varchar(20),
    renewal_fee varchar(40),
    guarantor_company varchar(255),
    other_initial_costs varchar(255),
    other_additional_costs varchar(255),
    exterior_photo varchar(255),
    layout_image varchar(255),
    remarks text,
    free_keyword text,
    effective_start_date date,
    effective_end_date date,
    PRIMARY KEY (rental_id)
);

COMMENT ON TABLE rental IS '賃貸物件';
COMMENT ON COLUMN rental.rental_id IS '賃貸物件ID';
COMMENT ON COLUMN rental.creation_time IS '作成日時';
COMMENT ON COLUMN rental.modification_time IS '変更日時';
COMMENT ON COLUMN rental.rental_common_id IS '賃貸物件共通ID';
COMMENT ON COLUMN rental.company_id IS '会社ID';
COMMENT ON COLUMN rental.staff_id IS '担当社員ID';
COMMENT ON COLUMN rental.property_type IS '物件タイプ';
COMMENT ON COLUMN rental.building_name IS '建物名';
COMMENT ON COLUMN rental.rent IS '賃料';
COMMENT ON COLUMN rental.management_fee IS '管理費等';
COMMENT ON COLUMN rental.maintenance_fee IS '維持費等';
COMMENT ON COLUMN rental.security_deposit IS '敷金';
COMMENT ON COLUMN rental.key_money IS '礼金';
COMMENT ON COLUMN rental.guarantee_money IS '保証金';
COMMENT ON COLUMN rental.deposit_deduction IS '敷引・償却金';
COMMENT ON COLUMN rental.address IS '所在地';
COMMENT ON COLUMN rental.transportation1 IS '交通1';
COMMENT ON COLUMN rental.walking_distance1 IS '徒歩距離1';
COMMENT ON COLUMN rental.transportation2 IS '交通2';
COMMENT ON COLUMN rental.walking_distance2 IS '徒歩距離2';
COMMENT ON COLUMN rental.transportation3 IS '交通3';
COMMENT ON COLUMN rental.walking_distance3 IS '徒歩距離3';
COMMENT ON COLUMN rental.layout_number IS '間取り（番号）';
COMMENT ON COLUMN rental.layout_type IS '間取り（タイプ）';
COMMENT ON COLUMN rental.layout_details IS '間取り（詳細）';
COMMENT ON COLUMN rental.exclusive_area IS '専有面積';
COMMENT ON COLUMN rental.balcony_area IS 'バルコニー面積';
COMMENT ON COLUMN rental.new_construction IS '新築';
COMMENT ON COLUMN rental.built_year_month IS '築年月';
COMMENT ON COLUMN rental.floor_number IS '所在階';
COMMENT ON COLUMN rental.total_floors IS '階建';
COMMENT ON COLUMN rental.main_light_direction IS '主要採光面';
COMMENT ON COLUMN rental.building_type IS '建物種類';
COMMENT ON COLUMN rental.building_structure IS '建物構造・工法';
COMMENT ON COLUMN rental.energy_efficiency IS 'エネルギー消費性能';
COMMENT ON COLUMN rental.insulation_performance IS '断熱性能';
COMMENT ON COLUMN rental.estimated_utility_cost IS '目安光熱費';
COMMENT ON COLUMN rental.insurance IS '保険等';
COMMENT ON COLUMN rental.parking IS '駐車場';
COMMENT ON COLUMN rental.current_condition IS '現況';
COMMENT ON COLUMN rental.available_from IS '入居可能時期';
COMMENT ON COLUMN rental.transaction_type IS '取引態様';
COMMENT ON COLUMN rental.key_type IS '鍵タイプ';
COMMENT ON COLUMN rental.rental_conditions IS '条件等';
COMMENT ON COLUMN rental.shop_company_name IS '店舗・会社名';
COMMENT ON COLUMN rental.shop_company_id IS '店舗・会社番号';
COMMENT ON COLUMN rental.management_system_id IS '管理システム番号';
COMMENT ON COLUMN rental.total_units IS '総戸数';
COMMENT ON COLUMN rental.published_date IS '情報公開日';
COMMENT ON COLUMN rental.updated_date IS '情報更新日';
COMMENT ON COLUMN rental.next_update_date IS '次回更新予定日';
COMMENT ON COLUMN rental.contract_period IS '契約期間';
COMMENT ON COLUMN rental.renewal_fee IS '更新料';
COMMENT ON COLUMN rental.guarantor_company IS '保証会社';
COMMENT ON COLUMN rental.other_initial_costs IS 'その他初期費用';
COMMENT ON COLUMN rental.other_additional_costs IS 'その他諸費用';
COMMENT ON COLUMN rental.exterior_photo IS '建物外観画像';
COMMENT ON COLUMN rental.layout_image IS '間取り図面';
COMMENT ON COLUMN rental.remarks IS '備考';
COMMENT ON COLUMN rental.free_keyword IS 'フリーキーワード';
COMMENT ON COLUMN rental_summary.creation_time IS '有効開始日';
COMMENT ON COLUMN rental_summary.modification_time IS '有効終了日';