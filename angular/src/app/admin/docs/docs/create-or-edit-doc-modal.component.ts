import { Component, ViewChild, Injector, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { DocsServiceProxy, CreateOrEditDocDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as moment from 'moment';

@Component({
    selector: 'createOrEditDocModal',
    templateUrl: './create-or-edit-doc-modal.component.html'
})
export class CreateOrEditDocModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    doc: CreateOrEditDocDto = new CreateOrEditDocDto();



    constructor(
        injector: Injector,
        private _docsServiceProxy: DocsServiceProxy
    ) {
        super(injector);
    }

    show(docId?: number): void {

        if (!docId) {
            this.doc = new CreateOrEditDocDto();
            this.doc.id = docId;

            this.active = true;
            this.modal.show();
        } else {
            this._docsServiceProxy.getDocForEdit(docId).subscribe(result => {
                this.doc = result.doc;


                this.active = true;
                this.modal.show();
            });
        }
        
    }

    save(): void {
            this.saving = true;

			
            this._docsServiceProxy.createOrEdit(this.doc)
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
