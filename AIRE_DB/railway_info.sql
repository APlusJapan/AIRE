CREATE TABLE railway_info
(
    railway_name varchar(20) Not Null,
    railway_company varchar(20) Not Null,
    prefecture_id char(5) Not Null,
    creation_time timestamp,
    modification_time timestamp,
    PRIMARY KEY (railway_name, railway_company, prefecture_id)
);

COMMENT ON TABLE railway_info IS '鉄道情報';
COMMENT ON COLUMN railway_info.railway_name IS '路線名';
COMMENT ON COLUMN railway_info.railway_company IS '運営会社';
COMMENT ON COLUMN railway_info.prefecture_id IS '都道府県ID';
COMMENT ON COLUMN railway_info.creation_time IS '作成日時';
COMMENT ON COLUMN railway_info.modification_time IS '変更日時';