import { Component, OnInit, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ActuService } from '../../../core/services/actu.service';
import { Actu } from '../../../core/models/actu.model';

@Component({
  selector: 'app-actu-detail',
  imports: [],
  templateUrl: './actu-detail.html'
})
export class ActuDetail implements OnInit {
  protected readonly actu = signal<Actu | null>(null);

  constructor(
    private readonly route: ActivatedRoute,
    private readonly actuService: ActuService
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.actuService.getById(id).subscribe((actu) => this.actu.set(actu));
    }
  }
}
