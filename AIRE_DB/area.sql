CREATE TABLE area
(
    area_id char(5) Not Null,
    creation_time timestamp,
    modification_time timestamp,
    prefecture_id char(5) Not Null,
    area_name varchar(20) Not Null,
    parent_area_id char(5),
    revised_area_id char(5),
    PRIMARY KEY (area_id)
);

COMMENT ON TABLE area IS 'エリア';
COMMENT ON COLUMN area.area_id IS 'エリアID';
COMMENT ON COLUMN area.creation_time IS '作成日時';
COMMENT ON COLUMN area.modification_time IS '変更日時';
COMMENT ON COLUMN area.prefecture_id IS '都道府県ID';
COMMENT ON COLUMN area.area_name IS 'エリア名';
COMMENT ON COLUMN area.parent_area_id IS '親エリアID';
COMMENT ON COLUMN area.revised_area_id IS '改訂エリアID';