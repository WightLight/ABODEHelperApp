using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopupText : MonoBehaviour
{
    public Animator dieLabelAnimator;
    public Animator rollResultAnimator;
    private Text dieLabelText;
    private Text rollResultText;
    public float waitTime;

	// Use this for initialization
	void Start ()
	{
        // Get the popup's animation length and destroy it after that long
        // AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        // Destroy(gameObject, clipInfo[0].clip.length);

        // Destroy the popup after the set amount of time
        Destroy(gameObject, waitTime);

        // Get the actual texts to rewrite later
        dieLabelText = dieLabelAnimator.GetComponent<Text>();
        rollResultText = rollResultAnimator.GetComponent<Text>();
	}
	
    public void SetText(string labelText, int rollNumber)
    {
        // Rewrite the popup's texts
        dieLabelText.text = labelText;
        rollResultText.text = rollNumber.ToString();
    }
}
