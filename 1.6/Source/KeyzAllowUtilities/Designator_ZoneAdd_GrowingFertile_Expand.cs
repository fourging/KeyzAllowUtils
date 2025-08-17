using RimWorld;
using Verse;

namespace KeyzAllowUtilities;

public class Designator_ZoneAdd_GrowingFertile_Expand : Designator_ZoneAdd_GrowingFertile
{
    public override bool Disabled
    {
        get => disabled || KeyzAllowUtilitiesMod.settings.DisableFertileZone;
        set => disabled = value;
    }

    public override bool Visible => !KeyzAllowUtilitiesMod.settings.DisableFertileZone;
    protected override bool ShowRightClickHideOptions => false;

    public Designator_ZoneAdd_GrowingFertile_Expand()
    {
        defaultLabel = "KAU_DesignatorZoneExpand".Translate();
        hotKey = KeyzAllowUtilitesDefOf.KAU_FertileGrowAreaExpand;
    }
}
