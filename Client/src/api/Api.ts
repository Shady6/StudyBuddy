import Axios from "axios";

const apiUrl = "https://localhost:44377";

const api = Axios.create({
    baseURL: apiUrl,
    responseType: "json",
    headers: {
        "Content-Type": "application/json"
    }
})

export default api;
