export interface RegisterModel{
    FirstName: string,
    LastName: string,
    Email: string,
    Password: string
}

export interface LoginModel{
    Email: string,
    Password: string
}

export interface UpdateModel{
    FirstName: string,
    LastName: string,
    Email: string,
    Password: string,
}

export interface AuthenticationData{
    Bearer: string,
    Id: number
}

export interface AuthenticatedUpdateModel{
    UpdateModel: UpdateModel,
    Authentication: AuthenticationData
}

export const REGISTER = "REGISTER";
export const LOGIN = "LOGIN";
export const UPDATE = "UPDATE";
export const DELETE = "DELETE";


export interface Register {
    type: typeof REGISTER,
    payload: RegisterModel
}

export interface Login {
    type: typeof LOGIN,
    payload: LoginModel
}

export interface Update {
    type: typeof UPDATE,
    payload: AuthenticatedUpdateModel
}

export interface Delete {
    type: typeof DELETE,
    payload: AuthenticationData
}

export type UserDispatchTypes = Register | Login | Update | Delete

