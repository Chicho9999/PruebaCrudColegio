import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ModeEnum } from '../models/mode.enum';
import { Student } from '../models/student';
import { Professor } from '../models/professor';
import { NavbarComponent } from '../navbar/navbar.component';
import { GradeComponent } from '../grade/grade.component';
import { ModalService } from '../services/modal.service';
import { StudentService } from '../services/user.service';
import { CommonModule, formatDate } from '@angular/common';
import { StudentGradeService } from '../services/studentGrade.service';
import { StudentGrade } from '../models/studentGrade';

@Component({
  selector: 'app-student',
  standalone: true,
  imports: [ReactiveFormsModule, NavbarComponent, GradeComponent, CommonModule],
  templateUrl: './student.component.html',  
  styleUrl: './student.component.css'
})

export class StudentComponent implements OnInit {
  ModeEnum = ModeEnum;
  students!: Student[];
  professors!: Professor[];
  grades!: StudentGrade[];
  studentGrades!: StudentGrade[];
  mode = ModeEnum.NON;
  studentId!: string;

  private studentService = inject(StudentService);
  private gradeService = inject(StudentGradeService);
  private modalService = inject(ModalService);
  private formBuilder = inject(FormBuilder);

  form = this.formBuilder.group({
    id: [''],
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    gender: ['', Validators.required],
    birthDay: [formatDate(new Date(), 'dd-MM-yyyy', 'en'), [Validators.required]]
  });

  ngOnInit(): void {
    this.setStudents();
  }

  setStudents() {
    this.studentService.getStudents().subscribe(students =>
      this.students = students
    );
  }

  setGradesByUserId(studentId: string): StudentGrade[] {
    this.gradeService.getStudentGradesByUserId(studentId).subscribe(grades => this.grades = grades);
    return this.grades;
  }

  addNewStudent() {
    this.mode = ModeEnum.ADD;
  }

  editStudent(student: Student) {
    this.mode = ModeEnum.EDIT;
    this.studentId = student.id;
    this.studentGrades = this.setGradesByUserId(student.id)
    this.form.setValue(student);
  }

  seeGrades(studentId: string, isEditting: boolean) {
    this.modalService.openModal(GradeComponent, studentId, isEditting);
  }

  saveStudent() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    const student = this.form.value as Student;

    if (this.mode === ModeEnum.ADD) {

      const studentToCreate = {
        firstName: student.firstName,
        lastName: student.lastName,
        gender: student.gender,
        birthday: student.birthDay
      }

      this.studentService.addStudent(studentToCreate).subscribe(x => this.setStudents());
    } else {
      this.studentService.updateStudent(student).subscribe(x => this.setStudents());
    }
    this.cancel();
  }

  removeStudent(student: Student) {
    this.studentService.deleteStudent(student.id).subscribe(x => this.setStudents());
  }

  cancel() {
    this.form.reset();
    this.mode = ModeEnum.NON;
  }
}
