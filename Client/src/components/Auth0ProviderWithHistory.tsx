import React from "react";
import { useHistory } from "react-router-dom";
import { Auth0Provider } from "@auth0/auth0-react";
import config from "../auth_config.json";

const Auth0ProviderWithHistory: React.FC = ({ children }) => {
  const domain = config.domain
  const clientId = config.clientId
  const audience = config.audience

  const history = useHistory();

  const onRedirectCallback = (appState: any) => {
    history.push(appState?.returnTo || window.location.pathname);
  };

  return (
    <Auth0Provider
      domain={domain}
      clientId={clientId}
      redirectUri={window.location.origin}
      audience={audience}
      onRedirectCallback={onRedirectCallback}
    >
      {children}
    </Auth0Provider>
  );
};

export default Auth0ProviderWithHistory;