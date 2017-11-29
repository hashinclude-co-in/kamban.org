export interface IFormField {
    id: string;
    index: number;
    type: string;
    title: string;
    value: string;
    instruction: string;
    mandatory: boolean;
}

export interface IForm {
    id: string;
    title: string;
    description: string;
    fields: IFormField[];
}
