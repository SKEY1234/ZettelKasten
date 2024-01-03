import { Card } from "antd"

export interface INoteProps {
    title: string;
    content: string;
}

export const Note: React.FC<INoteProps> = (props: INoteProps) => {

    return(
        <Card title={props.title} bordered={true} >
            {props.content}
        </Card>
    )
}