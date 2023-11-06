import ApiService from "./ApiService";
import ResponseCode from "../enums/ResponseCodes";

const api = new ApiService("http://localhost:5137/");

export const apiTester = async () => {
  const response = await api.get(`WeatherForecast`);
  return response;

  if (response.status === ResponseCode.Success) {
    return response.dat;
  } else {
    console.log("hello error");
    throw new Error("Requests were not approved.");
  }
};

export const apiTesterAddOne = async (count: number) => {
  //const response = await api.get(`/approverequest/${count}`);

  return count + 1;
};
