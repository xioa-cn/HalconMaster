using XPrism.Core.BindableBase;
using XPrism.Core.Events;

namespace HalconMaster.Common.Model;

public abstract class BindableBase : ViewModelBase, IDisposable {
    protected BindableBase(IEventAggregator eventAggregator) : base(eventAggregator) {
    }

    protected BindableBase() {
    }

    protected virtual void Dispose(bool disposing) {
        if (disposing)
        {
        }
    }

    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}