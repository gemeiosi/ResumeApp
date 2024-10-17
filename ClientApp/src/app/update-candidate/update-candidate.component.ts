import { Component, OnInit } from "@angular/core";
import { CandidateService } from "src/app/services/candidate.service";
import { DegreeService } from "src/app/services/degree.service";
import { ActivatedRoute, Router } from "@angular/router";
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: 'app-update-candidate',
  templateUrl: './update-candidate.component.html',
  styleUrls: ['./update-candidate.component.css']
})
export class UpdateCandidateComponent implements OnInit{
  isSubmitted = false;

  public degrees: any = [];
  updateCandidateForm: FormGroup = new FormGroup({
    // Define your form controls here
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl(''),
    mobile: new FormControl(''),
    degree: new FormControl(''),
    cv: new FormControl(''),
  });;
  candidate: any;

  constructor(
	private service: CandidateService,
  private degreeService: DegreeService,
	private route: ActivatedRoute,
	private router: Router,
	private fb: FormBuilder
  ) {}

  ngOnInit() {
  this.degreeService.getAllDegrees().subscribe(data => {	//=> Call Method from Angular Service
    console.log();
    this.degrees = data.map(x=>x.name);				//=> Handle the Response
  })
	this.service.getCandidateById(this.route.snapshot.params.id).subscribe(data => {
	  this.candidate = data;

	  // construct the formGroup
	  this.updateCandidateForm = this.fb.group({
      id: [data.id],
      firstName: [data.firstName, Validators.required],
      lastName: [data.lastName, Validators.required],
      email: [data.email, Validators.compose([Validators.required, Validators.email])],
      mobile: [data.mobile, Validators.compose([Validators.min(10)])],
      degree:[
        data.degree
      ],
      cv: [
          data.cv,
      ],
    });
	});
  }
  
  onSubmit() {
	this.service.updateCandidate(this.updateCandidateForm.value).subscribe(data => {
	  this.router.navigate(["/candidates"]);
	});
  }
}