using FleetLords;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SystemView : MonoBehaviour 
{
    public Orchestrator orchestrator;
    public GameObject Title;
    public Camera Camera;

    public Texture[] RockTextures;
    public Texture[] TerrestrialTextures;
    public Texture[] GasTextures;

    public GameObject Star;
    public GameObject PlanetPrefab;
    public GameObject TextPrefab;

    StarSystem starSystem;
    RenderTexture renderTexture;

    List<GameObject> whileOpen = new List<GameObject>();

    private void Start() 
    {
        var image = GetComponentInChildren<RawImage>();
        var rect = image.GetComponent<RectTransform>().rect;
        renderTexture = new RenderTexture((int)rect.width, (int)rect.height, 24);
        Camera.targetTexture = renderTexture;
        image.texture = renderTexture;
    }

    public void Show(StarSystem starSystem)
    {
        this.starSystem = starSystem;
        Title.GetComponent<Text>().text = starSystem.Name;
        Star.GetComponentInChildren<MeshRenderer>().material.mainTexture = StarMap.Textures[(int)starSystem.Type];
        
        var canvas = GetComponentInChildren<Canvas>();

        for (var i = 0; i < starSystem.Planets.Length; i++)
        {
            var planet = starSystem.Planets[i];
            if (planet == null) continue;

            var planetPosition = Star.transform.position + new Vector3(0.9f+i*1f,0,0);
            var go = Instantiate(PlanetPrefab, planetPosition, Quaternion.identity, Star.transform.parent);

            var textures = RockTextures;
            if (planet.Type == PlanetType.Continental)
                textures = TerrestrialTextures;
            else if (planet.Type == PlanetType.GasGiant)
                textures = GasTextures;
            go.GetComponentInChildren<MeshRenderer>().material.mainTexture = textures[planet.Variant % textures.Length];

            var sphere = go.GetComponentInChildren<Rotate>().transform;
            if (planet.Type == PlanetType.GasGiant)
                sphere.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            else
            {
                var scale = 0.1f + (int)planet.Size * 0.1f;
                sphere.localScale = new Vector3(scale, scale, scale);
            }

            var textPos = canvas.transform.position+new Vector3(-219f+i*104f, -70f, 0f);
            var text = Instantiate(TextPrefab, textPos, Quaternion.identity, canvas.transform);
            text.GetComponent<TMPro.TMP_Text>().text = planet.Name;

            whileOpen.Add(go);
            whileOpen.Add(text);
        }
        
        this.gameObject.SetActive(true);
    }

    public void OnClose()
    {
        this.gameObject.SetActive(false);
        foreach(var go in whileOpen)
            Destroy(go);
        whileOpen.Clear();
        orchestrator.CloseStarSystem();
    }
}