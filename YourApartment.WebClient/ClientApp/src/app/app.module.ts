import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { CounterComponent } from "./counter/counter.component";
import { FetchDataComponent } from "./fetch-data/fetch-data.component";
import { AppRoutingModule } from "./app-routing.module";
import { MatPaginatorModule } from "@angular/material/paginator";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { ApartmentDetailComponent } from "./apartment-detail/apartment-detail/apartment-detail.component";
import { AddApartmentModule } from "./add-apartment/add-apartment.module";
import { AddApartmentComponent } from "./add-apartment/add-apartment/add-apartment.component";
import { ApartmentDetailModule } from "./apartment-detail/apartment-detail.module";
import { ApartmentsListModule } from "./apartments-list/apartments-list.module";
import { ApartmentsListComponent } from "./apartments-list/apartments-list/apartments-list.component";
import { PerfectHomeComponent } from "./perfect-home/perfect-home/perfect-home.component";
import { PerfectHomeModule } from "./perfect-home/perfect-home.module";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "add-apartment", component: AddApartmentComponent },
      { path: "counter", component: CounterComponent },
      {
        path: "apartments-rent/detail/:id",
        component: ApartmentDetailComponent,
      },
      { path: "apartments-rent", component: ApartmentsListComponent },

      { path: "perfect-home", component: PerfectHomeComponent },
    ]),
    AppRoutingModule,
    MatPaginatorModule,
    BrowserAnimationsModule,
    ApartmentsListModule,
    ApartmentDetailModule,
    AddApartmentModule,
    PerfectHomeModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
