import type { VariantDto } from "./VariantDto";
import type { TagDto } from "./TagDto";

export interface ItemDto {
  ItemId: string;
  Description: string;
  Name: string;
  Hot: boolean;
  Price: number;
  Discount: number;
  LastChance: boolean;
  Brand: string;
  Collection: string;
  CareGuide: string;
  MaterialDistrubtion: string;
  TotalStock: number;
  CreatedAt: Date;

  variants: VariantDto[];
  tags: TagDto[]
}

