import { Dispatch } from "redux";
import { RegisterModel, UserDispatchTypes } from "./UserActionTypes";

export const Register = (registerModel: RegisterModel) => (
  dispatch: Dispatch<UserDispatchTypes>
) => {};
