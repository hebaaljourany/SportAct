import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { ClientDto, ClientService } from '@proxy/domain';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.scss'],
  providers: [ListService],
})
export class ClientComponent implements OnInit {
  client = { items: [], totalCount: 0 } as PagedResultDto<ClientDto>;

  constructor(public readonly list: ListService, private clientService: ClientService) {}
  loadingData = true;
  ngOnInit() {
    const clientStreamCreator = (query) => this.clientService.getList(query);

    this.list.hookToQuery(clientStreamCreator).subscribe((response) => {
      //this.client = response;
      this.client = response;
         console.log(this.client);
         this.loadingData = false;
       }, 
       (error) => {
         console.log(error);
    });
  }
}
