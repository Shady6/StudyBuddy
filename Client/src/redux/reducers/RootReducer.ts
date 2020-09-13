import {combineReducers} from "redux";
import registerReducer from "./RegisterReducer";
import userReducer from "./UserReducer"

const rootReducer = combineReducers({
    // user: userReducer
    registerReducer: registerReducer
});

export default rootReducer