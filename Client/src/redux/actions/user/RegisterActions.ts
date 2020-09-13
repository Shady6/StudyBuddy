import Axios from "axios";
import { Dispatch } from "redux";
import {
  RegisterModel,
  RegisterDispatchTypes,
  REGISTER_REQUEST,
  REGISTER_SUCCESS,
  REGISTER_FAILURE,
} from "./RegisterActionTypes";

export const Register = (registerModel: RegisterModel) => async (
  dispatch: Dispatch<RegisterDispatchTypes>
) => {
  dispatch({ type: REGISTER_REQUEST });
  try {
    const res = await Axios.post(
      "https://localhost:44377/User/register",
      registerModel,
      { headers: { "Content-Type": "application/json" } }
    );
    console.log(res);
    dispatch({
      type: REGISTER_SUCCESS,
    });
  } catch (e) {
    console.log(e);
    dispatch({ type: REGISTER_FAILURE, payload: e });
  }
};
