import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { AddApartmentComponent } from "./add-apartment/add-apartment.component";
import { AddApartmentFormComponent } from "./add-apartment-form/add-apartment-form.component";
import { ReactiveFormsModule } from "@angular/forms";
import { MapAddApartmentComponent } from "./map-add-apartment/map-add-apartment.component";
import { AgmCoreModule } from "@agm/core";

@NgModule({
  declarations: [
    AddApartmentComponent,
    AddApartmentFormComponent,
    MapAddApartmentComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AgmCoreModule.forRoot({
      apiKey: "AIzaSyBVmIevOIYNBX1c4ZKEcNArXL04WS_JVO0",
    }),
  ],
})
export class AddApartmentModule {}
