using System.Net.Http.Json;

namespace BlazorMulitpleFormApp.Services;

public interface IStep2ApiService
{
    Task<bool> ValidateStep2Async(Step2Data data);
}
public class Step2ApiService : IStep2ApiService
{
    private readonly HttpClient _httpClient;

    public Step2ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> ValidateStep2Async(Step2Data data)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/validateStep2", data);
        return response.IsSuccessStatusCode;
    }
}
public class DammyStep2ApiService : IStep2ApiService
{
    public async Task<bool> ValidateStep2Async(Step2Data data)
    {
        return await Task.FromResult(true);
    }
}
public class Step2Service
{
    private readonly IStep2ApiService _step2ApiService;

    // Step2 data model
    public Step2Data Data { get; private set; } = new Step2Data();

    // Event to notify when the validation state changes
    public event Action OnValidationStateChanged;

    // Property to check if Step 2 is valid
    public bool IsStepValid => Data.IsValid;

    public Step2Service(IStep2ApiService step2ApiService)
    {
        _step2ApiService = step2ApiService;
    }

    // Method to validate Step 2
    public async Task ValidateStep2()
    {
        // Call the API service to validate Step 2's data
        Data.IsValid = await _step2ApiService.ValidateStep2Async(Data);

        // Notify subscribers that the validation state has changed
        OnValidationStateChanged?.Invoke();
    }

    // Method to update Step 2 data
    public void UpdateData(string address, string city)
    {
        Data.Address = address;
        Data.City = city;

        // Optionally trigger revalidation here if needed
        // await ValidateStep2();
    }
}


