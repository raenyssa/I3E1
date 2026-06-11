using UnityEngine;
using System.Collections;

public class DoorMan3 : MonoBehaviour
{
	public GameObject Player;
	public bool IsActive,IsSelected,IsPlayerIn,IsLocked,IsTimed,UseMySkin,IsGuiOn;
	public GUISkin MySkin;
	public Texture2D MyCursor;
	public Vector2 MyhotSpot = Vector2.zero;
	public CursorMode MycursorMode = CursorMode.Auto;
	public string MyText,uPassCode,lPassCode;
	public float timer = 10.0f;
	public AudioClip open,close,locked,S_Button,Su_lock,S_Lock,Se_Lock,Alarm;

	private Color TColor;
	private Color MyColor;


	void Start()
	{
		MyColor = Color.red;
	}

	void  Update ()
	{
	if (IsPlayerIn && IsActive)
	{
	if (Input.GetMouseButtonDown (0))
	{
	IsSelected=true;
	}
	if (Input.GetMouseButtonDown (1))
	{
	IsSelected=false;
	}
	}

	if (IsGuiOn && IsTimed && IsActive)
	{
	timer -= Time.deltaTime;
	if (timer <= 0)
	{
	IsSelected = false;
	timer = 10;
	IsGuiOn = false;
	AudioSource.PlayClipAtPoint (Alarm, new Vector3 (0, 0, 0));
	}
	}
	}


	void OnGUI() 
	{
	if (IsActive && IsSelected)
	{
	if (IsPlayerIn)
	{
	if (UseMySkin) 
	{
	GUI.skin = MySkin;
	}

	IsGuiOn=true;
	GUILayout.BeginArea (new Rect (Screen.width / 2, Screen.height / 2, 250, 450));

				GUI.skin.label.normal.textColor = MyColor;

	GUILayout.BeginHorizontal ();
	GUILayout.Label (MyText, GUILayout.Width (140));
	GUILayout.EndHorizontal ();

	if(IsTimed)
	{
	GUILayout.BeginHorizontal ();
	GUILayout.Button("",GUILayout.Width (timer*21), GUILayout.Height (25));
	GUILayout.EndHorizontal ();		
	}

	GUILayout.BeginHorizontal ();
	if (GUILayout.Button ("1", GUILayout.Width (70), GUILayout.Height (25)))
	{
	StartCoroutine ("ButtonClick");
	MyText += "1";
	}
	if (GUILayout.Button ("2", GUILayout.Width (70), GUILayout.Height (25)))
	{
	StartCoroutine ("ButtonClick");
	MyText += "2";
	}
	if (GUILayout.Button ("3", GUILayout.Width (70), GUILayout.Height (25))) 
	{
	StartCoroutine ("ButtonClick");
	MyText += "3";
	}
	GUILayout.EndHorizontal ();

	GUILayout.BeginHorizontal ();
	if (GUILayout.Button ("4", GUILayout.Width (70), GUILayout.Height (25))) 
					{
	StartCoroutine ("ButtonClick");
	MyText += "4";
	}
	if (GUILayout.Button ("5", GUILayout.Width (70), GUILayout.Height (25)))
	{
	StartCoroutine ("ButtonClick");
	MyText += "5";
	}
	if (GUILayout.Button ("6", GUILayout.Width (70), GUILayout.Height (25))) 
	{
	StartCoroutine ("ButtonClick");
	MyText += "6";
	}
	GUILayout.EndHorizontal ();

	GUILayout.BeginHorizontal ();
	if (GUILayout.Button ("7", GUILayout.Width (70), GUILayout.Height (25))) 
	{
	StartCoroutine ("ButtonClick");
	MyText += "7";
	}
	if (GUILayout.Button ("8", GUILayout.Width (70), GUILayout.Height (25))) 
	{
	StartCoroutine ("ButtonClick");
	MyText += "8";
	}
	if (GUILayout.Button ("9", GUILayout.Width (70), GUILayout.Height (25)))
	{
	StartCoroutine ("ButtonClick");
	MyText += "9";
	}
	GUILayout.EndHorizontal ();

	GUILayout.BeginHorizontal ();

	if (GUILayout.Button ("CLEAR", GUILayout.Width (80), GUILayout.Height (40)))
	{
	StartCoroutine ("ButtonClick");
	MyText = "";
	}

	if (GUILayout.Button ("0", GUILayout.Width (51), GUILayout.Height (40))) 
	{
	StartCoroutine ("ButtonClick");
	MyText += "0";
	}
	if (GUILayout.Button ("ENTER", GUILayout.Width (80), GUILayout.Height (40)))
	{
	StartCoroutine ("ButtonClick");
	StartCoroutine ("KpSubmited");
	}
	GUILayout.EndHorizontal ();

	GUILayout.BeginHorizontal ();
	if (GUILayout.Button ("EXIT", GUILayout.Width (80), GUILayout.Height (40)))
	{
	StartCoroutine ("ButtonClick");
	MyText = "";
	IsSelected=false;
	timer=10;
	}
	GUILayout.EndHorizontal ();

	GUILayout.EndArea ();
	}
	}
	}

