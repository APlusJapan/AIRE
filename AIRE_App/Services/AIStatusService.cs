using System.Collections.ObjectModel;

namespace AIRE_App.Services;

public static class AIStatusService
{
    public static bool MessageReceived = true;

    public static String Message = String.Empty;

    public static bool MessageIsExpanded = false;

    public static ObservableCollection<String> MessageHistory = [];
}