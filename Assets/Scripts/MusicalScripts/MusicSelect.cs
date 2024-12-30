using UnityEngine;
public class MusicSelect : MonoBehaviour
{
    public GameObject musicSelect;
    public GameObject userPanel;
    public GameObject ostPanel;

    public void HideSelect()
    {
        musicSelect.SetActive(false);
    }
    public void DialogSelect()
    {
        musicSelect.SetActive(true);
    }

    public void HideUser()
    {
        userPanel.SetActive(false);
    }
    public void DialogUser()
    {
        userPanel.SetActive(true);
    }

    public void HideOST()
    {
        ostPanel.SetActive(false);
    }
    public void DialogOST()
    {
        ostPanel.SetActive(true);
    }
}