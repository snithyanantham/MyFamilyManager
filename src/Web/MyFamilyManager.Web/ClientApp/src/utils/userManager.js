"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var redux_oidc_1 = require("redux-oidc");
var userManagerConfig = {
    client_id: 'reactclient',
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
var userManager = redux_oidc_1.createUserManager(userManagerConfig);
exports.default = userManager;
//# sourceMappingURL=userManager.js.map