using System;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace KeyzAllowUtilities;

public static class WorkTypeDefUtils
{
    public static Lazy<FieldInfo> Visible = new(()=>AccessTools.Field(typeof(WorkTypeDef), "visible"));

    public static void Toggle(this WorkTypeDef def, bool state)
    {
        if(state) def.Show();
        else def.Hide();
    }
    public static void Hide(this WorkTypeDef def)
    {
        Visible.Value.SetValue(def, false);
    }

    public static void Show(this WorkTypeDef def)
    {
        Visible.Value.SetValue(def, true);
    }
}
