import { Component, OnInit, Input, ɵɵcontainerRefreshEnd } from "@angular/core";
import { ApartmentService } from "../shared/services/apartment.service";
import { Apartment } from "../shared/models/apartment.model";
import { first } from "rxjs/operators";
import { PageModel } from "../shared/models/page.model";
import { LocationService } from "../shared/services/location.service";
import { LocationModel } from "../shared/models/location.model";

@Component({
  selector: "app-apartments-rent-list",
  templateUrl: "./apartments-rent-list.component.html",
  styleUrls: ["./apartments-rent-list.component.scss"],
})
export class ApartmentsRentListComponent implements OnInit {
  public pageSize: number;
  public pageIndex: number;
  public apartmentsPageModel: PageModel<Apartment>;
  public apartmentsList: Apartment[];
  public locations: LocationModel[];

  constructor(
    private apartmentsService: ApartmentService,
    private locationService: LocationService
  ) {
    this.pageSize = 8;
    this.pageIndex = 1;
  }

  ngOnInit() {
    this.getFilteredApartments(this.pageSize, this.pageIndex);
    this.getZoneLocations();
  }
  private getFilteredApartments(pageSize: number, pageIndex: number) {
    this.apartmentsService
      .getApartments("", pageIndex, pageSize)
      .pipe(first())
      .subscribe((res) => {
        this.apartmentsPageModel = res;
        this.apartmentsList = this.apartmentsPageModel.records;
      });
  }

  private getZoneLocations() {
    this.locationService
      .getZoneLocations()
      .pipe(first())
      .subscribe((res) => (this.locations = res));
    console.log(this.locations);
  }

  public paginateResults(event): void {
    this.pageIndex = event.pageIndex + 1;
    this.pageSize = event.pageSize;
    this.getFilteredApartments(this.pageSize, this.pageIndex);
  }
}
