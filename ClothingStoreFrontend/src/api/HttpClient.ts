import axios  from "axios";

export const HttpClient = axios.create({
    baseURL: "https://localhost:7135/api",
    //timeout: 10000,
    headers: { "Content-Type": "application/json",
        Accept: "application/json",
     },
    validateStatus: (status) => status >= 200 && status < 300,
});