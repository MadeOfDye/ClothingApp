import type { CollectionResponse } from "../Common/CollectionResponse";
import type { ItemDto } from "../types/ItemDto";
import { HttpClient } from "./HttpClient";

export const ItemApi = {
    async getAllItems(): Promise<CollectionResponse<ItemDto>> {
        const response = await HttpClient.get<CollectionResponse<ItemDto>>("/Item");
        console.log(typeof response.data);
        return response.data;
    }, 

    async getItemById(id: string): Promise<ItemDto> {
        const response = await HttpClient.get<ItemDto>('/Item/' + id);
        return response.data;
    }
}