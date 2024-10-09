using System.Net.Http.Json;

namespace BlazorMulitpleFormApp.Services;

public interface IStep4ApiService
{
    Task<bool> ValidateStep4Async(Step4Data data);
}
public class Step4ApiService : IStep4ApiService
{
    private readonly HttpClient _httpClient;

    public Step4ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> ValidateStep4Async(Step4Data data)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/validateStep4", data);
        return response.IsSuccessStatusCode;
    }
}
public class DammyStep4ApiService : IStep4ApiService
{
    public async Task<bool> ValidateStep4Async(Step4Data data)
    {
        return await Task.FromResult(true);
    }
}
public class Step4Service
{
    private readonly IStep4ApiService _step4ApiService;

    // Step4 data model
    public Step4Data Data { get; private set; } = new Step4Data();

    // Event to notify when the validation state changes
    public event Action OnValidationStateChanged;

    // Property to check if Step 4 is valid
    public bool IsStepValid => Data.IsValid;

    public Step4Service(IStep4ApiService step4ApiService)
    {
        _step4ApiService = step4ApiService;
    }

    // Method to validate Step 4
    public async Task ValidateStep4()
    {
        // Call the API service to validate Step 4's data
        Data.IsValid = await _step4ApiService.ValidateStep4Async(Data);

        // Notify subscribers that the validation state has changed
        OnValidationStateChanged?.Invoke();
    }

    // Method to update Step 4 data
    public void UpdateData(string comments)
    {
        Data.Comments = comments;

        // Optionally trigger revalidation here if needed
        // await ValidateStep4();
    }
}
