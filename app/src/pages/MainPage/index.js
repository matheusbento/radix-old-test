import React from "react";
import {
    Container,
    Menu,
    Content
} from './styles'
import Routes from './../../routes';
import MainPageMenu from "@components/MainPageMenu";

const MainPage = props => {
    return (
        <Container>
            <Menu>
                <MainPageMenu />
            </Menu>
            <Content>
                <Routes />
            </Content>
        </Container>
    )
}

export default MainPage