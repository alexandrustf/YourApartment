import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { Validators } from "@angular/forms";
import { CreateApartmentModel } from "src/app/shared/models/add-apartment.model";
import { AddApartmentService } from "src/app/shared/services/add-apartment.service";
import { first } from "rxjs/operators";
import { ServiceResponse } from "src/app/shared/models/service-reponse.model";

export const NAME_MAX_LENGTH: number = 50;
export const DESCRIPTION_MAX_LENGTH: number = 1000;
@Component({
  selector: "app-add-apartment-form",
  templateUrl: "./add-apartment-form.component.html",
  styleUrls: ["./add-apartment-form.component.scss"],
})
export class AddApartmentFormComponent implements OnInit {
  public response: ServiceResponse;
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
  constructor(private addApartmentService: AddApartmentService) {}

  ngOnInit() {}

  onSubmit() {
    console.warn(this.apartmentForm.value);
    window.alert("A fost apasat butonu de submit" + this.apartmentForm.value);
    var apartment = new CreateApartmentModel();
    apartment.title = this.apartmentForm.get("title").value;
    apartment.area = this.apartmentForm.get("area").value;
    apartment.numberOfRooms = this.apartmentForm.get("numberOfRooms").value;
    apartment.totalNumberOfFloors = this.apartmentForm.get(
      "totalNumberOfFloors"
    ).value
      ? (apartment.totalNumberOfFloors = this.apartmentForm.get(
          "totalNumberOfFloors"
        ).value)
      : 0;
    apartment.numberOfBathrooms = this.apartmentForm.get("numberOfBathRooms")
      .value
      ? (apartment.numberOfBathrooms = this.apartmentForm.get(
          "numberOfBathRooms"
        ).value)
      : 0;
    apartment.exactAdress = this.apartmentForm.get("exactAdress").value
      ? this.apartmentForm.get("exactAdress").value
      : "";
    apartment.description = this.apartmentForm.get("description").value
      ? this.apartmentForm.get("description").value
      : "";
    apartment.confort = this.apartmentForm.get("confort").value
      ? (apartment.confort = this.apartmentForm.get("confort").value)
      : 0;
    apartment.constructionYear = this.apartmentForm.get("constructionYear")
      .value
      ? (apartment.constructionYear = this.apartmentForm.get(
          "constructionYear"
        ).value)
      : 0;
    apartment.locationId = "8bb2b4e1-c768-45b9-9b6f-aa61a86d7a59";
    apartment.price = this.apartmentForm.get("price").value;
    apartment.imagesBytes = this.imageContent;
    this.addApartmentService
      .AddApartment(apartment)
      .pipe(first())
      .subscribe((res) => (this.response = res));
  }
  imageContent: string;

  onFileChanged(event) {
    const reader = new FileReader();
    reader.readAsDataURL(event.target.files[0]);
    reader.onload = (event) => {
      var imageResult = event.target["result"].toString();
      this.imageContent = imageResult.slice(23, imageResult.length - 4);
    };
  }
}
