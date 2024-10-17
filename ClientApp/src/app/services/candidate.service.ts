// 1. define the base URL
 // 2. inject the HTTP client to be able to send HTTP requests to our Web API - cstr param
 // 3. create a method to get all books

 import { Injectable } from '@angular/core';
 import { HttpClient } from '@angular/common/http';

 @Injectable({
 providedIn: 'root'
 })
 	export class CandidateService {

 	_baseURL: string = "https://localhost:7169/api";		      //=> base URL

 	constructor(private http: HttpClient) { } //=> inject HttpClient

 	getAllCandidates() {						      //=> Create a Method in Angular Service
 	return this.http.get<Candidate[]>(this._baseURL + "/candidates");
 	}

	addCandidate(candidate: Candidate)
	{
		return this.http.post(this._baseURL+"/candidates", candidate);
	}
	getCandidateById(id: number) {
		return this.http.get<Candidate>(this._baseURL + "/candidates/" + id);
	  }
	
	updateCandidate(candidate: Candidate) {
	return this.http.put(this._baseURL + "/candidates/" + candidate.id, candidate);
	}

	deleteCandidate(id: number) {
	return this.http.delete(this._baseURL + "/candidates/" + id);
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
