using UnityEngine;
using System.Collections;
using System.Xml;

// all known gesture templates
public class GestureTemplates
{
    public static ArrayList Templates;
    public static ArrayList TemplateNames;

    public GestureTemplates ()
    {
		Templates = new ArrayList();
		TemplateNames = new ArrayList ();

		ArrayList gestureArrayList;
		Vector2[] vector2Array;

		string gestureName = string.Empty;

		TextAsset textAsset  = (TextAsset)Resources.Load("Gestures");
		XmlDocument xmlDoc = new XmlDocument ();
		xmlDoc.LoadXml ( textAsset.text );
		// Select all gestures.
		XmlNodeList gesturesList = xmlDoc.GetElementsByTagName ("Gesture");
		foreach (XmlNode gesture in gesturesList) {
			XmlNodeList gestureContent = gesture.ChildNodes;
			gestureArrayList = new ArrayList();
			vector2Array = new Vector2[gesture.ChildNodes.Count];

			foreach (XmlNode point in gesture.ChildNodes)
			{
				if(point.Name == "Point")
					gestureArrayList.Add(new Vector2(
						float.Parse(point.Attributes["X"].Value,System.Globalization.CultureInfo.InvariantCulture),
						float.Parse(point.Attributes["Y"].Value,System.Globalization.CultureInfo.InvariantCulture)));
				else
					gestureName = point.InnerText;
			}

			Templates.Add(gestureArrayList);
			TemplateNames.Add(gestureName);		}
    }
}