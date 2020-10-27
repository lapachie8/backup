
    create table item (
        Id UNIQUEIDENTIFIER not null,
       sku NVARCHAR(50) null,
       name NVARCHAR(255) not null,
       costPrice DECIMAL(19,5) null,
       retailPrice DECIMAL(19,5) not null,
       itemQty INT default 0  not null,
       marginPercentage DECIMAL(19,5) default 0  not null,
       isDeleted BIT default False  not null,
       supplier_id INT null,
       primary key (Id)
    )
    alter table supplier_contact 
        add name NVARCHAR(255)
    alter table supplier_contact 
        add contactType INT
    alter table item 
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