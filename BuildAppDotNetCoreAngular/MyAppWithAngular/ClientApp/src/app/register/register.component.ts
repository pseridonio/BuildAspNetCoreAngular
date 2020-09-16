import { Component, Input, Output, EventEmitter } from '@angular/core';
import { RegisterService } from '../services/register.service';

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
  constructor(private registerService: RegisterService) {

  }

  register() {
    this.registerService.registerNewUser(this.model).subscribe(
      () => {
        console.log('Registration successfull');
      },
      error => {
        console.log(error);
      }
    );
  }

  cancel() {
    this.cancelRegister.emit(false);
    console.log('canceled by the user');
  }
}
