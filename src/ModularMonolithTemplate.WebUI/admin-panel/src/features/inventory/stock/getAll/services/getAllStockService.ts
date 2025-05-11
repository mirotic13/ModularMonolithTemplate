import axios from '@services/api/axios';
import type { GetAllStockResponse } from '@inventory/stock/getAll/contracts/getAllStockResponse';
import type { Result } from '@shared/utils/apiResponses';
import { API_ROUTES } from '@services/api/apiRoutes';
import { parseApiError } from '@shared/utils/parseApiError';
import { safeApiCall } from '@shared/utils/safeApiCall';

export const getAllStock = async (): Promise<GetAllStockResponse> =>
  safeApiCall(async () => {
    const response = await axios.get<Result<GetAllStockResponse>>(API_ROUTES.INVENTORY.SOTCK.GET_ALL);

    if (!response.data.isSuccess) throw parseApiError({ response });

    return response.data.value!;
  });