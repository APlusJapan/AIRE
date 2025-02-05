CREATE TABLE property_fee
(
    property_id varchar(40) Not Null,
    fee_id smallint Not Null,
    property_type varchar(32) Not Null,
    sonotakinnai varchar(20) Not Null,
    sonotakinkbn varchar(32) DEFAULT 0,
    sonotakin decimal(10, 2) Not Null,
    sonotakinkikankbn varchar(32) DEFAULT 0,
    sonotakinhiwarikbn boolean Not Null DEFAULT FALSE,
    sonotakinjikikbn varchar(32) DEFAULT 0,
    PRIMARY KEY (property_id, fee_id, property_type)
);

COMMENT ON TABLE property_fee IS '掲載物件費用';
COMMENT ON COLUMN property_fee.property_id IS '物件ID';
COMMENT ON COLUMN property_fee.fee_id IS '費用ID';
COMMENT ON COLUMN property_fee.property_type IS '物件タイプ';
COMMENT ON COLUMN property_fee.sonotakinnai IS '名目';
COMMENT ON COLUMN property_fee.sonotakinkbn IS '区分';
COMMENT ON COLUMN property_fee.sonotakin IS '金額';
COMMENT ON COLUMN property_fee.sonotakinkikankbn IS '単位';
COMMENT ON COLUMN property_fee.sonotakinhiwarikbn IS '日割';
COMMENT ON COLUMN property_fee.sonotakinjikikbn IS '時期';