import { Col, Dropdown, MenuProps, Row, Space, Typography } from "antd"
import { DownOutlined } from '@ant-design/icons';
import { Note } from "./Note"
import React, { useState } from "react";
import { data } from "../api/Api";
import { useMount } from "ahooks";

export const Table: React.FC = () => {
    const [columnsNum, setColumnsNum] = useState<number>(2);

    // useMount(() => {
    //     drawTable();
    // })

    const columns: React.ReactElement[] = [];
    const rows: any[] = [];
    const wholeRows: number = data.length / columnsNum;

    for (let i = 0; i < data.length; i++) {
        columns.push(
        <Col span={24 / columnsNum} >
            <Note title={data[i].title} content={data[i].content}/>
        </Col>);
    }

    for (let i = 0, j = 0;  i < wholeRows; i++) {
        rows.push(
        //<div style={{ marginBottom: 16 }}>
            <Row gutter={[16, 16]}>
                {columns.slice(j, j + columnsNum)}
            </Row>);
        //</div>);
        j += columnsNum;
    }

    const handleSizeClick = (event: any) => {
        console.log(event)
        setColumnsNum(event.key)
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
            {rows}
            {wholeRows}
        </>
    )
}