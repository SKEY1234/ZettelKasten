import { Button, Col, Divider, Dropdown, List, MenuProps, Row, Skeleton, Space, Typography } from "antd"
import { DownOutlined } from '@ant-design/icons';
import { Note } from "./Note"
import React, { useEffect, useState } from "react";
import { useMount } from "ahooks";
import { store } from "../store/Store";
import VirtualList from 'rc-virtual-list';
import { observer } from "mobx-react";

export const Table: React.FC = observer(() => {
    const [columnsNum, setColumnsNum] = useState<number>(2);
    //const [columns, setColumns] = useState<React.ReactElement[]>([]);
    const [rows, setRows] = useState<React.ReactElement[]>([]);
    //;

    useMount(async () => {
        await store.getNotes();
        drawTable();
    })

    useEffect(() => {
        drawTable();
    }, [columnsNum])

    const drawTable = () => {
        const columns: React.ReactElement[] = [];
        const rows: React.ReactElement[] = [];
        const wholeRows: number = store.notes.length / columnsNum;

        for (let i = 0; i < store.notes.length; i++) {
            columns.push(
            <Col span={24 / columnsNum} >
                <Note noteId={store.notes[i].noteId} title={store.notes[i].title} content={store.notes[i].content}/>
            </Col>);
        }
    
        for (let i = 0, j = 0;  i < wholeRows; i++) {
            rows.push(
                <Row gutter={16}>
                    {columns.slice(j, j + columnsNum)}
                </Row>);
            j += columnsNum;
        }

        setRows(rows);
        console.log('rendered');
    }

    const handleSizeClick = (event: any) => {
        console.log(event);
        setColumnsNum(event.key);
        //drawTable();
    }

    const handleDelete = async (event: React.MouseEvent<HTMLElement>) => {
        await store.deleteNotes();
        await store.getNotes();
        drawTable();
    }

    const items: MenuProps['items'] = [
        {
            key: 1,
            label: 'large',
        },
        {
            key: 2,
            label: 'medium',
        },
        {
            key: 3,
            label: 'small',
        },
    ];

    return (
        <>
            <div style={{ paddingBottom: 20 }}>
                <Dropdown
                    menu={{
                    items,
                    selectable: true,
                    defaultSelectedKeys: ['2'],
                    onClick: handleSizeClick
                    }}
                >
                    <Typography.Link>
                        <Space>
                            Size
                            <DownOutlined />
                        </Space>
                    </Typography.Link>
                </Dropdown>
                {store.notes.some(n => n.checked) && 
                <Button style={{ float: 'right' }} type="primary" danger onClick={handleDelete}>
                    Delete
                </Button>}
            </div>
            
            <div style={{ overflow: 'scroll', overflowX: 'hidden', height: '80vh', width: '100%' }}>
                {rows}
            </div>
        </>
    )
})