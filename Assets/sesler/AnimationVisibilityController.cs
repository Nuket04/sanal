using UnityEngine;

public class AnimationVisibilityController : MonoBehaviour
{
    public void ShowAnimation()
    {
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();

        foreach (MonoBehaviour s in scripts)
        {
            if (s != this)
                s.enabled = true;
        }
    }

    public void HideAnimation()
    {
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();

        foreach (MonoBehaviour s in scripts)
        {
            if (s != this)
                s.enabled = false;
        }
    }
}
