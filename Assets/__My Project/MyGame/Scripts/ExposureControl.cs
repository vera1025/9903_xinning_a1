using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class ExposureControl : MonoBehaviour
{


    public Volume targetVolume;


    private ColorAdjustments colorAdjustments;

    public float exposureIncrement = 1.5f; 
    public float maxExposure = 13.0f;       

    void Start()
    {

        if (targetVolume != null && targetVolume.profile != null)
        {

            if (targetVolume.profile.TryGet(out colorAdjustments))
            {

                colorAdjustments.postExposure.overrideState = true;
            }
            else
            {
            }
        }
        else
        {
        }
    }

    void Update()
    {

        if (colorAdjustments != null)
        {

            float targetValue = colorAdjustments.postExposure.value + exposureIncrement * Time.deltaTime;


            colorAdjustments.postExposure.value = Mathf.Clamp(targetValue, -10f, maxExposure);

            if (targetValue >= maxExposure - 0.3)
            {
                colorAdjustments = null;
                SceneManager.LoadScene("2A");
            }
                
        }
    }

    public void SetExposure(float value)
    {
        if (colorAdjustments != null)
        {
            colorAdjustments.postExposure.value = value;
        }
    }
}