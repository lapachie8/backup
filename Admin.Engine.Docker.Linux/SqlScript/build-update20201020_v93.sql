
    create table Answers (
        Id INT IDENTITY NOT NULL,
       Title NVARCHAR(50) not null,
       Answer NVARCHAR(255) not null,
       AnswerBy NVARCHAR(255) not null,
       Helpful INT default 0  not null,
       NotHelpful INT default 0  not null,
       Comment NVARCHAR(255) not null,
       Updated DATETIME2 not null,
       AnswerDate DATETIME2 not null,
       AnswerType INT default 1  not null,
       IsAnswer BIT default 0  not null,
       question_id INT null,
       primary key (Id)
    )
    create table Questions (
        Id INT IDENTITY NOT NULL,
       Title NVARCHAR(100) not null,
       Category NVARCHAR(25) not null,
       Question NVARCHAR(255) not null,
       CreatedBy INT not null,
       CreatedDate DATETIME2 not null,
       Updated DATETIME2 not null,
       IsAnswered BIT default 0  not null,
       primary key (Id)
    )
    alter table Answers 
        add constraint fk_question_id 
        foreign key (question_id) 
        references Questions
    alter table Answers 
        add constraint fk_question_id 
        foreign key (id) 
        references Questions