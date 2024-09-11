import { Injectable, inject } from '@angular/core';
import { Student } from '../models/student';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class StudentService {
  private http = inject(HttpClient);
  private url = 'http://localhost:5053/api/Student/';

  getStudents() {
    return this.http.get<Student[]>(this.url);
  }

  addStudent(student: any): Observable<Student>{
    return this.http.post<Student>(this.url, student)
  }

  updateStudent(student: Student): Observable<Student>{
    return this.http.put<Student>(this.url, student)
  }

  deleteStudent(studentId: string) {
    return this.http.delete(`${this.url}${studentId}`);
  }
}
