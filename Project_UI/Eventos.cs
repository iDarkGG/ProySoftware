using System.Runtime.CompilerServices;

namespace Project_UI;

public static class Eventos
{
    public static event Action RefreshRequested;


    public static void Refresh()
    {
        RefreshRequested?.Invoke();
    }
}


