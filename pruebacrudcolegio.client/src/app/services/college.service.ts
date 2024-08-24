import { Injectable, inject } from '@angular/core';
import { College } from '../models/college';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class CollegeService {
  private http = inject(HttpClient);
  private url = 'http://localhost:5053/api/College/';
  private colleges : College[] = [];

  getColleges() {
    return this.http.get<College[]>(this.url);
  }
}
