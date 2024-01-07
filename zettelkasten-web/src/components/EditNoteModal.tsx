import { Modal, Input } from "antd";
import { observer } from "mobx-react";
import { store } from "../store/Store";
import { useState } from "react";

export interface IEditNoteProps {
    noteId: string;
    title: string;
    content: string;
}

export const EditNoteModal = observer((props: IEditNoteProps) => {
    const [titleText, setTitleText] = useState<string>(props.title);
    const [contentText, setContentText] = useState<string>(props.content);
    const [confirmLoading, setConfirmLoading] = useState<boolean>(false);

    const handleOk = async () => {
        setConfirmLoading(true);

        await store.updateNote({
            noteId: props.noteId,
            title: titleText,
            content: contentText,
            createdOn: new Date,
            checked: false
        });
        await store.getNotes();
        store.setNoteEditorModalVisible(false);
        setConfirmLoading(false);
    };
    
    const handleCancel = () => {
        store.setNoteEditorModalVisible(false);
    };

    const handleTitleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setTitleText(event.target.value);
    }

    const handleContentChange = (event: React.ChangeEvent<HTMLTextAreaElement>) => {
        setContentText(event.target.value);
    }

    return(
        <>
            <Modal
            title="Edit note"
            open={store.noteEditorModalVisible}
            onOk={handleOk}
            confirmLoading={confirmLoading}
            onCancel={handleCancel}
            >
                <Input 
                placeholder="Title" 
                style={{ marginBottom: 16 }} 
                value={titleText}
                onChange={handleTitleChange}/>
                <Input.TextArea 
                value={contentText}
                onChange={handleContentChange}
                placeholder="Content"
                autoSize={{ minRows: 3, maxRows: 5 }}
                />
            </Modal>
        </>
    )
});