
using UnityEngine;
using FleetLords;

public class Orchestrator : MonoBehaviour 
{
    Galaxy galaxy;

    public StarMap starMap;
    public SystemView systemView;

    public static Camera MainCamera;

    private void Start() 
    {
        MainCamera = Camera.main;

        galaxy = new Galaxy();
        galaxy.GenerateStarSystems();

        starMap.Init(this, galaxy);
        systemView.gameObject.SetActive(false);
    }

    public void OpenStarSystem(StarSystem starSystem)
    {
        starMap.EnableClick(false);
        systemView.Show(starSystem);
    }

    public void CloseStarSystem()
    {
        starMap.EnableClick(true); // note if this click hits an planet then the planet will immediately open...
    }
}