﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalController : MonoBehaviour
{
    [SerializeField] private Button button;

    private Player player;
    private Portal[] portal;
    private GameObject panel;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        panel = transform.Find("Panel_Portal").gameObject;
    }

    public void ActivatePortal(Portal[] portals)
    {
        panel.SetActive(true);
        for (int i = 0; i < portals.Length; i++)
        {
            Button portalButton = Instantiate(button, panel.transform);
            portalButton.GetComponentInChildren<Text>().text = portals[i].name;
            int x = i;
            portalButton.onClick.AddListener(delegate { OnPortalButtonClick(portals[x]); });
        }
    }

    void OnPortalButtonClick(Portal portal)
    {
        player.gameObject.transform.position = portal.TeleportLocation;
        foreach (Button button in GetComponentsInChildren<Button>())
        {
            Destroy(button.gameObject);
        }
        panel.SetActive(false);
    }
}




