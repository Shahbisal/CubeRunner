using UnityEngine;
using System.Collections;

public class PunithaAnimationHandler : MonoBehaviour
{
    private SkinnedMeshRenderer punithaRenderer;
    private Animator punithaAnimator;

    void Start()
    {
        punithaRenderer = GetComponent<SkinnedMeshRenderer>();
        punithaAnimator = GetComponent<Animator>();

        // Initially hide the model and disable its animator
        punithaRenderer.enabled = false;
        if (punithaAnimator != null)
        {
            punithaAnimator.enabled = false;
        }
    }

    public void RunAnimationForSeconds(float duration)
    {
        StartCoroutine(ShowAndHide(duration));
    }

    IEnumerator ShowAndHide(float duration)
    {
        // Show the model and enable its animator
        punithaRenderer.enabled = true;
        if (punithaAnimator != null)
        {
            punithaAnimator.enabled = true;
        }

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Hide the model and disable its animator again
        punithaRenderer.enabled = false;
        if (punithaAnimator != null)
        {
            punithaAnimator.enabled = false;
        }
    }
}