import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { LocationService, LocationDto, CityLookupDto  } from '@proxy/locations';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrls: ['./location.component.scss'],
  providers: [
    ListService,
    { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter } 
  ],
})
export class LocationComponent implements OnInit {
  location = { items: [], totalCount: 0 } as PagedResultDto<LocationDto>;
  selectedLocation = {} as LocationDto;
  form: FormGroup;
  isModalOpen = false;
  cities$: Observable<CityLookupDto[]>;

  constructor(
    public readonly list: ListService,
    private locationService: LocationService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService // inject the ConfirmationService
  ) {
    this.cities$ = locationService.getCityLookup().pipe(map((r) => r.items));
  }
  loadingData = true;
  ngOnInit() {
    const locationStreamCreator = (query) => this.locationService.getList(query);

    this.list.hookToQuery(locationStreamCreator).subscribe((response) => {
     
      this.location = response;
         console.log(this.location);
         this.loadingData = false;
       }, 
       (error) => {
         console.log(error);
    });
  }
  createLocation() {
    this.selectedLocation = {} as LocationDto;
    this.buildForm();
    this.isModalOpen = true;
  }
  editLocation(id: string) {
    this.locationService.get(id).subscribe((location) => {
     
      this.selectedLocation= location;
      this.buildForm();
      this.isModalOpen = true;
    });
  }
  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.locationService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  buildForm() {
    this.form = this.fb.group({
      cityId: [this.selectedLocation.cityId || null, Validators.required],

      LocationName: [this.selectedLocation.locationName||'', Validators.required],
      
    });
  }
  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedLocation.id
      ? this.locationService.update(this.selectedLocation.id, this.form.value)
      : this.locationService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
 

}
