import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { SportActivityService, SportActivityDto, LocationLookupDto, ActivityTypeLookupDto } from '@proxy/sport-activities';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ReservationService, ReservationDto } from '@proxy/reservations';


@Component({
  selector: 'app-sportactivity',
  templateUrl: './sportactivity.component.html',
  styleUrls: ['./sportactivity.component.scss'],
  providers: [
    ListService,
    { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter } 
  ],
})
export class SportActivityComponent implements OnInit {
  sportactivity = { items: [], totalCount: 0 } as PagedResultDto<SportActivityDto>;
  selectedSportActivity = {} as SportActivityDto;
  form: FormGroup;
  isModalOpen = false;
  locations$: Observable<LocationLookupDto[]>;
  activitytypes$: Observable<ActivityTypeLookupDto[]>;
  

  constructor(
    public readonly list: ListService,
    private sportactivityService: SportActivityService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService, // inject the ConfirmationService
    private reservationService: ReservationService
  ) {
    this.locations$ = sportactivityService.getLocationLookup().pipe(map((r) => r.items));
    this.activitytypes$ = sportactivityService.getActivityTypeLookup().pipe(map((r) => r.items));


  }
  loadingData = true;
  ngOnInit() {
    const sportactivityStreamCreator = (query) => this.sportactivityService.getList(query);

    this.list.hookToQuery(sportactivityStreamCreator).subscribe((response) => {
     
      this.sportactivity = response;
         console.log(this.sportactivity);
         this.loadingData = false;
       }, 
       (error) => {
         console.log(error);
    });
  }
  createSportActivity() {
    this.selectedSportActivity = {} as SportActivityDto;
    this.buildForm();
    this.isModalOpen = true;
  }
  editSportActivity(id: string) {
    this.sportactivityService.get(id).subscribe((sportactivity) => {
     
      this.selectedSportActivity= sportactivity;
      

      this.buildForm();
      this.isModalOpen = true;
    });
  }
  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.sportactivityService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
  reserveActivity(id: string) {
   
    this.sportactivityService.get(id).subscribe((sportactivity) => {
      this.selectedSportActivity= sportactivity;
      const reservation: ReservationDto = {
        // Initialize the reservation object with the selected activity
        sportActivityId: this.selectedSportActivity.id,
        activityName: this.selectedSportActivity.activityName,
      };
      this.reservationService.create(reservation).subscribe(() => this.list.get());
    });
  }
  buildForm() {
    this.form = this.fb.group({
     
      locationId: [this.selectedSportActivity.locationId || null, Validators.required],
      activitytypeId: [this.selectedSportActivity.activityTypeId || null, Validators.required],


      ActivityName: [this.selectedSportActivity.activityName || '', Validators.required],
     
      Capacity: [this.selectedSportActivity.capacity || null, Validators.required],
      Cost: [this.selectedSportActivity.cost || null, Validators.required],
      MinimumAge: [this.selectedSportActivity.minimumAge || null, Validators.required],
      MaximumAge: [this.selectedSportActivity.maximumAge || null, Validators.required],

      StartedTime: [this.selectedSportActivity.startedTime || null,Validators.required],
      EndedTime: [this.selectedSportActivity.endedTime || null,Validators.required],

      Description: [this.selectedSportActivity.description || '', Validators.required],
    });
      
   
  }
  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedSportActivity.id
      ? this.sportactivityService.update(this.selectedSportActivity.id, this.form.value)
      : this.sportactivityService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
 

}
