using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleClip : PlayableBehaviour
{
    public string subtitleText;

    private TextMeshProUGUI tmp;
    private CanvasGroup canvasGroup;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        tmp = playerData as TextMeshProUGUI;
        if (tmp == null) return;

        if (canvasGroup == null)
            canvasGroup = tmp.GetComponent<CanvasGroup>();

        if (canvasGroup == null) return;

        tmp.text = subtitleText;

        double time = playable.GetTime();
        double duration = playable.GetDuration();
        float normalized = (float)(time / duration);

        // Fade in/out
        if (normalized < 0.2f)
            canvasGroup.alpha = Mathf.Lerp(0, 1, normalized / 0.2f);
        else if (normalized > 0.8f)
            canvasGroup.alpha = Mathf.Lerp(1, 0, (normalized - 0.8f) / 0.2f);
        else
            canvasGroup.alpha = 1;
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        if (canvasGroup != null)
            canvasGroup.alpha = 0;
    }
}