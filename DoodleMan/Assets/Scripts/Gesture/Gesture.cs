using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;

public class Gesture : MonoBehaviour
{
    public static GameObject GuiText;
	public static int mouseDown;
	static ArrayList pointArr;
	static GameObject gestureDrawing;
	private GestureRecognizer gestureRecognizer;
	private GestureTemplates gestureTemplates;



    // runs when game starts - main function
    void Start ()
    {
	    pointArr = new ArrayList();
		gestureRecognizer = new GestureRecognizer();
		gestureTemplates = new GestureTemplates();

	    gestureDrawing = GameObject.Find("TouchDemo");
	    GuiText = GameObject.Find("GUIText");
	    GuiText.GetComponent<GUIText>().text = GuiText.GetComponent<GUIText>().text + "\n Templates loaded: " + GestureTemplates.Templates.Count;
    }

	public void AddPoint(Vector2 p){
		pointArr.Add(p);
	}

	public void Recognize(){
		// start recognizing! 
		GestureRecognizer.startRecognizer(pointArr);

		pointArr.Clear();
	}


//    IEnumerator worldToScreenCoordinates ()
//    {
//	    // fix world coordinate to the viewport coordinate
//	    Vector3 screenSpace = Camera.main.WorldToScreenPoint(gestureDrawing.transform.position);
//    	
//	    while (Input.GetMouseButton(1))
//	    {
//		    Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
//		    Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace); 
//		    gestureDrawing.transform.position = curPosition;
//		    yield return 0;
//	    }
//    }

//    void Update()
//    {
//	    if (Input.GetMouseButtonDown(1))
//        {
//		    mouseDown = 1;
//	    }
//    	
//	    if (mouseDown == 1)
//        {
//		    Vector2 p = new Vector2(Input.mousePosition.x , Input.mousePosition.y);
//		    pointArr.Add(p);
//		    StartCoroutine(worldToScreenCoordinates());
//	    }
//
//
//	    if (Input.GetMouseButtonUp(1))
//        {
//		    if (Input.GetKey (KeyCode.LeftControl))
//            {
//			    // if CTRL is held down, the script will record a gesture. 
//			    mouseDown = 0;
//			    GestureRecognizer.recordTemplate(pointArr);
//    		
//		    }
//            else
//            {
//			    mouseDown = 0;
//
//			    // start recognizing! 
//			    GestureRecognizer.startRecognizer(pointArr);
//
//			    pointArr.Clear();
//		    }
// 	    }
//     } 

//    void OnGUI ()
//    {
//	    if(GestureRecognizer.recordDone == 1)
//        { 
//		    GUI.Window (0, new Rect (350, 220, 300, 100), DoMyWindow, "Save the template?");
//	    }
//    }
//
//    void DoMyWindow (int windowID)
//    {
//        GestureRecognizer.stringToEdit = GUILayout.TextField(GestureRecognizer.stringToEdit);
//
//        if (GUI.Button (new Rect (100,50,50,20), "Save"))
//        {
//            ArrayList temp = new ArrayList();
//            ArrayList a = (ArrayList)GestureTemplates.Templates[GestureTemplates.Templates.Count - 1];
//
//            for (int i = 0; i < GestureRecognizer.newTemplateArr.Count; i++)
//                temp.Add(GestureRecognizer.newTemplateArr[i]);
//
//            GestureTemplates.Templates.Add(temp);
//            GestureTemplates.TemplateNames.Add(GestureRecognizer.stringToEdit);
//			this.CreateFile(GestureRecognizer.stringToEdit,GestureRecognizer.newTemplateArr );
//            GestureRecognizer.recordDone = 0;
//
//            GestureRecognizer.newTemplateArr.Clear();
//
//            GuiText.guiText.text = "TEMPLATE: " + GestureRecognizer.stringToEdit + "\n STATUS: SAVED";
//	    }
//
//	    if (GUI.Button (new Rect (160,50,50,20), "Cancel")) 
//        {
//            GestureRecognizer.recordDone = 0;
//	       GuiText.guiText.text = "";
//	    }
//    }
//
//	void CreateFile(string gestureName, ArrayList points) 
//	{ 
//		StreamWriter writer; 
//		FileInfo t = new FileInfo(Application.dataPath + @"/Data/"+ gestureName + ".xml"); 
//		if(!t.Exists) 
//		{ 
//			writer = t.CreateText(); 
//		} 
//		else 
//		{ 
//			t.Delete(); 
//			writer = t.CreateText(); 
//		} 
//
//		writer.Write("<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>\n<Gesture>\n");
//		writer.Write("<Name>"+gestureName+"</Name>\n"); 
//		Vector2 v;
//		for (int i = 0; i < points.Count; i++) {
//			v = (Vector2) points[i];
//			writer.Write("<Point X=\""+v.x+"\" Y=\""+v.y+"\" T = \"0\"/>\n");
//
//			}
//
//		writer.Write("</Gesture>\n");
//
//		writer.Close(); 
//		//Debug.Log("File written."); 
//	}
}
