
using UnityEngine;
using UnityEngine.UI;
using FleetLords;

public class StarMap : MonoBehaviour 
{
    public Texture[] StarColours;
    public GameObject StarPrefab;
    public LayerMask StarsLayer;
    
    public Orchestrator orchestrator;

    Galaxy galaxy;
    bool canClick = true;

    public void Init(Orchestrator orchestrator, Galaxy galaxy)
    {
        this.orchestrator = orchestrator;
        this.galaxy = galaxy;

        var rangeX = 8.0F/Config.GalaxyWidth;
        var rangeY = 4.0F/Config.GalaxyWidth;
        var scale = new Vector3(0.4F, 0.4F, 0.4F);

        for(var i = 0; i < galaxy.starSystems.Length; i++)
        {
            var star = galaxy.starSystems[i];
            var pos = new Vector2(star.Position.x * rangeX, star.Position.y * rangeY);
            var go = Instantiate(StarPrefab, pos, Quaternion.identity, transform);
            go.transform.localScale = scale;
            go.GetComponent<StarInfo>().StarIndex = i;
            go.GetComponentInChildren<MeshRenderer>().material.mainTexture = StarColours[(int)star.Type];
            go.GetComponentInChildren<Text>().text = star.Name;
        }
    }

    private void Update() 
    {
        if(!canClick || !Input.GetMouseButtonUp(0))
            return;

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, StarsLayer))
        {
            var index = hitInfo.collider.GetComponentInParent<StarInfo>().StarIndex;
            var star = galaxy.starSystems[index];
            orchestrator.OpenStarSystem(star);
        }
    }

    public void EnableClick(bool enable) => canClick = enable;
}