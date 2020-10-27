
    create table inventory (
        Id UNIQUEIDENTIFIER not null,
       sku NVARCHAR(50) null,
       name NVARCHAR(255) not null,
       costPrice DECIMAL(19,5) null,
       retailPrice DECIMAL(19,5) not null,
       itemQty INT default 0  not null,
       marginPercentage DECIMAL(19,5) default 0  not null,
       isDeleted BIT default (0)  not null,
       supplier_id INT null,
       primary key (Id)
    )
    create table supplier_contact (
        Id INT IDENTITY NOT NULL,
       name NVARCHAR(255) not null,
       contactType INT not null,
       value NVARCHAR(255) not null,
       supplier_id INT not null,
       primary key (Id)
    )
    create table supplier (
        Id INT IDENTITY NOT NULL,
       name NVARCHAR(255) not null,
       address NVARCHAR(500) not null,
       city NVARCHAR(255) not null,
       postCode NVARCHAR(5) not null,
       primary key (Id)
    )
    alter table inventory 
        add constraint fk_supplier_id 
        foreign key (supplier_id) 
        references supplier
    alter table supplier_contact 
        add constraint fk_supplier_id 
        foreign key (supplier_id) 
        references supplier
    alter table supplier_contact 
        add constraint fk_supplier_id 
        foreign key (id) 
        references supplier