import { useQuery } from '@tanstack/react-query';
import { ItemApi } from '../../../api/ItemApi';
import type { ItemDto } from '../../../types/ItemDto';

export function useItems() {
    return useQuery<ItemDto[]>(
        {
            queryKey: ['items'],
            queryFn: ItemApi.getAllItems,
            staleTime: 60 * 1000,
        }
    );// TODO: implement exponential backoff retry logic
}