CREATE TABLE rental_statistic
(
    statistic_id varchar(6) Not Null,
    update_time timestamp Not Null,
    property_count bigint,
    PRIMARY KEY (statistic_id)
);

COMMENT ON TABLE rental_statistic IS '賃貸物件統計';
COMMENT ON COLUMN rental_statistic.statistic_id IS '統計ID';
COMMENT ON COLUMN rental_statistic.update_time IS '更新時間';
COMMENT ON COLUMN rental_statistic.property_count IS '物件数';