using System.Net.Http.Json;

namespace BlazorMulitpleFormApp.Services;

public interface IStep1ApiService
{
    Task<bool> ValidateStep1Async(Step1Data data);
}

public class Step1ApiService : IStep1ApiService
{
    private readonly HttpClient _httpClient;

    public Step1ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> ValidateStep1Async(Step1Data data)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/validateStep1", data);
        return response.IsSuccessStatusCode;
    }
}
public class DammyStep1ApiService : IStep1ApiService
{
    public async Task<bool> ValidateStep1Async(Step1Data data)
    {
        return await Task.FromResult(true);
    }
}


public class Step1Service
{
    private readonly IStep1ApiService _step1ApiService;

    // Step1 data model
    public Step1Data Data { get; private set; } = new Step1Data();

    // Event to notify when the validation state changes
    public event Action OnValidationStateChanged;

    // Property to check if Step 1 is valid
    public bool IsStepValid => Data.IsValid;

    public Step1Service(IStep1ApiService step1ApiService)
    {
        _step1ApiService = step1ApiService;
    }

    // Method to validate Step 1
    public async Task ValidateStep1()
    {
        // Call the API service to validate Step 1's data
        Data.IsValid = await _step1ApiService.ValidateStep1Async(Data);

        // Notify subscribers that the validation state has changed
        OnValidationStateChanged?.Invoke();
    }

    // Method to update Step 1 data
    public void UpdateData(string name, int age)
    {
        Data.Name = name;
        Data.Age = age;

        // Optionally trigger revalidation here if needed
        // await ValidateStep1();
    }
}
