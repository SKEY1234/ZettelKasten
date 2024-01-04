import { observable, runInAction } from "mobx";
import { INote } from "../models/INote";
import { getNotes } from "../api/Api";

interface IStore {
    notes: INote[];
    isLoading: boolean;
    loadingMessage: string;
    hasResult: boolean;
    isSuccess: boolean;
    showAlert: boolean;
    errorMessages: string[] | undefined;
    mortgageId: string | undefined;
    setNotes: (notes: INote[]) => void;
    setLoading: (loading: boolean) => void;
    setLoadingMessage: (loadingMsg: string) => void;
    setHasResult: (hasResult: boolean) => void;
    setErrorMessages: (message: string[] | undefined) => void;
    setSuccess: (isSuccess: boolean) => void;
    setShowAlert: (showAlert: boolean) => void;
    getResultMessage: () => string;
    getNotes: () => void;
}

export function createstore(): IStore {
    return {
        notes: [],
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
    }
}

export const store = observable(createstore()) 