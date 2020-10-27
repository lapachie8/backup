
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[fk_supplier_id]') and parent_object_id = OBJECT_ID(N'supplier_contact'))
alter table supplier_contact  drop constraint fk_supplier_id


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[fk_supplier_id]') and parent_object_id = OBJECT_ID(N'supplier_contact'))
alter table supplier_contact  drop constraint fk_supplier_id


    if exists (select * from dbo.sysobjects where id = object_id(N'supplier_contact') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table supplier_contact

    if exists (select * from dbo.sysobjects where id = object_id(N'supplier') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table supplier

    create table supplier_contact (
        Id INT IDENTITY NOT NULL,
       timestamp DATETIME2 null,
       actor NVARCHAR(255) null,
       ContactType INT not null,
       Value NVARCHAR(255) not null,
       supplier_id INT not null,
       primary key (Id)
    )

    create table supplier (
        Id INT IDENTITY NOT NULL,
       timestamp DATETIME2 null,
       actor NVARCHAR(255) null,
       Name NVARCHAR(150) not null,
       Address NVARCHAR(255) not null,
       City NVARCHAR(50) not null,
       PostCode NVARCHAR(5) not null,
       primary key (Id)
    )

    alter table supplier_contact 
        add constraint fk_supplier_id 
        foreign key (supplier_id) 
        references supplier

    alter table supplier_contact 
        add constraint fk_supplier_id 
        foreign key (id) 
        references supplier
