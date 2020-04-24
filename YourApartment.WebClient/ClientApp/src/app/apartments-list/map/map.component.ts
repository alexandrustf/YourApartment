import {
  Component,
  AfterViewInit,
  ViewChild,
  ElementRef,
  Input,
} from "@angular/core";
import {} from "googlemaps";
import { Apartment } from "src/app/shared/models/apartment.model";

@Component({
  selector: "app-map",
  templateUrl: "./map.component.html",
  styleUrls: ["./map.component.scss"],
})
export class MapComponent implements AfterViewInit {
  @Input() apartmentsList: Apartment[];

  public getLat(apartment) {
    console.log(apartment.lat);
    return apartment.lat;
  }
  ngAfterViewInit() {
    // this.mapInitializer();
    console.log(this.apartmentsList);
  }
  infoWindowOpened = null;
  previous_info_window = null;
  close_window() {
    if (this.previous_info_window != null) {
      this.previous_info_window.close();
    }
  }

  select_marker(infoWindow) {
    console.log("aici");
    if (this.previous_info_window == null)
      this.previous_info_window = infoWindow;
    else {
      this.infoWindowOpened = infoWindow;
      this.previous_info_window.close();
    }
    this.previous_info_window = infoWindow;
  }
  // @ViewChild("mapContainer", { static: false }) gmap: ElementRef;
  // map: google.maps.Map;

  // public lat = 47.161494;
  // public lng = 27.5840504;
  // public coordinates = new google.maps.LatLng(this.lat, this.lng);
  // mapOptions: google.maps.MapOptions = {
  //   center: this.coordinates,
  //   zoom: 13,
  // };
  // marker = new google.maps.Marker({
  //   position: this.coordinates,
  //   map: this.map,
  //   title: "apartmant cu 2 camere in unirii",
  // });
  // public markers = [
  //   {
  //     position: new google.maps.LatLng(47.999321, 27.3210231),
  //     map: this.map,
  //     title: "apartmant cu 2 camere in unirii",
  //   },
  //   {
  //     position: new google.maps.LatLng(47.876354, 27.1230525),
  //     map: this.map,
  //     title: "apartament cu 2 camere in copou",
  //   },
  // ];

  // constructor() {}

  // private mapInitializer() {
  //   console.log(this.apartmentsList);
  //   this.map = new google.maps.Map(this.gmap.nativeElement, this.mapOptions);
  //   this.marker.setMap(this.map);
  //   this.marker.addListener("click", () => {
  //     const infowindow = new google.maps.InfoWindow({
  //       content: `${this.apartmentsList[0].price}`,
  //     });

  //     infowindow.open(this.marker.getMap(), this.marker);
  //   });
  //   this.loadAllMarkers();
  // }

  // private loadAllMarkers() {
  //   this.apartmentsList.forEach((a) => {
  //     var marker = {
  //       position: new google.maps.LatLng(a.lat, a.lng),
  //       map: this.map,
  //       title: a.name,
  //     };
  //     this.markers.push(marker);
  //   });
  //   console.log(this.markers);
  //   this.markers.forEach((markerInfo) => {
  //     const marker = new google.maps.Marker({
  //       ...markerInfo,
  //     });
  //     const infoWindow = new google.maps.InfoWindow({
  //       content: marker.getTitle(),
  //     });
  //     marker.addListener("click", () => {
  //       infoWindow.open(marker.getMap(), marker);
  //     });
  //     marker.setMap(this.map);
  //   });
  // }
}
