import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { AuthService } from "../shared/services/auth.service";
import { AuthenticationToken } from "../shared/models/authentication-token.model";

@Component({
  selector: "app-nav-menu",
  templateUrl: "./nav-menu.component.html",
  styleUrls: ["./nav-menu.component.scss"],
})
export class NavMenuComponent {
  isExpanded = false;
  currentUser: AuthenticationToken;
  constructor(private router: Router, private authService: AuthService) {
    this.authService.currentUser.subscribe((x) => (this.currentUser = x));
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  logout() {
    this.authService.logout();
    this.router.navigate(["/my-account"]);
  }
}
