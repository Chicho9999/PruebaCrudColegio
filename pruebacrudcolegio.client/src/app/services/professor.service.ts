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

  getAll() {
    return this.http.get<Professor[]>(this.url);
  }

  updateProfessor(professor: Professor) {
    return this.http.put<Professor[]>(`${this.url}`, professor);
  }

  addProfessor(professorToCreate: any) {
    return this.http.post<Professor>(this.url, professorToCreate);
  }

  deleteProfessor(id: string) {
    return this.http.delete(`${this.url}${id}`);
  }
}
