CREATE TABLE code_master
(
    code_type varchar(32) Not Null,
    code_name varchar(32),
    option_value varchar(32) Not Null,
    creation_time timestamp,
    modification_time timestamp,
    option_name varchar(32),
    note varchar(255),
    PRIMARY KEY (code_type, option_value)
);

COMMENT ON TABLE code_master IS 'コードマスタ';
COMMENT ON COLUMN code_master.code_type IS 'コードタイプ';
COMMENT ON COLUMN code_master.code_name IS 'コード名';
COMMENT ON COLUMN code_master.option_value IS 'オプション値';
COMMENT ON COLUMN code_master.creation_time IS '作成日時';
COMMENT ON COLUMN code_master.modification_time IS '変更日時';
COMMENT ON COLUMN code_master.option_name IS 'オプション名';
COMMENT ON COLUMN code_master.note IS '備考';

INSERT INTO code_master(code_type, code_name, option_value, option_name, note) VALUES
    ('property_type', '物件タイプ', '0', '全物件', ''),
    ('property_type', '物件タイプ', '1', '全賃貸', ''),
    ('property_type', '物件タイプ', '11', '賃貸居住用', ''),
    ('property_type', '物件タイプ', '12', '賃貸事業用', ''),
    ('property_type', '物件タイプ', '2', '全売買', ''),
    ('property_type', '物件タイプ', '21', '売買マンション', ''),
    ('property_type', '物件タイプ', '22', '売買一戸建て', ''),
    ('property_type', '物件タイプ', '23', '売買土地', ''),
    ('property_type', '物件タイプ', '24', '売買事業用', ''),
    ('madotaipu', 'タイプ（間取り）', '0', 'ワンルーム', ''),
    ('madotaipu', 'タイプ（間取り）', '1', 'Ｋ', ''),
    ('madotaipu', 'タイプ（間取り）', '3', 'ＤＫ', ''),
    ('madotaipu', 'タイプ（間取り）', '5', 'ＬＫ', ''),
    ('madotaipu', 'タイプ（間取り）', '7', 'ＬＤＫ', ''),
    ('madotaipu', 'タイプ（間取り）', '9', 'ＳＫ', ''),
    ('madotaipu', 'タイプ（間取り）', '11', 'ＳＤＫ', ''),
    ('madotaipu', 'タイプ（間取り）', '13', 'ＳＬＫ', ''),
    ('madotaipu', 'タイプ（間取り）', '15', 'ＳＬＤＫ', '');