using System.Text;
using System.Windows.Threading;

namespace HalconMaster.Common.Tools.DispatcherTools;

public static class DispatcherHelper {
    private static Dispatcher? UiDispatcher { get; set; }

    public static void CheckBeginInvokeOnUI(Action? action) {
        if (action == null) return;
        CheckDispatcher();
        if (UiDispatcher!.CheckAccess())
        {
            action();
        }
        else
        {
            UiDispatcher.BeginInvoke(action);
        }
    }

    private static void CheckDispatcher() {
        if (UiDispatcher != null) return;
        StringBuilder stringBuilder = new("The DispatcherHelper is not initialized.");
        stringBuilder.AppendLine();
        stringBuilder.Append("Call DispatcherHelper.Initialize() in the static App constructor.");
        throw new InvalidOperationException(stringBuilder.ToString());
    }

    public static DispatcherOperation RunAsync(Action action) {
        CheckDispatcher();
        return UiDispatcher!.BeginInvoke(action);
    }

    public static void Initialize() {
        if (UiDispatcher == null || !UiDispatcher.Thread.IsAlive)
        {
            UiDispatcher = Dispatcher.CurrentDispatcher;
        }
    }

    public static void Reset() {
        UiDispatcher = null;
    }
}