﻿/* Copyright (c) 2013 ETH Zurich
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using FIcontent.Gaming.Enabler.GameSynchronization;

/// <summary>
/// GUI Component to manage the server creation / connection
/// </summary>
public class ManageServerPanelGUI : HideableCanvas
{

    public RectTransform serverListPanel;
    public GameObject serverButtonPrefab;
    public InputField serverNameInputField;

    public string serverName
    {
        get
        {
            string serverName = Network.player.ipAddress;

            if (serverNameInputField && !string.IsNullOrEmpty(serverNameInputField.text))
                serverName = serverNameInputField.text;

            return serverName;
        }
    }

    public void ClearServerList()
    {
        foreach (RectTransform t in serverListPanel)
        {
            Destroy(t.gameObject);
        }
    }

    public void AddServerToList(HostData hostData)
    {
        var newButton = Instantiate(serverButtonPrefab) as GameObject;
        newButton.GetComponentInChildren<Text>().text = hostData.gameName;
        newButton.GetComponent<RectTransform>().SetParent(serverListPanel);
        newButton.transform.localScale = Vector3.one;
        newButton.GetComponent<ServerButton>().hostData = hostData;
    }
}
