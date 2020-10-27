
    create table inventory (
        Id UNIQUEIDENTIFIER not null,
       sku NVARCHAR(50) null,
       name NVARCHAR(255) not null,
       costPrice DECIMAL(19,5) null,
       retailPrice DECIMAL(19,5) not null,
       itemQty INT not null,
       marginPercentage DECIMAL(19,5) default 0  not null,
       isDeleted BIT default 0  not null,
       supplier_id INT null,
       primary key (Id)
    )
    alter table inventory 
        add constraint fk_supplier_id 
        foreign key (supplier_id) 
        references supplier