using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public CameraFocus focus;

    public GameObject Player;

    public GameObject LeftWing;
    public GameObject RightWing;
    public GameObject TextThing;
    public GameObject TextHolder;

    public GameObject CrowdL;
    public GameObject CrowdR;

    public SlidingDoorController Left;
    public SlidingDoorController Right;

    

    public SlidingDoorController TextBox;
    public TMPro.TMP_Text Text;

    private Vector2 speed = Vector2.zero;

    private static CameraController reference;

    // Start is called before the first frame update
    void Start()
    {
        WorldManager.MainCamera = this;
        reference = this;
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
        Right = RightWing.GetComponent<SlidingDoorController>();
        Left = LeftWing.GetComponent<SlidingDoorController>();
        TextBox = TextThing.GetComponent<SlidingDoorController>();
        Text = TextHolder.GetComponent<TMPro.TMP_Text>();

        Left.Origin = new Vector2(-3.75f, 0);
        Right.Origin = new Vector2(3.75f, 0);

        StartCoroutine(StartGameIn(3f));
    }

    public IEnumerator StartGameIn(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(HideTextIn(1f));

        //Right.ReloadOrigin();
        Right.SendAway();
        Left.SendAway();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 goal = Player.transform.position;

        if (focus != null)
        {
            goal = focus.ApplyCameraFocus(goal);
        }
        Vector2 target = Vector2.SmoothDamp(transform.position, goal, ref speed, 0.1f);

        transform.position = new Vector3(target.x, target.y, transform.position.z);


    }

    public static void LockCameraTo(CameraFocus focus)
    {
        reference.focus = focus;
    }

    public static void ReleaseCameraLock(CameraFocus focus)
    {
        if (reference.focus == focus)
        {
            reference.focus = null;
        }
    }

    // TODO: Dont forget to add the despawn things to objects

    public void Open()
    {
        Right.SendAway();
        Left.SendAway();
    }

    public IEnumerator ShowTextIn(string content, float time)
    {
        yield return new WaitForSeconds(time);
        Text.text = content;
        TextBox.Return();
    }

    public IEnumerator HideTextIn(float time)
    {
        yield return new WaitForSeconds(time);
        TextBox.SendAway();
    }

    public IEnumerator OpenIn(float time)
    {
        yield return new WaitForSeconds(time);
        Open();
    }

    public IEnumerator CloseIn(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        Close();
    }
    public void Close()
    {
        Right.Return();
        Left.Return();
    }

    public void WinTheGame()
    {
        WorldManager.movement.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        WorldManager.movement.enabled = false;
       

        StartCoroutine(CloseIn(1f));
        StartCoroutine(ShowTextIn("... And they lived Happily ever After", 1.5f));

        StartCoroutine(HideTextIn(5f));
        StartCoroutine(ShowTextIn("Thank you for Playing 'Cheap Block Theatre'", 7f));
        StartCoroutine(PeopleLeaving(7f));

        StartCoroutine(HideTextIn(12f));
        StartCoroutine(ShowTextIn("I Hope you enjoyed it!", 14f));

        StartCoroutine(HideTextIn(20f));
        StartCoroutine(ShowTextIn("The Game will restart in a moment!", 22f));

        StartCoroutine(RestartGame(25f));

    }

    public IEnumerator RestartGame(float time)
    {
        yield return new WaitForSeconds(time);

        WorldManager.movement.enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator PeopleLeaving(float time)
    {
        yield return new WaitForSeconds(time);
        CrowdL.GetComponent<SlidingDoorController>().SendAway();
        CrowdR.GetComponent<SlidingDoorController>().SendAway();

    }

}
