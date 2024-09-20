namespace BlazorAppPlusWASM.Services;
public interface IStateService
{
    AppState State { get; }

    event Action OnStateChange;

    Task SetUserAuthenticated(bool isAuthenticated);
    void SetTheme(string theme);
    void SetNotification(string message); // Nouvelle méthode pour gérer les notifications
    void Reset();
    Task LoadStateAsync();
}

public class StateService : IStateService
{
    // Objet contenant les états globaux
    public AppState State { get; private set; } = new AppState();

    // Événement pour notifier les composants lorsque l'état change
    public event Action OnStateChange;

    // Méthode pour changer l'authentification de l'utilisateur
    public async Task SetUserAuthenticated(bool isAuthenticated)
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

    // Nouvelle méthode pour changer la notification utilisateur
    public void SetNotification(string message)
    {
        if (State.NotificationMessage != message)
        {
            State.NotificationMessage = message;
            NotifyStateChanged();
        }
    }

    // Réinitialiser l'état
    public void Reset()
    {
        State.Reset();
        NotifyStateChanged();
    }

    // Notifier les composants que l'état a changé
    private void NotifyStateChanged() => OnStateChange?.Invoke();

    public Task LoadStateAsync()
    {
        throw new NotImplementedException();
    }
}

public class StateService2 : IStateService
{
    private readonly LocalStorageService _localStorage;
    public StateService2(LocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    // Objet contenant les états globaux
    public AppState State { get; private set; } = new AppState();

    // Événement pour notifier les composants lorsque l'état change
    public event Action OnStateChange;

    // Méthode pour changer l'authentification de l'utilisateur
    public async Task SetUserAuthenticated(bool isAuthenticated)
    {
        if (State.IsUserAuthenticated != isAuthenticated)
        {
            State.IsUserAuthenticated = isAuthenticated;
            await _localStorage.SetItemAsync("isUserAuthenticated", isAuthenticated.ToString());
            NotifyStateChanged();
        }
    }

    public async Task LoadStateAsync()
    {
        var isAuthenticated = await _localStorage.GetItemAsync("isUserAuthenticated");
        State.IsUserAuthenticated = bool.TryParse(isAuthenticated, out var result) && result;
        NotifyStateChanged();

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

    // Nouvelle méthode pour changer la notification utilisateur
    public void SetNotification(string message)
    {
        if (State.NotificationMessage != message)
        {
            State.NotificationMessage = message;
            NotifyStateChanged();
        }
    }

    // Réinitialiser l'état
    public void Reset()
    {
        State.Reset();
        NotifyStateChanged();
    }

    // Notifier les composants que l'état a changé
    private void NotifyStateChanged() => OnStateChange?.Invoke();
}

