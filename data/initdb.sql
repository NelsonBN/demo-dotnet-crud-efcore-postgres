CREATE TABLE "Product" (
  "Id" SERIAL PRIMARY KEY,
  "Name" varchar(50) NOT NULL,
  "Price" numeric(10, 2) NOT NULL);


INSERT INTO "Product" ("Name", "Price") VALUES
    ('Motherboard', 79.78),
    ('Keyboard', 54.97),
    ('Mouse', 23.78),
    ('Disk', 97.89);
