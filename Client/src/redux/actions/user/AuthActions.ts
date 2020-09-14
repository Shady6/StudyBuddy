import Axios, { AxiosError, AxiosResponse } from "axios";
import { Dispatch } from "redux";
import {
  LoginDispatchTypes,
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
    const res: AxiosResponse<UserModel> = await Axios.post(
      "https://localhost:44377/Users/authenticate",
      loginModel,
      { headers: { "Content-Type": "application/json" } }
    );
    localStorage.setItem("user", JSON.stringify(res.data));
    dispatch({
      type: LOGIN_SUCCESS,
      payload: res.data,
    });
  } catch (ex) {
    const axiosError: AxiosError<{
      errors: LoginValidationErrors;
    }> = ex as AxiosError<{ errors: LoginValidationErrors }>;
    if (axiosError && axiosError.response) {
      dispatch({
        type: LOGIN_FAILURE,
        payload: axiosError.response.data.errors,
      });
    }
  }
};

export const Logout = () => async (dispatch: Dispatch<LoginDispatchTypes>) => {
  localStorage.removeItem("user");
  dispatch({
    type: LOGOUT,
  });
};
