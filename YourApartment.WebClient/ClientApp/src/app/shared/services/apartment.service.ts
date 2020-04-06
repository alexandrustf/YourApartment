import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
import { Apartment } from "../models/apartment.model";
import { map } from "rxjs/operators";
import { environment } from "src/environments/environment";
import { PageModel } from "../models/page.model";
import { FilterModel } from "../models/filter.model";

@Injectable({
  providedIn: "root",
})
export class ApartmentService {
  public constructor(private http: HttpClient) {}

  public getApartments(
    filterModel: FilterModel
  ): Observable<PageModel<Apartment>> {
    let filters: string = "";
    filters = name
      ? filters.concat(`Name@=${filterModel.name}`)
      : filters.concat();

    for (let property of Object.keys(filterModel)) {
      if (property !== "page" && property !== "pageSize" && property !== "Name")
        filters = filters.concat(`${property}==${filterModel[property]},`);
    }

    let params: HttpParams = new HttpParams().append("filters", filters);

    params = filterModel.page
      ? params.append("page", filterModel.page.toString())
      : params;
    params = filterModel.pageSize
      ? params.append("pageSize", filterModel.pageSize.toString())
      : params;

    return this.http
      .get<PageModel<Apartment>>(`${environment.YourApartmentUrl}/Apartments`, {
        params: params,
      })
      .pipe(
        map((res) => {
          const pageModel: PageModel<Apartment> = new PageModel<Apartment>();
          pageModel.totalNumberOfRecords = res.totalNumberOfRecords;
          pageModel.records = res.records.map((s) =>
            Object.assign(new Apartment(), s)
          );
          return pageModel;
        })
      );
  }
}
