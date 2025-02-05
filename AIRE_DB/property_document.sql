CREATE TABLE property_document
(
    property_id varchar(40) Not Null,
    document_id smallint Not Null,
    property_type varchar(32) Not Null,
    document_uri varchar(255) Not Null,
    siryoucaption varchar(80),
    PRIMARY KEY (property_id, document_id, property_type)
);

COMMENT ON TABLE property_document IS '掲載物件資料';
COMMENT ON COLUMN property_document.property_id IS '物件ID';
COMMENT ON COLUMN property_document.document_id IS '資料ID';
COMMENT ON COLUMN property_document.property_type IS '物件タイプ';
COMMENT ON COLUMN property_document.document_uri IS '資料URI';
COMMENT ON COLUMN property_document.siryoucaption IS 'コメント';