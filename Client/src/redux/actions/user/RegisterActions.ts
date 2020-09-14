import Axios, { AxiosError } from "axios";
import { Dispatch } from "redux";
import {
  RegisterModel,
  RegisterDispatchTypes,
  REGISTER_REQUEST,
  REGISTER_SUCCESS,
  REGISTER_FAILURE,
  RegisterValidationErrors,
} from "./RegisterActionTypes";

export const Register = (registerModel: RegisterModel) => async (
  dispatch: Dispatch<RegisterDispatchTypes>
) => {
  dispatch({ type: REGISTER_REQUEST });
  try {
    const res = await Axios.post(
      "https://localhost:44377/Users/register",
      registerModel,
      { headers: { "Content-Type": "application/json" } }
    );
    dispatch({
      type: REGISTER_SUCCESS,
    });
  } catch (ex) {
    const axiosError: AxiosError<{
      errors: RegisterValidationErrors;
    }> = ex as AxiosError<{ errors: RegisterValidationErrors }>;
    if (axiosError && axiosError.response) {
      dispatch({
        type: REGISTER_FAILURE,
        payload: axiosError.response.data.errors,
      });
    }
  }
};
