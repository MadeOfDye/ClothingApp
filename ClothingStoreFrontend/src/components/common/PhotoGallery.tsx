import type { PhotoGalleryProps } from "../props/PhotoGalleryProps";
import { useState } from "react";
export function PhotoGallery(photoProps: PhotoGalleryProps) {
    const length = photoProps.gallery.length ?? 0;
    const [index, setIndex] = useState(0);
    return (
        <div>
            {/*Implement Carrousel*/}

        </div>
    )
}