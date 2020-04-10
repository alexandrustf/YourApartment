import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ApartmentsListComponent } from "./apartments-list/apartments-list.component";
import { FiltersComponent } from "./filters/filters.component";
import { ApartmentCardComponent } from "./apartment-card/apartment-card.component";
import { PaginationComponent } from "./pagination/pagination.component";
import { CardsListComponent } from "./cards-list/cards-list.component";
import { RouterModule } from "@angular/router";
import { MatPaginatorModule } from "@angular/material/paginator";

@NgModule({
  declarations: [
    ApartmentsListComponent,
    FiltersComponent,
    ApartmentCardComponent,
    PaginationComponent,
    CardsListComponent,
  ],
  imports: [CommonModule, RouterModule, MatPaginatorModule],
})
export class ApartmentsListModule {}
