import { Component, AfterViewInit, ViewChild, ElementRef } from "@angular/core";
import {} from "googlemaps";

@Component({
  selector: "app-map",
  templateUrl: "./map.component.html",
  styleUrls: ["./map.component.scss"],
})
export class MapComponent implements AfterViewInit {
  @ViewChild("mapContainer", { static: false }) gmap: ElementRef;
  map: google.maps.Map;
  public lat = 47.161494;
  public lng = 27.5840504;
  public coordinates = new google.maps.LatLng(this.lat, this.lng);
  mapOptions: google.maps.MapOptions = {
    center: this.coordinates,
    zoom: 13,
  };
  marker = new google.maps.Marker({
    position: this.coordinates,
    map: this.map,
  });

  markers = [
    {
      position: new google.maps.LatLng(47.999321, 27.3210231),
      map: this.map,
      title: "apartmant cu 2 camere in unirii",
    },
    {
      position: new google.maps.LatLng(47.876354, 27.1230525),
      map: this.map,
      title: "apartament cu 2 camere in copou",
    },
  ];

  constructor() {}

  ngAfterViewInit() {
    this.mapInitializer();
  }

  private mapInitializer() {
    this.map = new google.maps.Map(this.gmap.nativeElement, this.mapOptions);
    this.marker.setMap(this.map);
    this.marker.addListener("click", () => {
      const infoWindow = new google.maps.InfoWindow({
        content: this.marker.getTitle(),
      });
      infoWindow.open(this.marker.getMap(), this.marker);
    });
    this.loadAllMarkers();
  }

  private loadAllMarkers() {
    this.markers.forEach((markerInfo) => {
      const marker = new google.maps.Marker({
        ...markerInfo,
      });
      const infoWindow = new google.maps.InfoWindow({
        content: marker.getTitle(),
      });
      marker.addListener("click", () => {
        infoWindow.open(marker.getMap(), marker);
      });
      marker.setMap(this.map);
    });
  }
}
