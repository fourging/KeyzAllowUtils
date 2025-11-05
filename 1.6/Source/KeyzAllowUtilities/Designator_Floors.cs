using RimWorld;
using UnityEngine;
using Verse;

namespace KeyzAllowUtilities;

[StaticConstructorOnStartup]
public class Designator_Floors: Designator
{
	public static readonly Texture2D EyeDropperTex = ContentFinder<Texture2D>.Get("UI/Icons/Eyedropper");

	public Designator_Floors()
	{
		defaultLabel = "KAU_DesignatorFloors".Translate();
        defaultDesc = "KAU_DesignatorFloorsDesc".Translate();
		icon = EyeDropperTex;
		useMouseIcon = true;
        hotKey = KeyzAllowUtilitesDefOf.KAU_SelectFloor;
    }

	public override AcceptanceReport CanDesignateCell(IntVec3 c)
    {
        return TerrainDefAt(c, out AcceptanceReport report) != null ? AcceptanceReport.WasAccepted : report;
    }

	public override void DesignateSingleCell(IntVec3 cell)
	{
		TerrainDef terrainDef = TerrainDefAt(cell, out AcceptanceReport report);
		if (terrainDef != null)
        {
            Designator_Build des = BuildCopyCommandUtility.FindAllowedDesignator(terrainDef, true);

            Find.DesignatorManager.Select(des);
			Messages.Message("KAU_GrabbedTerrain".Translate() + ": " + terrainDef.LabelCap, null, MessageTypeDefOf.NeutralEvent, historical: false);
		}
		else
		{
			Messages.Message(report.Reason, null, MessageTypeDefOf.RejectInput, historical: false);
		}
	}

    public virtual TerrainDef TerrainDefAt(IntVec3 cell, out AcceptanceReport report)
    {
        report = null;

        if (!cell.InBounds(Map) || cell.Fogged(Map))
        {
            report = "KAU_OOB".Translate();
            return null;
        }

        TerrainDef def = Map.terrainGrid.TerrainAt(cell);

        if (!def.BuildableByPlayer)
        {
            report = "KAU_NotBuildable".Translate();
            return null;
        }

        if(!def.IsResearchFinished)
        {
            report = "KAU_ResearchNotFinished".Translate();
            return null;
        }

        return def;
    }

	public override void DrawMouseAttachments()
	{
		if (useMouseIcon)
		{
			string text;
			TerrainDef terrainDef = TerrainDefAt(UI.MouseCell(), out AcceptanceReport report);
			if (terrainDef != null)
			{
				text = "KAU_GrabTerrain".Translate() + ": " + terrainDef.LabelCap;
			}
			else
			{
				text = report.Reason;
			}
			GenUI.DrawMouseAttachment(icon, text, iconAngle, iconOffset);
		}
	}
}
