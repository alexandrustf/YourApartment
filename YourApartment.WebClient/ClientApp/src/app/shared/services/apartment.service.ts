import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Apartment } from "../models/apartment.model";
import { map } from "rxjs/operators";
import { environment } from "src/environments/environment";
import { PageModel } from "../models/page.model";

@Injectable({
  providedIn: "root"
})
export class ApartmentService {
  public constructor(private http: HttpClient) {}

  public getApartments(): Observable<PageModel<Apartment>> {
    let filters: string = "";
    filters = name ? filters.concat(`Name@=${name}`) : filters.concat();

    return this.http
      .get<PageModel<Apartment>>(
        `${environment.YourApartmentUrl}/Apartments`,
        {}
      )
      .pipe(
        map(res => {
          const pageModel: PageModel<Apartment> = new PageModel<Apartment>();
          pageModel.totalNumberOfRecords = res.totalNumberOfRecords;
          pageModel.records = res.records.map(s =>
            Object.assign(new Apartment(), s)
          );
          return pageModel;
        })
      );
  }
}
