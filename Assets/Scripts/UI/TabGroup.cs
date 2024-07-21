using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<CustomTabButton> CustomTabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public CustomTabButton selectedTab;
    public List<GameObject> ObjectsToSwap;
    public void Subscribe(CustomTabButton button)
    {
        if (CustomTabButtons == null)
        {
            CustomTabButtons = new List<CustomTabButton>();
        }
        CustomTabButtons.Add(button);
    }


    public void OnTabEnter(CustomTabButton button)
    {
        if (selectedTab == null || button != selectedTab)
        {
            ResetTabs();
            button.background.sprite = tabHover;
        }
    }

    public void GotoInventory(){
        Debug.Log("BUTTON CLICKEDFvnjfdkvdmnbd");
        selectedTab = CustomTabButtons[3];
        ResetTabs();
        selectedTab.background.sprite = tabActive;
        int index = selectedTab.transform.GetSiblingIndex();
        for(int i = 0; i < ObjectsToSwap.Count; ++i){
            if(i == index){
                ObjectsToSwap[i].SetActive(true);
            }
            else{
                ObjectsToSwap[i].SetActive(false);
            }
        }
    }

    public void OnTabExit(CustomTabButton button)
    {
        ResetTabs();
    }


    public void OnTabSelected(CustomTabButton button)
    {
        selectedTab = button;
        ResetTabs();
        button.background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();
        for(int i = 0; i < ObjectsToSwap.Count; ++i){
            if(i == index){
                ObjectsToSwap[i].SetActive(true);
            }
            else{
                ObjectsToSwap[i].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach (CustomTabButton button in CustomTabButtons)
        {
            if (selectedTab != null && button == selectedTab) { continue; }
            button.background.sprite = tabIdle;
        }
    }
}
