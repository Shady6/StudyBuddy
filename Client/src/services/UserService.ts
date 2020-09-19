import api from "../api/Api";
import { LoginModel } from "../redux/actions/user/AuthActionTypes";
import { RegisterModel } from "../redux/actions/user/RegisterActionTypes";
import { UserModel } from "../redux/actions/user/UserActionTypes";

const userUrlSuffix = "/users";

const registerUser = async (registerModel: RegisterModel) => {
  await api.post(userUrlSuffix + "/register", registerModel);
};

const loginUser = async (loginModel: LoginModel) => {
  return await api.post<UserModel>(userUrlSuffix + "/authenticate", loginModel);
};

const userService = {
  registerUser,
  loginUser,
};

export default userService;
