class ApiService {
  private baseUrl: string;

  constructor(baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public parse = (data: any) => {
    try {
      return JSON.parse(data);
    } catch (error: any) {
      throw new Error("Error parsing response data: " + error.message);
    }
  };

  private async handleResponse(response: Response) {
    if (!response.ok) {
      throw new Error(`Request failed with status: ${response.status}`);
    }

    const data = await response.json();
    return data;
  }

  private async request(method: string, endpoint: string, body?: any) {
    const requestOptions: RequestInit = {
      method,
      headers: {
        "Content-Type": "application/json",
      },
    };

    if (body) {
      requestOptions.body = JSON.stringify(body);
    }

    const response = await fetch(`${this.baseUrl}${endpoint}`, requestOptions);
    return this.handleResponse(response);
  }

  async get(endpoint: string) {
    return this.request("GET", endpoint);
  }

  async post(endpoint: string, body: any) {
    return this.request("POST", endpoint, body);
  }

  async put(endpoint: string, body: any) {
    return this.request("PUT", endpoint, body);
  }
}

export default ApiService;
