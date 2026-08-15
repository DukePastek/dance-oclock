import { Routes } from '@angular/router';
import { PublicLayout } from './layout/public-layout/public-layout';
import { AdminLayout } from './layout/admin-layout/admin-layout';
import { adminGuard } from './core/guards/admin.guard';

export const routes: Routes = [
  {
    path: '',
    component: PublicLayout,
    children: [
      { path: '', loadComponent: () => import('./features/home/home').then((m) => m.Home) },
      { path: 'actu', loadComponent: () => import('./features/actus/actu-list/actu-list').then((m) => m.ActuList) },
      {
        path: 'actu/:id',
        loadComponent: () => import('./features/actus/actu-detail/actu-detail').then((m) => m.ActuDetail)
      },
      { path: 'bachata', loadComponent: () => import('./features/bachata/bachata').then((m) => m.Bachata) },
      {
        path: 'qui-sommes-nous',
        loadComponent: () => import('./features/qui-sommes-nous/qui-sommes-nous').then((m) => m.QuiSommesNous)
      },
      { path: 'nos-cours', loadComponent: () => import('./features/nos-cours/nos-cours').then((m) => m.NosCours) },
      { path: 'galerie', loadComponent: () => import('./features/galerie/galerie').then((m) => m.Galerie) }
    ]
  },
  {
    path: 'admin/login',
    loadComponent: () => import('./features/admin/login/login').then((m) => m.Login)
  },
  {
    path: 'admin',
    component: AdminLayout,
    canActivate: [adminGuard],
    children: [
      { path: '', redirectTo: 'actus', pathMatch: 'full' },
      {
        path: 'actus',
        loadComponent: () => import('./features/admin/actus-admin/actus-admin-list').then((m) => m.ActusAdminList)
      },
      {
        path: 'actus/nouvelle',
        loadComponent: () => import('./features/admin/actus-admin/actu-form').then((m) => m.ActuFormComponent)
      },
      {
        path: 'actus/:id',
        loadComponent: () => import('./features/admin/actus-admin/actu-form').then((m) => m.ActuFormComponent)
      }
    ]
  },
  { path: '**', redirectTo: '' }
];
