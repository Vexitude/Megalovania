using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject fight;
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject mercy;
    [SerializeField] private GameObject act;
    [SerializeField] private SpriteRenderer fightBox;
    [SerializeField] private SpriteRenderer itemBox;
    [SerializeField] private SpriteRenderer mercyBox;
    [SerializeField] private SpriteRenderer actBox;

    private void Fight()
    {
        EventSystem.current.SetSelectedGameObject(fight);
    }

    private void Item()
    {
        EventSystem.current.SetSelectedGameObject(item);
    }

    private void Mercy()
    {
        EventSystem.current.SetSelectedGameObject(mercy);
    }

    private void Act()
    {
        EventSystem.current.SetSelectedGameObject(act);
    }

    public void closeMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void onFightPress()
    {
        fightBox.enabled = true;
    }

    public void onItemPress()
    {
        itemBox.enabled = true;
    }

    public void onMercyPress()
    {
        mercyBox.enabled = true;
    }

    public void onActPress()
    {
        actBox.enabled = true;
    }
}
