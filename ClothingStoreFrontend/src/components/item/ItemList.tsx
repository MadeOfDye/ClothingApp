import {useItems} from '../../features/item/hooks/useItems';
import { ItemCard } from './ItemCard';
import "./ItemList.css";
export function ItemList() {
    const {data: items, isPending, isError} = useItems();
    if (isPending) return <div>Loading...</div>;
    if (isError) return <div>Error loading items.</div>;
    return (
        <ul className="flex flex-row flex-wrap gap-4 justify-start">
      {items?.records.map((item) => (
        <li key={item.itemId}>
          <ItemCard item={item} />
        </li>
      ))}
    </ul>
    );
}