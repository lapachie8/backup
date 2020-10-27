
    if exists (select * from dbo.sysobjects where id = object_id(N'student') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table student

    if exists (select * from dbo.sysobjects where id = object_id(N'teacher_data') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table teacher_data

    create table student (
        Id INT IDENTITY NOT NULL,
       timestamp DATETIME2 null,
       actor NVARCHAR(255) null,
       studentId INT not null,
       nisn INT not null,
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

    create table teacher_data (
        Id INT IDENTITY NOT NULL,
       timestamp DATETIME2 null,
       actor NVARCHAR(255) null,
       name NVARCHAR(255) not null,
       birth_date NVARCHAR(255) not null,
       address NVARCHAR(255) not null,
       last_academy NVARCHAR(255) not null,
       is_deleted BIT not null,
       primary key (Id)
    )
