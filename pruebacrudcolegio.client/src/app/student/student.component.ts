import { Component, OnInit, TemplateRef, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { StudentService } from '../services/user.service';
import { GradeService } from '../services/grade.service';
import { ModeEnum } from '../models/mode.enum';
import { Student } from '../models/student';
import { Professor } from '../models/professor';
import { Grade } from '../models/grade';
import { NavbarComponent } from '../navbar/navbar.component';
import { GradeComponent } from '../grade/grade.component';
import { ModalService } from '../services/modal.service';

@Component({
  selector: 'app-student',
  standalone: true,
  imports: [ReactiveFormsModule, NavbarComponent, GradeComponent],
  templateUrl: './student.component.html',  
  styleUrl: './student.component.css'
})

export class StudentComponent implements OnInit {
  private studentService = inject(StudentService);
  private gradeService = inject(GradeService);
  private modalService = inject(ModalService);
  private formBuilder = inject(FormBuilder);

  form = this.formBuilder.group({
    id: [''],
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    gender: ['', Validators.required],
    birthday: ['', Validators.required],
  });

  ModeEnum = ModeEnum;
  users!: Student[];
  professors!: Professor[];
  grades!: Grade[];
  mode = ModeEnum.NON;

  ngOnInit(): void {
    this.setUsers();
  }

  setUsers() {
    this.studentService.getUsers().subscribe(students =>
      this.users = students
    );
  }

  setGrades() {
    this.gradeService.getGrades().subscribe(grades =>
      this.grades = grades
    );
  }

  addNewUser() {
    this.mode = ModeEnum.ADD;
  }

  editUser(user: Student) {
    this.mode = ModeEnum.EDIT;
    this.form.setValue(user);
  }

  seeGrades(userId: string) {
    this.modalService.openModal(GradeComponent, userId, false);
  }

  closeModalFunction() {
  }

  saveUser() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    const user = this.form.value as Student;

    if (this.mode === ModeEnum.ADD) {

      const userToCreate = {
        firstName: user.firstName,
        lastName: user.lastName,
        gender: user.gender,
        birthday: user.birthday
      }

      this.studentService.addUser(userToCreate).subscribe(x => this.setUsers());
    } else {
      this.studentService.updateUser(user).subscribe(x => this.setUsers());
    }
    this.cancel();
  }

  removeUser(user: Student) {
    this.studentService.deleteUser(user.id).subscribe(x => this.setUsers());
  }

  cancel() {
    this.form.reset();
    this.mode = ModeEnum.NON;
  }
}
