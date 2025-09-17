import type { ItemCardProps } from "../props/ItemCardProps";

export function ItemCard({ item }: ItemCardProps) {
    const hasDiscount = item.discount > 0;

    const firstPhotoURL = item.variants[0]?.gallery[0]?.url ?? '';
    console.log("this is the url: " + firstPhotoURL);
    return (
        <div className="max-w-sm rounded overflow-hidden shadow-lg">
            <img className="w-full h-48 object-cover" 
            src={firstPhotoURL} 
            alt={item.name} />
            <h2 className="text-xl font-bold mt-2 px-4">{item.name}</h2>
            <p className="text-gray-700 text-base px-4 mt-1">{item.description}</p>
            
            {/* Price Section */}
            { hasDiscount ? (
            <div className="mb-2">
                <span className="line-through text-gray-500 text-lg font-semibold mr-2">
                    ${item.price.toFixed(2)}
                </span>
                <span className="text-red-500 text-lg font-bold px-4">
                    ${(item.price * item.discount).toFixed(2)}
                </span>
            </div>
            ):(
                <div className="mb-2">
                    <span className="text-gray-900 text-lg font-bold px-4">
                        ${item.price.toFixed(2)}
                    </span>
                </div>
            )}

            {/* Label Section */}
            <div className="flex gap-2">
                {item.hot && (
                    <span className="bg-red-500 text-white text-xs font-semibold px-2 py-1 rounded">
                        Hot
                    </span>
                )}
                {item.lastChance && (
                    <span className="bg-yellow-500 text-white text-xs font-semibold px-2 py-1 rounded">
                        Last Chance
                    </span>
                )}
            </div>
        </div>
    )
}