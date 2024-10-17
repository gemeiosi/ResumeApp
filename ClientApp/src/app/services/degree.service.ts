// 1. define the base URL
 // 2. inject the HTTP client to be able to send HTTP requests to our Web API - cstr param
 // 3. create a method to get all books

 import { Injectable } from '@angular/core';
 import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DegreeService {

  _baseURL: string = "https://localhost:7169/api";		      //=> base URL

 	constructor(private http: HttpClient) { } //=> inject HttpClient

  getAllDegrees() {						      //=> Create a Method in Angular Service
    return this.http.get<Degree[]>(this._baseURL + "/degrees");
  }

  addDegree(degree: Degree)
	{
		return this.http.post(this._baseURL+"/degrees", degree);
	}

  getDegreeById(id: number) {
    return this.http.get<Degree>(this._baseURL + "/degrees/" + id);
  }

  updateDegree(degree: Degree) {
    return this.http.put(this._baseURL + "/degrees/" + degree.id, degree);
  }

  deleteDegree(id: number) {
    return this.http.delete(this._baseURL + "/degrees/" + id);
  }
  deleteAllDegrees() {
    return this.http.delete(this._baseURL + "/degrees/");
  }
}

interface Degree {
  id: number;
  name: string;
  creationTime: Date;
}
