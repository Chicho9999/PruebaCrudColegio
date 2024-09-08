import { CommonModule } from '@angular/common';
import { Component, Input, OnInit, inject } from '@angular/core';
import { ModalService } from '../services/modal.service';
import { MAT_DIALOG_DATA, MatDialogContent } from '@angular/material/dialog';
import { Grade } from '../models/grade';
import { GradeService } from '../services/grade.service';

@Component({
  standalone: true,
  imports: [CommonModule],
  selector: 'app-grade',
  templateUrl: './grade.component.html',
  styleUrl: './grade.component.css'
})
export class GradeComponent implements OnInit {

  private readonly modalService = inject(ModalService);
  private readonly gradeService = inject(GradeService);
  private readonly matDialog = inject(MAT_DIALOG_DATA);
  grades!: Grade[];

  ngOnInit(): void {
    this.gradeService.getGradesByUserId(this.matDialog.data).subscribe(grades =>
      this.grades = grades
    );;
  }

  @Input() user: any;
  exitModal() {
    this.modalService.closeModal();
  };
}
