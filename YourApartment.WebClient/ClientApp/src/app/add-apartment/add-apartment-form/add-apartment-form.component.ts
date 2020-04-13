import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { Validators } from "@angular/forms";

export const NAME_MAX_LENGTH: number = 50;
export const DESCRIPTION_MAX_LENGTH: number = 1000;
@Component({
  selector: "app-add-apartment-form",
  templateUrl: "./add-apartment-form.component.html",
  styleUrls: ["./add-apartment-form.component.scss"],
})
export class AddApartmentFormComponent implements OnInit {
  public apartmentForm: FormGroup = new FormGroup({
    image: new FormControl("", {
      validators: [Validators.required],
      updateOn: "change",
    }),
    title: new FormControl("", {
      validators: [Validators.required, Validators.maxLength(NAME_MAX_LENGTH)],
      updateOn: "change",
    }),
    price: new FormControl("", {
      validators: [Validators.required, Validators.min(0)],
      updateOn: "change",
    }),
    area: new FormControl("", {
      validators: [Validators.required, Validators.min(0)],
      updateOn: "change",
    }),
    numberOfRooms: new FormControl("", {
      validators: [Validators.required],
      updateOn: "change",
    }),
    description: new FormControl("", {
      validators: [Validators.maxLength(DESCRIPTION_MAX_LENGTH)],
      updateOn: "change",
    }),
    floor: new FormControl("", {
      validators: [],
      updateOn: "change",
    }),
    totalNumberOfFloors: new FormControl("", {
      validators: [],
      updateOn: "change",
    }),
    numberOfBathRooms: new FormControl("", {
      validators: [Validators.min(0), Validators.max(20)],
      updateOn: "change",
    }),
    exactAdress: new FormControl("", {
      validators: [],
      updateOn: "change",
    }),
    confort: new FormControl("", {
      validators: [Validators.maxLength(NAME_MAX_LENGTH)],
      updateOn: "change",
    }),
    constructionYear: new FormControl("", {
      validators: [Validators.min(1920), Validators.max(2020)],
      updateOn: "change",
    }),
    phone: new FormControl("", {
      validators: [],
      updateOn: "change",
    }),
  });
  constructor() {}

  ngOnInit() {}

  onSubmit() {
    // TODO: Use EventEmitter with form value
    console.log("ceva");
    console.warn(this.apartmentForm.value);
    window.alert("A fost apasat butonu de submit" + this.apartmentForm.value);
  }

  // public findInvalidControls() {
  //   const invalid = [];
  //   const controls = this.apartmentForm.controls;
  //   for (const name in controls) {
  //     if (controls[name].invalid) {
  //       invalid.push(name);
  //     }
  //   }
  //   console.log(invalid);
  //   // return invalid;
  // }
}
