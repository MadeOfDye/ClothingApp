import type { CollectionResponse } from "../Common/CollectionResponse";
import type { ItemDto } from "../types/ItemDto";
import type { VariantDto } from "../types/VariantDto";
import type { PhotoDto } from "../types/PhotoDto";
import type { TagDto } from "../types/TagDto";
import type { AvailableLocationBySizeDto } from "../types/AvailableLocationBySizeDto";
import type { StockByLocationDto } from "../types/StockByLocationDto";
import type { AnySizeDto } from "../types/SizeDto";

// --- StockByLocationDto Mapper ---
function mapStockByLocationDto(raw: any): StockByLocationDto {
    return {
        stockByLocationId: raw.stockByLocationId,
        availableLocationBySizeId: raw.availableLocationBySizeId,
        stock: raw.stock,
        location: raw.location
    };
}

// --- AvailableLocationBySizeDto Mapper ---
function mapAvailableLocationBySizeDto(raw: any): AvailableLocationBySizeDto {
    return {
        availableLocationBySizeId: raw.availableLocationBySizeId,
        variantId: raw.variantId,
        size: raw.sizeId as AnySizeDto, // Backend uses 'sizeId', DTO expects 'size'
        availableLocationsOfGivenSize: (raw.availableLocationsOfGivenSize ?? []).map(mapStockByLocationDto)
    };
}

// --- PhotoDto Mapper ---
function mapPhotoDto(raw: any): PhotoDto {
    return {
        photoId: raw.photoId,
        variantId: raw.variantId,
        url: raw.url,
        description: raw.description,
        uploadedAt: raw.uploadedAt
    };
}

// --- VariantDto Mapper ---
function mapVariantDto(raw: any): VariantDto {
    return {
        variantId: raw.variantId,
        itemId: raw.itemId,
        color: raw.color,
        totalQuantity: raw.totalQuantity,
        availableLocations: (raw.availableLocations ?? []).map(mapAvailableLocationBySizeDto),
        gallery: (raw.gallery ?? []).map(mapPhotoDto)
    };
}

// --- TagDto Mapper ---
function mapTagDto(raw: any): TagDto {
    return {
        tagId: raw.tagId,
        itemId: raw.itemId,
        name: raw.name
    };
}

// --- ItemDto Mapper ---
function mapItemDto(raw: any): ItemDto {
    return {
        itemId: raw.itemId,
        description: raw.description,
        name: raw.name,
        hot: raw.hot,
        price: raw.price,
        discount: raw.discount,
        lastChance: raw.lastChance,
        brand: raw.brand,
        collection: raw.collection,
        careGuide: raw.careGuide,
        materialDistribution: raw.materialDistribution,
        totalStock: raw.totalStock,
        createdAt: raw.createdAt,
        variants: (raw.variants ?? []).map(mapVariantDto),
        tags: (raw.tags ?? []).map(mapTagDto)
    };
}

// --- CollectionResponse<ItemDto> Mapper ---
export function mapItemCollectionResponse(raw: any): CollectionResponse<ItemDto> {
    return {
        records: (raw.records ?? []).map(mapItemDto),
        totalNumberOfRecords: raw.totalNumberOfRecords
    };
}

// --- Single ItemDto Mapper (exported for detail views, etc.) ---
export { mapItemDto };