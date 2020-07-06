import { createUserManager } from 'redux-oidc';

const userManagerConfig = {
    client_id:'reactclient',
    redirect_uri: 'https://localhost:44303/callback',
    post_logout_redirect_uri: 'https://localhost:44303',
    response_type: 'id_token token',
    scope: 'openid profile api1',
    authority: 'https://localhost:44341',
    silent_redirect_uri: 'https://localhost:44303/silent_renew.html',
    automaticSilentRenew: true,
    filterProtocolClaims: true,
    loadUserInfo: true,
    monitorSession: true
};

const userManager = createUserManager(userManagerConfig);

export default userManager;