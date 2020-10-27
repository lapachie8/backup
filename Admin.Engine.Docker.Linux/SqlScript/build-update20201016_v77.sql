
    create table Answers (
        Id UNIQUEIDENTIFIER not null,
       Title NVARCHAR(50) not null,
       Answer NVARCHAR(255) not null,
       AnswerStatus INT default 1  not null,
       Helpful INT default 0  not null,
       NotHelpful INT default 0  not null,
       question_id UNIQUEIDENTIFIER null,
       primary key (Id)
    )
    create table Questions (
        Id UNIQUEIDENTIFIER not null,
       Title NVARCHAR(100) not null,
       Category NVARCHAR(25) not null,
       Question NVARCHAR(255) not null,
       QuestionStatus INT default 1  not null,
       QuestionDate DATETIME2 not null,
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