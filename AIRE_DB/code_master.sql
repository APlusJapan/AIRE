CREATE TABLE code_master
(
    code_type varchar(32) Not Null,
    code_name varchar(32),
    option_value varchar(32) Not Null,
    option_name varchar(32),
    note varchar(255),
    PRIMARY KEY (code_type, option_value)
);

COMMENT ON TABLE code_master IS 'コードマスタ';
COMMENT ON COLUMN code_master.code_type IS 'コードタイプ';
COMMENT ON COLUMN code_master.code_name IS 'コード名';
COMMENT ON COLUMN code_master.option_value IS 'オプション値';
COMMENT ON COLUMN code_master.option_name IS 'オプション名';
COMMENT ON COLUMN code_master.note IS '備考';