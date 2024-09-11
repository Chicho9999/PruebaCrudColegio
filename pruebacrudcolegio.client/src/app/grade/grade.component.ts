import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { GradeService } from '../services/grade.service';
import { Grade } from '../models/grade';
import { ModeEnum } from '../models/mode.enum';
import { NavbarComponent } from '../navbar/navbar.component';
import { CommonModule } from '@angular/common';
import { Professor } from '../models/professor';
import { ProfessorService } from '../services/professor.service';

@Component({
  standalone: true,
  imports: [ReactiveFormsModule, NavbarComponent, CommonModule],
  selector: 'app-grade',
  templateUrl: './grade.component.html'
})
export class GradeComponent {

  private formBuilder = inject(FormBuilder);
  private gradeService = inject(GradeService);
  private professorService = inject(ProfessorService);

  ModeEnum = ModeEnum;
  mode = ModeEnum.NON;
  grades!: Grade[];
  professors!: Professor[];

  form = this.formBuilder.group({
    id: [''],
    name: ['', Validators.required],
    professorName: [''],
    professorId: ['', Validators.required]
  });

  ngOnInit(): void {
    this.setGrades();
    this.setProfessors();
  }

  setGrades() {
    this.gradeService.getAll().subscribe(gs => this.grades = gs);
  }

  setProfessors() {
    this.professorService.getAll().subscribe(ps => this.professors = ps);
  }

  addNewGrade() {
    this.mode = ModeEnum.ADD;
  }

  editGrade(grade: Grade) {
    this.mode = ModeEnum.EDIT;
    this.form.setValue(grade);
  }

  saveGrade() {

    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const grade = this.form.value as Grade;

    const gradeOccupied = this.grades.filter(g => g.professorId == grade.professorId);

    if (gradeOccupied.length > 1) {
      window.alert("Please Choose another Professor without Grade!")
      return;
    }

    if (this.mode === ModeEnum.ADD) {

      const gradeToCreate = {
        name: grade.name,
        professorId: grade.professorId
      }

      this.gradeService.addGrade(gradeToCreate).subscribe(() => this.setGrades());
    } else {
      this.gradeService.updateGrade(grade).subscribe(() => this.setGrades());
    }

    this.cancel();
  }

  removeGrade(grade: Grade) {
    this.gradeService.deleteGrade(grade.id).subscribe(x => this.setGrades());
  }

  cancel() {
    this.form.reset();
    this.mode = ModeEnum.NON;
  }
}
