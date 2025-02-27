using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpenableGroundButtonController : MonoBehaviour
{
    GameObject button,wall;
    Material buttonMaterial;
    MeshRenderer wallRender;
    Transform playerPos;
    bool isPress;

    // Start is called before the first frame update
    void Start()
    {
        button         = transform.GetChild(1).gameObject;
        buttonMaterial = button.GetComponent<MeshRenderer>().material;
        wall = transform.parent.gameObject.transform.GetChild(0).gameObject;
        wallRender = wall.GetComponent<MeshRenderer>();
        playerPos = GameObject.FindObjectOfType<MainBlockController>().transform;
    }


    void collisionFunc(){
        buttonMaterial.color = Color.green;
        isPress = true;
        wall.transform.parent = null;
        Vector3 wallPos = wall.transform.position;
        wallPos.y = 0;
        wallPos.z = playerPos.position.z - 0.55f;
        wall.transform.DOLocalMove(wallPos,0.3f);

        Color wallColor = wallRender.material.color;
        wallColor.a = 0.5f;
        wallRender.material.DOColor(wallColor,0.3f).SetDelay(0.33f);
    }

    private void OnTriggerEnter(Collider other) {
        string tag = other.tag;
        if(tag == "Collected" && !isPress){
            collisionFunc();
        }
    }
}
