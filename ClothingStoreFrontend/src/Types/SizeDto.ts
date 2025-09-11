export interface SizeDto{
    sizeId: string;
    letter: string;
}

export interface ShirtSizeDto extends SizeDto{
    length: number;
    shoulderWidth: number;
    chestWidth: number;
    sleeveLength: number;
    sleeveCircumference: number;
    neckCircumference: number;
}

export interface PantsSizeDto extends SizeDto{
    waist: number;
    inseam: number;
    pantLegCircumference: number;
}

export interface ShoeSizeDto extends SizeDto{
    length: number;
    eidth: number;
    heelHight?: number;
}

export interface HatSizeDto extends SizeDto{
    circumference: number;
}

export interface DressSizeDto extends SizeDto{
    bust: number;
    waist: number;
    hip: number;
    length: number;
}

export type AnySizeDto = ShirtSizeDto | PantsSizeDto | ShoeSizeDto | HatSizeDto | DressSizeDto;