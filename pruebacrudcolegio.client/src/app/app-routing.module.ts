import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentComponent } from './student/student.component';
import { HomeComponent } from './home/home.component';
import { GradeComponent } from './grade/grade.component';
import { ProfessorComponent } from './professor/professor.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'grade', component: GradeComponent },
  { path: 'student', component: StudentComponent },
  { path: 'professor', component: ProfessorComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
