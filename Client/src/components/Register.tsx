import React, { useState } from "react";
import {
  RegisterModel
} from "../redux/actions/user/RegisterActionTypes";
import {Register as RegisterAction} from "../redux/actions/user/RegisterActions";
import { RootReducer } from "../redux/Store";
import { useSelector, useDispatch } from "react-redux";
import { RegisterState } from "../redux/reducers/RegisterReducer";

interface RegisterProps {}

type RegisterStateKey = "Email" | "FirstName" | "LastName" | "Password";

export const Register: React.FC<RegisterProps> = ({}) => {
  const [registerModel, setRegisterModel] = useState<RegisterModel>({
    Email: "",
    FirstName: "",
    LastName: "",
    Password: "",
  });
  const registerState: RegisterState = useSelector(
    (state: RootReducer) => state.registerReducer
  );
  const dispatch = useDispatch();

  const handleInput = (
    e: React.ChangeEvent<HTMLInputElement>,
    attribute: RegisterStateKey
  ) => {
    let newState: RegisterModel = { ...registerModel };
    newState[attribute] = e.target.value;
    setRegisterModel(newState);
  };

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    dispatch(RegisterAction(registerModel));
  };

  return (
    <div>
      <form onSubmit={(e) => handleSubmit(e)}>
        <p>First Name</p>
        <input
          value={registerModel.FirstName}
          onChange={(e) => handleInput(e, "FirstName")}
          type="text"
        />
        <p>Last Name</p>
        <input
          value={registerModel.LastName}
          onChange={(e) => handleInput(e, "LastName")}
          type="text"
        />
        <p>Email</p>
        <input
          value={registerModel.Email}
          onChange={(e) => handleInput(e, "Email")}
          type="text"
        />
        <p>Password</p>
        <input
          value={registerModel.Password}
          onChange={(e) => handleInput(e, "Password")}
          type="text"
        />
        <button type="submit">
          Submit
        </button>
      </form>

      {registerState.registering ? <p>Requesting a register</p> : <p></p>}

      {registerState.success ? <p>Register was success</p> : <p></p>}

      {registerState.failiure ? <p>Register was error</p> : <p></p>}
    </div>
  );
};
