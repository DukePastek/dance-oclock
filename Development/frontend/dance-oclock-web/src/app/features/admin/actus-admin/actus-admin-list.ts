import { DatePipe } from '@angular/common';
import { Component, OnInit, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatIconButton, MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { ActuService } from '../../../core/services/actu.service';
import { Actu } from '../../../core/models/actu.model';

@Component({
  selector: 'app-actus-admin-list',
  imports: [RouterLink, DatePipe, MatTableModule, MatIconButton, MatButton, MatIcon],
  templateUrl: './actus-admin-list.html',
  styleUrl: './actus-admin-list.scss'
})
export class ActusAdminList implements OnInit {
  protected readonly actus = signal<Actu[]>([]);
  protected readonly displayedColumns = ['title', 'type', 'isPublished', 'publishedAt', 'actions'];

  constructor(private readonly actuService: ActuService) {}

  ngOnInit(): void {
    this.load();
  }

  private load(): void {
    this.actuService.getAllForAdmin().subscribe((actus) => this.actus.set(actus));
  }

  remove(actu: Actu): void {
    if (!confirm(`Supprimer "${actu.title}" ?`)) {
      return;
    }
    this.actuService.delete(actu.id).subscribe(() => this.load());
  }
}
