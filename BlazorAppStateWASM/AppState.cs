namespace BlazorAppStateWASM;

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
        NotifyStateChanged();
    }

    // Événement pour notifier les composants lorsque l'état change
    public event Action OnStateChange;

    // Méthode pour changer l'authentification de l'utilisateur
    public void SetUserAuthenticated(bool isAuthenticated)
    {
        if (IsUserAuthenticated != isAuthenticated)
        {
            IsUserAuthenticated = isAuthenticated;
            NotifyStateChanged();
        }
    }

    // Méthode pour changer le thème
    public void SetTheme(string theme)
    {
        if (Theme != theme)
        {
            Theme = theme;
            NotifyStateChanged();
        }
    }

    // Notifier les composants que l'état a changé
    private void NotifyStateChanged() => OnStateChange?.Invoke();
}
