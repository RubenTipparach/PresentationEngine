using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentationGenerator : MonoBehaviour {

  //  [SerializeField]
  //  int numberOfSlides = 20;

    [SerializeField]
    List<SlideTextures> slideTextures; // *WARNING* Must be equal to number of slides!

    float rotAmount = 90.0f;

    [SerializeField]
    Vector3 destEuler = Vector3.zero;

    [SerializeField]
    float speed = 5.0f;

    [SerializeField]
    float carrouselRadius;

    private Vector3 currEuler;

    [SerializeField]
    GameObject slideTemplate;

    [Serializable]
    public struct SlideTextures
    {
        // Overlay is optional.
        public Texture2D slideOverlay;

        public Texture2D slideMain;
    }

    void Start()
    {
        rotAmount = 360.0f / (float)slideTextures.Count;
        currEuler = destEuler;
        transform.eulerAngles = destEuler;

        for(int i = 0; i < slideTextures.Count; i++)
        {
            Quaternion rotation = Quaternion.Euler(0, rotAmount * (i), 0);
            Vector3 postion = rotation * (transform.position + Vector3.forward * carrouselRadius);

            //Quaternion rotation2 = Quaternion.Euler(0, -rotAmount * i, 0);

            GameObject gobj = Instantiate(slideTemplate, postion, rotation);
            gobj.transform.parent = transform;

            var slideAssign = gobj.GetComponent<SlideAssignment>();

            slideAssign.slideOverlay = slideTextures[i].slideOverlay;
            slideAssign.slideMain = slideTextures[i].slideMain;

            slideAssign.AssignChildrenMaterial();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            destEuler.y += -rotAmount;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            destEuler.y += rotAmount;
        }


        currEuler = Vector3.Lerp(currEuler, destEuler, Time.deltaTime * speed);
        transform.eulerAngles = currEuler;
    }
}
