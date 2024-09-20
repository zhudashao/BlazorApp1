namespace BlazorAppPlusWASM;
public class AppState
{
    // État de l'utilisateur authentifié
    public bool IsUserAuthenticated { get; set; }

    // État du thème
    public string Theme { get; set; } = "light";

    public void Reset()
    {
        IsUserAuthenticated = false;
        Theme = "light";
        NotificationMessage = string.Empty;
    }


    // Nouvelle propriété pour gérer les notifications
    public string NotificationMessage { get; set; } = "Init message";
}