	void OnTriggerEnter(Collider Other)
	{
	if (Player && !IsLocked) 
	{
	IsPlayerIn=true;StartCoroutine("DoorOpen");
	}
	else
	{
	IsPlayerIn=true;AudioSource.PlayClipAtPoint(locked, new Vector3(0,0,0));
	Cursor.SetCursor(MyCursor, MyhotSpot, MycursorMode);
	}
	}

	void OnTriggerExit(Collider Other)
	{
	if (Player && !IsLocked) 
	{
	IsPlayerIn = false;StartCoroutine ("CloseDoor");Cursor.SetCursor(null, Vector2.zero, MycursorMode);
	}
	else
	{
	IsPlayerIn = false;Cursor.SetCursor(null, Vector2.zero, MycursorMode);
	}
	}

	void DoorOpen()
	{
	GetComponent<Animation>().Blend ("Door_Open");AudioSource.PlayClipAtPoint(open, new Vector3(0,0,0));
	}

	void DoorClose()
	{
	GetComponent<Animation>().Blend ("Door_Close");AudioSource.PlayClipAtPoint(open, new Vector3(0,0,0));
	}


	void ButtonClick()
	{
	AudioSource.PlayClipAtPoint(S_Button, new Vector3(0,0,0));
	}

	void KpSubmited()
	{
	if (MyText == uPassCode)
	{
	MyText = "UNLOCKED";
	IsLocked = false;
	IsGuiOn=false;
	IsSelected = false;
	timer = 10;
			MyColor = Color.green;
	AudioSource.PlayClipAtPoint (Su_lock, new Vector3 (0, 0, 0));
	StartCoroutine("DoorOpen");
	Cursor.SetCursor(null, Vector2.zero, MycursorMode);

	} else if (MyText == lPassCode)
	{
	MyText = "LOCKED";
	IsLocked = true;
	IsGuiOn=false;
	IsSelected = false;
	timer = 10;
			MyColor = Color.red;
	AudioSource.PlayClipAtPoint (S_Lock, new Vector3 (0, 0, 0));
	StartCoroutine("DoorClose");

	} 
	else
	{
	MyText = "FAILED";

			MyColor = Color.red;
			TColor = MyColor;
	AudioSource.PlayClipAtPoint (Se_Lock, new Vector3 (0, 0, 0));
	StartCoroutine ("ResTime");
	}
	}

	IEnumerator CloseDoor()
	{
	yield return new WaitForSeconds (2);
	GetComponent<Animation>().Blend("Door_Close");
	AudioSource.PlayClipAtPoint(close, new Vector3(0,0,0));
	MyColor = TColor;
	}

	IEnumerator ResTime() 
	{
		yield return new WaitForSeconds(2);MyColor = Color.red;MyText = "CODE ? ";
	}
}