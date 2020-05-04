import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FavoriteApartmentsListComponent } from "./favorite-apartments-list/favorite-apartments-list.component";
import { ApartmentsListModule } from "../apartments-list/apartments-list.module";
import { RouterModule } from "@angular/router";

@NgModule({
  declarations: [FavoriteApartmentsListComponent],
  imports: [CommonModule, ApartmentsListModule, RouterModule],
})
export class MyAccountModule {}
