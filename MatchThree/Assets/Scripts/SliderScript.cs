using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{

    private Slider slider;
    public int colorIndex = 0;
    private SceneManager sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.Find("ColorManager").GetComponent<SceneManager>();
        slider = gameObject.GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { ValueChangedCheck(); });
    }

   
    public void ValueChangedCheck()
    {
        Debug.Log("Value: " + slider.value);
        sceneManager.ChangePlayerColor(colorIndex, slider.value);

    }
}
