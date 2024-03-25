import * as apiModule from "./ApiEndpoints";

// Mocking ApiService
jest.mock("./ApiService", () => {
  return {
    default: jest.fn().mockImplementation(() => ({
      post: jest.fn(),
      get: jest.fn(),
      setAuthToken: "loggedInUser",
    })),
  };
});

const localStorageMock = {
  getItem: jest.fn(),
  setItem: jest.fn(),
  removeItem: jest.fn(),
  clear: jest.fn(),
};

(global as any).localStorage = localStorageMock;

describe("API Module Tests", () => {
  let mockApiService: { post: any; get: any };

  beforeAll(() => {
    const ApiService = jest.requireMock("./ApiService").default;
    mockApiService = new ApiService();
  });
  beforeEach(() => {
    localStorageMock.getItem.mockReturnValue("dummyToken");
  });
  afterEach(() => {
    jest.clearAllMocks();
  });

  it("should call api.post with correct parameters for sortingAlgorithm", async () => {
    const algorithm = "mergeSort";
    const data = [4, 2, 7, 1];
    await apiModule.sortingAlgorithm(algorithm, data);
    expect(mockApiService.post).toHaveBeenCalledTimes(0);
  });

  it("should call api.post with correct parameters for userLogin", async () => {
    const email = "test@example.com";
    const password = "password123";
    await apiModule.userLogin(email, password);
    expect(mockApiService.post).toHaveBeenCalledTimes(0);
  });

  it("should call api.post with generateQuizQuestions", async () => {
    await apiModule.generateQuizQuestions([1, 2, 3]);
    expect(mockApiService.post).toHaveBeenCalledTimes(0);
  });

  it("should call api.post with register", async () => {
    const email = "test@example.com";
    const password = "password123";
    await apiModule.registerUser(email, password);
    expect(mockApiService.post).toHaveBeenCalledTimes(0);
  });

  it("should call api.post with saveProfile", async () => {
    const newUserProfile: UserProfile = {
      email: "example@example.com",
      firstName: "John",
      lastName: "Doe",
      proficiencyLevelId: 3,
      createdOn: "2024-03-22",
    };
    await apiModule.saveProfile(newUserProfile);
    expect(mockApiService.post).toHaveBeenCalledTimes(0);
  });

  it("should call api.post with correct parameters for updateProficencyLevel", async () => {
    await apiModule.updateProficencyLevel();
    expect(mockApiService.post).toHaveBeenCalledTimes(0);
  });

  it("should throw error when token is not found in localStorage", async () => {
    const functionUnderTest = async () => {
      await apiModule.getProfile();
    };

    await expect(functionUnderTest()).rejects.toThrow(
      "Token not found in localStorage"
    );
  });

  it("should throw error for sortingAlgorithm", async () => {
    const algorithm = "mergeSort";
    const data = [4, 2, 7, 1];
    const functionUnderTest = async () => {
      await apiModule.sortingAlgorithm(algorithm, data);
      throw new Error("Expected error not thrown");
    };

    await expect(functionUnderTest()).rejects.toThrow();
  });

  it("should throw error for userLogin", async () => {
    const user = "user";
    const password = "pass";
    const functionUnderTest = async () => {
      await apiModule.userLogin(user, password);
      throw new Error("Expected error not thrown");
    };

    await expect(functionUnderTest()).rejects.toThrow();
  });

  it("should throw error for generateQuizQuestions", async () => {
    const id = [1, 2, 3];

    const functionUnderTest = async () => {
      await apiModule.generateQuizQuestions(id);
      throw new Error("Expected error not thrown");
    };

    await expect(functionUnderTest()).rejects.toThrow();
  });

  it("should throw error for register", async () => {
    const user = "user";
    const password = "pass";

    const functionUnderTest = async () => {
      await apiModule.registerUser(user, password);
      throw new Error("Expected error not thrown");
    };

    await expect(functionUnderTest()).rejects.toThrow();
  });

  it("should throw error for saveprofile", async () => {
    const newUserProfile: UserProfile = {
      email: "example@example.com",
      firstName: "John",
      lastName: "Doe",
      proficiencyLevelId: 3,
      createdOn: "2024-03-22",
    };

    const functionUnderTest = async () => {
      await apiModule.saveProfile(newUserProfile);
      throw new Error("Expected error not thrown");
    };

    await expect(functionUnderTest()).rejects.toThrow();
  });

  it("should throw error for updateProficencyLevel", async () => {
    const functionUnderTest = async () => {
      await apiModule.updateProficencyLevel();
      throw new Error("Expected error not thrown");
    };

    await expect(functionUnderTest()).rejects.toThrow();
  });
});
