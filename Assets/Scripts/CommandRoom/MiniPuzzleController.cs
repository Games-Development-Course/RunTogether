
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MiniPuzzleController : MonoBehaviour
{
    public TextMeshProUGUI puzzleTitle;
    public TextMeshProUGUI puzzleDescription;
    public Button solveButton;
    public Button failButton;

    private DoorTypeSO currentDoor;

    void Start()
    {
        solveButton.onClick.AddListener(OnSolvePuzzle);
        failButton.onClick.AddListener(OnFailPuzzle);
    }

    public void InitPuzzle(DoorTypeSO door)
    {
        currentDoor = door;
        puzzleTitle.text = door.puzzle.puzzleTitle;
        puzzleDescription.text = door.puzzle.puzzleDescription;
    }

    private void OnSolvePuzzle()
    {
        CommandRoomManager.Instance.OnPuzzleSolved(currentDoor.id);
        gameObject.SetActive(false);
    }

    private void OnFailPuzzle()
    {
        CommandRoomManager.Instance.OnPuzzleFailed(currentDoor.id);
        gameObject.SetActive(false);
    }
}
