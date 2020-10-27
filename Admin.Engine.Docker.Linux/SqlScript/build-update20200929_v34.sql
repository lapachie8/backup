
    alter table inventory 
        add constraint fk_supplier_id 
        foreign key (supplier_id) 
        references supplier