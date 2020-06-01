import { Component, OnInit, EventEmitter, Output } from "@angular/core";
import { LocationCoordinates } from "src/app/add-apartment/map-add-apartment/location-coordinates.model";

@Component({
  selector: "app-perfect-home-question",
  templateUrl: "./perfect-home-question.component.html",
  styleUrls: ["./perfect-home-question.component.scss"],
})
export class PerfectHomeQuestionComponent implements OnInit {
  public step;
  public PreciseLocation: LocationCoordinates;
  public QuestionAnswer: boolean;
  public FavoriteLocations: LocationCoordinates[];
  @Output() public questionResponse: EventEmitter<boolean> = new EventEmitter<
    boolean
  >();
  constructor() {
    this.step = 1;
    this.FavoriteLocations = [];
  }

  ngOnInit() {}

  public SkipQuestion() {
    console.log(this.step);
    this.step = this.step + 1;
  }

  public Respond() {
    console.log("res");

    this.FavoriteLocations.push(this.PreciseLocation);

    console.log(this.FavoriteLocations);
  }

  onItemChange(value) {
    console.log("selectat");
    console.log(value);
    if (value == "1") {
      this.QuestionAnswer = true;
    }
    if (value == "0") {
      this.QuestionAnswer = false;
      this.step++;
    }
    console.log(this.QuestionAnswer);
  }
}
