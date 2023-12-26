import {
    MenuFoldOutlined,
    MenuUnfoldOutlined,
    FileOutlined,
    TagOutlined,
  } from '@ant-design/icons';
  import { Layout, Menu, Button, Input, theme, Col, Card, Row } from 'antd';
import { useState } from 'react';
import { Note } from '../components/Note';
import { Table } from '../components/Table';

export const BasePage: React.FC = () => {
    const { Header, Sider, Content } = Layout;
    const { Search } = Input;

    const [collapsed, setCollapsed] = useState(false);
    const {
        token: { colorBgContainer, borderRadiusLG },
    } = theme.useToken();

    return(
        <Layout style={{ height: '100vh' }}>
            <Sider trigger={null} collapsible collapsed={collapsed}>
                <div className="demo-logo-vertical" />
                <Menu
                theme="dark"
                mode="inline"
                defaultSelectedKeys={['1']}
                items={[
                    {
                    key: '1',
                    icon: <FileOutlined />,
                    label: 'Notes',
                    },
                    {
                    key: '2',
                    icon: <TagOutlined />,
                    label: 'Tags',
                    }
                ]}
                />
            </Sider>
            <Layout>
                <Header style={{ padding: 0, background: colorBgContainer }} >
                <div style={{ display: 'flex' }}>
                    <Button
                    type="text"
                    icon={collapsed ? <MenuUnfoldOutlined /> : <MenuFoldOutlined />}
                    onClick={() => setCollapsed(!collapsed)}
                    style={{
                        fontSize: '16px',
                        width: 64,
                        height: 64,
                    }}
                    />
                    <Search style={{ padding: '20px' }} placeholder="input search loading with enterButton" 
                    loading enterButton 
                    />
                </div>
                </Header>
                <Content
                style={{
                    margin: '24px 16px',
                    padding: 24,
                    minHeight: 280,
                    background: colorBgContainer,
                    borderRadius: borderRadiusLG,
                }}
                >
                <Table />
                </Content>
            </Layout>
        </Layout>
    )
}