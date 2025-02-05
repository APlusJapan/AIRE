CREATE TABLE rental_browsing_history
(
    device_unique_id char(38) Not Null,
    operation_time timestamp Not Null,
    user_id varchar(20),
    logical_delete boolean Not Null DEFAULT FALSE,
    favorite boolean Not Null DEFAULT FALSE,
    rental_id varchar(40) Not Null,
    PRIMARY KEY (device_unique_id, operation_time)
);

COMMENT ON TABLE rental_browsing_history IS '賃貸物件閲覧履歴';
COMMENT ON COLUMN rental_browsing_history.device_unique_id IS 'デバイス一意ID';
COMMENT ON COLUMN rental_browsing_history.operation_time IS '操作時間';
COMMENT ON COLUMN rental_browsing_history.user_id IS 'ユーザーID';
COMMENT ON COLUMN rental_browsing_history.logical_delete IS '論理削除';
COMMENT ON COLUMN rental_browsing_history.favorite IS 'お気に入り';
COMMENT ON COLUMN rental_browsing_history.rental_id IS '物件ID';