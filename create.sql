CREATE DATABASE dentalclinic;

USE dentalclinic;

CREATE TABLE dentist(
	id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(25) NOT NULL,
    last_name VARCHAR(25) NOT NULL,
    description TEXT
);

CREATE TABLE patient(
	id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(25) NOT NULL,
    last_name VARCHAR(25) NOT NULL,
    age TINYINT UNSIGNED NOT NULL,
    birth_date DATE NOT NULL,
    dentist_id BIGINT UNSIGNED NOT NULL
);

CREATE TABLE appointment(
	id BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    patient_id BIGINT UNSIGNED NOT NULL,
    dentist_id BIGINT UNSIGNED NOT NULL,
    scheduled_for DATETIME NOT NULL,
    description TEXT
);


ALTER TABLE patient ADD CONSTRAINT fk_patient_dentist_id 
FOREIGN KEY (dentist_id) REFERENCES dentist(id) ON DELETE CASCADE;

ALTER TABLE appointment ADD CONSTRAINT fk_appointment_dentist_id
FOREIGN KEY (dentist_id) REFERENCES dentist(id) ON DELETE CASCADE;

ALTER TABLE appointment ADD CONSTRAINT fk_appointment_patient_id
FOREIGN KEY (patient_id) REFERENCES patient(id) ON DELETE CASCADE;

ALTER TABLE appointment ADD CONSTRAINT  unique_dentist_appointment
UNIQUE (dentist_id, scheduled_for);


