-- Create Users Table
CREATE TABLE users (
    user_id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    phone VARCHAR(20),
    passport_number VARCHAR(50) NOT NULL UNIQUE,
    address_line1 VARCHAR(100) NOT NULL,
    address_line2 VARCHAR(100),
    city VARCHAR(50) NOT NULL,
    postcode VARCHAR(20) NOT NULL,
    country VARCHAR(50) DEFAULT 'United Kingdom' NOT NULL
);

-- Create Personal Accounts Table
CREATE TABLE personal_accounts (
    account_id SERIAL PRIMARY KEY,
    user_id INT REFERENCES users(user_id),
    account_balance DECIMAL(15, 2) NOT NULL,
    account_number VARCHAR(20) NOT NULL UNIQUE,
    account_sort_code VARCHAR(20) NOT NULL,
    overdraft BOOLEAN DEFAULT FALSE,
    created_at TIMESTAMP WITHOUT TIME ZONE DEFAULT NOW()
);

-- Create ISA Accounts Table
CREATE TABLE isa_accounts (
    account_id SERIAL PRIMARY KEY,
    user_id INT REFERENCES users(user_id),
    account_balance DECIMAL(15, 2) NOT NULL,
    account_number VARCHAR(20) NOT NULL UNIQUE,
    account_sort_code VARCHAR(20) NOT NULL,
    annual_apr DECIMAL(5, 2) DEFAULT 2.75,
    created_at TIMESTAMP WITHOUT TIME ZONE DEFAULT NOW()
);

-- Create Business Accounts Table
CREATE TABLE business_accounts (
    account_id SERIAL PRIMARY KEY,
    user_id INT REFERENCES users(user_id),
    business_name VARCHAR(100) NOT NULL,
    account_balance DECIMAL(15, 2) NOT NULL,
    account_number VARCHAR(20) NOT NULL UNIQUE,
    account_sort_code VARCHAR(20) NOT NULL,
    has_cheque_book BOOLEAN DEFAULT FALSE,
    annual_charge DECIMAL(15, 2) DEFAULT 120.00,
    created_at TIMESTAMP WITHOUT TIME ZONE DEFAULT NOW()
);

-- Create Tellers Table
CREATE TABLE tellers (
    teller_id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    phone VARCHAR(20),
    branch VARCHAR(100) NOT NULL,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL, -- Passwords are hashed using bcrypt or salt dependant on time
    created_at TIMESTAMP WITHOUT TIME ZONE DEFAULT NOW()
);

CREATE TABLE transactions (
    transaction_id SERIAL PRIMARY KEY,
    personal_account_id INT,
    isa_account_id INT,
    business_account_id INT,
    transaction_date TIMESTAMP WITHOUT TIME ZONE DEFAULT NOW(),
    amount DECIMAL(15, 2) NOT NULL,
    transaction_type VARCHAR(50) NOT NULL,
    description TEXT,
    FOREIGN KEY (personal_account_id) REFERENCES personal_accounts(account_id) ON DELETE SET NULL,
    FOREIGN KEY (isa_account_id) REFERENCES isa_accounts(account_id) ON DELETE SET NULL,
    FOREIGN KEY (business_account_id) REFERENCES business_accounts(account_id) ON DELETE SET NULL
);

-- Create SecurityQA Table
CREATE TABLE SecurityQA (
    id SERIAL PRIMARY KEY,
    user_id INT REFERENCES users(user_id),
    question VARCHAR(255) NOT NULL,
    answer VARCHAR(255) NOT NULL,
    UNIQUE (user_id, question),
    CHECK (LENGTH(answer) >= 3)
);