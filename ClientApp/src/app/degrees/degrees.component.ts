import { Component, OnInit } from '@angular/core';
import { DegreeService } from "src/app/services/degree.service";
import { Router } from '@angular/router';

@Component({
  selector: 'app-degrees',
  templateUrl: './degrees.component.html',
  styleUrls: ['./degrees.component.css']
})
export class DegreesComponent implements OnInit {
  public degrees: Degree[] = [];

  constructor(
    private service: DegreeService,
    private router: Router,
  ) {}  //=> inject the service we created
  
  deleteDegree(id: number) {
    alert("Are you sure?");
    this.service.deleteDegree(id).subscribe(data => {
      this.router.navigate(["/degrees"]);
    });
  }
  deleteAllDegrees() {
    alert("Are you sure?");
    this.service.deleteAllDegrees().subscribe(data => {
      this.router.navigate(["/degrees"]);
    });
  }
  ngOnInit() {		
  this.service.getAllDegrees().subscribe(data => {	//=> Call Method from Angular Service
    this.degrees = data;				//=> Handle the Response
  })
  }
}

interface Degree {
  id: number;
  name: string;
  creationTime: Date;
}

