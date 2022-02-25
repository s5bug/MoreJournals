namespace Celeste.Mod.MoreJournals

open Celeste.Mod

type MoreJournalsModule() =
    inherit EverestModule()
    
    override this.Load() =
        On.Celeste.OuiMainMenu.add_OnBegin this.MainMenuOnBeginHook
        On.Celeste.OuiMainMenu.add_Update this.MainMenuUpdateHook
    
    override this.Unload() =
        On.Celeste.OuiMainMenu.remove_OnBegin this.MainMenuOnBeginHook
        On.Celeste.OuiMainMenu.remove_Update this.MainMenuUpdateHook
    
    member this.MainMenuOnBegin (orig: On.Celeste.OuiMainMenu.orig_OnBegin) (self: Celeste.OuiMainMenu): unit =
        orig.Invoke self
    
    member this.MainMenuOnBeginHook =
        On.Celeste.OuiMainMenu.hook_OnBegin this.MainMenuOnBegin
    
    member this.MainMenuUpdate (orig: On.Celeste.OuiMainMenu.orig_Update) (self: Celeste.OuiMainMenu): unit =
        if self.Selected && self.Focused && Celeste.Input.MenuJournal.Pressed then
            self.Overworld.Goto<GlobalJournal>()
            |> ignore
        orig.Invoke self
    
    member this.MainMenuUpdateHook =
        On.Celeste.OuiMainMenu.hook_Update this.MainMenuUpdate
