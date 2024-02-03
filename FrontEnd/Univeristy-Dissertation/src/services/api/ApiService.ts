import axios, { AxiosInstance, AxiosError } from "axios";

class ApiAuthService {
  private axiosInstance: AxiosInstance;
  private authToken: string | null;

  constructor(baseUrl: string, authToken: string | null) {
    this.authToken = authToken;
    this.axiosInstance = axios.create({
      baseURL: baseUrl,
      headers: {
        Authorization: `Bearer ${authToken}`,
        "Content-Type": "application/json",
      },
    });
  }

  private handleError(error: AxiosError) {
    if (error.response) {
      const { status, data } = error.response;
      throw new Error(
        `Request failed with status: ${status} - ${JSON.stringify(data)}`
      );
    } else if (error.request) {
      throw new Error("Request failed: No response received");
    } else {
      throw new Error(`Request failed: ${error.message}`);
    }
  }

  setAuthToken(authToken: string | null) {
    this.authToken = authToken;
  }

  private async request(method: string, endpoint: string, data?: any) {
    try {
      const response = await this.axiosInstance.request({
        method,
        url: endpoint,
        data,
        headers: {
          Authorization: `Bearer ${this.authToken}`,
        },
      });
      return response.data;
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

export default ApiAuthService;
