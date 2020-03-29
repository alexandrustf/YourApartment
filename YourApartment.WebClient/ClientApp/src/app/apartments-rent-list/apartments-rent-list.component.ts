import { Component, OnInit } from "@angular/core";
import { ApartmentService } from "../shared/services/apartment.service";
import { Apartment } from "../shared/models/apartment.model";
import { first } from "rxjs/operators";
import { PageModel } from "../shared/models/page.model";

@Component({
  selector: "app-apartments-rent-list",
  templateUrl: "./apartments-rent-list.component.html",
  styleUrls: ["./apartments-rent-list.component.scss"]
})
export class ApartmentsRentListComponent implements OnInit {
  private page: number;
  private pageSize: number;
  public apartments: PageModel<Apartment>;
  public apartmentsList: Apartment[];
  constructor(private apartmentsService: ApartmentService) {}

  ngOnInit() {
    this.apartmentsService
      .getApartments()
      .pipe(first())
      .subscribe(res => (this.apartmentsList = res.records));
    console.log(this.apartments);
    // this.apartmentsList = this.convertToList();
  }

  public convertToList() {
    return this.apartments.records;
    console.log(this.apartmentsList);
  }
}
