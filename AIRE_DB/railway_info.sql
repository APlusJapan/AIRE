CREATE TABLE railway_info
(
    railway_name varchar(20) Not Null,
    railway_company varchar(20) Not Null,
    prefecture_id char(5) Not Null,
    PRIMARY KEY (railway_name, railway_company, prefecture_id)
);

COMMENT ON TABLE railway_info IS '鉄道情報';
COMMENT ON COLUMN railway_info.railway_name IS '路線名';
COMMENT ON COLUMN railway_info.railway_company IS '運営会社';
COMMENT ON COLUMN railway_info.prefecture_id IS '都道府県ID';