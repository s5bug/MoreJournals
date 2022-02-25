namespace Celeste.Mod.MoreJournals

open System.Collections

type GlobalJournal() =
    inherit Celeste.Oui()

    override this.Enter(from: Celeste.Oui): IEnumerator =
        upcast (seq {
            Celeste.Audio.Play "event:/ui/world_map/journal/select" |> ignore
            
            yield null
        }).GetEnumerator()
    override this.Leave(next) =
        upcast (seq {
            Celeste.Audio.Play "event:/ui/world_map/journal/back" |> ignore
            
            yield null
        }).GetEnumerator()

    override this.Update() =
        base.Update()
        if this.Focused then
            if Celeste.Input.MenuCancel.Pressed then this.Close()
    
    member this.Close() =
        this.Overworld.Goto<Celeste.OuiMainMenu>()
        |> ignore
