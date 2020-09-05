import React from "react";
import { TestLogin } from "./TestLogin";
import { TestLogout } from "./TestLogout";

interface HomeProps {}

export const Home: React.FC<HomeProps> = ({}) => {
  return (
    <div>
      <TestLogin />
      <TestLogout />
    </div>
  );
};
