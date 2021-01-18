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

    StarSystem starSystem;
    RenderTexture renderTexture;

    List<GameObject> localPlanets = new List<GameObject>();

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

        for (var i = 0; i < starSystem.Planets.Length; i++)
        {
            var planet = starSystem.Planets[i];
            if (planet == null) continue;

            var position = Star.transform.position + new Vector3(0.9f+i*1f,0,0);
            var go = Instantiate(PlanetPrefab, position, Quaternion.identity, Star.transform.parent);
            var textures = RockTextures;
            if (planet.Type == PlanetType.Continental)
                textures = TerrestrialTextures;
            else if (planet.Type == PlanetType.GasGiant)
                textures = GasTextures;

            go.GetComponentInChildren<MeshRenderer>().material.mainTexture = textures[planet.Variant % textures.Length];

            if (planet.Type == PlanetType.GasGiant)
                go.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            else
            {
                var scale = 0.1f + (int)planet.Size * 0.1f;
                go.transform.localScale = new Vector3(scale, scale, scale);
            }

            localPlanets.Add(go);
        }
        
        this.gameObject.SetActive(true);
    }

    public void OnClose()
    {
        this.gameObject.SetActive(false);
        foreach(var go in localPlanets)
            Destroy(go);
        localPlanets.Clear();
        orchestrator.CloseStarSystem();
    }
}