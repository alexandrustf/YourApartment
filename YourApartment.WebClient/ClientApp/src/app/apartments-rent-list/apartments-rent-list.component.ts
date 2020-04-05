import { Component, OnInit, Input, ɵɵcontainerRefreshEnd } from "@angular/core";
import { ApartmentService } from "../shared/services/apartment.service";
import { Apartment } from "../shared/models/apartment.model";
import { first } from "rxjs/operators";
import { PageModel } from "../shared/models/page.model";

@Component({
  selector: "app-apartments-rent-list",
  templateUrl: "./apartments-rent-list.component.html",
  styleUrls: ["./apartments-rent-list.component.scss"],
})
export class ApartmentsRentListComponent implements OnInit {
  public page;
  public pageSize: number;
  public pageIndex: number;
  public apartmentsPageModel: PageModel<Apartment>;
  public apartmentsList: Apartment[];

  constructor(private apartmentsService: ApartmentService) {
    this.pageSize = 4;
    this.pageIndex = 1;
  }

  ngOnInit() {
    this.getFilteredApartments(this.pageSize, this.pageIndex);
    console.log(this.apartmentsPageModel);
  }
  getFilteredApartments(pageSize: number, pageIndex: number) {
    this.apartmentsService
      .getApartments("", pageIndex, pageSize)
      .pipe(first())
      .subscribe((res) => {
        this.apartmentsPageModel = res;
        this.apartmentsList = this.apartmentsPageModel.records;
        console.log(this.apartmentsList);
      });
  }
  public getlogs() {
    console.log(this.page);
  }
  public paginateResults(): void {
    console.log(this.page);
    this.pageSize = 5;
    this.pageIndex = 2;
    this.getFilteredApartments(this.pageSize, this.pageIndex);
  }
}
