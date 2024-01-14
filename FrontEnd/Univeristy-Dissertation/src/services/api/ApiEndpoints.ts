import ApiService from "./ApiService";

const api = new ApiService("http://localhost:5137/");

export const sortingAlgorithm = async (algorithm: string, data: number[]) => {
  try {
    const response = await api.post(`sortingAlgorithm/${algorithm}/`, data);
    return response;
  } catch (error: any) {
    console.log(error.message);
    throw error;
  }
};

export const userLogin = async (email: string, password: string) => {
  try {
    const response = await api.post("login", { email, password });
    console.log(response);
    return response;
  } catch (error: any) {
    console.log(error.message);
    throw error;
  }
};

export const registerUser = async (email: string, password: string) => {
  try {
    const response = await api.post("register", { email, password });
    console.log(response);
    return response;
  } catch (error: any) {
    console.log(error.message);
    throw error;
  }
};
