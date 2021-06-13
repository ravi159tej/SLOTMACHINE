using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class gamemanager : MonoBehaviour
{
    public List<float> yvalue = new List<float>();
    RaycastHit hit;
    Ray ray;
    public bool buttonclick = false;
    public GameObject s1, s2, s3,button,pe1,pe2,cam;
    public Vector3 camstartpos, zoompos,startrot;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("MATCH"))
        {
            PlayerPrefs.SetInt("MATCH", 1);
        }
        if (!PlayerPrefs.HasKey("click"))
        {
            PlayerPrefs.SetInt("click", 0);
        }
    }
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        s1.transform.localPosition =  new Vector3(s1.transform.position.x, yvalue[Random.Range(0,yvalue.Count)], -1.47f);
        s2.transform.localPosition =  new Vector3(6, yvalue[Random.Range(0,yvalue.Count)], -1.47f);
        s3.transform.localPosition =  new Vector3(-4.75f, yvalue[Random.Range(0,yvalue.Count)], -1.47f);
        camstartpos = cam.transform.position;
        startrot = cam.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (!buttonclick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "BUTTON")
                    {
                        buttonclick = true;
                        hit.collider.transform.DOMove(hit.transform.position + new Vector3(0, -1f, 0), 0.1f);
                        hit.collider.transform.GetComponent<Renderer>().material.color = Color.red;
                        runslotmachine();
                    }
                }
            }
        }
    }

    void runslotmachine()
    {
        PlayerPrefs.SetInt("click", PlayerPrefs.GetInt("click")+1);
        print(PlayerPrefs.GetInt("click") + "  CLICK" + "         " + PlayerPrefs.GetInt("MATCH") + "  MATCH");
        int match = Random.Range(3, yvalue.Count);
        cam.transform.DOMove(zoompos, 0.5f);
        cam.transform.DORotate(new Vector3(15,0,0), 0.5f);
        if (PlayerPrefs.GetInt("MATCH") == PlayerPrefs.GetInt("click"))///MATCH 
        {
            s1.transform.DOLocalMoveY(s1.transform.localPosition.y + 50, 1).SetEase(Ease.InSine).OnComplete(() =>
            {


                s1.transform.DOLocalMoveY(yvalue[0], 0f).OnComplete(() =>
                {
                    s1.transform.DOLocalMoveY(yvalue[yvalue.Count - 1], 1f).SetEase(Ease.Linear).SetLoops(2, LoopType.Restart).OnComplete(() =>
                    {
                        s1.transform.DOLocalMoveY(yvalue[match-3], 0f).OnComplete(() => {

                            s1.transform.DOLocalMoveY(yvalue[match], 0.5f).SetEase(Ease.OutSine).OnComplete(() => {
                                Reset();
                            PlayerPrefs.SetInt("MATCH", PlayerPrefs.GetInt("MATCH") + 1);
                            PlayerPrefs.SetInt("click", 0);
                            pe1.SetActive(true);
                            pe2.SetActive(true);
                            cam.transform.DOMove(camstartpos, 0.5f);
                            cam.transform.DORotate(startrot, 0.5f);
                            pe1.GetComponent<ParticleSystem>().Play();
                            pe2.GetComponent<ParticleSystem>().Play();
                            });
                        });

                    });
                });


            });
            s2.transform.DOLocalMoveY(s2.transform.localPosition.y + 50, 1).SetEase(Ease.InSine).OnComplete(() =>
            {


                s2.transform.DOLocalMoveY(yvalue[3], 0f).OnComplete(() =>
                {
                    s2.transform.DOLocalMoveY(yvalue[yvalue.Count - 1], 1f).SetEase(Ease.Linear).SetLoops(2, LoopType.Restart).OnComplete(() =>
                    {
                        s2.transform.DOLocalMoveY(yvalue[match-3], 0f).OnComplete(() => {

                            s2.transform.DOLocalMoveY(yvalue[match], 0.5f).SetEase(Ease.OutSine);
                        });

                    });

                });


            });
            s3.transform.DOLocalMoveY(s2.transform.localPosition.y + 50, 1).SetEase(Ease.InSine).OnComplete(() =>
            {


                s3.transform.DOLocalMoveY(yvalue[2], 0f).OnComplete(() =>
                {
                    s3.transform.DOLocalMoveY(yvalue[yvalue.Count - 1], 1f).SetEase(Ease.Linear).SetLoops(2, LoopType.Restart).OnComplete(() =>
                    {
                        s3.transform.DOLocalMoveY(yvalue[match - 3], 0f).OnComplete(() => {

                            s3.transform.DOLocalMoveY(yvalue[match], 0.5f).SetEase(Ease.OutSine);
                        });

                    });

                });


            });
        }
        else
        {
            s1.transform.DOLocalMoveY(s1.transform.localPosition.y + 50, 1).SetEase(Ease.InSine).OnComplete(() =>
            {


                s1.transform.DOLocalMoveY(yvalue[0], 0f).OnComplete(() =>
                {
                    s1.transform.DOLocalMoveY(yvalue[yvalue.Count - 1], 1f).SetEase(Ease.Linear).SetLoops(2, LoopType.Restart).OnComplete(() => 
                    {
                        int i = Random.Range(3, yvalue.Count);
                        s1.transform.DOLocalMoveY(yvalue[i-3], 0f).OnComplete(()=>{

                            s1.transform.DOLocalMoveY(yvalue[i], 0.5f).SetEase(Ease.OutSine).OnComplete(() => {
                                Reset();
                                cam.transform.DOMove(camstartpos, 0.5f);
                                cam.transform.DORotate(startrot, 0.5f);
                            });
                        });
                    
                    });

                });


            });
            s2.transform.DOLocalMoveY(s2.transform.localPosition.y + 50, 1).SetEase(Ease.InSine).OnComplete(() =>
            {


                s2.transform.DOLocalMoveY(yvalue[3], 0f).OnComplete(() =>
                {
                    s2.transform.DOLocalMoveY(yvalue[yvalue.Count - 1], 1f).SetEase(Ease.Linear).SetLoops(2, LoopType.Restart).OnComplete(() =>
                    {
                        int i = Random.Range(3, yvalue.Count);
                        s2.transform.DOLocalMoveY(yvalue[i - 3], 0f).OnComplete(() => {

                            s2.transform.DOLocalMoveY(yvalue[i], 0.5f).SetEase(Ease.OutSine);
                        });

                    });

                });


            });
            s3.transform.DOLocalMoveY(s3.transform.localPosition.y + 50, 1).SetEase(Ease.InSine).OnComplete(() =>
            {


                s3.transform.DOLocalMoveY(yvalue[2], 0f).OnComplete(() =>
                {
                    s3.transform.DOLocalMoveY(yvalue[yvalue.Count - 1], 1f).SetEase(Ease.Linear).SetLoops(2, LoopType.Restart).OnComplete(() =>
                    {
                        int i = Random.Range(3, yvalue.Count);
                        s3.transform.DOLocalMoveY(yvalue[i - 3], 0f).OnComplete(() => {

                            s3.transform.DOLocalMoveY(yvalue[i], 0.5f).SetEase(Ease.OutSine);
                        });

                    });

                });


            });
        }
    }
    private void Reset()
    {
        buttonclick = false;
       button.transform.DOMove(hit.transform.position + new Vector3(0, 1f, 0), 0.1f);
        button.transform.GetComponent<Renderer>().material.color = Color.green;

    }
}
