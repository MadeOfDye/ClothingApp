import type { CollectionResponse } from "../Common/CollectionResponse";
import type { ItemDto } from "../Types/ItemDto";
import { HttpClient } from "./HttpClient";

export const ItemApi = {
    async getAllItems(): Promise<CollectionResponse<ItemDto>> {
        const response = await HttpClient.get<CollectionResponse<ItemDto>>("/Item");
        return response.data;
    }, 

    async getItemById(id: string): Promise<ItemDto> {
        const response = await HttpClient.get<ItemDto>('/Item/' + id);
        return response.data;
    }
}