import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { CityService, CityDto } from '@proxy/cities';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';


@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.scss'],
  providers: [
    ListService,
    { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter } 
  ],
})
export class CityComponent implements OnInit {
  city = { items: [], totalCount: 0 } as PagedResultDto<CityDto>;
  selectedCity = {} as CityDto;
  form: FormGroup;
  isModalOpen = false;

  constructor(
    public readonly list: ListService,
    private cityService: CityService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService // inject the ConfirmationService
  ) {}
  loadingData = true;
  ngOnInit() {
    const cityStreamCreator = (query) => this.cityService.getList(query);

    this.list.hookToQuery(cityStreamCreator).subscribe((response) => {
     
      this.city = response;
         console.log(this.city);
         this.loadingData = false;
       }, 
       (error) => {
         console.log(error);
    });
  }
  createCity() {
    this.selectedCity = {} as CityDto;
    this.buildForm();
    this.isModalOpen = true;
  }
  editCity(id: string) {
    this.cityService.get(id).subscribe((city) => {
     
      this.selectedCity= city;
      this.buildForm();
      this.isModalOpen = true;
    });
  }
  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.cityService.delete(id).subscribe(() => this.list.get());
      }
    });
  }

  buildForm() {
    this.form = this.fb.group({
      CityName: [this.selectedCity.cityName||'', Validators.required],
      
    });
  }
  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedCity.id
      ? this.cityService.update(this.selectedCity.id, this.form.value)
      : this.cityService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
  }
 

}
