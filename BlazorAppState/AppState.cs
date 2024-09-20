namespace BlazorAppState;

public class AppState
{
    // État de l'utilisateur authentifié
    public bool IsUserAuthenticated { get; set; }

    // État du thème
    public string Theme { get; set; } = "light";
}
