import { Component, OnInit, Input, ɵɵcontainerRefreshEnd } from "@angular/core";
import { ApartmentService } from "../shared/services/apartment.service";
import { Apartment } from "../shared/models/apartment.model";
import { first } from "rxjs/operators";
import { PageModel } from "../shared/models/page.model";
import { LocationService } from "../shared/services/location.service";
import { LocationModel } from "../shared/models/location.model";
import { FilterModel } from "../shared/models/filter.model";

@Component({
  selector: "app-apartments-rent-list",
  templateUrl: "./apartments-rent-list.component.html",
  styleUrls: ["./apartments-rent-list.component.scss"],
})
export class ApartmentsRentListComponent implements OnInit {
  public filterModel: FilterModel;
  public apartmentsPageModel: PageModel<Apartment>;
  public apartmentsList: Apartment[];
  public locations: LocationModel[];

  constructor(
    private apartmentsService: ApartmentService,
    private locationService: LocationService
  ) {
    this.filterModel = new FilterModel();
    this.filterModel.pageSize = 8;
    this.filterModel.page = 1;
  }

  ngOnInit() {
    this.getFilteredApartments();
    this.getZoneLocations();
  }
  private getFilteredApartments() {
    this.apartmentsService
      .getApartments(this.filterModel)
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
    console.log(event);
    this.filterModel.page = event.pageIndex + 1;
    this.filterModel.pageSize = event.pageSize;
    this.getFilteredApartments();
  }

  public filterByRooms(event) {
    this.filterModel.numberOfRooms = event;
    this.getFilteredApartments();
  }

  public filterByMinPrice(event) {
    this.filterModel.priceMin = event;
    this.getFilteredApartments();
  }

  public filterByMaxPrice(event) {
    this.filterModel.priceMax = event;
    this.getFilteredApartments();
  }

  public filterByLocation(event) {
    this.filterModel.location = event;
    this.getFilteredApartments();
  }
}
