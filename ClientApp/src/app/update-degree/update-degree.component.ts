import { Component, OnInit } from "@angular/core";
import { DegreeService } from "src/app/services/degree.service";
import { ActivatedRoute, Router } from "@angular/router";
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: 'app-update-degree',
  templateUrl: './update-degree.component.html',
  styleUrls: ['./update-degree.component.css']
})
export class UpdateDegreeComponent implements OnInit{
  isSubmitted = false;

  updateDegreeForm: FormGroup = new FormGroup({
    // Define your form controls here
    name: new FormControl(''),
  });;
  degree: any;

  constructor(
	private service: DegreeService,
	private route: ActivatedRoute,
	private router: Router,
	private fb: FormBuilder
  ) {}

  ngOnInit() {
	this.service.getDegreeById(this.route.snapshot.params.id).subscribe(data => {
    console.log(data);
	  this.degree = data;

	  // construct the formGroup
	  this.updateDegreeForm = this.fb.group({
		id: [data.id],
		name: [data.name, Validators.required]
	  });
	});
  }
  
  onSubmit() {
	this.service.updateDegree(this.updateDegreeForm.value).subscribe(data => {
	  this.router.navigate(["/degrees"]);
	});
  }
}