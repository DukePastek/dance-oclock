import { Component, inject } from '@angular/core';
import { MatIconButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { ThemeService } from '../../core/services/theme.service';

@Component({
  selector: 'app-theme-toggle',
  imports: [MatIconButton, MatIcon],
  templateUrl: './theme-toggle.html'
})
export class ThemeToggle {
  protected readonly themeService = inject(ThemeService);
}
