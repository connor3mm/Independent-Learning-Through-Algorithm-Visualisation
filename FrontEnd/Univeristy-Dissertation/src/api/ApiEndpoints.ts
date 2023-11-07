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

export const apiTesterAddOne = async (count: number) => {
  //const response = await api.get(`/approverequest/${count}`);

  return count + 1;
};

export const bubbleSort = async () => {
  try {
    const response = await api.get(`sortingAlgorithm/bubblesort`);
    return response;
  } catch (error: any) {
    console.log(error.message);
  }
};
