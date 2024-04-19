CREATE TABLE public.customer (
	id serial4 NOT NULL,
	address varchar(255) NULL,
	email varchar(100) NULL,
	"name" varchar(100) NULL,
	phone_number varchar(20) NULL,
	CONSTRAINT customer_pkey PRIMARY KEY (id)
);

INSERT INTO customer (address, email, name, phone_number) VALUES
    ('123 Main St', 'john@example.com', 'John Doe', '123-456-7890'),
    ('456 Elm St', 'jane@example.com', 'Jane Smith', '987-654-3210');