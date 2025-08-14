using Verse;

namespace KeyzAllowUtilities;

public class GameComp(Game game) : GameComponent
{
    public Game Game = game;

    public override void FinalizeInit()
    {
        KeyzAllowUtilitiesMod.settings.ValidateDesignators();
    }

    public override void StartedNewGame()
    {
        KeyzAllowUtilitiesMod.settings.ValidateDesignators();
    }

    public override void LoadedGame()
    {
        KeyzAllowUtilitiesMod.settings.ValidateDesignators();
    }
}
