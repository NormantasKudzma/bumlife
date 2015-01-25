using UnityEngine;

public class TextGen {
	static int count = 0;
	
	public static void MakeText(){
		//STUB
	}
	
	public static void MakeText(string text, Color col, Vector3 pos){
		MakeText(text, col, pos, 50);
	}
	
	public static void MakeText(string text, Color col, Vector3 pos, int size){
		MakeText(text, col, pos, size, true);
	}
	
	public static void MakeText(string text, Color col, Vector3 pos, int size, bool moving){
		Font ff = Resources.Load<Font>("Fonts/droidfont");
		GameObject entity = new GameObject("TxtEntity" + count);
		if (pos.z >= 0){
			pos.z = 9;
		}
		entity.transform.position = pos;
		entity.AddComponent<TextEntity>().moving = moving;
		TextMesh txtmesh = entity.AddComponent<TextMesh>();
		txtmesh.anchor = TextAnchor.MiddleCenter;
		txtmesh.text = text;
		txtmesh.color = col;
		txtmesh.font = ff;
		txtmesh.fontSize = size;
		txtmesh.characterSize = 0.20f;
		entity.renderer.material = ff.material;
		count++;
	}
}
