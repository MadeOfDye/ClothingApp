import type { LocationDto } from "./LocationDto";

export interface StockByLocationDto{
    stockByLocationId: string;
    availableLocationBySizeId: string;
    stock: number;
    location: LocationDto
}