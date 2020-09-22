import { Component, Input, Output, EventEmitter } from '@angular/core';
import { RegisterService } from '../services/register.service';
import { AlertifyService } from '../services/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
/** register component*/
export class RegisterComponent {
  @Output() cancelRegister = new EventEmitter();

  model: any = {};
  

  /** register ctor */
  constructor(private registerService: RegisterService, private alertify: AlertifyService) {

  }

  register() {
    this.registerService.registerNewUser(this.model).subscribe(
      () => {
        this.alertify.success('Registration successfull');
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  cancel() {
    this.cancelRegister.emit(false);
    this.alertify.message('canceled by the user');
  }
}
