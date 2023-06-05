-- Database: UrediDom

DROP TABLE IF EXISTS "productOrder";
DROP TABLE IF EXISTS "discount";
DROP TABLE IF EXISTS "order";
DROP TABLE IF EXISTS "reservation";
DROP TABLE IF EXISTS "availability";
DROP TABLE IF EXISTS "repairman";
DROP TABLE IF EXISTS "customer";
DROP TABLE IF EXISTS "admin";
DROP TABLE IF EXISTS "user";
DROP TABLE IF EXISTS "categoryProduct";
DROP TABLE IF EXISTS "product";
DROP TABLE IF EXISTS "productGroup";
DROP TABLE IF EXISTS "typeOfProduct";
DROP TABLE IF EXISTS "productCategory";

CREATE TABLE public."productCategory" 
(
    "categoryID" serial NOT NULL,
    "category" varchar(15) NOT NULL,
    "valueCat" varchar(20) NOT NULL,
	PRIMARY KEY ("categoryID")
);

CREATE TABLE public."typeOfProduct"
(
	"typeID" serial NOT NULL,
	"typeName" varchar(15) NOT NULL,
	PRIMARY KEY ("typeID")
);

CREATE TABLE public."productGroup"
(
	"groupID" serial NOT NULL,
	PRIMARY KEY ("groupID")
);

CREATE TABLE public."product"
(
	"productID" serial NOT NULL,
	"productName" varchar(50) NOT NULL,
	"price" float4 NOT NULL,
	"description" text,
	"quantity" integer NOT NULL,
	"typeID" integer NOT NULL,
	"groupID" integer,
	"imgSrc" text,
	PRIMARY KEY ("productID"),
	CONSTRAINT "FK_typeID" FOREIGN KEY ("typeID")
		REFERENCES public."typeOfProduct" ("typeID"),
	CONSTRAINT "FK_groupID" FOREIGN KEY ("groupID")
		REFERENCES public."productGroup" ("groupID")
);

CREATE TABLE public."categoryProduct"
(
	"categoryID" serial NOT NULL,
	"productID" integer NOT NULL,
	CONSTRAINT "FK_categoryID" FOREIGN KEY ("categoryID")
		REFERENCES public."productCategory" ("categoryID"),
	CONSTRAINT "FK_product" FOREIGN KEY ("productID")
		REFERENCES public."product" ("productID")
);

CREATE TABLE public."user"
(
	"userID" serial NOT NULL,
	"name" varchar(15) NOT NULL,
	"surname" varchar(20) NOT NULL,
	"username" varchar(35) NOT NULL,
	"email" varchar(40) NOT NULL,
	"password" varchar(50) NOT NULL,
	"phone" varchar(10) NOT NULL,
	"birthday" date NOT NULL,
	"role" varchar(10) NOT NULL,
	PRIMARY KEY ("userID")
);

CREATE TABLE public."admin"
(
	"adminID" integer NOT NULL,
	PRIMARY KEY ("adminID"),
	CONSTRAINT "FK_adminID" FOREIGN KEY ("adminID")
		REFERENCES public."user" ("userID")
);

CREATE TABLE public."customer"
(
	"customerID" integer NOT NULL,
	"address" varchar(50) NOT NULL,
	PRIMARY KEY ("customerID"),
	CONSTRAINT "FK_customerID" FOREIGN KEY ("customerID")
		REFERENCES public."user" ("userID")
);

CREATE TABLE public."repairman"
(
	"repairmanID" integer NOT NULL,
	"sector" varchar(20) NOT NULL,
	PRIMARY KEY ("repairmanID"),
	CONSTRAINT "FK_repairmanID" FOREIGN KEY ("repairmanID")
		REFERENCES public."user" ("userID")
);

CREATE TABLE public."availability"
(
	"repairmanID" integer NOT NULL,
	"unavailable" date NOT NULL
);

CREATE TABLE public."reservation"
(
	"reservationID" serial NOT NULL,
	"startDate" date NOT NULL,
	"endDate" date NOT NULL,
	"repairmanID" integer NOT NULL,
	PRIMARY KEY ("reservationID"),
	CONSTRAINT "FK_repairmanIDRes" FOREIGN KEY ("repairmanID")
		REFERENCES public."repairman" ("repairmanID")
);

CREATE TABLE public."order"
(
	"orderID" serial NOT NULL,
	"dateOfOrder" date NOT NULL,
	"amount" float4 NOT NULL,
	"customerID" integer,
	"repairmanID" integer,
	"intent" text,
	PRIMARY KEY ("orderID"),
	CONSTRAINT "FK_customerOrder" FOREIGN KEY ("customerID")
		REFERENCES public."user" ("userID"),
	CONSTRAINT "FK_repairmanOrder" FOREIGN KEY ("repairmanID")
		REFERENCES public."repairman" ("repairmanID")
);

CREATE TABLE public."discount"
(
	"discountID" serial NOT NULL,
	"discountProcent" integer NOT NULL,
	"discountName" varchar(50) NOT NULL,
	"discountDescription" text,
	"startDay" integer NOT NULL,
	"startMonth" integer NOT NULL,
	"endDay" integer NOT NULL,
	"endMonth" integer NOT NULL,
	PRIMARY KEY ("discountID")
);

CREATE TABLE public."productOrder"
(
	"productOrderID" serial NOT NULL,
	"productID" serial NOT NULL,
	"orderID" integer NOT NULL,
	"quantity" integer NOT NULL,
	"price" float4 NOT NULL,
	"discountID" integer,
	PRIMARY KEY ("productOrderID"),
	CONSTRAINT "FK_productID" FOREIGN KEY ("productID")
		REFERENCES public."product" ("productID"),
	CONSTRAINT "FK_orderID" FOREIGN KEY ("orderID")
		REFERENCES public."order" ("orderID"),
	CONSTRAINT "FK_discountID" FOREIGN KEY ("discountID")
		REFERENCES public."discount" ("discountID")
);

CREATE OR REPLACE FUNCTION checkGroup() RETURNS trigger AS $$
	DECLARE
	left_groups integer;
	BEGIN
		SELECT COUNT("groupID") 
		FROM public."product"
		INTO left_groups
		WHERE product."groupID" = OLD."groupID";
				
		IF left_groups = 0 THEN
			DELETE FROM public."productGroup" WHERE "productGroup"."groupID" = OLD."groupID";
		END IF;
		RETURN OLD;
	END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE TRIGGER removeUnusedGroup AFTER UPDATE
	ON public."product"
	FOR EACH ROW
	EXECUTE PROCEDURE checkGroup();

CREATE OR REPLACE FUNCTION checkQuantity() RETURNS trigger AS $$
	DECLARE
	BEGIN
		UPDATE public."product"
		SET quantity = quantity - NEW."quantity"
		WHERE "productID" = NEW."productID";
		RETURN NEW;
	END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE TRIGGER updateQuantity AFTER INSERT
	ON public."productOrder"
	FOR EACH ROW
	EXECUTE PROCEDURE checkQuantity();

	
