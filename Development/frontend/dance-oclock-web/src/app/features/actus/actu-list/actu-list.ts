import { Component, OnInit, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ActuService } from '../../../core/services/actu.service';
import { Actu } from '../../../core/models/actu.model';

@Component({
  selector: 'app-actu-list',
  imports: [RouterLink],
  templateUrl: './actu-list.html',
  styleUrl: './actu-list.scss'
})
export class ActuList implements OnInit {
  protected readonly actus = signal<Actu[]>([]);

  constructor(private readonly actuService: ActuService) {}

  ngOnInit(): void {
    this.actuService.getPublished().subscribe((actus) => this.actus.set(actus));
  }
}
