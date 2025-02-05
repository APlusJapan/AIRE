CREATE TABLE general_user
(
    user_id varchar (20) Not Null,
    user_name varchar (40),
    PRIMARY KEY (user_id)
);

COMMENT ON TABLE general_user IS '一般ユーザー';
COMMENT ON COLUMN general_user.user_id IS 'ユーザーID';
COMMENT ON COLUMN general_user.user_name IS 'ユーザー名';