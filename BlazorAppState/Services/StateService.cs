namespace BlazorAppState.Services;

public class StateService
{
    public StateService(AppState state)
    {
        this.State = state;
    }
    // Objet contenant les états globaux
    public AppState State { get; private set; }

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

    // Notifier les composants que l'état a changé
    private void NotifyStateChanged() => OnStateChange?.Invoke();
}
