import React, { useEffect } from "react";
import {Route} from "react-router-dom"
import { useAuth0 } from "@auth0/auth0-react";

interface PrivateRouteProps{
    component: React.FC
    path: string
}

const PrivateRoute: React.FC<PrivateRouteProps> = ({ component: Component, path, ...rest }) => {
  const { isLoading, isAuthenticated, loginWithRedirect } = useAuth0();

  useEffect(() => {
    if (isLoading || isAuthenticated) {
      return;
    }
    const fn = async () => {
      await loginWithRedirect({
        appState: { targetUrl: path },
      });
    };
    fn();
  }, [isLoading, isAuthenticated, loginWithRedirect, path]);

  const render = (props: any) =>
    !isLoading && isAuthenticated === true ? (
      <Component {...props} {...rest} />
    ) : (
      loginWithRedirect
    );

  return <Route path={path} render={render} {...rest} />;
};

export default PrivateRoute;