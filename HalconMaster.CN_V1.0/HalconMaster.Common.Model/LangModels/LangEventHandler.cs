namespace HalconMaster.Common.Model.LangModels;

public delegate void LangEventHandler(object sender, LangEventArgs e);

public class LangEventArgs(string newLanguage,string oldLanguage) : EventArgs {
    public string NewLanguage { get; } = newLanguage;
    public string OldLanguage { get; } = oldLanguage;
}