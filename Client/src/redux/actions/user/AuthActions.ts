import Axios, { AxiosError, AxiosResponse } from "axios";
import { Dispatch } from "redux";
import { handleAxiosError } from "../../../helpers/ErrorHelper";
import userService from "../../../services/UserService";
import {
  LoginDispatchTypes,
  LoginFailure,
  LoginModel,
  LoginValidationErrors,
  LOGIN_FAILURE,
  LOGIN_REQUEST,
  LOGIN_SUCCESS,
  LOGOUT,
} from "./AuthActionTypes";
import { UserModel } from "./UserActionTypes";

export const Login = (loginModel: LoginModel) => async (
  dispatch: Dispatch<LoginDispatchTypes>
) => {
  dispatch({ type: LOGIN_REQUEST });
  try {
    const res: AxiosResponse<UserModel> = await userService.loginUser(
      loginModel
    );
    localStorage.setItem("user", JSON.stringify(res.data));
    dispatch({
      type: LOGIN_SUCCESS,
      payload: res.data,
    });
  } catch (ex) {
    handleAxiosError<LoginValidationErrors, LoginFailure>(ex, (error) => {
      return dispatch({
        type: LOGIN_FAILURE,
        payload: error,
      });
    });
  }
};

export const Logout = () => async (dispatch: Dispatch<LoginDispatchTypes>) => {
  localStorage.removeItem("user");
  dispatch({
    type: LOGOUT,
  });
};
