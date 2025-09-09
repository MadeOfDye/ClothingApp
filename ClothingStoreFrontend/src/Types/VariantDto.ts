import type { ColorDto } from "./ColorDto";
import type { PhotoDto } from "./PhotoDto";
import type { AvailableLocationBySizeDto } from "./AvailableLocationBySizeDto";

export interface VariantDto{
    VariantId: string;
    ItemId: string;
    Color: ColorDto;
    TotalQuantity: number;

    AvailableLocations: AvailableLocationBySizeDto[];
    Photos: PhotoDto[];
}