import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { ModalService } from '../services/modal.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { StudentGrade } from '../models/studentGrade';
import { Grade } from '../models/grade';
import { GradeService } from '../services/grade.service';

@Component({
  standalone: true,
  imports: [CommonModule],
  selector: 'app-grade',
  templateUrl: './gradeModal.component.html'
})
export class GradeComponent implements OnInit {

  private readonly modalService = inject(ModalService);
  private readonly gradeService = inject(GradeService);
  matDialog = inject(MAT_DIALOG_DATA);
  grades!: Grade[];
  section!: number;
  selectedGrade!: Grade | undefined;

  ngOnInit(): void {
    this.section = 1;
    if (this.matDialog.isEditing) {
      this.GetAllGrades();
    }
  }

  GetAllGrades() {
    this.gradeService.getAll().subscribe(grades => {
      this.grades = grades;
      this.selectedGrade = this.grades[0];
    });
  }

  exitModal() {
    this.modalService.closeModal();
  };

  updateGradeSelected($event: any) {
    this.selectedGrade = this.grades.find(g => g.id == $event.target.value);
  }

  updateSection($event: any) {
    this.section = $event.target.value;
  }

  addGrade() {
    if (this.selectedGrade != undefined) {
      if (!this.matDialog.data.grades.some((x: { gradeId: string | undefined; studentId: any; }) => x.gradeId == this.selectedGrade?.id && x.studentId == this.matDialog.data.id)) {
        var newGrade = {
          id: '00000000-0000-0000-0000-000000000000',
          studentId: this.matDialog.data ? this.matDialog.data.id : '00000000-0000-0000-0000-000000000000',
          gradeId: this.selectedGrade.id,
          professorId: this.selectedGrade.professorId,
          gradeName: this.selectedGrade.name,
          section: this.section,
          professorName: this.selectedGrade.professorName
        }
        this.matDialog.data.grades.push(newGrade as StudentGrade);
      }
    }
  }

  removeGrade(grade: StudentGrade) {
    this.matDialog.data.grades = this.matDialog.data.grades.filter((y: { id: string; }) => y.id != grade.id);
  }
}
