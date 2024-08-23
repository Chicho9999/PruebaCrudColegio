import { Injectable, inject } from '@angular/core';
import { User } from '../models/user';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private http = inject(HttpClient);
  private url = 'http://localhost:5053/api/Student/';
  private users : User[] = [];

  getUsers() {
    return this.http.get<User[]>(this.url);
  }

  addUser(user: any): Observable<User>{
    return this.http.post<User>(this.url, user)
  }

  updateUser(user: User): Observable<User>{
    return this.http.put<User>(this.url, user)
  }

  deleteUser(userId: string) {
    return this.http.delete(`${this.url}${userId}`);
  }
}
