import React, { useState } from "react";
import {
  RegisterModel
} from "../redux/actions/user/RegisterActionTypes";
import {Register as RegisterAction} from "../redux/actions/user/RegisterActions";
import { RootReducer } from "../redux/Store";
import { useSelector, useDispatch } from "react-redux";
import { RegisterState } from "../redux/reducers/RegisterReducer";
import { LoginModel } from "../redux/actions/user/AuthActionTypes";
import { LoginState } from "../redux/reducers/AuthReducer";
import {Login as LoginAction, Logout} from "../redux/actions/user/AuthActions"

interface LoginProps {}

type LoginStateKey = "Email" | "Password";

export const Login: React.FC<LoginProps> = ({}) => {
  const [loginModel, setLoginModel] = useState<LoginModel>({
    Email: "",
    Password: "",
  });
  const loginState: LoginState = useSelector(
    (state: RootReducer) => state.loginReducer
  );
  const dispatch = useDispatch();

  const handleInput = (
    e: React.ChangeEvent<HTMLInputElement>,
    attribute: LoginStateKey
  ) => {
    let newState: LoginModel = { ...loginModel };
    newState[attribute] = e.target.value;
    setLoginModel(newState);
  };

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    dispatch(LoginAction(loginModel));
  };

  const handleClick = (e: React.MouseEvent<HTMLButtonElement>) => {
      dispatch(Logout());
  }

  return (
    <div>
      <form onSubmit={(e) => handleSubmit(e)}>
        <p>Email</p>
        <input
          value={loginModel.Email}
          onChange={(e) => handleInput(e, "Email")}
          type="text"
        />
        <p>Password</p>
        <input
          value={loginModel.Password}
          onChange={(e) => handleInput(e, "Password")}
          type="text"
        />
        <button type="submit">
          Submit
        </button>
      </form>

      {loginState.loggingIn ? <p>Requesting a login</p> : <p></p>}

      {loginState.success ? <p>login was success</p> : <p></p>}

      {loginState.failiure ? <p>login was error</p> : <p></p>}

      <button onClick={e => handleClick(e)}>Logout</button>
    </div>
  );
};
