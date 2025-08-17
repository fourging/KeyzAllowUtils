using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace KeyzAllowUtilities;

[StaticConstructorOnStartup]
public class Designator_CutGrown : Designator_PlantsCut
{
    public override bool Disabled
    {
        get => disabled || KeyzAllowUtilitiesMod.settings.DisableCut;
        set => disabled = value;
    }

    public override bool Visible => !KeyzAllowUtilitiesMod.settings.DisableCut;
    protected override DesignationDef Designation => DesignationDefOf.CutPlant;

    public override DrawStyleCategoryDef DrawStyleCategory => DrawStyleCategoryDefOf.FilledRectangle;

    public Designator_CutGrown()
    {
        defaultLabel = "KUA_CutGrown".Translate();
        icon = ContentFinder<Texture2D>.Get("UI/KUA_CutGrown");
        defaultDesc = "KUA_CutGrownDesc".Translate();
        soundDragSustain = SoundDefOf.Designate_DragStandard;
        soundDragChanged = SoundDefOf.Designate_DragStandard_Changed;
        useMouseIcon = true;
        soundSucceeded = SoundDefOf.Designate_CutPlants;
        hotKey = KeyzAllowUtilitesDefOf.KAU_CutFullyGrown;
    }

    public override AcceptanceReport CanDesignateThing(Thing t)
    {
        return t is Plant plant  && base.CanDesignateThing(t) && Mathf.Approximately(plant.Growth, 1f);
    }

    public override void DesignateThing(Thing t)
    {
        Designator_PlantsHarvestWood.PossiblyWarnPlayerImportantPlantDesignateCut(t);
        if (ModsConfig.IdeologyActive && t.def.plant.IsTree && t.def.plant.treeLoversCareIfChopped)
            Designator_PlantsHarvestWood.PossiblyWarnPlayerOnDesignatingTreeCut();
        Map.designationManager.AddDesignation(new Designation((LocalTargetInfo) t, DesignationDefOf.CutPlant));
        t.SetForbidden(false, false);
    }
}
