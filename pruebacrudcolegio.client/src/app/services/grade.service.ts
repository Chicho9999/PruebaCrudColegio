import { Injectable, inject } from '@angular/core';
import { Grade } from '../models/grade';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class CollegeService {
  private http = inject(HttpClient);
  private url = 'http://localhost:5053/api/Grade/';
  private grades : Grade[] = [];

  getColleges() {
    return this.http.get<Grade[]>(this.url);
  }
}
