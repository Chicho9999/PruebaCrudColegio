import { Injectable, inject } from '@angular/core';
import { Grade } from '../models/grade';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class GradeService {
  private http = inject(HttpClient);
  private url = 'http://localhost:5053/api/Grade/';

  getAll() {
    return this.http.get<Grade[]>(this.url);
  }

  getGradesByUserId(studentId: string) {
    return this.http.get<Grade[]>(`${this.url}ByStudentId/${studentId}`);
  }

  saveGrades(gradesByStudent: Grade[], studentId: string) {
    return this.http.put<Grade[]>(`${this.url}updateGrades/${studentId}`, gradesByStudent);
  }

  updateGrade(grade: Grade) {
    return this.http.put<Grade[]>(`${this.url}`, grade);
  }

  addGrade(gradeToCreate: any) {
    return this.http.post<Grade>(this.url, gradeToCreate);
  }

  deleteGrade(gradeId: string) {
    return this.http.delete(`${this.url}${gradeId}`);
  }
}
