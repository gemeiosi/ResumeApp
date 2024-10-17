import { Component, OnInit } from "@angular/core";
import { DegreeService } from "src/app/services/degree.service";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { HttpErrorResponse } from "@angular/common/http";

@Component({
  selector: 'app-new-degree',
  templateUrl: './new-degree.component.html',
  styleUrls: ['./new-degree.component.css']
})
export class NewDegreeComponent {
  // create a formGroup to use in the form
  isSubmitted = false;

  addDegreeForm: FormGroup = new FormGroup({
    // Define your form controls here
  });;

  // inject the service
  constructor(
    private degreeService: DegreeService,
    private fb: FormBuilder,
    private router: Router
    ) {}

    ngOnInit() {

    // construct the formGroup
    this.addDegreeForm = this.fb.group({
      name: [null, Validators.required],
    });
    }

  onSubmit() {
    this.isSubmitted = true;
    if (!this.addDegreeForm.valid) {
      console.log(JSON.stringify(this.addDegreeForm.value))
    } else {
      this.degreeService.addDegree(this.addDegreeForm.value).subscribe(data => {
        this.router.navigate(["/degrees"]);  // the router service is injected to the constructor.
      },
      (error: HttpErrorResponse)=>{
        alert(error.error);
      });
    }
    }
}