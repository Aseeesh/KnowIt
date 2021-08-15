export interface GenericResponse<T> {
    status: string;
    data: T;
    errors?: string[];
}
