CREATE TABLE rental_image
(
    rental_id varchar(40) Not Null,
    image_id smallint Not Null,
    creation_time timestamp,
    modification_time timestamp,
    image_uri varchar(255) Not Null,
    shuhenmei varchar(80),
    gpcaption_s varchar(40),
    shuhenkyori int,
    PRIMARY KEY (rental_id, image_id)
);

COMMENT ON TABLE rental_image IS '賃貸物件画像';
COMMENT ON COLUMN rental_image.rental_id IS '賃貸物件ID';
COMMENT ON COLUMN rental_image.image_id IS '画像ID';
COMMENT ON COLUMN rental_image.creation_time IS '作成日時';
COMMENT ON COLUMN rental_image.modification_time IS '変更日時';
COMMENT ON COLUMN rental_image.image_uri IS '画像URI';
COMMENT ON COLUMN rental_image.shuhenmei IS '施設名';
COMMENT ON COLUMN rental_image.gpcaption_s IS 'コメント';
COMMENT ON COLUMN rental_image.shuhenkyori IS '周辺施設まで';