import { useItems } from '../../features/item/hooks/useItems';
import { ItemCard } from './ItemCard';

export function ItemList() {
    const { data: items, isPending, isError } = useItems();

    if (isPending) return (
        <div className="flex justify-center items-center py-12">
            <div className="animate-spin rounded-full h-12 w-12 border-b-2 border-black"></div>
        </div>
    );
    
    if (isError) return (
        <div className="text-center py-12">
            <p className="text-gray-600">Error loading items. Please try again.</p>
        </div>
    );

    return (
        <div className="container mx-auto px-4">
            {/* Optional: Results count */}
            <div className="mb-6">
                <p className="text-sm text-gray-600">
                    {items?.records.length} products
                </p>
            </div>

            {/* Responsive grid with consistent item heights */}
            <div className="grid grid-cols-2 sm:grid-cols-3 md:grid-cols-4 lg:grid-cols-5 xl:grid-cols-6 gap-4 md:gap-6">
                {items?.records.map((item) => (
                    <div key={item.itemId} className="min-h-0"> {/* Ensures grid items don't overflow */}
                        <ItemCard item={item} />
                    </div>
                ))}
            </div>

            {/* Optional: Load more button */}
            {items?.records.length === 0 && (
                <div className="text-center py-12">
                    <p className="text-gray-600">No products found.</p>
                </div>
            )}
        </div>
    );
}