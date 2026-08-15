import { Component, inject } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { map } from 'rxjs';
import { MatToolbar } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatIconButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { ThemeToggle } from '../../shared/theme-toggle/theme-toggle';

@Component({
  selector: 'app-public-layout',
  imports: [
    RouterOutlet,
    RouterLink,
    RouterLinkActive,
    MatToolbar,
    MatSidenavModule,
    MatListModule,
    MatIconButton,
    MatIcon,
    ThemeToggle
  ],
  templateUrl: './public-layout.html',
  styleUrl: './public-layout.scss'
})
export class PublicLayout {
  protected readonly currentYear = new Date().getFullYear();

  private readonly breakpointObserver = inject(BreakpointObserver);
  protected readonly isMobile = toSignal(
    this.breakpointObserver.observe(Breakpoints.Handset).pipe(map((result) => result.matches)),
    { initialValue: false }
  );

  protected readonly navLinks = [
    { path: '/actu', label: 'Actu' },
    { path: '/bachata', label: "C'est quoi la bachata" },
    { path: '/qui-sommes-nous', label: 'Qui sommes-nous' },
    { path: '/nos-cours', label: 'Nos cours' },
    { path: '/galerie', label: 'Galerie' }
  ];
}
