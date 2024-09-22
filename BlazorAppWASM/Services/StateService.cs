namespace BlazorAppStandardWASM.Services;

public class StateService
{
    // Objet contenant les états globaux
    public AppState State { get; private set; } = new AppState();

    // Événement pour notifier les composants lorsque l'état change
    public event Action OnStateChange;

    // Méthode pour changer l'authentification de l'utilisateur
    public void SetUserAuthenticated(bool isAuthenticated)
    {
        if (State.IsUserAuthenticated != isAuthenticated)
        {
            State.IsUserAuthenticated = isAuthenticated;
            NotifyStateChanged();
        }
    }

    // Méthode pour changer le thème
    public void SetTheme(string theme)
    {
        if (State.Theme != theme)
        {
            State.Theme = theme;
            NotifyStateChanged();
        }
    }

    public void Reset()
    {
        State.Reset();
        NotifyStateChanged();
    }

    // Notifier les composants que l'état a changé
    private void NotifyStateChanged() => OnStateChange?.Invoke();
}
