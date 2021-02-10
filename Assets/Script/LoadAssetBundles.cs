using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class LoadAssetBundles : MonoBehaviour
{
    AssetBundle m_loadedAssetBundle;
    string url = "https://storage.googleapis.com/dviewer-59182.appspot.com/food"; 
    public string[] assetsName;
    int index = 0;
    GameObject instancedPrefab;
    

    void Start()
    {
        StartCoroutine(LoadAssetBundle());
       
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            DestroyObject();
            if (index == assetsName.Length - 1) index = 0;
            else index++;
            Debug.Log("index= " + index);
            instancedPrefab = InstantialteObjectFromBundle(assetsName[index]);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            DestroyObject();
            if (index == 0) index = assetsName.Length - 1;
            else index--;
            Debug.Log("index= " + index);
            instancedPrefab = InstantialteObjectFromBundle(assetsName[index]);
        }
       

    }

    GameObject InstantialteObjectFromBundle(string assetName)
    {
        var prefab = m_loadedAssetBundle.LoadAsset(assetName);
        GameObject instancedPrefab = (GameObject)Instantiate(prefab);
        return instancedPrefab;
    }
    void DestroyObject()
    {
        Destroy(instancedPrefab);
    }
    IEnumerator LoadAssetBundle()
    {
        UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(url);

        yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Get downloaded asset bundle
              
                m_loadedAssetBundle = DownloadHandlerAssetBundle.GetContent(uwr);

                assetsName = new string[m_loadedAssetBundle.GetAllAssetNames().Length];
                assetsName = m_loadedAssetBundle.GetAllAssetNames();

                instancedPrefab = InstantialteObjectFromBundle(assetsName[index]);
            }
        
    }
   
}


