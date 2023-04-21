-- Database: UrediDom

INSERT INTO public."productCategory"("categoryID", category, "valueCat")
VALUES
(1, 'Boja', 'Siva'),
(2, 'Boja', 'Plava'),
(3, 'Brend', 'Kai'),
(4, 'Brend', 'Qua'),
(5, 'Dizajn', 'Mermer'),
(6, 'Dizajn', 'Kamen');

INSERT INTO public."typeOfProduct" ("typeID", "typeName")
VALUES
(1, 'Plocice'),
(2, 'Ormani'),
(3, 'Laminat');

INSERT INTO public."productGroup" ("groupID")
VALUES
(1),
(2),
(3);

INSERT INTO public."product" ("productID", "productName", price, description, quantity, "typeID", "groupID")
VALUES
(1, 'ASTON Azul', 1500, 'ASTON AZUL 8300 1 33,3X33,3 PODNE PLOCICE', 20, 1, 1),
(2, 'LATINA Grey', 1450, 'LATINA Grey 25x40 ZIDNE PLOCICE', 40, 1, 2),
(3, 'Garderober ATLAS', 29990, 'Garderober ATLAS 165 OG, SIRINA 160, DUBINA 57, VISINA 206', 5, 2, 3);

INSERT INTO public."categoryProduct" ("categoryID", "productID")
VALUES
(2, 1),
(3, 1),
(5, 1),
(1, 2),
(3, 2),
(6, 2),
(1, 3);

INSERT INTO public."user" ("userID", "name", surname, username, email, "password", phone, birthday, role)
VALUES
(1, 'Petar', 'Petrovic', 'perica123', 'petarp@gmail.com', 'petar123', '0698234235', '1995-05-22', 'admin'),
(2, 'Sandra', 'Saric', 'Sandra123', 'sandra@gmail.com', 'sandra123', '0618233338', '1994-06-19', 'customer'),
(3, 'Marko', 'Markovic', 'markicmare', 'markovicm@gmail.com', 'marko2000', '065534235', '2000-10-10', 'repairman'),
(4, 'Sara', 'Susic', 'SaraSusic', 'susics@gmail.com', 'Sara1234', '0607274244', '1999-01-17', 'customer');

INSERT INTO public."admin" ("adminID")
VALUES
(1);

INSERT INTO public."customer" ("customerID", address)
VALUES
(2, 'Kraljevica Marka 5, NS'),
(4, 'Strazilovska 27, ZR');

INSERT INTO public."repairman" ("repairmanID", sector)
VALUES
(3, 'Keramicar');

INSERT INTO public."availability" ("repairmanID", unavailable)
VALUES
(3, '2023-01-12'),
(3, '2023-01-13'),
(3, '2023-01-14'),
(3, '2023-01-15');

INSERT INTO public."reservation" ("reservationID", "startDate", "endDate", "repairmanID")
VALUES 
(1, '2022-12-12', '2022-12-19', 3),
(2, '2022-11-25', '2022-11-30', 3);

INSERT INTO public."order" ("orderID", "dateOfOrder", amount, "customerID", "repairmanID")
VALUES
(1, '2022-12-05', 7500, 2, 3),
(2, '2022-11-20', 14500, 4, 3);

INSERT INTO public."discount" ("discountID", "discountProcent", "discountName", "discountDescription", "startDay", "startMonth", "endDay", "endMonth")
VALUES
(1, 10, 'Novogodisnji popust', 'Popust koji korisnici ostvaruju u vreme novogodisnjih praznika', 15, 12, 15, 01),
(2, 15, 'Crni novembar', 'Popust koji korisnici ostvaruju u novembru mesecu', 01, 11, 30, 11);

INSERT INTO public."productOrder" ("productID", "orderID", quantity, price)
VALUES
(1, 1, 5, 1500),
(2, 2, 10, 1450);
