namespace GhostService.GhostServicePlugin
{ 
    /// <summary>
    /// These are the current types of runs for the plugins. 
    /// </summary>
    public enum PluginRunType : short
    {
        PerInterval = 0,
        OnceOnly = 1,
        OnceAWeek = 2
    }    
}
