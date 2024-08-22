import { Injectable, inject } from '@angular/core';
import { User } from '../models/user';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private http = inject(HttpClient);

  private readonly users = this.getApiUsers();

  /**
   * @returns 
   */
  getApiUsers() {
    return this.http.get<User[]>('http://localhost:5053/api/student');
  }

  /**
   * @returns 
   */
  addApiUser(user: User) {
    return this.http.post<User>('http://localhost:5053/api/student', user);
  }

  getAllUsers(): User[] {
    return this.users;
  }

  addUser(user: User) {
    user.id = this.users.length + 1;
    this.users.push(user);
  }

  updateUser(user: User) {
    const index = this.users.findIndex((u) => user.id === u.id);
    this.users[index] = user;
  }

  deleteUser(user: User) {
    this.users.splice(this.users.indexOf(user), 1);
  }
}
