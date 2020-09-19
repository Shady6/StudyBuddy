import { AxiosError } from "axios";

export const handleAxiosError = <T, R>(ex: any, callback: (error: T) => R) => {
  const axiosError = ex as AxiosError<{ errors: T }>;
  if (axiosError && axiosError.response)
    callback(axiosError.response.data.errors);
};
