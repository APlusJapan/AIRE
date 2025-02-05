CREATE TABLE role
(
    user_id varchar(20) Not Null,
    role_id varchar(20) Not Null,
    PRIMARY KEY (user_id, role_id)
);

COMMENT ON TABLE role IS '役割';
COMMENT ON COLUMN role.user_id IS 'ユーザーID';
COMMENT ON COLUMN role.role_id IS '役割ID';