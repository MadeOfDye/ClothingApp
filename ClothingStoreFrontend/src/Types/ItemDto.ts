import type { VariantDto } from "./VariantDto";
import type { TagDto } from "./TagDto";

export interface ItemDto {
  itemId: string;
  description: string;
  name: string;
  hot: boolean;
  price: number;
  discount: number;
  lastChance: boolean;
  brand: string;
  collection: string;
  careGuide: string;
  materialDistribution: string;
  totalStock: number;
  createdAt: string;

  variants: VariantDto[];
  tags: TagDto[]
}

