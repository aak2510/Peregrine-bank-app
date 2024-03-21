-- Need to hash the passwords before inputting into the database
INSERT INTO tellers (name, email, phone, branch, username, password, created_at) VALUES
                                                                                     ('Ethan Clark', 'ethanclark@example.com', '555-0201', 'Central London', 'ethanclark', 'hashed_password', NOW()),
                                                                                     ('Olivia Brown', 'oliviabrown@example.com', '555-0202', 'Manchester Central', 'oliviabrown', 'hashed_password', NOW()),
                                                                                     ('Noah Wilson', 'noahwilson@example.com', '555-0203', 'Bristol East', 'noahwilson', 'hashed_password', NOW());