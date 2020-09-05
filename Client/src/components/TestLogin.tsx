import React from "react";
import { useAuth0 } from "@auth0/auth0-react";

interface TestLoginProps {}

export const TestLogin: React.FC<TestLoginProps> = ({}) => {
  const { loginWithRedirect } = useAuth0();

  return <button onClick={() => loginWithRedirect()}>Log In</button>;
};
