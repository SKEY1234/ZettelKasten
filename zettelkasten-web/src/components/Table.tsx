import { Col, Row } from "antd"
import { Note } from "./Note"

export const Table: React.FC = () => {

    return (
        <>
            <Row gutter={16}>
                <Col span={8}>
                    <Note />
                </Col>
                <Col span={8}>
                    <Note />
                </Col>
                <Col span={8}>
                    <Note />
                </Col>
            </Row>
            <Row gutter={16} >
                <Col span={8}>
                    <Note />
                </Col>
                <Col span={8}>
                    <Note />
                </Col>
                <Col span={8}>
                    <Note />
                </Col>
            </Row>
        </>
    )
}