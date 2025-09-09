import type { LocationDto } from "./LocationDto";

export interface StockByLocationDto{
    StockByLocationId: string;
    AvailableLocationBySizeId: string;
    Stock: number;
    Location: LocationDto
}