using FleetLords;
using UnityEngine;
using UnityEngine.UI;

public class SystemView : MonoBehaviour 
{
    public Orchestrator orchestrator;
    public GameObject Title;
    public Camera Camera;

    public Texture[] RockTextures;
    public Texture[] TerrestrialTextures;
    public Texture[] GasTextures;

    public GameObject Star;
    public GameObject[] Planets = new GameObject[Config.MaxPlanets];

    StarSystem starSystem;
    RenderTexture renderTexture;

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
        this.gameObject.SetActive(true);

        this.starSystem = starSystem;
        Title.GetComponent<Text>().text = starSystem.Name;
        Star.GetComponentInChildren<MeshRenderer>().material.mainTexture = StarMap.Textures[(int)starSystem.Type];

        for (var i = 0; i < starSystem.Planets.Length; i++)
        {
            var planet = starSystem.Planets[i];
            var go = Planets[i];
            go.SetActive(planet != null);
            if (planet == null) continue;

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
        }
    }

    public void OnClose()
    {
        this.gameObject.SetActive(false);
        orchestrator.CloseStarSystem();
    }
}