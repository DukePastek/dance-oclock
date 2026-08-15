export type ActuType = 'Actu' | 'Promo' | 'BonPlan';

export interface Actu {
  id: string;
  title: string;
  summary: string;
  content: string;
  type: ActuType;
  imageUrl: string | null;
  publishedAt: string;
  isPublished: boolean;
}

export type ActuUpsert = Omit<Actu, 'id'>;
