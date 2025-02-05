CREATE TABLE prefecture
(
    prefecture_id char(6) Not Null,
    prefecture_name varchar(10) Not Null,
    PRIMARY KEY (prefecture_id)
);

COMMENT ON TABLE prefecture IS '都道府県';
COMMENT ON COLUMN prefecture.prefecture_id IS '都道府県ID';
COMMENT ON COLUMN prefecture.prefecture_name IS '都道府県名';