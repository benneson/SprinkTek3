import { Component, ViewChild, Injector, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { PhonebooksServiceProxy, CreateOrEditPhonebookDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as moment from 'moment';
import { PhonebookPersonLookupTableModalComponent } from './phonebook-person-lookup-table-modal.component';

@Component({
    selector: 'createOrEditPhonebookModal',
    templateUrl: './create-or-edit-phonebook-modal.component.html'
})
export class CreateOrEditPhonebookModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @ViewChild('phonebookPersonLookupTableModal', { static: true }) phonebookPersonLookupTableModal: PhonebookPersonLookupTableModalComponent;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    phonebook: CreateOrEditPhonebookDto = new CreateOrEditPhonebookDto();

    personName = '';


    constructor(
        injector: Injector,
        private _phonebooksServiceProxy: PhonebooksServiceProxy
    ) {
        super(injector);
    }

    show(phonebookId?: number): void {

        if (!phonebookId) {
            this.phonebook = new CreateOrEditPhonebookDto();
            this.phonebook.id = phonebookId;
            this.personName = '';

            this.active = true;
            this.modal.show();
        } else {
            this._phonebooksServiceProxy.getPhonebookForEdit(phonebookId).subscribe(result => {
                this.phonebook = result.phonebook;

                this.personName = result.personName;

                this.active = true;
                this.modal.show();
            });
        }
        
    }

    save(): void {
            this.saving = true;

			
            this._phonebooksServiceProxy.createOrEdit(this.phonebook)
             .pipe(finalize(() => { this.saving = false;}))
             .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
             });
    }

    openSelectPersonModal() {
        this.phonebookPersonLookupTableModal.id = this.phonebook.personId;
        this.phonebookPersonLookupTableModal.displayName = this.personName;
        this.phonebookPersonLookupTableModal.show();
    }


    setPersonIdNull() {
        this.phonebook.personId = null;
        this.personName = '';
    }


    getNewPersonId() {
        this.phonebook.personId = this.phonebookPersonLookupTableModal.id;
        this.personName = this.phonebookPersonLookupTableModal.displayName;
    }


    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
