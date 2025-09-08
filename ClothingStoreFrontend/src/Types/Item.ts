export interface Item {
  itemId: string;
  name: string;
  description: string;
  price: number;
  brand: string;
  collection: string;
  careGuide: string;
  discount: number;
  hot: boolean;
  lastChance: boolean;

  variants: Variant[];
  photos: Photo[];
  reviews: Review[];
}

