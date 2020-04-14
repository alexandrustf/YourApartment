import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { AddApartmentComponent } from "./add-apartment/add-apartment.component";
import { AddApartmentFormComponent } from "./add-apartment-form/add-apartment-form.component";
import { ReactiveFormsModule } from "@angular/forms";

@NgModule({
  declarations: [AddApartmentComponent, AddApartmentFormComponent],
  imports: [CommonModule, ReactiveFormsModule],
})
export class AddApartmentModule {}
