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
  @Output() public locationResponse: EventEmitter<
    LocationCoordinates
  > = new EventEmitter<LocationCoordinates>();
  @Output() public responded: EventEmitter<boolean> = new EventEmitter<
    boolean
  >();
  constructor() {
    this.step = 1;
  }

  ngOnInit() {}

  public SkipQuestion() {
    this.step = this.step + 1;
    console.log(this.step);
    this.CheckRespondedToAllQuestions();
  }

  public Respond() {
    console.log("res");
    this.step = this.step + 1;
    this.locationResponse.emit(Object.assign({}, this.PreciseLocation));
    console.log("Am emis : " + this.PreciseLocation);
    this.CheckRespondedToAllQuestions();
  }

  public CheckRespondedToAllQuestions() {
    if (this.step > 6) {
      console.log("emit that you are done!");
      this.sayDone();
    }
  }

  public sayDone() {
    this.responded.emit(true);
  }
}
