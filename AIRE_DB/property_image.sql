CREATE TABLE property_image
(
    property_id varchar(40) Not Null,
    image_id smallint Not Null,
    property_type varchar(32) Not Null,
    image_uri varchar(255) Not Null,
    gpcategory varchar(32) DEFAULT 0,
    shuhenmei varchar(80),
    gpcaption_s varchar(40),
    shuhenkyori int,
    PRIMARY KEY (property_id, image_id, property_type)
);

COMMENT ON TABLE property_image IS '掲載物件画像';
COMMENT ON COLUMN property_image.property_id IS '物件ID';
COMMENT ON COLUMN property_image.image_id IS '画像ID';
COMMENT ON COLUMN property_image.property_type IS '物件タイプ';
COMMENT ON COLUMN property_image.image_uri IS '画像URI';
COMMENT ON COLUMN property_image.gpcategory IS 'カテゴリ';
COMMENT ON COLUMN property_image.shuhenmei IS '施設名';
COMMENT ON COLUMN property_image.gpcaption_s IS 'コメント';
COMMENT ON COLUMN property_image.shuhenkyori IS '周辺施設まで';