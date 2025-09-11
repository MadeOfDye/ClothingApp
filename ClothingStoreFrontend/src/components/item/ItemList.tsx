import {useItems} from '../../features/item/hooks/useItems';

export function ItemList() {
    const {data: items, isPending, isError} = useItems();

    if (isPending) return <div>Loading...</div>;
    if (isError) return <div>Error loading items.</div>;
    return (
        <ul>
            {items?.records.map(item => (
                <li key={item.itemId}>{item.name} - {item.price}</li>
            ))}
        </ul>
    );
}