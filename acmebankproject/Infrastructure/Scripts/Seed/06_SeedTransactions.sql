-- Personal account transactions
INSERT INTO transactions (personal_account_id, transaction_date, amount, transaction_type, description) VALUES
                                                                                                            (1, NOW(), -100.00, 'withdrawal', 'ATM withdrawal'),
                                                                                                            (1, NOW(), 200.00, 'deposit', 'Salary deposit');
-- ISA account transactions
INSERT INTO transactions (isa_account_id, transaction_date, amount, transaction_type, description) VALUES
    (2, NOW(), 500.00, 'deposit', 'Annual savings');

-- Business account transactions
INSERT INTO transactions (business_account_id, transaction_date, amount, transaction_type, description) VALUES
    (3, NOW(), -500.00, 'withdrawal', 'Operational expenses');