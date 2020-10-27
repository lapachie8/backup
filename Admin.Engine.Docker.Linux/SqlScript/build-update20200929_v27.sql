
    create table inventory (
        Id UNIQUEIDENTIFIER not null,
       sku NVARCHAR(50) null,
       name NVARCHAR(255) null,
       costPrice DECIMAL(19,5) null,
       retailPrice DECIMAL(19,5) null,
       itemQty INT null,
       marginPercentage DECIMAL(19,5) default 0  null,
       isDeleted BIT default False  null,
       supplier_id INT null,
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