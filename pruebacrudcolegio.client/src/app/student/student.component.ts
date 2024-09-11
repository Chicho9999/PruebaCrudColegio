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
  studentToEdit!: Student;
  professors!: Professor[];
  grades!: StudentGrade[];
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
    this.studentService.getStudents().subscribe(students => {
      for (var i = 0; i < students.length; i++) {
        var currentStudent = students[i];
        this.setGradesByUserId(currentStudent);
      }
      this.students = students
    });
  }

  setGradesByUserId(student: Student): StudentGrade[] {
    this.gradeService.getStudentGradesByUserId(student.id).subscribe(grades => student.grades = grades);
    return this.grades;
  }

  addNewStudent() {
    this.mode = ModeEnum.ADD;
    this.studentToEdit = {} as Student;
    this.studentToEdit.grades = [] as StudentGrade[];
  }

  editStudent(student: Student) {
    this.mode = ModeEnum.EDIT;
    this.studentToEdit = student;
    this.form.setValue(student);
  }

  seeGrades(student: Student, isEditting: boolean) {
    this.modalService.openModal(GradeComponent, student, isEditting);
  }

  saveStudent() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    const student = this.form.value as Student;
    student.grades = this.studentToEdit.grades;

    if (this.mode === ModeEnum.ADD) {
      const studentToCreate = {
        firstName: student.firstName,
        lastName: student.lastName,
        gender: student.gender,
        birthday: student.birthDay,
        grades: student.grades
      }

      this.studentService.addStudent(studentToCreate).subscribe(() => this.setStudents());
    } else {
      this.studentService.updateStudent(student).subscribe(() => this.setStudents());
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
