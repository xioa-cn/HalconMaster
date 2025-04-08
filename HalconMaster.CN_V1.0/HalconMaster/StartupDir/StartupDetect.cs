using System.Text;
using System.Windows;
using HalconMaster.Common.Tools.DispatcherTools;
using XSharedMemoryPubSub.Models;
using XSharedMemoryPubSub.Services;

namespace HalconMaster.StartupDir;

public partial class Startup {
    private SharedMemoryPubSub? _sharedMemoryPubSub;
    private const string AppOpen = "OPEN";
    private string? _memoryName;

    private bool Detection {
        get
        {
            _sharedMemoryPubSub ??= new SharedMemoryPubSub(_memoryName);
            string? mName = System.Diagnostics.Process.GetCurrentProcess().MainModule?.ModuleName;
            string? pName = System.IO.Path.GetFileNameWithoutExtension(mName);
            if (System.Diagnostics.Process.GetProcessesByName(pName).Length > 1)
            {
                _sharedMemoryPubSub.Publish(MessageTopics.STATUS_UPDATE,
                    Encoding.UTF8.GetBytes(AppOpen)
                );
                return true;
            }
            else
            {
                _sharedMemoryPubSub.Subscribe(MessageTopics.STATUS_UPDATE, OnApplicationOpen);
                return false;
            }
        }
    }

    private void OnApplicationOpen((int MessageId, int TopicId, byte[] Data) obj) {
        if (obj.TopicId != MessageTopics.STATUS_UPDATE)
            return;

        var ms = Encoding.UTF8.GetString(obj.Data).TrimEnd('\0');

        if (ms == AppOpen)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() => { });
        }
    }

    public void Detect(string memoryName = "HalconMaster") {
        _memoryName = memoryName;
        if (!Detection) return;

        Application.Current.Shutdown();
        Environment.Exit(0);
        return;
    }
}