export interface SizeDto{
    SizeId: string;
    letter: string;
}

export interface ShirtSizeDto extends SizeDto{
    length: number;
    ShoulderWidth: number;
    ChestWidth: number;
    SleeveLength: number;
    SleeveCircumference: number;
    NeckCircumference: number;
}

export interface PantsSizeDto extends SizeDto{
    Waist: number;
    Inseam: number;
    PantLegCircumference: number;
}

export interface ShoeSizeDto extends SizeDto{
    Length: number;
    Width: number;
    HeelHight?: number;
}

export interface HatSizeDto extends SizeDto{
    Circumference: number;
}

export interface DressSizeDto extends SizeDto{
    Bust: number;
    Waist: number;
    Hip: number;
    Length: number;
}

export type AnySizeDto = ShirtSizeDto | PantsSizeDto | ShoeSizeDto | HatSizeDto | DressSizeDto;