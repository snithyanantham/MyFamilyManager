"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_redux_1 = require("react-redux");
var redux_oidc_1 = require("redux-oidc");
var react_router_redux_1 = require("react-router-redux");
var userManager_1 = require("../utils/userManager");
var CallbackPage = /** @class */ (function (_super) {
    __extends(CallbackPage, _super);
    function CallbackPage() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    CallbackPage.prototype.render = function () {
        var _this = this;
        return (React.createElement(redux_oidc_1.CallbackComponent, { userManager: userManager_1.default, successCallback: function () { return _this.props.dispatch(react_router_redux_1.push('/')); }, errorCallback: function (error) {
                _this.props.dispatch(react_router_redux_1.push('/'));
                console.error(error);
            } },
            React.createElement("div", null, "Redirecting...")));
    };
    return CallbackPage;
}(React.Component));
exports.default = react_redux_1.connect()(redux_oidc_1.CallbackComponent);
//# sourceMappingURL=CallbackPage.js.map