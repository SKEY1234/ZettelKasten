import { observable, runInAction } from "mobx";
import { INote } from "../models/INote";
import { createNote, deleteNote, getNotes, updateNote } from "../api/Api";

interface IStore {
    notes: INote[];
    noteCreatorModalVisible: boolean;
    noteEditorModalVisible: boolean;
    noteTableColumnsNum: number;
    isLoading: boolean;
    loadingMessage: string;
    hasResult: boolean;
    isSuccess: boolean;
    showAlert: boolean;
    errorMessages: string[] | undefined;
    mortgageId: string | undefined;
    setNotes: (notes: INote[]) => void;
    createNote: (note: INote) => void;
    updateNote: (note: INote) => void;
    setChecked: (noteId: string, checked: boolean) => void;
    setLoading: (loading: boolean) => void;
    setLoadingMessage: (loadingMsg: string) => void;
    setHasResult: (hasResult: boolean) => void;
    setErrorMessages: (message: string[] | undefined) => void;
    setSuccess: (isSuccess: boolean) => void;
    setShowAlert: (showAlert: boolean) => void;
    getResultMessage: () => string;
    getNotes: () => void;
    deleteNotes: () => void;
    setNoteCreatorModalVisible: (visible: boolean) => void;
    setNoteEditorModalVisible: (visible: boolean) => void;
    setNoteTableColumnsNum: (columnsNum: number) => void;
}

export function createstore(): IStore {
    return {
        notes: [],
        noteCreatorModalVisible: false,
        noteEditorModalVisible: false,
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

        setChecked(noteId: string, checked: boolean) {
            this.notes = this.notes.map(n => {
                if (n.noteId == noteId)
                    return { ...n, checked: checked};
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

            await createNote(note);

            this.setLoading(false);
        },

        async updateNote(note: INote) {
            this.setLoading(true);

            await updateNote(note);

            this.setLoading(false);
        },
    }
}

export const store = observable(createstore()) 