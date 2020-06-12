import { Component, OnInit, EventEmitter, Output } from "@angular/core";
import { LocationCoordinates } from "src/app/add-apartment/map-add-apartment/location-coordinates.model";
import {
  animate,
  transition,
  trigger,
  state,
  style,
} from "@angular/animations";

@Component({
  selector: "app-perfect-home-question",
  templateUrl: "./perfect-home-question.component.html",
  styleUrls: ["./perfect-home-question.component.scss"],
  animations: [
    trigger("popOverState", [
      state(
        "show",
        style({
          opacity: 1,
        })
      ),
      state(
        "hide",
        style({
          opacity: 0,
        })
      ),
      transition("show => hide", animate("600ms ease-out")),
      transition("hide => show", animate("1000ms ease-in")),
    ]),
  ],
})
export class PerfectHomeQuestionComponent implements OnInit {
  public step;
  public PreciseLocation: LocationCoordinates;
  public showMap: boolean;
  public guide: string;
  public map;
  public priceMax: number;
  public roomsWanted: number;
  @Output() public locationResponse: EventEmitter<
    LocationCoordinates
  > = new EventEmitter<LocationCoordinates>();
  @Output() public responded: EventEmitter<boolean> = new EventEmitter<
    boolean
  >();
  @Output() public price: EventEmitter<number> = new EventEmitter<number>();
  @Output() public rooms: EventEmitter<number> = new EventEmitter<number>();

  constructor() {
    this.step = 1;
  }

  get stateName() {
    return this.showMap ? "show" : "hide";
  }

  toggleMap(target) {
    this.showMap = true;
    this.scrollDown(target);
  }

  ngOnInit() {
    this.CheckRespondedToAllQuestions();
  }

  public SkipQuestion(map) {
    this.step = this.step + 1;
    console.log(this.step);
    this.CheckRespondedToAllQuestions();
  }

  public getRooms(rooms) {
    this.roomsWanted = +rooms;
  }

  public getPrice(price) {
    this.priceMax = +price;
  }

  public Respond(map) {
    console.log("res");
    this.step = this.step + 1;
    this.locationResponse.emit(Object.assign({}, this.PreciseLocation));
    console.log("Am emis : " + this.PreciseLocation);
    this.CheckRespondedToAllQuestions();
    this.scrollUp(map);
  }

  public CheckRespondedToAllQuestions() {
    switch (this.step) {
      case 1:
        this.guide =
          "Alege pe hartă facultatea/liceul la care studiezi, iar noi îți vom găsi un apartament în apropiere. (Plaseaza markerul apoi apasa pe Gata.)";
        break;
      case 2:
        this.guide =
          "Alege pe hartă locul unde lucrezi, iar noi îți vom găsi un apartament în apropiere. (Plaseaza markerul apoi apasa pe Gata.)";
        break;
      case 3:
        this.guide =
          "Alege pe hartă scoala unde invata copii tai, iar noi îți vom găsi un apartament în apropiere. (Plaseaza markerul apoi apasa pe Gata.)";
        break;
      case 4:
        this.guide =
          "Alege pe hartă unde iti place sa iesi cu prietenii, iar noi îți vom găsi un apartament în apropiere. (Plaseaza markerul apoi apasa pe Gata.)";
        break;
      case 5:
        this.guide =
          "Alege pe hartă in ce loc iti place sa te distrezi, iar noi îți vom găsi un apartament în apropiere. (Plaseaza markerul apoi apasa pe Gata.)";
        break;
      case 6:
        this.guide =
          "Alege pe hartă gradinita unde iti duci copiii, iar noi îți vom găsi un apartament în apropiere. (Plaseaza markerul apoi apasa pe Gata.)";
        break;
      default:
        this.guide = "";
        break;
    }
    if (this.step == 6) {
      this.showMap = false;
    }
    if (this.step > 6) {
      console.log("emit that you are done!");
      this.sayDone();
    }
  }

  public sayDone() {
    this.price.emit(this.priceMax);
    this.rooms.emit(this.roomsWanted);
    this.responded.emit(true);
    this.scrollUp(this.map);
  }
  private scrollUp(map) {
    // window.scrollTo({
    //   top: 0,
    //   left: 0,
    //   behavior: "smooth",
    // });
    map.scrollIntoView({ behavior: "smooth" });
  }

  private scrollDown(target) {
    target.scrollIntoView({ behavior: "smooth" });
    // window.scrollTo({
    //   top: 1285,
    //   left: 0,
    //   behavior: "smooth",
    // });
  }
}
