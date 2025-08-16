CREATE TABLE station
(
    station_id char(6) Not Null,
    creation_time timestamp,
    modification_time timestamp,
    railway_name varchar(20) Not Null,
    railway_company varchar(20) Not Null,
    station_name varchar(20) Not Null,
    PRIMARY KEY (station_id)
);

COMMENT ON TABLE station IS '駅';
COMMENT ON COLUMN station.station_id IS '駅ID';
COMMENT ON COLUMN station.creation_time IS '作成日時';
COMMENT ON COLUMN station.modification_time IS '変更日時';
COMMENT ON COLUMN station.railway_name IS '路線名';
COMMENT ON COLUMN station.railway_company IS '運営会社';
COMMENT ON COLUMN station.station_name IS '駅名';