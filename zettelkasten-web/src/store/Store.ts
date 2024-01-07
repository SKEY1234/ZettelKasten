import { observable, runInAction } from "mobx";
import { INote } from "../models/INote";
import { createNote, createTag, deleteNote, deleteTag, getNotes, getTags, updateNote, updateTag } from "../api/Api";
import { ITag } from "../models/ITag";

interface IStore {
    notes: INote[];
    tags: ITag[];
    noteCreatorModalVisible: boolean;
    noteEditorModalVisible: boolean;
    tagCreatorModalVisible: boolean;
    tagEditorModalVisible: boolean;
    noteTableColumnsNum: number;
    isLoading: boolean;
    loadingMessage: string;
    hasResult: boolean;
    isSuccess: boolean;
    showAlert: boolean;
    errorMessages: string[] | undefined;
    mortgageId: string | undefined;
    setNotes: (notes: INote[]) => void;
    setTags: (tags: ITag[]) => void;
    createNote: (note: INote) => void;
    updateNote: (note: INote) => void;
    createTag: (tag: ITag) => void;
    updateTag: (tag: ITag) => void;
    setCheckedNote: (noteId: string, checked: boolean) => void;
    setCheckedTag: (key: React.Key, checked: boolean) => void;
    setTagKey: (tagId: string) => void;
    setLoading: (loading: boolean) => void;
    setLoadingMessage: (loadingMsg: string) => void;
    setHasResult: (hasResult: boolean) => void;
    setErrorMessages: (message: string[] | undefined) => void;
    setSuccess: (isSuccess: boolean) => void;
    setShowAlert: (showAlert: boolean) => void;
    getResultMessage: () => string;
    getNotes: () => void;
    getTags: () => void;
    deleteNotes: () => void;
    deleteTags: () => void;
    setNoteCreatorModalVisible: (visible: boolean) => void;
    setNoteEditorModalVisible: (visible: boolean) => void;
    setTagCreatorModalVisible: (visible: boolean) => void;
    setTagEditorModalVisible: (visible: boolean) => void;
    setNoteTableColumnsNum: (columnsNum: number) => void;
}

export function createstore(): IStore {
    return {
        notes: [],
        tags: [],
        noteCreatorModalVisible: false,
        noteEditorModalVisible: false,
        tagCreatorModalVisible: false,
        tagEditorModalVisible: false,
        noteTableColumnsNum: 2,
        isLoading: false,
        loadingMessage: '',
        hasResult: false,
        isSuccess: false,
        showAlert: false,
        errorMessages: [],
        mortgageId: undefined,

        setNotes(notes: INote[]) {
            runInAction(() => {
                this.notes = notes;
            });
        },

        setTags(tags: ITag[]) {
            runInAction(() => {
                this.tags = tags;
                this.tags.forEach(t => 
                    this.setTagKey(t.tagId!))
            });
        },

        setCheckedNote(noteId: string, checked: boolean) {
            this.notes = this.notes.map(n => {
                if (n.noteId == noteId)
                    return { ...n, checked: checked};
                else
                    return n;
            });
        },

        setCheckedTag(key: React.Key, checked: boolean) {
            this.tags = this.tags.map(t => {
                if (t.key == key)
                    return { ...t, checked: checked};
                else
                    return t;
            });
        },

        setTagKey(tagId: string) {
            this.tags = this.tags.map(n => {
                if (n.tagId == tagId)
                    return { ...n, key: tagId};
                else
                    return n;
            });
        },

        setNoteCreatorModalVisible(visible: boolean) {
            this.noteCreatorModalVisible = visible;
        },

        setNoteEditorModalVisible(visible: boolean) {
            this.noteEditorModalVisible = visible;
        },

        setTagCreatorModalVisible(visible: boolean) {
            this.tagCreatorModalVisible = visible;
        },

        setTagEditorModalVisible(visible: boolean) {
            this.tagEditorModalVisible = visible;
        },

        setNoteTableColumnsNum(columnsNum: number) {
            this.noteTableColumnsNum = columnsNum;
        },

        setLoading(isLoading: boolean) {
            this.isLoading = isLoading;
        },

        setLoadingMessage(loadingMsg: string) {
            this.loadingMessage = loadingMsg;
        },

        setHasResult(hasResult: boolean) {
            this.hasResult = hasResult;
        },

        setErrorMessages(errorMessages: string[] | undefined) {
            this.errorMessages = errorMessages;
        },

        setSuccess(isSuccess: boolean) {
            this.isSuccess = isSuccess;
        },

        setShowAlert(showAlert: boolean) {
            this.showAlert = showAlert;
        },

        getResultMessage() {
            return this.isSuccess 
            ? `${this.loadingMessage} завершен(а) успешно`
            : `${this.loadingMessage} завершен(а) с ошибками`
        },

        async getNotes() {
            this.setLoading(true);
            const response = await getNotes();
            
            this.setSuccess(response?.isSuccess ?? false);

            if (response?.value) {
                this.setNotes(response.value!);
            }
            if (response?.errors) {
                this.setErrorMessages(response?.errors);
            }

            this.setLoading(false);
        },

        async deleteNotes() {
            this.setLoading(true);

            this.notes.filter(n => n.checked)
                .forEach(async (n) => 
                    await deleteNote(n.noteId!));

            this.setLoading(false);
        },

        async createNote(note: INote) {
            this.setLoading(true);

            const response = await createNote(note);

            console.log('created note:', response.value);

            this.setLoading(false);
        },

        async updateNote(note: INote) {
            this.setLoading(true);

            await updateNote(note);

            this.setLoading(false);
        },

        async getTags() {
            this.setLoading(true);
            const response = await getTags();
            
            this.setSuccess(response?.isSuccess ?? false);

            if (response?.value) {
                this.setTags(response.value!);
            }

            if (response?.errors) {
                this.setErrorMessages(response?.errors);
            }

            this.setLoading(false);
        },

        async deleteTags() {
            this.setLoading(true);

            this.tags.filter(n => n.checked)
                .forEach(async (n) => 
                    await deleteTag(n.tagId!));

            this.setLoading(false);
        },

        async createTag(tag: ITag) {
            this.setLoading(true);

            await createTag(tag);

            this.setLoading(false);
        },

        async updateTag(tag: ITag) {
            this.setLoading(true);

            await updateTag(tag);

            this.setLoading(false);
        },
    }
}

export const store = observable(createstore()) 