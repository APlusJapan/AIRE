CREATE TABLE operation_log
(
    device_unique_id char(38) Not Null,
    operation_time timestamp Not Null,
    user_id varchar(20),
    type varchar(40) Not Null,
    title varchar(255) Not Null,
    content varchar(255),
    PRIMARY KEY (device_unique_id, operation_time)
);

COMMENT ON TABLE operation_log IS '操作ログ';
COMMENT ON COLUMN operation_log.device_unique_id IS 'デバイス一意ID ';
COMMENT ON COLUMN operation_log.operation_time IS '操作時間 ';
COMMENT ON COLUMN operation_log.user_id IS 'ユーザーID ';
COMMENT ON COLUMN operation_log.type IS 'ログタイプ ';
COMMENT ON COLUMN operation_log.title IS 'ログタイトル ';
COMMENT ON COLUMN operation_log.content IS 'ログ内容';