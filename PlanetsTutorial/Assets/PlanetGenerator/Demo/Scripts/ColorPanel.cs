using UnityEngine;
using UnityEngine.UI;
using System.Collections;
[ExecuteInEditMode]
public class ColorPanel : MonoBehaviour {
    Image image;
    public Color col;
	// Use this for initialization
	void Awake () {
        image = GetComponent<Image>();
        col = new Color(0, 0, 0, 1f);
	}
	
	// Update is called once per frame
	public void OnBChange (float t)
    {
        col.b = t;
        image.color = col;
	}
    public void OnGChange(float t)
    {
        col.g = t;
        image.color = col;
    }
    public void OnRChange(float t)
    {
        col.r = t;
        image.color = col;
    }
    public void OnAChange(float t)
    {
        col.a = t;
        image.color = col;
    }
    public void OnVChange(float t)
    {
        float h, v, s;
        Color.RGBToHSV(col,out h, out s, out v);
        v = t;
        col = Color.HSVToRGB(h, s, v);
    }
}
