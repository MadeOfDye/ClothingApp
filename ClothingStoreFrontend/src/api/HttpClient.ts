import { Axios } from "axios";

export const HttpClient = new Axios({
    baseURL: "http://localhost:5071/api",
    //timeout: 10000,
    headers: { "Content-Type": "application/json" },
    validateStatus: (status) => status >= 200 && status < 300,
});