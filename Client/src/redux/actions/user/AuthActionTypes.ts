import { UserModel } from "./UserActionTypes";

export interface LoginModel{
    Email: string
    Password: string
}

export interface LoginValidationErrors{
    Email?: string[]
    Password?: string[]
    Message?: string
}

export const LOGIN_REQUEST = "LOGIN_REQUEST";
export const LOGIN_SUCCESS = "LOGIN_SUCCESS";
export const LOGIN_FAILURE = "LOGIN_FAILURE";
export const LOGOUT = "LOGOUT";

export interface LoginRequest {
    type: typeof LOGIN_REQUEST
}

export interface LoginSuccess {
    type: typeof LOGIN_SUCCESS
    payload: UserModel
}

export interface LoginFailure {
    type: typeof LOGIN_FAILURE
    payload: LoginValidationErrors
}

export interface Logout{
    type: typeof LOGOUT
}

export type LoginDispatchTypes = LoginRequest | LoginSuccess | LoginFailure | Logout;