import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  standalone: true,
  imports: [CommonModule],
  selector: 'app-grade',
  templateUrl: './grade.component.html',
  styleUrl: './grade.component.css'
})
export class GradeComponent {
  @Input() user: any;
  @Input() exitModal = (): void => { };
}
