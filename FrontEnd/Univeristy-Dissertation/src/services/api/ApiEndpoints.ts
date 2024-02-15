import ApiService from "./ApiService";

const defaultUrl = "https://localhost:7206/";
const api = new ApiService(defaultUrl, null);

export const sortingAlgorithm = async (algorithm: string, data: number[]) => {
  try {
    const responseData = await api.post(`sortingAlgorithm/${algorithm}/`, data);
    return responseData;
  } catch (error: any) {
    console.log(error.message);
    throw error;
  }
};

export const userLogin = async (email: string, password: string) => {
  try {
    const response = await api.post("login", { email, password });
    return response;
  } catch (error: any) {
    console.log(error.message);
    throw error;
  }
};

export const registerUser = async (email: string, password: string) => {
  try {
    const response = await api.post("register", { email, password });
    return response;
  } catch (error: any) {
    console.log(error.message);
    throw error;
  }
};

export const getProfile = async () => {
  setUserToken();

  try {
    const responseData = await api.get(`profile`);
    return responseData;
  } catch (error: any) {
    console.log(error.message);
    throw error;
  }
};

export const saveProfile = async (userProfile: UserProfile) => {
  try {
    const responseData = await api.post(`profile/saveprofile`, userProfile);
    return responseData;
  } catch (error: any) {
    console.log(error.message);
    throw error;
  }
};

export const generateQuizQuestions = async () => {
  try {
    const responseData = await api.get(`quiz/generatequiz`);
    return responseData;
  } catch (error: any) {
    console.log(error.message);
    throw error;
  }
};

export const saveCurrentUserStatistics = async (userStatistics: any) => {
  setUserToken();
  try {
    return await api.post(`profile/saveuserstatistics`, userStatistics);
  } catch (error: any) {
    console.log(error.message);
    throw error;
  }
};

export const getUserStatistics = async () => {
  setUserToken();
  try {
    return await api.get(`profile/userstatistics`);
  } catch (error: any) {
    console.log(error.message);
    throw error;
  }
};

const setUserToken = () => {
  try {
    const token = localStorage.getItem("loggedInUser");
    if (!token) {
      throw new Error("Token not found in localStorage");
    }
    api.setAuthToken(token);
  } catch (error) {
    throw error;
  }
};
