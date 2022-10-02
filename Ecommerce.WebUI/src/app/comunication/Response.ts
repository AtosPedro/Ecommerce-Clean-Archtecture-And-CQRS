import { ErrorResponse } from "./ErrorResponse"

export interface Response{
    data: any
    message: string
    error: boolean
    errorResponse: ErrorResponse
}