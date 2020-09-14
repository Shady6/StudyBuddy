import {
  RegisterDispatchTypes,
  RegisterValidationErrors,
  REGISTER_FAILURE,
  REGISTER_REQUEST,
  REGISTER_SUCCESS,
} from "../actions/user/RegisterActionTypes";

export interface RegisterState {
  registering: boolean;
  errors: RegisterValidationErrors;
  failiure: boolean;
  success: boolean;
}

const DefaultRegisterState: RegisterState = {
  registering: false,
  errors: {},
  failiure: false,
  success: false,
};


const registerReducer = (
  state: RegisterState = DefaultRegisterState,
  action: RegisterDispatchTypes
): RegisterState => {
  switch (action.type) {
    case REGISTER_REQUEST:
      return { ...DefaultRegisterState, registering: true };
    case REGISTER_SUCCESS:
      return { ...DefaultRegisterState, success: true };
    case REGISTER_FAILURE:
      return {
        ...DefaultRegisterState,
        failiure: true,
        errors: action.payload,
      };
    default:
      return state;
  }
};

export default registerReducer;
