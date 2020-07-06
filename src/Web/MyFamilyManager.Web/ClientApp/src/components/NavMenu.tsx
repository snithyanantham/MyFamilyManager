import * as React from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import userManager from '../utils/userManager';
import { connect } from 'react-redux';

import './NavMenu.css';

interface NavProps {
    user: any,
    isAuthenticated: any
}

export default class NavMenu extends React.PureComponent<{}, { isOpen: boolean}> {
    public state = {
        isOpen: false
    };

    public render() {
       // const { user, isAuthenticated } = this.props;
        const onLoginButtonClick = (event: any) => {
            event.preventDefault();
            userManager.signinRedirect();
        };

        const onLogoutButtonClick = (event: any) => {
            event.preventDefault();
            //userManager.signoutRedirect({ id_token_hint: user.id_token });
            userManager.removeUser();
        };
        return (
            <header>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow mb-3" light>
                    <Container>
                        <NavbarBrand tag={Link} to="/">MyFamilyManager.Web</NavbarBrand>
                        <NavbarToggler onClick={this.toggle} className="mr-2" />
                        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={this.state.isOpen} navbar>
                            <ul className="navbar-nav flex-grow">
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/counter">Counter</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/fetch-data">Fetch data</NavLink>
                                </NavItem>
                                <NavItem>
                                    <button className="btn btn-primary" onClick={onLoginButtonClick}
                                    >
                                       Log In
                                    </button>
                                </NavItem>
                            </ul>
                        </Collapse>
                    </Container>
                </Navbar>
            </header>
        );
    }

    private toggle = () => {
        this.setState({
            isOpen: !this.state.isOpen
        });
    }
}
