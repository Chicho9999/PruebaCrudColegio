import { Injectable, inject } from '@angular/core';
import { User } from '../models/user';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private http = inject(HttpClient);
  private url = 'http://localhost:5053/api/student';
  private users : User[] = [];

  getUsers() {
    return this.http.get<User[]>(this.url);
  }

  addUser(user: User) {
    this.http.post<User>(this.url, user)
  }

  updateUser(user: User) {
    this.http.put<User>(this.url, user)
  }

  deleteUser(user: User) {
    this.http.delete<User>(this.url + user.id)
  }
}
