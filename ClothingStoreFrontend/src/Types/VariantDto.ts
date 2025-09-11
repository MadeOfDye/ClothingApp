import type { ColorDto } from "./ColorDto";
import type { PhotoDto } from "./PhotoDto";
import type { AvailableLocationBySizeDto } from "./AvailableLocationBySizeDto";

export interface VariantDto{
    variantId: string;
    itemId: string;
    color: ColorDto;
    totalQuantity: number;

    availableLocations: AvailableLocationBySizeDto[];
    gallery: PhotoDto[];
}