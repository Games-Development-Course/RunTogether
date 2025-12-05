using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RightPanelInfoController : MonoBehaviour
{
    [Header("UI References")]    
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI statusText;

    public Button openDoorButton;
    public Button startPuzzleButton;

    public GameObject puzzleContainer;
    public MiniPuzzleController puzzleController;

    private DoorTypeSO currentDoor;
    private ResourceTypeSO currentResource;

    private void Start()
    {
        ClearPanel();
        openDoorButton.onClick.AddListener(OnOpenDoorClicked);
        startPuzzleButton.onClick.AddListener(OnStartPuzzleClicked);
    }

    public void ClearPanel()
    {
        titleText.text = "Select an object";
        statusText.text = "";
        openDoorButton.gameObject.SetActive(false);
        startPuzzleButton.gameObject.SetActive(false);
        puzzleContainer.SetActive(false);

        currentDoor = null;
        currentResource = null;
    }

    public void DisplayDoor(DoorTypeSO door)
    {
        currentDoor = door;
        currentResource = null;

        titleText.text = door.doorName;
        statusText.text = $"Status: {door.initialState}";

        openDoorButton.gameObject.SetActive(true);
        startPuzzleButton.gameObject.SetActive(true);
        puzzleContainer.SetActive(false);
    }

    public void DisplayResource(ResourceTypeSO resource)
    {
        currentResource = resource;
        currentDoor = null;

        titleText.text = resource.resourceName;
        statusText.text = $"Category: {resource.resourceCategory}";

        openDoorButton.gameObject.SetActive(false);
        startPuzzleButton.gameObject.SetActive(false);
        puzzleContainer.SetActive(false);
    }

    private void OnOpenDoorClicked()
    {
        if (currentDoor == null) return;
        CommandRoomManager.Instance.OpenDoor(currentDoor.id);
    }

    private void OnStartPuzzleClicked()
    {
        if (currentDoor == null) return;

        CommandRoomManager.Instance.StartPuzzle(currentDoor.id);

        puzzleContainer.SetActive(true);
        puzzleController.InitPuzzle(currentDoor);
    }
}
