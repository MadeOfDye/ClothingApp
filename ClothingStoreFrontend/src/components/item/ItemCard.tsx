import type { ItemCardProps } from "../props/ItemCardProps";
import "./ItemCard.css";
export function ItemCard({ item }: ItemCardProps) {
    const hasDiscount = item.discount > 0;

    const firstPhotoURL = item.variants[0]?.gallery[0]?.url ?? '';
    return (
        <div className="bg-red-500 flex-grow-4 basis-60 p-4 rounded shadow-lg hover:shadow-2xl transition-shadow duration-300 border-transparent">
            {/*Photo Section TODO: Implement carousel gallery instead*/}
            {/*Information section*/}
            <h1>{item.name}</h1>
            <p>{item.description}</p>
            {/*Tag Section*/}
        </div>
    )
}