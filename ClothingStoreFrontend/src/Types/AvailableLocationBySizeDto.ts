import type { AnySizeDto } from "./SizeDto";
import type { StockByLocationDto } from "./StockByLocationDto";

export interface AvailableLocationBySizeDto {
    AvailableLocationBySizeId: string;
    VariantId: string;
    Size: AnySizeDto;

    AvailableLocationsOfGivenSize: StockByLocationDto[];
}