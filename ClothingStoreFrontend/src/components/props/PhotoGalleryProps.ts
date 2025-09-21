import type { PhotoDto } from "../../types/PhotoDto";

export type PhotoGalleryProps = {
    gallery: PhotoDto[];
    autoplay: boolean;
    autoPlayInterval?: number; //miliseconds
    showThumbnails?: boolean;
    showIndicators?: boolean;
    infiniteLoop?: boolean;
};