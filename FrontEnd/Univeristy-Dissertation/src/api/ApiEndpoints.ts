import ApiService from "./ApiService";

const api = new ApiService("http://localhost:5137/");

export const apiTester = async () => {
  try {
    const response = await api.get(`WeatherForecast/firstendpoint`);
    return response;
  } catch (error) {
    console.error(error);
  }
};

export const bubbleSort = async (data: number[]) => {
  try {
    const response = await api.post(`sortingAlgorithm/bubblesort/`, data);
    return response;
  } catch (error: any) {
    console.log(error.message);
  }
};
