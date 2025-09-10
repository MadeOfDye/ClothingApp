import {useItems} from '../../features/item/hooks/useItems';

export function ItemList() {
    const {data: items, isPending, isError} = useItems();

    if (isPending) return <div>Loading...</div>;
    if (isError) return <div>Error loading items.</div>;

    return (
        <ul>
            {items?.map(item => (
                <li key={item.ItemId}>{item.Name}</li>
            ))}
        </ul>
    );
}