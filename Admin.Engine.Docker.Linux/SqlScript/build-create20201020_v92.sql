
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[fk_question_id]') and parent_object_id = OBJECT_ID(N'Answers'))
alter table Answers  drop constraint fk_question_id


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[fk_question_id]') and parent_object_id = OBJECT_ID(N'Answers'))
alter table Answers  drop constraint fk_question_id


    if exists (select * from dbo.sysobjects where id = object_id(N'Answers') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Answers

    if exists (select * from dbo.sysobjects where id = object_id(N'Questions') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Questions

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
