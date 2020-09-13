export interface RegisterModel{
    FirstName: string
    LastName: string
    Email: string
    Password: string
}

export const REGISTER_REQUEST = "REGISTER_REQUEST";
export const REGISTER_SUCCESS = "REGISTER_SUCCESS";
export const REGISTER_FAILURE = "REGISTER_FAILURE";

export interface RegisterRequest {
    type: typeof REGISTER_REQUEST
}

export interface RegisterSuccess {
    type: typeof REGISTER_SUCCESS
}

export interface RegisterFailure {
    type: typeof REGISTER_FAILURE
    payload: any
}

export type RegisterDispatchTypes = RegisterRequest | RegisterSuccess | RegisterFailure;