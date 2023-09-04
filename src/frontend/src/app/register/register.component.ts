import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators,AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms'


export const confirmPasswordValidator: ValidatorFn = (
  control: AbstractControl
): ValidationErrors | null => {
  return control.value.password === control.value.repeatPassword
    ? null
    : { PasswordNoMatch: true };
};

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})



export class RegisterComponent implements OnInit {
  RegisterGroup: FormGroup;
  constructor(private fb: FormBuilder) {}
  
  
  
  ngOnInit(): void {
    this.RegisterGroup = this.fb.group({
      username: ['',[Validators.required,Validators.minLength(5)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(20)]],
      repeatPassword: ['', [Validators.required]]}, {validators: [confirmPasswordValidator]},
    );
  }

  onSubmit(registerForm: FormGroup) {
    if (registerForm.valid) {
      // Passwords match, handle form submission
      console.log('Passwords match:', registerForm.value.password);
    } else {
      // Passwords do not match, display an error message
      console.log('Passwords do not match');
    }
}
}