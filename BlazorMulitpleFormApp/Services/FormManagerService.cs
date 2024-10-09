namespace BlazorMulitpleFormApp.Services;

public class FormManagerService
{
    public Step1Service Step1Service { get; }
    public Step2Service Step2Service { get; }
    public Step3Service Step3Service { get; }
    public Step4Service Step4Service { get; }

    public event Action OnFormStateUpdated;

    public FormManagerService(Step1Service step1Service, Step2Service step2Service, Step3Service step3Service, Step4Service step4Service)
    {
        Step1Service = step1Service;
        Step2Service = step2Service;
        Step3Service = step3Service;
        Step4Service = step4Service;

        // Revalidate Step 1 when Step 3 data changes
        Step3Service.OnDataChanged += RevalidateStep1;

        // Subscribe to validation state changes
        Step1Service.OnValidationStateChanged += NotifyFormStateUpdated;
        Step2Service.OnValidationStateChanged += NotifyFormStateUpdated;
        Step3Service.OnValidationStateChanged += NotifyFormStateUpdated;
        Step4Service.OnValidationStateChanged += NotifyFormStateUpdated;
    }

    private void RevalidateStep1()
    {
        Step1Service.ValidateStep1();
    }

    private void NotifyFormStateUpdated()
    {
        OnFormStateUpdated?.Invoke();
    }

    public bool CanProceedToNextStep(int currentStep)
    {
        return currentStep switch
        {
            1 => Step1Service.IsStepValid,
            2 => Step2Service.IsStepValid,
            3 => Step3Service.IsStepValid,
            4 => Step4Service.IsStepValid,
            _ => false
        };
    }
    public void Dispose()
    {
        Step3Service.OnDataChanged -= RevalidateStep1;
    }
}

