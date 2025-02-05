CREATE TABLE company_group
(
    company_id varchar(40) Not Null,
    company_name varchar(40) Not Null,
    company_overview varchar(255),
    PRIMARY KEY (company_id)
);

COMMENT ON TABLE company_group IS '会社グループ';
COMMENT ON COLUMN company_group.company_id IS '会社ID';
COMMENT ON COLUMN company_group.company_name IS '会社名';
COMMENT ON COLUMN company_group.company_overview IS '会社概要';