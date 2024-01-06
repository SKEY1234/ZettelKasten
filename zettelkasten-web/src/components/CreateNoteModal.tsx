import { Input, Modal } from "antd";
import { observer } from "mobx-react";
import { useState } from "react";
import { store } from "../store/Store";

export const CreateNoteModal = observer(() => {
    const [titleText, setTitleText] = useState<string>('');
    const [contentText, setContentText] = useState<string>('');
    const [confirmLoading, setConfirmLoading] = useState<boolean>(false);
    
    const handleOk = async () => {
        setConfirmLoading(true);

        await store.createNote({
            noteId: undefined,
            title: titleText,
            content: contentText,
            createdOn: new Date,
            checked: false
        });
        await store.getNotes();
        store.setNoteCreatorModalVisible(false);
        setConfirmLoading(false);
    };
    
    const handleCancel = () => {
        store.setNoteCreatorModalVisible(false);
    };

    const handleTitleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setTitleText(event.target.value);
    }

    const handleContentChange = (event: React.ChangeEvent<HTMLTextAreaElement>) => {
        setContentText(event.target.value);
    }

    return (
        <>
            <Modal
            title="New note"
            open={store.noteCreatorModalVisible}
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
})