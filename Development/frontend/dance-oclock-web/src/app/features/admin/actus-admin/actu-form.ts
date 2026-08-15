import { Component, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButton } from '@angular/material/button';
import { ActuService } from '../../../core/services/actu.service';
import { ActuType, ActuUpsert } from '../../../core/models/actu.model';

@Component({
  selector: 'app-actu-form',
  imports: [
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatCheckboxModule,
    MatButton
  ],
  templateUrl: './actu-form.html',
  styleUrl: './actu-form.scss'
})
export class ActuFormComponent implements OnInit {
  protected readonly actuTypes: ActuType[] = ['Actu', 'Promo', 'BonPlan'];
  protected readonly isEditMode = signal(false);

  protected model: ActuUpsert = {
    title: '',
    summary: '',
    content: '',
    type: 'Actu',
    imageUrl: null,
    publishedAt: new Date().toISOString(),
    isPublished: false
  };

  private actuId: string | null = null;

  constructor(
    private readonly route: ActivatedRoute,
    private readonly router: Router,
    private readonly actuService: ActuService
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.actuId = id;
      this.isEditMode.set(true);
      this.actuService.getAllForAdmin().subscribe((actus) => {
        const actu = actus.find((a) => a.id === id);
        if (actu) {
          const { id: _ignored, ...rest } = actu;
          this.model = rest;
        }
      });
    }
  }

  submit(): void {
    const onSaved = () => this.router.navigate(['/admin/actus']);

    if (this.actuId) {
      this.actuService.update(this.actuId, this.model).subscribe(onSaved);
    } else {
      this.actuService.create(this.model).subscribe(onSaved);
    }
  }
}
