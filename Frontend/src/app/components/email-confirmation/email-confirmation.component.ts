import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmEmailModel } from 'src/app/models/auth';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-email-confirmation',
  templateUrl: './email-confirmation.component.html',
  styleUrls: ['./email-confirmation.component.css']
})
export class EmailConfirmationComponent {
  email: string;
  token: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService
  ){
    this.route.queryParams.subscribe(p => {
      this.email = p['email'];
      this.token = p['token'];

      this.confirmEmail();
    })
  }

  confirmEmail(){
    const model = new ConfirmEmailModel();
    model.email = this.email;
    model.token = this.token;

    this.authService.confirmEmail(model).subscribe(_ => {
      this.router.navigateByUrl('/');
    })
  }
}
