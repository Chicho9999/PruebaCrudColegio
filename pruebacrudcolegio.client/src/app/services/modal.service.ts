import { ComponentType } from '@angular/cdk/portal';
import { Injectable, inject } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

@Injectable({ providedIn: 'root' })
export class ModalService {
  private readonly _dialog = inject(MatDialog);

  openModal<CT, T>(componentRef: ComponentType<CT>, data?: T, isEditing = false): void {
    const config = {
      data,
      isEditing
    }

    this._dialog.open(componentRef, {
      data: config,
      height: '300px',
      width: '800px'
    });
  }
  closeModal(): void {
    this._dialog.closeAll();
  }
}
