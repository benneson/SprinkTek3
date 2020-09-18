import { Component, ViewChild, Injector, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { BottlesServiceProxy, CreateOrEditBottleDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as moment from 'moment';

@Component({
    selector: 'createOrEditBottleModal',
    templateUrl: './create-or-edit-bottle-modal.component.html'
})
export class CreateOrEditBottleModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    bottle: CreateOrEditBottleDto = new CreateOrEditBottleDto();



    constructor(
        injector: Injector,
        private _bottlesServiceProxy: BottlesServiceProxy
    ) {
        super(injector);
    }

    show(bottleId?: number): void {

        if (!bottleId) {
            this.bottle = new CreateOrEditBottleDto();
            this.bottle.id = bottleId;

            this.active = true;
            this.modal.show();
        } else {
            this._bottlesServiceProxy.getBottleForEdit(bottleId).subscribe(result => {
                this.bottle = result.bottle;


                this.active = true;
                this.modal.show();
            });
        }
        
    }

    save(): void {
            this.saving = true;

			
            this._bottlesServiceProxy.createOrEdit(this.bottle)
             .pipe(finalize(() => { this.saving = false;}))
             .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
             });
    }







    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
