import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { BehaviorSubject, Observable } from "rxjs";
import { map } from "rxjs/operators";
import { AuthenticationToken } from "../models/authentication-token.model";
import { environment } from "src/environments/environment";
import { User } from "../models/user.model";

@Injectable({ providedIn: "root" })
export class AuthService {
  private currentUserSubject: BehaviorSubject<AuthenticationToken>;
  public currentUser: Observable<AuthenticationToken>;

  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<AuthenticationToken>(
      JSON.parse(localStorage.getItem("currentUser"))
    );
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): AuthenticationToken {
    return this.currentUserSubject.value;
  }

  login(email: string, password: string) {
    return this.http
      .post<any>(`${environment.YourApartmentUrl}/users/authenticate`, {
        email,
        password,
      })
      .pipe(
        map((user) => {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem("currentUser", JSON.stringify(user));
          this.currentUserSubject.next(user);
          return user;
        })
      );
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem("currentUser");
    this.currentUserSubject.next(null);
  }

  register(user: User) {
    return this.http.post(
      `${environment.YourApartmentUrl}/users/register`,
      user
    );
  }
}
