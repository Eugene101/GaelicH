using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShelvesInstall : MonoBehaviour
{
    public GameObject basicShelve;
    public GameObject basicSeat;
    public Transform basicShelvedot;
    public Transform photoPos;
    public Canvas mainCanvas;
    Sprite rivalImage;
    public GameObject rivalsControllerObject;
    RivalsController rivalsController;
    public int maxShelves;
    public Quaternion imageRot;
    public Quaternion textRot;
    int randRiv;
    //int FindNumber;
    void Start()
    {
        rivalsController = rivalsControllerObject.GetComponent<RivalsController>();
        setShelves();
    }

    void setShelves()
    {
        List<int> rivalnum = new List<int>();
        for (int i = 0; i < rivalsController.rivalAvatars.Length; i++)
        {
            rivalnum.Add(i);
        }
        Vector3 pos = basicShelvedot.position;
        Vector3 imagePos = photoPos.position;
        for (int i = 0; i < maxShelves; i++)
        {
            Vector3 shift = new Vector3((float)1.6 * i - 0.05f, -0.6f, 0f);
            Vector3 shiftCube = new Vector3((float)1.6 * i - 0.05f, 0.75f, 0f);
            GameObject shelve = Instantiate(basicShelve, pos - shift, transform.rotation);
            GameObject cubeSeat = Instantiate(basicSeat, pos - shiftCube, transform.rotation);
            Transform spriteObj = shelve.transform.Find("ForSprite");
            Transform textPoint = shelve.transform.Find("ForText");
            Transform textSeat = cubeSeat.transform.Find("ForNumber");
            TextMeshProUGUI shelveText = textPoint.gameObject.AddComponent<TextMeshProUGUI>();
            TextMeshProUGUI seatText = textSeat.gameObject.AddComponent<TextMeshProUGUI>();
            spriteObj.transform.SetParent(mainCanvas.transform);
            shelveText.transform.SetParent(mainCanvas.transform);
            seatText.transform.SetParent(mainCanvas.transform);
            //spriteObj.transform.position = imagePos - shift;
            Image image = spriteObj.gameObject.AddComponent<Image>();
            rndNumber();
            image.sprite = rivalsController.rivalAvatars[randRiv];
            image.transform.rotation = imageRot;
            image.transform.localScale *= 2;
            shelveText.transform.rotation = textRot;
            shelveText.transform.localScale = new Vector3(0.0025f, 0.0025f, 0.0025f);
            image.transform.localScale = new Vector3(0.04f, 0.025f, 0.04f);
            shelveText.text = "" + rivalsController.names[randRiv];
            seatText.transform.rotation = textRot;
            seatText.alignment = TextAlignmentOptions.Midline;
            seatText.transform.localScale = new Vector3(0.006f, 0.006f, 0.006f);
            seatText.text = "" + randRiv;

        }
        void rndNumber()
        {
            int rand = Random.Range(0, rivalnum.Count);

            if (rivalnum.Contains(rand))
            {
               randRiv = rand;
                rivalnum.Remove(rand);
            }
            else
            {
                rndNumber();
            }
        }




    }
}
