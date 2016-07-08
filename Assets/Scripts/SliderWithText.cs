using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderWithText : MonoBehaviour {

/*  Unity API
 *  ==========================================================================*/
    void Start() {
        this.slider = GetComponent<Slider>();
    }

/*  Public Methods
 *  ==========================================================================*/
    public void UpdateText(Text text) {
        string sign = slider.value > 0 ? "+" : "";
        text.text = sign + slider.value.ToString();
    }

/*  Private Members
 *  ==========================================================================*/
    private Slider slider;
}
