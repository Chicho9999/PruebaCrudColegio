import { CommonModule } from '@angular/common';
import { Component, Input, OnInit, inject } from '@angular/core';
import { ModalService } from '../services/modal.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { StudentGradeService } from '../services/studentGrade.service';
import { StudentGrade } from '../models/studentGrade';
import { GradeService } from '../services/grade.service';
import { Grade } from '../models/grade';
import { StudentService } from '../services/user.service';

@Component({
  standalone: true,
  imports: [CommonModule],
  selector: 'app-grade',
  templateUrl: './grade.component.html',
  styleUrl: './grade.component.css'
})
export class GradeComponent implements OnInit {

  private readonly modalService = inject(ModalService);
  private readonly studentGradeService = inject(StudentGradeService);
  private readonly gradeService = inject(GradeService);
  matDialog = inject(MAT_DIALOG_DATA);
  gradesByStudent!: StudentGrade[];
  grades!: Grade[];
  section!: number;
  selectedGrade!: Grade | undefined;

  ngOnInit(): void {
    this.section = 1;
    this.GetGradesByUser(this.matDialog.data);
    if (this.matDialog.isEditing) {
      this.GetAllGrades();
    }
  }

  GetAllGrades() {
    this.gradeService.getGrades().subscribe(grades => {
      this.grades = grades;
      this.selectedGrade = this.grades[0];
    });
  }

  exitModal() {
    this.modalService.closeModal();
  };

  GetGradesByUser(userId: string) {
    this.studentGradeService.getStudentGradesByUserId(userId).subscribe(
      grades => this.gradesByStudent = grades
    );
  }

  updateGradeSelected($event: any) {
    this.selectedGrade = this.grades.find(g => g.id == $event.target.value);
  }

  updateSection($event: any) {
    this.section = $event.target.value;
  }

  addGrade() {
    if (this.selectedGrade != undefined) {
      if (!this.gradesByStudent.some(x => x.gradeId == this.selectedGrade?.id && x.studentId == this.matDialog.data)) {
        var newGrade = {
          id: '00000000-0000-0000-0000-000000000000',
          studentId: this.matDialog.data,
          gradeId: this.selectedGrade.id,
          professorId: this.selectedGrade.professorId,
          gradeName: this.selectedGrade.name,
          section: this.section,
          professorName: this.selectedGrade.professorName
        }
        this.gradesByStudent.push(newGrade as StudentGrade);
      }
    }
  }
  saveGrades() {
    this.studentGradeService.saveStudentGrades(this.gradesByStudent, this.matDialog.data).subscribe(x => this.exitModal());
  }

  removeGrade(grade: StudentGrade) {
    this.gradesByStudent = this.gradesByStudent.filter(x => x.id != grade.id);
  }
}
