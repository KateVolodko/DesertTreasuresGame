using UnityEngine;
using UnityEngine.UI;

public class HidePanel : MonoBehaviour
{
    public float delay = 5f; 
    public GameObject panel;
    public GameObject figure;

    private float timeElapsed = 0f;

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= delay) 
        {
            panel.SetActive(false);
            figure.SetActive(true);
            enabled = false;
        }
    }
}
