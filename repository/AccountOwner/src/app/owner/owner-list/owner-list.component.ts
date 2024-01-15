import { Component, OnInit } from '@angular/core';
import { OwnerRepositoryService } from 'src/app/shared/services/owner-repository.service';
import { Owner } from '../../_interface/owner.model';

@Component({
  selector: 'app-owner-list',
  templateUrl: './owner-list.component.html',
  styleUrls: ['./owner-list.component.css']
})
export class OwnerListComponent implements OnInit {
  owners!: Owner[];
  constructor(private repository: OwnerRepositoryService){}

  ngOnInit(): void {
    this.getAllOwners();
  }
  // private getAllOwners(){
  //   // urlAddress: string = 'api/owners'
  //   this.repository.getOwners('api/owners').subscribe(ow => {
  //     this.owners = ow
  //   });
  // }

  private getAllOwners = () => {
    const apiAddress: string = 'api/owner';
    this.repository.getOwners(apiAddress)
        .subscribe(
            own => {
                console.log('Data from API:', own);
                this.owners = own;
            },
            error => {
                console.error('Error:', error);
            }
        );
}

}
