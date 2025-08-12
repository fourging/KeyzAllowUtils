using Verse;

namespace KeyzAllowUtilities;

public class ToggleableWorkTypeDef: WorkTypeDef
{
    public virtual void Toggle(bool state)
    {
        if(state) Show();
        else Hide();
    }
    public virtual void Hide()
    {
        visible = false;
    }

    public virtual void Show()
    {
        visible = true;
    }
}
