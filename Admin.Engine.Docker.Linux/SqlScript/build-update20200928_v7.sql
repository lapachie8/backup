
    alter table supplier_contact 
        add constraint fk_supplier_id 
        foreign key (supplier_id) 
        references supplier
    alter table supplier_contact 
        add constraint fk_supplier_id 
        foreign key (id) 
        references supplier