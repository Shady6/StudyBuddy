export interface LoginModel{
    Email: string,
    Password: string
}

export const LOGIN = "LOGIN";



export interface Login {
    type: typeof LOGIN,
    payload: LoginModel
}