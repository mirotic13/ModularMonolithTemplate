export interface ApiError {
  code: string;
  message: string;
}

export interface Result<T> {
  isSuccess: boolean;
  isFailure: boolean;
  value?: T;
  error: ApiError;
}

export interface PagedResult<T> {
  isSuccess: boolean;
  isFailure: boolean;
  data?: T[];
  error: ApiError;
  page: number;
  pageSize: number;
  totalCount: number;
  totalPages: number;
}
