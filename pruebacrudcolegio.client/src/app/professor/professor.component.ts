import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { NavbarComponent } from '../navbar/navbar.component';
import { CommonModule } from '@angular/common';
import { ModeEnum } from '../models/mode.enum';
import { ProfessorService } from '../services/professor.service';
import { Professor } from '../models/professor';

@Component({
  standalone: true,
  imports: [ReactiveFormsModule, NavbarComponent, CommonModule],
  selector: 'app-professor',
  templateUrl: './professor.component.html'
})
export class ProfessorComponent {

  private formBuilder = inject(FormBuilder);
  private professorService = inject(ProfessorService);

  ModeEnum = ModeEnum;
  mode = ModeEnum.NON;
  professors!: Professor[];

  form = this.formBuilder.group({
    id: [''],
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    gender: ['', Validators.required]
  });

  ngOnInit(): void {
    this.setProfessors();
  }

  setProfessors() {
    this.professorService.getAll().subscribe(ps => this.professors = ps);
  }

  addNewProfessor() {
    this.mode = ModeEnum.ADD;
  }

  editProfessor(professor: Professor) {
    this.mode = ModeEnum.EDIT;
    this.form.setValue(professor);
  }

  saveProfessor() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    const professor = this.form.value as Professor;

    if (this.mode === ModeEnum.ADD) {

      const professorToCreate = {
        firstName: professor.firstName,
        lastName: professor.lastName,
        gender: professor.gender
      }

      this.professorService.addProfessor(professorToCreate).subscribe(() => this.setProfessors());
    } else {
      this.professorService.updateProfessor(professor).subscribe(() => this.setProfessors());
    }

    this.cancel();
  }

  removeProfessor(grade: Professor) {
    this.professorService.deleteProfessor(grade.id).subscribe(x => this.setProfessors());
  }

  cancel() {
    this.form.reset();
    this.mode = ModeEnum.NON;
  }

}
