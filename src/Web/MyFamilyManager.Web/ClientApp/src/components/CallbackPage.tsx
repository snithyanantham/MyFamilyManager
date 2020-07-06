import * as React from 'react';
import { connect } from 'react-redux';
import { CallbackComponent } from 'redux-oidc';
import { push } from 'react-router-redux';
import userManager from '../utils/userManager';
import { UserManager } from 'oidc-client';
import { RouteComponentProps } from 'react-router';

type CallbackPageProps = RouteComponentProps<{}> & { dispatch: any }

class CallbackPage extends React.Component<CallbackPageProps, {}> {
    render() {
        return (
            <CallbackComponent
                userManager={userManager}
                successCallback={() => this.props.dispatch(push('/'))}
                errorCallback={error => {
                    this.props.dispatch(push('/'));
                    console.error(error);
                }}
            >
                <div>Redirecting...</div>
            </CallbackComponent>
        );
    }
}

export default connect()(CallbackComponent);