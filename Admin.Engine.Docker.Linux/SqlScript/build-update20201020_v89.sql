
    alter table Answers 
        add Updated DATETIME2
    alter table Questions 
        add CreatedBy INT
    alter table Questions 
        add CreatedDate DATETIME2
    alter table Questions 
        add Updated DATETIME2