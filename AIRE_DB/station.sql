CREATE TABLE station
(
    station_id char(5) Not Null,
    railway_id char(5) Not Null,
    station_name varchar(20) Not Null,
    PRIMARY KEY (station_id)
);

COMMENT ON TABLE station IS '駅';
COMMENT ON COLUMN station.station_id IS '駅ID';
COMMENT ON COLUMN station.railway_id IS '路線ID';
COMMENT ON COLUMN station.station_name IS '駅名';