import {combineReducers} from "redux";
import loginReducer from "./AuthReducer";
import registerReducer from "./RegisterReducer";

const rootReducer = combineReducers({
    registerReducer: registerReducer,
    loginReducer: loginReducer
});

export default rootReducer