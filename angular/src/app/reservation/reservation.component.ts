import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ReservationService, ReservationDto, SportActivityLookupDto } from '@proxy/reservations';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.scss'],
  providers: [
    ListService,
    { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter } 
  ],
})
export class ReservationComponent implements OnInit {
  reservation = { items: [], totalCount: 0 } as PagedResultDto<ReservationDto>;
  selectedReservation = {} as ReservationDto;
  form: FormGroup;
  isModalOpen = false;
  sportactivities$: Observable<SportActivityLookupDto[]>;


  constructor(
    public readonly list: ListService,
    private reservationService: ReservationService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService // inject the ConfirmationService
  ) {
    this.sportactivities$ = reservationService.getSportActivityLookup().pipe(map((r) => r.items));

  }
  loadingData = true;
  ngOnInit() {
    const reservationStreamCreator = (query) => this.reservationService.getList(query);

    this.list.hookToQuery(reservationStreamCreator).subscribe((response) => {
     
      this.reservation = response;
         console.log(this.reservation);
         this.loadingData = false;
       }, 
       (error) => {
         console.log(error);
    });
  }
  createReservation() {
    this.selectedReservation = {} as ReservationDto;
    this.buildForm();
    this.isModalOpen = true;
  }
  editReservation(id: string) {
    this.reservationService.get(id).subscribe((reservation) => {
     
      this.selectedReservation= reservation;
      this.buildForm();
      this.isModalOpen = true;
    });
  }
  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.reservationService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  buildForm() {
    this.form = this.fb.group({
      

      Participants: [this.selectedReservation.participants||null, Validators.required],
      sportactivityId: [this.selectedReservation.sportActivityId || null, Validators.required],
      
    });
  }
  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedReservation.id
      ? this.reservationService.update(this.selectedReservation.id, this.form.value)
      : this.reservationService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
 

}
