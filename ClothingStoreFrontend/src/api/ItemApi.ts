import type { ItemDto } from "../types/ItemDto";
import { HttpClient } from "./HttpClient";

export const ItemApi = {
    async getAllItems(): Promise<ItemDto[]> {
        const response = await HttpClient.get<ItemDto[]>("/Item");
        return response.data;
    }, 

    async getItemById(id: string): Promise<ItemDto> {
        const response = await HttpClient.get<ItemDto>('/Item/' + id);
        return response.data;
    }
}