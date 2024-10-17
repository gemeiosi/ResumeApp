import { Component, OnInit } from "@angular/core";
  import { CandidateService } from "src/app/services/candidate.service";
  import { DegreeService } from "src/app/services/degree.service";
  import { FormGroup, FormBuilder, Validators } from "@angular/forms";
  import { Router } from "@angular/router";

@Component({
  selector: 'app-new-candidate',
  templateUrl: './new-candidate.component.html',
  styleUrls: ['./new-candidate.component.css']
})
export class NewCandidateComponent implements OnInit {
  // create a formGroup to use in the form
  isSubmitted = false;

  public degrees: any = [];
  addCandidateForm: FormGroup = new FormGroup({
    // Define your form controls here
  });;

  // inject the service
  constructor(
  private candidateService: CandidateService,
  private degreeService: DegreeService,
  private fb: FormBuilder,
  private router: Router
  ) {}

  ngOnInit() {
    this.degreeService.getAllDegrees().subscribe(data => {	//=> Call Method from Angular Service
      console.log();
      this.degrees = data.map(x=>x.name);				//=> Handle the Response
    })
  // construct the formGroup
  this.addCandidateForm = this.fb.group({
    firstName: [null, Validators.required],
    lastName: [null, Validators.required],
    email: [null, Validators.compose([Validators.required, Validators.email])],
    mobile: [null, Validators.compose([Validators.minLength(10), Validators.maxLength(10)])],
    degree:[
      null
    ],
    cv: [
        null,
    ],
  });
  }
  // Choose degree using select dropdown
  /*changeDegree(e) {
    console.log(e.value)
    this.Degree.setValue(e.target.value, {
      onlySelf: true
    })
  }*/

  // Getter method to access formcontrols
  get degree() {
    return this.addCandidateForm.get('degree');
  }

  onSubmit() {
    this.isSubmitted = true;
    if (!this.addCandidateForm.valid) {
      console.log(JSON.stringify(this.addCandidateForm.value))
    } else {
      this.candidateService.addCandidate(this.addCandidateForm.value).subscribe(data => {
        this.router.navigate(["/candidates"]);  // the router service is injected to the constructor.
      });
    }
    }
}