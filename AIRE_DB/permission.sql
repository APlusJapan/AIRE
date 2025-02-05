CREATE TABLE permission
(
    role_id varchar(20) Not Null,
    action_id varchar(20) Not Null,
    level smallint Not Null,
    PRIMARY KEY (role_id, action_id)
);

COMMENT ON TABLE permission IS '権限';
COMMENT ON COLUMN permission.role_id IS 'ロールID';
COMMENT ON COLUMN permission.action_id IS 'アクションID';
COMMENT ON COLUMN permission.level IS '権限レベル';