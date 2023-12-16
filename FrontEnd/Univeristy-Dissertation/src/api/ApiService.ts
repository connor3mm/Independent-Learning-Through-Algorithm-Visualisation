import axios, { AxiosInstance, AxiosResponse, AxiosError } from "axios";

class ApiService {
  private axiosInstance: AxiosInstance;

  constructor(baseUrl: string) {
    this.axiosInstance = axios.create({
      baseURL: baseUrl,
      headers: {
        "Content-Type": "application/json",
      },
    });
  }

  private handleResponse(response: AxiosResponse) {
    return response.data;
  }

  private handleError(error: AxiosError) {
    if (error.response) {
      throw new Error(`Request failed with status: ${error.response.status}`);
    } else if (error.request) {
      throw new Error("Request failed: No response received");
    } else {
      throw new Error(`Request failed: ${error.message}`);
    }
  }

  private async request(method: string, endpoint: string, data?: any) {
    try {
      const response = await this.axiosInstance.request({
        method,
        url: endpoint,
        data,
      });
      return this.handleResponse(response);
    } catch (error) {
      if (axios.isAxiosError(error)) {
        this.handleError(error as AxiosError);
      } else {
        throw error;
      }
    }
  }

  async get(endpoint: string) {
    return this.request("get", endpoint);
  }

  async post(endpoint: string, data: any) {
    return this.request("post", endpoint, data);
  }

  async put(endpoint: string, data: any) {
    return this.request("put", endpoint, data);
  }
}

export default ApiService;
