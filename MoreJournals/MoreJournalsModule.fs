namespace Celeste.Mod.MoreJournals

open Celeste.Mod

type MoreJournalsModule() =
    inherit EverestModule()
    
    override this.Load() =
        On.Celeste.OuiMainMenu.add_OnBegin this.MainMenuOnBeginHook
    
    override this.Unload() =
        On.Celeste.OuiMainMenu.remove_OnBegin this.MainMenuOnBeginHook
    
    member this.MainMenuOnBegin (orig: On.Celeste.OuiMainMenu.orig_OnBegin) (self: Celeste.OuiMainMenu): unit =
        ()
    
    member this.MainMenuOnBeginHook =
        On.Celeste.OuiMainMenu.hook_OnBegin this.MainMenuOnBegin
