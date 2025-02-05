CREATE TABLE railway
(
    railway_id char(5) Not Null,
    railway_name varchar(20) Not Null,
    railway_company varchar(20) Not Null,
    PRIMARY KEY (railway_id)
);

COMMENT ON TABLE railway IS '路線';
COMMENT ON COLUMN railway.railway_id IS '路線ID';
COMMENT ON COLUMN railway.railway_name IS '路線名';
COMMENT ON COLUMN railway.railway_company IS '鉄道会社';