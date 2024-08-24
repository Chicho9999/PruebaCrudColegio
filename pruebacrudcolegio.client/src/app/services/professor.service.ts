import { Injectable, inject } from '@angular/core';
import { Professor } from '../models/professor';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ProfessorService {
  private http = inject(HttpClient);
  private url = 'http://localhost:5053/api/Professor/';
  private professors : Professor[] = [];

  getProfessors() {
    return this.http.get<Professor[]>(this.url);
  }
}
