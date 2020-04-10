import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
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

  public getApartments(
    name?: string,
    page?: number,
    pageSize?: number
  ): Observable<PageModel<Apartment>> {
    let filters: string = "";
    filters = name ? filters.concat(`Name@=${name}`) : filters.concat();

    let params: HttpParams = new HttpParams().append("filters", filters);

    params = page ? params.append("page", page.toString()) : params;
    params = pageSize ? params.append("pageSize", pageSize.toString()) : params;

    return this.http
      .get<PageModel<Apartment>>(`${environment.YourApartmentUrl}/Apartments`, {
        params: params
      })
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
