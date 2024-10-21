import { Component, OnInit } from "@angular/core";
import { CandidateService } from "src/app/services/candidate.service";
import { Router } from '@angular/router';

@Component({
  selector: "app-candidates",
  templateUrl: "./candidates.component.html",
  styleUrls: ["./candidates.component.css"]
})
export class CandidatesComponent implements OnInit {
  public candidates: Candidate[] = [];
  
  constructor(
    private service: CandidateService,
    private router: Router
  ) {}  //=> inject the service we created
  
  deleteCandidate(id: number) {
    alert("Are you sure?");
    this.service.deleteCandidate(id).subscribe(data => {
      window.location.reload();
    });
  }
  ngOnInit() {		
  this.service.getAllCandidates().subscribe(data => {	//=> Call Method from Angular Service
    this.candidates = data;				//=> Handle the Response
  })
  }
}

interface Candidate {
	id: number;
    firstName: string;
    lastName: string;
    email: string;
    mobile: string;
    degree: string;
    cv: string;
    creationTime: Date;
  }