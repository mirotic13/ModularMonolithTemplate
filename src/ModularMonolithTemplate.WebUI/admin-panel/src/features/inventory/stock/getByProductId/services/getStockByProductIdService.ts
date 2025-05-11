import axios from '@services/api/axios';
import type { GetStockByProductIdResponse } from '@inventory/stock/getByProductId/contracts/getStockByProductIdResponse';
import type { Result } from '@shared/utils/apiResponses';
import { API_ROUTES } from '@services/api/apiRoutes';
import { parseApiError } from '@shared/utils/parseApiError';
import { safeApiCall } from '@shared/utils/safeApiCall';

export const getStockByProductId = async (productId: string): Promise<GetStockByProductIdResponse> =>
  safeApiCall(async () => {
    const response = await axios.get<Result<GetStockByProductIdResponse>>(API_ROUTES.INVENTORY.SOTCK.GET_BY_PRODUCT_ID(productId));

    if (!response.data.isSuccess) throw parseApiError({ response });

    return response.data.value!;
  });