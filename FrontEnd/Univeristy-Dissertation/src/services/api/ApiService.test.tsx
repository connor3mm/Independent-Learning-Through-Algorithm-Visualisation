import axios from "axios";
import ApiAuthService from "./ApiService";

jest.mock("axios");
const mockedAxios = axios as jest.Mocked<typeof axios>;

describe("ApiAuthService", () => {
  const baseUrl = "https://example.com/api";
  const authToken = "mockAuthToken";
  let apiAuthService: ApiAuthService;

  beforeEach(() => {
    apiAuthService = new ApiAuthService(baseUrl, authToken);
  });

  afterEach(() => {
    jest.clearAllMocks();
  });

  describe("get", () => {
    it("should make a GET request with the provided endpoint", async () => {
      const endpoint = "/test";
      const responseData = { message: "Test data" };
      const mockGet = jest
        .spyOn(apiAuthService, "get")
        .mockResolvedValueOnce(responseData);
      const mockResponse = { data: responseData };
      mockedAxios.request.mockResolvedValueOnce(mockResponse);

      apiAuthService.setAuthToken("token");

      await apiAuthService.get(endpoint);

      expect(mockGet).toHaveBeenCalledTimes(1);
    });

    it("should throw an error if request fails", async () => {
      const endpoint = "/test";
      const errorMessage =
        "Cannot read properties of undefined (reading 'request')";
      mockedAxios.request.mockRejectedValueOnce(new Error(errorMessage));

      await expect(apiAuthService.get(endpoint)).rejects.toThrowError(
        errorMessage
      );
    });
  });

  describe("post", () => {
    it("should make a post request with the provided endpoint", async () => {
      const endpoint = "/test";
      const responseData = { message: "Test data" };
      const mockPost = jest
        .spyOn(apiAuthService, "post")
        .mockResolvedValueOnce(responseData);
      const mockResponse = { data: responseData };
      mockedAxios.request.mockResolvedValueOnce(mockResponse);

      await apiAuthService.post(endpoint, responseData);

      expect(mockPost).toHaveBeenCalledTimes(1);
    });
  });

  describe("put", () => {
    it("should make a put request with the provided endpoint", async () => {
      const endpoint = "/test";
      const responseData = { message: "Test data" };
      const mockPut = jest
        .spyOn(apiAuthService, "put")
        .mockResolvedValueOnce(responseData);
      const mockResponse = { data: responseData };
      mockedAxios.request.mockResolvedValueOnce(mockResponse);

      await apiAuthService.put(endpoint, responseData);

      expect(mockPut).toHaveBeenCalledTimes(1);
    });
  });
  describe("patch", () => {
    it("should make a put request with the provided endpoint", async () => {
      const endpoint = "/test";
      const responseData = { message: "Test data" };
      const mockPatch = jest
        .spyOn(apiAuthService, "patch")
        .mockResolvedValueOnce(responseData);
      const mockResponse = { data: responseData };
      mockedAxios.request.mockResolvedValueOnce(mockResponse);

      await apiAuthService.patch(endpoint, responseData);

      expect(mockPatch).toHaveBeenCalledTimes(1);
    });
  });
});
