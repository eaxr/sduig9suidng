\connect test_db

CREATE TABLE clclients
(
    id INT GENERATED ALWAYS AS IDENTITY,
    firstName VARCHAR (60) NOT NULL,
    lastname VARCHAR (60) NOT NULL,
    PRIMARY KEY(id)
);

CREATE TABLE clveterinarians
(
    id INT GENERATED ALWAYS AS IDENTITY,
    firstName VARCHAR (60) NOT NULL,
    lastname VARCHAR (60) NOT NULL,
    PRIMARY KEY(id)
);

CREATE TABLE clvaccinations
(
    id INT GENERATED ALWAYS AS IDENTITY,
    title VARCHAR (80) NOT NULL,
    PRIMARY KEY(id)
);

CREATE TABLE clservices
(
    id INT GENERATED ALWAYS AS IDENTITY,
    title VARCHAR (80) NOT NULL,
    PRIMARY KEY(id),
    "VeterinarianId" INT,
    CONSTRAINT fk_veterinarian
        FOREIGN KEY ("VeterinarianId")
            REFERENCES clveterinarians(id)
);

CREATE TABLE clpets
(
    id INT GENERATED ALWAYS AS IDENTITY,
    name VARCHAR (60) NOT NULL,
    "ClientId" INT,
    PRIMARY KEY(id),
    CONSTRAINT fk_client
        FOREIGN KEY ("ClientId")
            REFERENCES clclients(id)
);

CREATE TABLE clvaccinationlist
(
    id INT GENERATED ALWAYS AS IDENTITY,
    PRIMARY KEY(id),
    "PetId" INT,
    CONSTRAINT fk_pet
        FOREIGN KEY ("PetId")
            REFERENCES clpets(id),
    "VaccinationId" INT,
    CONSTRAINT fk_vaccination
        FOREIGN KEY ("VaccinationId")
            REFERENCES clvaccinations(id)
);

ALTER TABLE "clveterinarians" OWNER TO test_user;
ALTER TABLE "clservices" OWNER TO test_user;
ALTER TABLE "clvaccinations" OWNER TO test_user;
ALTER TABLE "clpets" OWNER TO test_user;
ALTER TABLE "clvaccinationlist" OWNER TO test_user;
ALTER TABLE "clclients" OWNER TO test_user;

Insert into clclients( firstname, lastname ) values( 'Имя 1', 'Фамилия 1' );
Insert into clclients( firstname, lastname ) values( 'Имя 2', 'Фамилия 2' );
Insert into clclients( firstname, lastname ) values( 'Имя 3', 'Фамилия 3' );

Insert into clpets( name, "ClientId" ) values( 'Животное 1', '1' );
Insert into clpets( name, "ClientId" ) values( 'Животное 2', '1' );
Insert into clpets( name, "ClientId" ) values( 'Животное 3', '2' );
Insert into clpets( name, "ClientId" ) values( 'Животное 4', '3' );
Insert into clpets( name, "ClientId" ) values( 'Животное 5', '3' );

Insert into clveterinarians( firstname, lastname ) values( 'Имя 1', 'Фамилия 1' );
Insert into clveterinarians( firstname, lastname ) values( 'Имя 2', 'Фамилия 2' );
Insert into clveterinarians( firstname, lastname ) values( 'Имя 3', 'Фамилия 3' );

Insert into clservices( title, "VeterinarianId" ) values( 'Услуга 1', '1' );
Insert into clservices( title, "VeterinarianId" ) values( 'Услуга 2', '2' );
Insert into clservices( title, "VeterinarianId" ) values( 'Услуга 3', '3' );

Insert into clvaccinations( title ) values( 'Прививка 1' );
Insert into clvaccinations( title ) values( 'Прививка 2' );
Insert into clvaccinations( title ) values( 'Прививка 3' );

Insert into clvaccinationlist( "PetId", "VaccinationId" ) values( '1', '1');
Insert into clvaccinationlist( "PetId", "VaccinationId" ) values( '1', '2');
Insert into clvaccinationlist( "PetId", "VaccinationId" ) values( '2', '2');
Insert into clvaccinationlist( "PetId", "VaccinationId" ) values( '3', '1');
Insert into clvaccinationlist( "PetId", "VaccinationId" ) values( '3', '3');
Insert into clvaccinationlist( "PetId", "VaccinationId" ) values( '4', '2');
Insert into clvaccinationlist( "PetId", "VaccinationId" ) values( '5', '2');