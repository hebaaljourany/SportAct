import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ActivityTypeService, ActivityTypeDto } from '@proxy/activity-types';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';


@Component({
  selector: 'app-activitytype',
  templateUrl: './activitytype.component.html',
  styleUrls: ['./activitytype.component.scss'],
  providers: [
    ListService,
    { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter } 
  ],
})
export class ActivityTypeComponent implements OnInit {
  activitytype = { items: [], totalCount: 0 } as PagedResultDto<ActivityTypeDto>;
  selectedActivityType = {} as ActivityTypeDto;
  form: FormGroup;
  isModalOpen = false;

  constructor(
    public readonly list: ListService,
    private activitytypeService: ActivityTypeService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService // inject the ConfirmationService
  ) {}
  loadingData = true;
  ngOnInit() {
    const activitytypeStreamCreator = (query) => this.activitytypeService.getList(query);

    this.list.hookToQuery(activitytypeStreamCreator).subscribe((response) => {
     
      this.activitytype = response;
         console.log(this.activitytype);
         this.loadingData = false;
       }, 
       (error) => {
         console.log(error);
    });
  }
  createActivityType() {
    this.selectedActivityType = {} as ActivityTypeDto;
    this.buildForm();
    this.isModalOpen = true;
  }
  editActivityType(id: string) {
    this.activitytypeService.get(id).subscribe((activitytype) => {
     
      this.selectedActivityType= activitytype;
      this.buildForm();
      this.isModalOpen = true;
    });
  }
  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.activitytypeService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  buildForm() {
    this.form = this.fb.group({
      ActivityTypeName: [this.selectedActivityType.activityTypeName||'', Validators.required],
      
    });
  }
  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedActivityType.id
      ? this.activitytypeService.update(this.selectedActivityType.id, this.form.value)
      : this.activitytypeService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
 

}
