import { Component, OnInit } from "@angular/core";
import { ApartmentService } from "src/app/shared/services/apartment.service";
import { ActivatedRoute } from "@angular/router";
import { Subscription } from "rxjs";
import { first } from "rxjs/operators";
import { ApartmentDetails } from "src/app/shared/models/apartment-details.model";

@Component({
  selector: "app-apartment-detail",
  templateUrl: "./apartment-detail.component.html",
  styleUrls: ["./apartment-detail.component.scss"],
})
export class ApartmentDetailComponent implements OnInit {
  public apartment: ApartmentDetails;

  constructor(
    private route: ActivatedRoute,
    private apartmentsService: ApartmentService
  ) {}

  ngOnInit() {
    const id: string = this.route.snapshot.paramMap.get("id");
    this.apartmentsService
      .getApartmentById(id)
      .pipe(first())
      .subscribe((res) => (this.apartment = res));
  }
}
