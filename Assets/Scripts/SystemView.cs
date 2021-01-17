using FleetLords;
using UnityEngine;
using UnityEngine.UI;

public class SystemView : MonoBehaviour 
{
    public Orchestrator orchestrator;
    public GameObject Title;
    public Camera Camera;

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
    }

    public void OnClose()
    {
        this.gameObject.SetActive(false);
        orchestrator.CloseStarSystem();
    }
}