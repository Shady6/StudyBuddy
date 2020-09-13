import {combineReducers} from "redux";
import authReducer from "./AuthReducer"

const rootReducer = combineReducers({
    pokemon: authReducer
});

export default rootReducer