CREATE TABLE area
(
    area_id char(6) Not Null,
    prefecture_id char(6) Not Null,
    area_name varchar(10) Not Null,
    parent_area_id char(6),
    PRIMARY KEY (area_id)
);

COMMENT ON TABLE area IS 'エリア';
COMMENT ON COLUMN area.area_id IS 'エリアID';
COMMENT ON COLUMN area.prefecture_id IS '都道府県ID';
COMMENT ON COLUMN area.area_name IS 'エリア名';
COMMENT ON COLUMN area.parent_area_id IS '親エリアID';