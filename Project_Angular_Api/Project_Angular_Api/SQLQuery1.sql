--Users
INSERT INTO AspNetUsers (
    Address,
    UserName,
    NormalizedUserName,
    Email,
    NormalizedEmail,
    EmailConfirmed,
    PasswordHash,
    SecurityStamp,
    ConcurrencyStamp,
    PhoneNumber,
    PhoneNumberConfirmed,
    TwoFactorEnabled,
    LockoutEnd,
    LockoutEnabled,
    AccessFailedCount
)
VALUES 
(
    '123 Main Street, Anytown, USA',
    'user1',
    'USER1',
    'user1@example.com',
    'USER1@EXAMPLE.COM',
    1,
    'password_hash_user1',
    'security_stamp_user1',
    'concurrency_stamp_user1',
    '1234567890',
    1,
    0,
    NULL,
    1,
    0
),
(
    '456 Elm Street, Othertown, USA',
    'user2',
    'USER2',
    'user2@example.com',
    'USER2@EXAMPLE.COM',
    1,
    'password_hash_user2',
    'security_stamp_user2',
    'concurrency_stamp_user2',
    '2345678901',
    1,
    0,
    NULL,
    1,
    0
),
(
    '789 Oak Street, Anycity, USA',
    'user3',
    'USER3',
    'user3@example.com',
    'USER3@EXAMPLE.COM',
    1,
    'password_hash_user3',
    'security_stamp_user3',
    'concurrency_stamp_user3',
    '3456789012',
    1,
    0,
    NULL,
    1,
    0
),
(
    '101 Pine Street, Anothertown, USA',
    'user4',
    'USER4',
    'user4@example.com',
    'USER4@EXAMPLE.COM',
    1,
    'password_hash_user4',
    'security_stamp_user4',
    'concurrency_stamp_user4',
    '4567890123',
    1,
    0,
    NULL,
    1,
    0
),
(
    '202 Cedar Street, Somewhere, USA',
    'user5',
    'USER5',
    'user5@example.com',
    'USER5@EXAMPLE.COM',
    1,
    'password_hash_user5',
    'security_stamp_user5',
    'concurrency_stamp_user5',
    '5678901234',
    1,
    0,
    NULL,
    1,
    0
);

-- Role

INSERT INTO AspNetRoles ( Name, NormalizedName, ConcurrencyStamp)
VALUES ( 'Admin', 'ADMIN', 'd5d8c0ff-6954-41d6-8a44-87f0b8a70234');

INSERT INTO AspNetRoles ( Name, NormalizedName, ConcurrencyStamp)
VALUES ( 'User', 'USER', 'e6797799-ff28-4d07-8b7e-cce87a0a2493');

--AspNetUserRoles
INSERT INTO AspNetUserRoles (UserId, RoleId)
VALUES (1, 1);

INSERT INTO AspNetUserRoles (UserId, RoleId)
VALUES (2, 2);


INSERT INTO AspNetUserRoles (UserId, RoleId)
VALUES (3 ,1);

INSERT INTO AspNetUserRoles (UserId, RoleId)
VALUES (4, 2);
INSERT INTO AspNetUserRoles (UserId, RoleId)
VALUES (5, 1);



insert into categories (Name) values ('Skirts');
insert into categories (Name) values ('Jeans');
insert into categories (Name) values ('Blous');
insert into categories (Name) values ('Trouthers');




insert into brands (Name) values ('Zara');
insert into brands (Name) values ('X&M');
insert into brands (Name) values ('H&M');
insert into brands (Name) values ('CoCo');








-- First INSERT statement
INSERT INTO clothes (Name, Image, Price, Qunatity, Description, categoryID, brandID) 
VALUES ('T-Shirt', 'tshirt.jpg', 20.99, 50, 'Comfortable cotton t-shirt', 1, 2);

-- Second INSERT statement
INSERT INTO clothes (Name, Image, Price, Qunatity, Description, categoryID, brandID) 
VALUES ('Jeans', 'jeans.jpg', 39.99, 30, 'Classic denim jeans', 2, 3);

-- Third INSERT statement
INSERT INTO clothes (Name, Image, Price, Qunatity, Description, categoryID, brandID) 
VALUES ('Dress', 'dress.jpg', 49.99, 20, 'Elegant evening dress', 3, 1);

-- Fourth INSERT statement
INSERT INTO clothes (Name, Image, Price, Qunatity, Description, categoryID, brandID) 
VALUES ('Hoodie', 'hoodie.jpg', 29.99, 40, 'Warm and cozy hoodie', 4, 4);

-- Fifth INSERT statement
INSERT INTO clothes (Name, Image, Price, Qunatity, Description, categoryID, brandID) 
VALUES ('Skirt', 'skirt.jpg', 25.99, 35, 'Flowy summer skirt', 1, 3);

-- Sixth INSERT statement
INSERT INTO clothes (Name, Image, Price, Qunatity, Description, categoryID, brandID) 
VALUES ('Shorts', 'shorts.jpg', 19.99, 45, 'Casual denim shorts', 2, 4);

-- Seventh INSERT statement
INSERT INTO clothes (Name, Image, Price, Qunatity, Description, categoryID, brandID) 
VALUES ('Blouse', 'blouse.jpg', 34.99, 25, 'Stylish silk blouse', 3, 2);

-- Eighth INSERT statement
INSERT INTO clothes (Name, Image, Price, Qunatity, Description, categoryID, brandID) 
VALUES ('Jacket', 'jacket.jpg', 59.99, 15, 'Waterproof outdoor jacket', 4, 1);

-- Ninth INSERT statement
INSERT INTO clothes (Name, Image, Price, Qunatity, Description, categoryID, brandID) 
VALUES ('Sweater', 'sweater.jpg', 44.99, 20, 'Soft knit sweater', 1, 4);

-- Tenth INSERT statement
INSERT INTO clothes (Name, Image, Price, Qunatity, Description, categoryID, brandID) 
VALUES ('Pants', 'pants.jpg', 35.99, 30, 'Formal trousers', 2, 1);



