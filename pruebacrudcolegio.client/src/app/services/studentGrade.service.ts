import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StudentGrade } from '../models/studentGrade';

@Injectable({
  providedIn: 'root',
})
export class StudentGradeService {
  private http = inject(HttpClient);
  private url = 'http://localhost:5053/api/StudentGrade/';

  getStudentGrades() {
    return this.http.get<StudentGrade[]>(this.url);
  }

  getStudentGradesByUserId(studentId: string) {
    return this.http.get<StudentGrade[]>(`${this.url}ByStudentId/${studentId}`);
  }

  saveStudentGrades(gradesByStudent: StudentGrade[], studentId: string) {
    return this.http.put<StudentGrade[]>(`${this.url}updateStudentGrades/${studentId}`, gradesByStudent);
  }
}
