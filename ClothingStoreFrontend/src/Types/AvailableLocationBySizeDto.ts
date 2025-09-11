import type { AnySizeDto } from "./SizeDto";
import type { StockByLocationDto } from "./StockByLocationDto";

export interface AvailableLocationBySizeDto {
    availableLocationBySizeId: string;
    variantId: string;
    size: AnySizeDto;

    availableLocationsOfGivenSize: StockByLocationDto[];
}