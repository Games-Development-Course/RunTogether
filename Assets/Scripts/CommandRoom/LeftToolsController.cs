using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LeftToolsController : MonoBehaviour
{
    [Header("Tool Buttons")]    
    public Transform toolButtonContainer;
    public ToolButton toolButtonPrefab;

    private List<ToolButton> buttons = new List<ToolButton>();
    private ToolSO selectedTool;

    public void Init(List<ToolSO> tools)
    {
        ClearButtons();

        foreach (var tool in tools)
        {
            var btn = Instantiate(toolButtonPrefab, toolButtonContainer);
            btn.Setup(tool, this);
            buttons.Add(btn);
        }
    }

    private void ClearButtons()
    {
        foreach (var b in buttons)
        {
            if (b != null)
                Destroy(b.gameObject);
        }
        buttons.Clear();
    }

    public void SelectTool(ToolSO tool)
    {
        selectedTool = tool;

        foreach (var btn in buttons)
        {
            btn.SetSelected(btn.Tool == tool);
        }

        CommandRoomManager.Instance.OnToolSelected(tool);
    }

    public ToolSO GetSelectedTool()
    {
        return selectedTool;
    }
}
