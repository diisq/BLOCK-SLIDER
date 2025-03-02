using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    [SerializeField, Range(0, 24)] private float timeOfDay;

    private void Update()
    {
        if(Preset==null){
            return;
        }
        if(Application.isPlaying){
            timeOfDay += Time.deltaTime;
            timeOfDay %= 24;
            UpdateLighting(timeOfDay / 24);

        }
        else
        {
            UpdateLighting(timeOfDay / 24);
        }
    }
    private void OnValidate()
    {
        if(DirectionalLight != null){
            return;
        }
        if(RenderSettings.sun != null){
            DirectionalLight = RenderSettings.sun;
        }
        else{
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights){
                if(light.type == LightType.Directional){
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
    private void UpdateLighting(float TimePercent){
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(TimePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(TimePercent);

        if(DirectionalLight != null){
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(TimePercent);
             DirectionalLight.transform.localRotation = UnityEngine.Quaternion.Euler(new UnityEngine.Vector3((TimePercent * 360f)-90f, -170, 0));
        }
    }

}
