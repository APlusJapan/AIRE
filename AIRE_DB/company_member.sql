CREATE TABLE company_member
(
    company_id varchar(40) Not Null,
    staff_id varchar(20) Not Null,
    staff_name varchar(40),
    phone_number varchar(20),
    email varchar(40),
    line_id varchar(20) Not Null,
    route_id varchar(20),
    is_business boolean Not Null DEFAULT TRUE,
    PRIMARY KEY (company_id, staff_id)
);

COMMENT ON TABLE company_member IS '会社メンバー';
COMMENT ON COLUMN company_member.company_id IS '会社ID';
COMMENT ON COLUMN company_member.staff_id IS '社員ID';
COMMENT ON COLUMN company_member.staff_name IS '社員名';
COMMENT ON COLUMN company_member.phone_number IS '電話番号';
COMMENT ON COLUMN company_member.email IS 'Eメール';
COMMENT ON COLUMN company_member.line_id IS 'Line ID';
COMMENT ON COLUMN company_member.route_id IS '追加経路ID';
COMMENT ON COLUMN company_member.is_business IS 'ビジネスアカウント';