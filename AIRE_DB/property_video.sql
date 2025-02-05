CREATE TABLE property_video
(
    property_id varchar(40) Not Null,
    video_id smallint Not Null,
    property_type varchar(32) Not Null,
    video_uri varchar(255) Not Null,
    dougaf_name varchar(255),
    dougaf_caption varchar(255),
    PRIMARY KEY (property_id, video_id, property_type)
);

COMMENT ON TABLE property_video IS '掲載物件動画';
COMMENT ON COLUMN property_video.property_id IS '物件ID';
COMMENT ON COLUMN property_video.video_id IS '動画ID';
COMMENT ON COLUMN property_video.property_type IS '物件タイプ';
COMMENT ON COLUMN property_video.video_uri IS '動画URI';
COMMENT ON COLUMN property_video.dougaf_name IS '動画名';
COMMENT ON COLUMN property_video.dougaf_caption IS 'キャプション';