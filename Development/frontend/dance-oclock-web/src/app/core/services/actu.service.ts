import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { Actu, ActuUpsert } from '../models/actu.model';

@Injectable({ providedIn: 'root' })
export class ActuService {
  private readonly baseUrl = `${environment.apiUrl}/actus`;

  constructor(private readonly http: HttpClient) {}

  getPublished(): Observable<Actu[]> {
    return this.http.get<Actu[]>(this.baseUrl);
  }

  getById(id: string): Observable<Actu> {
    return this.http.get<Actu>(`${this.baseUrl}/${id}`);
  }

  getAllForAdmin(): Observable<Actu[]> {
    return this.http.get<Actu[]>(`${this.baseUrl}/admin`);
  }

  create(actu: ActuUpsert): Observable<Actu> {
    return this.http.post<Actu>(this.baseUrl, actu);
  }

  update(id: string, actu: ActuUpsert): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/${id}`, actu);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
