import {useItems} from '../../features/item/hooks/useItems';
import { ItemCard } from './ItemCard';

export function ItemList() {
    const {data: items, isPending, isError} = useItems();

    if (isPending) return <div>Loading...</div>;
    if (isError) return <div>Error loading items.</div>;
    return (
        <ul className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
      {items?.records.map((item) => (
        <li key={item.itemId}>
          <ItemCard item={item} />
        </li>
      ))}
    </ul>
    );
}