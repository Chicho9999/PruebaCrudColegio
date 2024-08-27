
import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UserService } from './services/user.service';
import { ProfessorService } from './services/professor.service';
import { CollegeService } from './services/grade.service';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { User } from './models/user';
import { ModeEnum } from './models/mode.enum';
import { Professor } from './models/professor';
import { Grade } from './models/grade';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ReactiveFormsModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  private userService = inject(UserService);
  private professorService = inject(ProfessorService);
  private collegeService = inject(CollegeService);
  private fb = inject(FormBuilder);
  form = this.fb.group({
    id: [''],
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    collegeId: ['', Validators.required], 
    collegeName: [''], 
    professorId: ['', Validators.required],
    professorName: [''], 
  });
  ModeEnum = ModeEnum;
  users!: User[];
  professors!: Professor[];
  grades!: Grade[];
  mode = ModeEnum.NON;

  ngOnInit(): void {
    this.setUsers();
    this.setProfessors();
    this.setColleges();
  }

  setUsers() {
    this.userService.getUsers().subscribe(students => 
      this.users = students
    );
  }

  setProfessors() {
    this.professorService.getProfessors().subscribe(professors =>
      this.professors = professors
    );
  }

  setColleges() {
    this.collegeService.getColleges().subscribe(grades =>
      this.grades = grades
    );
  }

  addNewUser() {
    this.mode = ModeEnum.ADD;
  }

  editUser(user: User) {
    this.mode = ModeEnum.EDIT;
    this.form.setValue(user);
    var a = 0;
  }

  saveUser() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    const user = this.form.value as User;

    if (this.mode === ModeEnum.ADD) {

      const userToCreate = {
        firstName: user.firstName,
        lastName: user.lastName,
        collegeId: user.collegeId,
        professorId: user.professorId
      }

      this.userService.addUser(userToCreate).subscribe(x => this.setUsers());
    } else {
      this.userService.updateUser(user).subscribe(x => this.setUsers());
    }
    this.cancel();
  }

  removeUser(user: User) {
    this.userService.deleteUser(user.id).subscribe(x => this.setUsers());
  }

  cancel() {
    this.form.reset();
    this.mode = ModeEnum.NON;
  }
}
