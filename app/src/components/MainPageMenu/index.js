import React from "react";
import {
    Container
} from './styles'
import { Menu } from 'antd';
import { UnorderedListOutlined, AppstoreOutlined } from '@ant-design/icons';
const { SubMenu } = Menu;

const MainPageMenu = props => {
    const handleClick = e => {
        window.location.href = `${window.location.origin}/${e.key}`;
    }

    return (
        <Container>
            <Menu onClick={handleClick} style={{ width: 256 }} mode="vertical">
                <Menu.Item key="dashboard" icon={<UnorderedListOutlined />}>
                    Dashboard
                </Menu.Item>
                <SubMenu key="sensors" icon={<AppstoreOutlined />} title="Sensors">
                    <Menu.Item key="sensors">List</Menu.Item>
                    <Menu.Item key="sensors/add">Add</Menu.Item>
                </SubMenu>
            </Menu>
        </Container >
    )
}

export default MainPageMenu