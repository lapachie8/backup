
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[student_id]') and parent_object_id = OBJECT_ID(N'mapel'))
alter table mapel  drop constraint student_id


    if exists (select * from dbo.sysobjects where id = object_id(N'mapel') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table mapel

    if exists (select * from dbo.sysobjects where id = object_id(N'student') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table student

    if exists (select * from dbo.sysobjects where id = object_id(N'teacher') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table teacher

    create table mapel (
        Id INT IDENTITY NOT NULL,
       timestamp DATETIME2 null,
       actor NVARCHAR(255) null,
       studentId INT not null,
       pai DECIMAL(19,5) default 0  not null,
       ipa DECIMAL(19,5) default 0  not null,
       ips DECIMAL(19,5) default 0  not null,
       mtk DECIMAL(19,5) default 0  not null,
       pkn DECIMAL(19,5) default 0  not null,
       bindo DECIMAL(19,5) default 0  not null,
       binggris DECIMAL(19,5) default 0  not null,
       student_id INT not null,
       primary key (Id)
    )

    create table student (
        Id INT IDENTITY NOT NULL,
       timestamp DATETIME2 null,
       actor NVARCHAR(255) null,
       studentId INT not null,
       nisn BIGINT not null,
       name NVARCHAR(255) not null,
       birthDate NVARCHAR(255) not null,
       religion NVARCHAR(255) not null,
       address NVARCHAR(255) not null,
       majors NVARCHAR(255) not null,
       gender NVARCHAR(255) not null,
       fatherName NVARCHAR(255) not null,
       motherName NVARCHAR(255) not null,
       primary key (Id)
    )

    create table teacher (
        Id INT IDENTITY NOT NULL,
       timestamp DATETIME2 null,
       actor NVARCHAR(255) null,
       name NVARCHAR(255) not null,
       birthDate NVARCHAR(255) not null,
       address NVARCHAR(255) not null,
       lastAcad NVARCHAR(255) not null,
       isDeleted BIT not null,
       primary key (Id)
    )

    alter table mapel 
        add constraint student_id 
        foreign key (student_id) 
        references student
