import type { ItemCardProps } from "../props/ItemCardProps";

export function ItemCard({ item }: ItemCardProps) {
    const hasDiscount = item.discount > 0;
    const discountedPrice = item.price * (1 - item.discount);

    const firstPhotoURL = item.variants[0]?.gallery[0]?.url ?? '';

    return (
        <div className="group relative bg-white rounded-none overflow-hidden transition-all duration-300 hover:shadow-lg flex flex-col h-full">
            {/* Image Container with fixed dimensions */}
            <div className="relative overflow-hidden bg-gray-100 flex-shrink-0">
                <div className="aspect-[3/4] w-full relative">
                    <img 
                        className="absolute inset-0 w-full h-full object-cover transition-transform duration-500 group-hover:scale-105" 
                        src={firstPhotoURL} 
                        alt={item.name}
                        loading="lazy"
                        // Prevent image from affecting layout
                        style={{ maxWidth: '100%', maxHeight: '100%' }}
                    />
                </div>
                
                {/* Labels positioned on image */}
                <div className="absolute top-3 left-3 flex flex-col gap-2">
                    {item.hot && (
                        <span className="bg-black text-white text-xs font-medium px-2 py-1 uppercase tracking-wide">
                            Hot
                        </span>
                    )}
                    {item.lastChance && (
                        <span className="bg-red-600 text-white text-xs font-medium px-2 py-1 uppercase tracking-wide">
                            Last Chance
                        </span>
                    )}
                </div>

                {/* Discount badge */}
                {hasDiscount && (
                    <span className="absolute top-3 right-3 bg-red-600 text-white text-sm font-bold px-2 py-1">
                        -{Math.round(item.discount * 100)}%
                    </span>
                )}
            </div>

            {/* Content - takes remaining space */}
            <div className="p-3 flex flex-col flex-grow">
                {/* Product Name */}
                <h3 className="text-sm font-normal text-gray-900 mb-1 line-clamp-2 flex-shrink-0">
                    {item.name}
                </h3>
                
                {/* Description */}
                <p className="text-xs text-gray-600 mb-2 line-clamp-2 flex-shrink-0">
                    {item.description}
                </p>

                {/* Price Section */}
                <div className="flex items-center gap-2 mt-auto flex-shrink-0">
                    {hasDiscount ? (
                        <>
                            <span className="text-lg font-bold text-gray-900">
                                ${discountedPrice.toFixed(2)}
                            </span>
                            <span className="text-sm text-gray-500 line-through">
                                ${item.price.toFixed(2)}
                            </span>
                        </>
                    ) : (
                        <span className="text-lg font-bold text-gray-900">
                            ${item.price.toFixed(2)}
                        </span>
                    )}
                </div>

                {/* Color variants (if available) */}
                {item.variants && item.variants.length > 1 && (
                    <div className="flex gap-1 mt-2 flex-shrink-0">
                        {item.variants.slice(0, 4).map((variant, index) => (
                            <div 
                                key={index}
                                className="w-3 h-3 border border-gray-300"
                                style={{ 
                                    backgroundColor: variant.color?.hexadecimal || '#ccc',
                                    borderRadius: '50%'
                                }}
                                title={variant.color?.hexadecimal || 'No color'}
                            />
                        ))}
                        {item.variants.length > 4 && (
                            <div className="w-3 h-3 bg-gray-200 rounded-full flex items-center justify-center">
                                <span className="text-xs">+{item.variants.length - 4}</span>
                            </div>
                        )}
                    </div>
                )}
            </div>

            {/* Hover actions (like quick add to cart) */}
            <div className="absolute bottom-20 left-0 right-0 px-3 opacity-0 group-hover:opacity-100 transition-opacity duration-300">
                <button className="w-full bg-black text-white py-2 text-sm font-medium uppercase tracking-wide hover:bg-gray-800 transition-colors">
                    Quick Add
                </button>
            </div>
        </div>
    );
}