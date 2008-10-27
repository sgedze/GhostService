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

    /// <summary>
    /// These are the check types of checks for the GC plugins. 
    /// </summary>
    public enum CheckType : short
    {     
        Less = 2,
        Equal = 1,
        Larger = 0
    }
}
