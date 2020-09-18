import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetBottleForViewDto, BottleDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewBottleModal',
    templateUrl: './view-bottle-modal.component.html'
})
export class ViewBottleModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetBottleForViewDto;


    constructor(
        injector: Injector
    ) {
        super(injector);
        this.item = new GetBottleForViewDto();
        this.item.bottle = new BottleDto();
    }

    show(item: GetBottleForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
