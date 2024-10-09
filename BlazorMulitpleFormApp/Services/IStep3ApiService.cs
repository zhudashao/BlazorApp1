using System.Net.Http.Json;

namespace BlazorMulitpleFormApp.Services;

public interface IStep3ApiService
{
    Task<bool> ValidateStep3Async(Step3Data data);
}
public class Step3ApiService : IStep3ApiService
{
    private readonly HttpClient _httpClient;

    public Step3ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> ValidateStep3Async(Step3Data data)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/validateStep3", data);
        return response.IsSuccessStatusCode;
    }
}

public class DammyStep3ApiService : IStep3ApiService
{
    public async Task<bool> ValidateStep3Async(Step3Data data)
    {
        return await Task.FromResult(true);
    }
}
public class Step3Service
{
    private readonly IStep3ApiService _step3ApiService;

    // The Step3 data model
    public Step3Data Data { get; private set; } = new Step3Data();

    // Event to notify when validation status changes
    public event Action OnValidationStateChanged;
    public event Action OnDataChanged; // Notify when Step 3 data changes
    // Property to check if Step 3 is valid
    public bool IsStepValid => Data.IsValid;

    public Step3Service(IStep3ApiService step3ApiService)
    {
        _step3ApiService = step3ApiService;
    }

    // Method to validate Step 3
    public async Task ValidateStep3()
    {
        // Call the API service to validate Step 3's data
        Data.IsValid = await _step3ApiService.ValidateStep3Async(Data);

        // Notify subscribers that the validation state has changed
        OnValidationStateChanged?.Invoke();
    }

    // Method to update Step 3 data (can trigger validation as needed)
    public void UpdateData(string company, string position)
    {
        Data.Company = company;
        Data.Position = position;
        OnDataChanged?.Invoke(); // Notify that data has changed
        // Optionally trigger revalidation here if needed
        // await ValidateStep3();
    }
    public void NotifyDataChanged()
    {
        OnDataChanged?.Invoke(); // Trigger event for data change
    }

   
}


