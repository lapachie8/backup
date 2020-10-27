
    create table supplier_contact (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) not null,
       ContactType INT not null,
       Value NVARCHAR(255) not null,
       supplier_id INT not null,
       primary key (Id)
    )
    create table supplier (
        Id INT IDENTITY NOT NULL,
       Name NVARCHAR(255) not null,
       Address NVARCHAR(500) not null,
       City NVARCHAR(255) not null,
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