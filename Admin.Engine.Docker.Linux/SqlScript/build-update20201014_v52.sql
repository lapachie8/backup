
    create table supplier_contact (
        Id INT IDENTITY NOT NULL,
       ContactType INT not null,
       Value NVARCHAR(255) not null,
       supplier_id INT not null,
       primary key (Id)
    )
    create table supplier (
        Id INT IDENTITY NOT NULL,
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