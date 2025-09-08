export interface Variant {
  variantId: string;
  color: string;
  size: string;
  stock: number;

  availableLocations: AvailableLocationBySize[];
}