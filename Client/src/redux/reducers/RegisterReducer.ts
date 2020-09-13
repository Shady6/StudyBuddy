import {
  RegisterDispatchTypes,
  REGISTER_FAILURE,
  REGISTER_REQUEST,
  REGISTER_SUCCESS,
} from "../actions/user/RegisterActionTypes";

interface RegisterState {
  registering: boolean;
  errors: any;
  failiure: boolean;
  success: boolean;
}

const DefaultRegistrationState: RegisterState = {
  registering: false,
  errors: [],
  failiure: false,
  success: false,
};

const registerReducer = (
  state: RegisterState = DefaultRegistrationState,
  action: RegisterDispatchTypes
): RegisterState => {
  switch (action.type) {
    case REGISTER_REQUEST:
      return { ...DefaultRegistrationState, registering: true };
    case REGISTER_SUCCESS:
      return { ...DefaultRegistrationState, success: true };
    case REGISTER_FAILURE:
      return {
        ...DefaultRegistrationState,
        failiure: true,
        errors: action.payload,
      };
    default:
      return state;
  }
};

export default registerReducer;
