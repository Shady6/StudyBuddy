export interface UpdateModel {
  FirstName: string;
  LastName: string;
  Email: string;
  Password: string;
}

export interface UserModel{
  id: number;
  FirstName: string;
  LastName: string;
  Email: string;
  Password: string;
  Token: string
}

export interface AuthenticationData {
  Bearer: string;
  Id: number;
}

export interface AuthenticatedUpdateModel {
  UpdateModel: UpdateModel;
  Authentication: AuthenticationData;
}

export const UPDATE = "UPDATE";
export const DELETE = "DELETE";

export interface Update {
  type: typeof UPDATE;
  payload: AuthenticatedUpdateModel;
}

export interface Delete {
  type: typeof DELETE;
  payload: AuthenticationData;
}

export type UserDispatchTypes = Update | Delete;
