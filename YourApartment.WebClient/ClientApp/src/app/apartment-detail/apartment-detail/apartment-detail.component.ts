import { Component, OnInit } from "@angular/core";
import { ApartmentService } from "src/app/shared/services/apartment.service";
import { ActivatedRoute } from "@angular/router";
import { Subscription } from "rxjs";
import { first } from "rxjs/operators";
import { ApartmentDetails } from "src/app/shared/models/apartment-details.model";
import { FavoriteService } from "src/app/shared/services/favorite.service";
import { Favorite } from "src/app/shared/models/favorite.model";

@Component({
  selector: "app-apartment-detail",
  templateUrl: "./apartment-detail.component.html",
  styleUrls: ["./apartment-detail.component.scss"],
})
export class ApartmentDetailComponent implements OnInit {
  public apartment: ApartmentDetails;

  constructor(
    private route: ActivatedRoute,
    private apartmentsService: ApartmentService,
    private favoriteService: FavoriteService
  ) {}

  ngOnInit() {
    const id: string = this.route.snapshot.paramMap.get("id");
    this.apartmentsService
      .getApartmentById(id)
      .pipe(first())
      .subscribe((res) => (this.apartment = res));
  }

  addFavorite() {
    console.log("adaugam la favorite");
    var favorite = new Favorite();
    favorite.idApartment = this.apartment.id;
    favorite.favorite = true;
    this.favoriteService.addFavorite(favorite).subscribe();
  }
}
