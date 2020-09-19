import { Dispatch } from "redux";
import { handleAxiosError } from "../../../helpers/ErrorHelper";
import userService from "../../../services/UserService";
import {
  RegisterModel,
  RegisterDispatchTypes,
  REGISTER_REQUEST,
  REGISTER_SUCCESS,
  REGISTER_FAILURE,
  RegisterValidationErrors,
  RegisterFailure,
} from "./RegisterActionTypes";

export const Register = (registerModel: RegisterModel) => async (
  dispatch: Dispatch<RegisterDispatchTypes>
) => {
  dispatch({ type: REGISTER_REQUEST });
  try {
    await userService.registerUser(registerModel);
    dispatch({
      type: REGISTER_SUCCESS,
    });
  } catch (ex) {
    handleAxiosError<RegisterValidationErrors, RegisterFailure>(ex, (error) => {
      return dispatch({
        type: REGISTER_FAILURE,
        payload: error,
      });
    });
  }
};
