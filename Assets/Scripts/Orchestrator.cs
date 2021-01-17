
using UnityEngine;
using FleetLords;

public class Orchestrator : MonoBehaviour 
{
    Galaxy galaxy;

    public StarMap starMap;
    public SystemView systemView;

    private void Start() 
    {
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
        starMap.EnableClick(true);
    }
}