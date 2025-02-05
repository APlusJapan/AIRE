CREATE TABLE property_panorama
(
    property_id varchar(40) Not Null,
    panorama_id smallint Not Null,
    property_type varchar(32) Not Null,
    panorama_uri varchar(255) Not Null,
    panoramacategory varchar(32) DEFAULT 0,
    panoramacaption varchar(32) DEFAULT 0,
    PRIMARY KEY (property_id, panorama_id, property_type)
);

COMMENT ON TABLE property_panorama IS '掲載物件パノラマ';
COMMENT ON COLUMN property_panorama.property_id IS '物件ID';
COMMENT ON COLUMN property_panorama.panorama_id IS 'パノラマID';
COMMENT ON COLUMN property_panorama.property_type IS '物件タイプ';
COMMENT ON COLUMN property_panorama.panorama_uri IS 'パノラマURI';
COMMENT ON COLUMN property_panorama.panoramacategory IS 'カテゴリ';
COMMENT ON COLUMN property_panorama.panoramacaption IS 'カメラ種類';