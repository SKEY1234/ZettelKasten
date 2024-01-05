import {
    MenuFoldOutlined,
    MenuUnfoldOutlined,
    FileOutlined,
    TagOutlined,
  } from '@ant-design/icons';
  import { Layout, Menu, Button, Input, theme, Col, Card, Row, Spin } from 'antd';
import { useState } from 'react';
import { Note } from '../components/Note';
import { Table } from '../components/Table';
import { store } from '../store/Store';

export const BasePage: React.FC = () => {
    //const { Header, Sider, Content } = Layout;
    const { Search } = Input;

    const [collapsed, setCollapsed] = useState(false);
    const {
        token: { colorBgContainer, borderRadiusLG },
    } = theme.useToken();

    const handleInput = (event: React.FormEvent<HTMLElement>) => {
        console.log(event.target);
    }

    return(
        <Layout style={{ height: '100vh' }}>
            <Layout.Sider trigger={null} collapsible collapsed={collapsed}>
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
            </Layout.Sider>
        <Layout>
            <Layout.Header style={{ padding: 0, background: colorBgContainer }} >
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
                    loading enterButton onInput={handleInput}
                    />
                </div>
            </Layout.Header>
            <Layout.Content
                style={{
                    margin: '24px 16px',
                    padding: 24,
                    minHeight: 280,
                    background: colorBgContainer,
                    borderRadius: borderRadiusLG,
                }}
                >
                {store.isLoading && <Spin style={{ display: 'block', margin: 'auto', padding: 100 }} />} 
                {!store.isLoading && <Table />}
            </Layout.Content>
            </Layout>
        </Layout>
    )
}