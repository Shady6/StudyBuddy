import {
  LoginDispatchTypes,
  LoginValidationErrors,
  LOGIN_FAILURE,
  LOGIN_REQUEST,
  LOGIN_SUCCESS,
  LOGOUT,
} from "../actions/user/AuthActionTypes";

import { UserModel } from "../actions/user/UserActionTypes";

export interface LoginState {
  loggingIn: boolean;
  errors: LoginValidationErrors;
  failiure: boolean;
  success: boolean;
  user?: UserModel;
}

const user = JSON.parse(localStorage.getItem("user") || "null");

const DefaultLoginState: LoginState = {
  loggingIn: false,
  errors: {},
  failiure: false,
  success: false,
  user: (user as UserModel) || null,
};

const loginReducer = (
  state: LoginState = DefaultLoginState,
  action: LoginDispatchTypes
): LoginState => {
  switch (action.type) {
    case LOGIN_REQUEST:
      return { ...DefaultLoginState, loggingIn: true };
    case LOGIN_SUCCESS:
      return { ...DefaultLoginState, success: true, user: action.payload };
    case LOGIN_FAILURE:
      return {
        ...DefaultLoginState,
        failiure: true,
        errors: action.payload,
      };
    case LOGOUT:
      return {
        ...DefaultLoginState,
      };
    default:
      return state;
  }
};

export default loginReducer;
