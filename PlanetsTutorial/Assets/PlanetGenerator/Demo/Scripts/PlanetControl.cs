using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlanetControl : MonoBehaviour {
    public GameObject[] planets = new GameObject[3];
    public Text seedT;
    public Slider relief;
    public Material[] mat = new Material[3];
    public Slider liquidLevel;
    public Slider size;
    public Slider temperature;
    public Slider atmosphere;
    public Slider fertility;
    public Slider population;
    public Slider cloudsAmount;

    public Slider shoresR;
    public Slider shoresG;
    public Slider shoresB;

    public Slider planesR;
    public Slider planesG;
    public Slider planesB;

    public Slider mountainsR;
    public Slider mountainsG;
    public Slider mountainsB;

    public Slider atmosphereR;
    public Slider atmosphereG;
    public Slider atmosphereB;

    public Slider cloudsR;
    public Slider cloudsG;
    public Slider cloudsB; 

    public Slider vegetationR;
    public Slider vegetationG;
    public Slider vegetationB;

    public Slider citiesR;
    public Slider citiesG;
    public Slider citiesB;

    public Toggle volAtm;
    public Slider rim;
    public Slider refraction;
    public Slider border;
    public Slider aSize;

    public Slider cracksSize;
    public Slider cracksDepth;
    public Slider cracksR;
    public Slider cracksG;
    public Slider cracksB;
    public Slider cracksA;
    public Slider cracksV;
    public Toggle emissiveCracks;
    public int picked = 0;

    public AtmosphereInfo[] atm;

    public void OnGenerate()
    {
        float seed = Random.Range(0f, 500f);
        seedT.text = "Random seed: " + seed;
        mat[picked].SetFloat("_RandomSeed", seed);
    }

    public void Start()
    {
        Init();

    }
    public void OnPicked1()
    {
        if (picked == 0) return;
        StartCoroutine(moveAway(picked));
        picked = 0;
        StartCoroutine(moveIn());
        planets[0].transform.position = Vector3.zero;
    }
    IEnumerator moveAway(int i)
    {
        float t = 0;
        float time = 1.5f;
        while (t < time)
        {
            planets[i].transform.position = Vector3.Lerp(Vector3.zero, Camera.main.transform.TransformDirection(Vector3.left)*20, t / time);
            t += Time.deltaTime;
            yield return null;
        }
        planets[i].SetActive(false);
    }
    IEnumerator moveIn()
    {
        planets[picked].SetActive(true);
        float t = 0;
        float time = 0.75f;
        while (t < time)
        {
            planets[picked].transform.position = Vector3.Lerp(Camera.main.transform.TransformDirection(Vector3.right)*10, Vector3.zero, t / time);
            t += Time.deltaTime;
            yield return null;
        }
        planets[picked].transform.position = Vector3.zero;
        Init();
    }
    public void OnPicked2()
    {
        if (picked == 1) return;
        StartCoroutine(moveAway(picked));
        picked = 1;
        StartCoroutine(moveIn());

    }
    public void OnPicked3()
    {
        if (picked == 2) return;
        StartCoroutine(moveAway(picked));
        picked = 2;
        StartCoroutine(moveIn());
    }
    public void OnPicked4()
    {
        if (picked == 3) return;
        StartCoroutine(moveAway(picked));
        picked = 3;
        StartCoroutine(moveIn());
    }
    public void OnPicked5()
    {
        if (picked == 4) return;
        StartCoroutine(moveAway(picked));
        picked = 4;
        StartCoroutine(moveIn());
    }
    public void OnPicked6()
    {
        if (picked == 5) return;
        StartCoroutine(moveAway(picked));
        picked = 5;
        StartCoroutine(moveIn());
    }
    public void OnVolAtm(bool value)
    {
        if (value)
            mat[picked].SetInt("_Emission", 0);
        else
            mat[picked].SetInt("_Emission", 1);
        if (value)
        {
            if(planets[picked].transform.Find("Atmosphere")==null)
            GenerateAtm();
        }
        else
        {
            if (planets[picked].transform.Find("Atmosphere") != null)
                Destroy(planets[picked].transform.Find("Atmosphere").gameObject);
        }
    }

    public void GenerateAtm()
    {
        GameObject atmo = Instantiate(planets[picked]);
        if (atmo.transform.childCount > 0)
        {
            for (int i = 0; i < atmo.transform.childCount; i++)
            {
                Destroy(atmo.transform.GetChild(i).gameObject);
            }
        }
        atmo.name = "Atmosphere";
        atmo.transform.parent = planets[picked].transform;
        atmo.transform.localPosition = Vector3.zero;
        Renderer rend = atmo.GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Human Unit/Atmosphere");
        rend.material.SetColor("_Color", mat[picked].GetColor("_AtmosphereColor"));
        rend.material.SetFloat("_Rim", atm[picked].rim);
        rend.material.SetFloat("_Refraction", atm[picked].refration);
        rend.material.SetFloat("_Border", atm[picked].border);
        rend.material.SetFloat("_Size", atm[picked].size);
        rend.material.SetFloat("_Brightness", mat[picked].GetFloat("_Atmosphere"));
        rend.material.SetFloat("_Density", mat[picked].GetFloat("_Atmosphere"));
    }
    public void Init()
    {
        liquidLevel.value = mat[picked].GetFloat("_WaterLevel");
        size.value = mat[picked].GetFloat("_Size");
        temperature.value = mat[picked].GetFloat("_Temperature");
        atmosphere.value = mat[picked].GetFloat("_Atmosphere");
        fertility.value = mat[picked].GetFloat("_Fertility");
        population.value = mat[picked].GetFloat("_Population");
        relief.value = mat[picked].GetFloat("_NormalIntencity");
        cloudsAmount.value = mat[picked].GetFloat("_CloudsAmount");
        volAtm.isOn = mat[picked].GetInt("_Emission") == 0;
        rim.value = atm[picked].rim;
        refraction.value = atm[picked].refration;
        border.value = atm[picked].border;
        aSize.value = atm[picked].size;

        shoresR.value = mat[picked].GetColor("_Shores").r;
        shoresG.value = mat[picked].GetColor("_Shores").g;
        shoresB.value = mat[picked].GetColor("_Shores").b;

        planesR.value = mat[picked].GetColor("_Planes").r;
        planesG.value = mat[picked].GetColor("_Planes").g;
        planesB.value = mat[picked].GetColor("_Planes").b;

        mountainsR.value = mat[picked].GetColor("_Mountains").r;
        mountainsG.value = mat[picked].GetColor("_Mountains").g;
        mountainsB.value = mat[picked].GetColor("_Mountains").b;

        atmosphereR.value = mat[picked].GetColor("_AtmosphereColor").r;
        atmosphereG.value = mat[picked].GetColor("_AtmosphereColor").g;
        atmosphereB.value = mat[picked].GetColor("_AtmosphereColor").b;

        cloudsR.value = mat[picked].GetColor("_CloudsColor").r;
        cloudsG.value = mat[picked].GetColor("_CloudsColor").g;
        cloudsB.value = mat[picked].GetColor("_CloudsColor").b;

        vegetationR.value = mat[picked].GetColor("_VegetationColor").r;
        vegetationG.value = mat[picked].GetColor("_VegetationColor").g;
        vegetationB.value = mat[picked].GetColor("_VegetationColor").b;

        citiesR.value = mat[picked].GetColor("_CityColor").r;
        citiesG.value = mat[picked].GetColor("_CityColor").g;
        citiesB.value = mat[picked].GetColor("_CityColor").b;



        cracksA.value = mat[picked].GetColor("_CracksColor").a;
        cracksR.value = mat[picked].GetColor("_CracksColor").r;
        cracksG.value = mat[picked].GetColor("_CracksColor").g;
        cracksB.value = mat[picked].GetColor("_CracksColor").b;
        float foo=0;
        float v;
        Color.RGBToHSV(mat[picked].GetColor("_CracksColor"), out foo, out foo, out v);
        cracksV.value = v;

        cracksSize.value = mat[picked].GetFloat("_Cracks");
        cracksDepth.value = mat[picked].GetFloat("_CracksDepth");
        emissiveCracks.isOn = mat[picked].GetInt("_EmissiveCracks") == 1;
    }
    public void OnLiquidLevel(float value)
    {
        mat[picked].SetFloat("_WaterLevel", value);
    }
    public void OnSize(float value)
    {
        mat[picked].SetFloat("_Size", value);
    }
    public void OnTemperature(float value)
    {
        mat[picked].SetFloat("_Temperature", value);
    }
    public void OnAtmosphere(float value)
    {
        mat[picked].SetFloat("_Atmosphere", value);
        if (volAtm.isOn)
        {
            if (planets[picked].transform.Find("Atmosphere") == null) GenerateAtm();
            planets[picked].transform.Find("Atmosphere").gameObject.GetComponent<Renderer>().material.SetFloat("_Brightness", value);
            planets[picked].transform.Find("Atmosphere").gameObject.GetComponent<Renderer>().material.SetFloat("_Desity", value);
        }
    }
    public void OnCloudsAmount(float value)
    {
        mat[picked].SetFloat("_CloudsAmount", value);
    }
    public void OnRelief(float value)
    {
        mat[picked].SetFloat("_NormalIntencity", value);
    }
    public void OnFertility(float value)
    {
        mat[picked].SetFloat("_Fertility", value);
    }
    public void OnPopulation(float value)
    {
        mat[picked].SetFloat("_Population", value);
    }
    public void OnRim( float value)
    {
        atm[picked].rim = value;
        if (volAtm.isOn)
            planets[picked].transform.Find("Atmosphere").gameObject.GetComponent<Renderer>().material.SetFloat("_Rim", value);
    }
    public void OnRefraction(float value)
    {
        atm[picked].refration = value;
        if(volAtm.isOn)
            planets[picked].transform.Find("Atmosphere").gameObject.GetComponent<Renderer>().material.SetFloat("_Refraction", value);
    }
    public void OnBorder(float value)
    {
        atm[picked].border = value;
        if (volAtm.isOn)
            planets[picked].transform.Find("Atmosphere").gameObject.GetComponent<Renderer>().material.SetFloat("_Border", value);
    }
    public void OnASize(float value)
    {
        atm[picked].size = value;
        if (volAtm.isOn)
            planets[picked].transform.Find("Atmosphere").gameObject.GetComponent<Renderer>().material.SetFloat("_Size", value);
    }

    public void OnShoresR(float value)
    {
        Color col = mat[picked].GetColor("_Shores");
        col.r = value;
        mat[picked].SetColor("_Shores", col);
    }
    public void OnShoresG(float value)
    {
        Color col = mat[picked].GetColor("_Shores");
        col.g = value;
        mat[picked].SetColor("_Shores", col);
    }
    public void OnShoresB(float value)
    {
        Color col = mat[picked].GetColor("_Shores");
        col.b = value;
        mat[picked].SetColor("_Shores", col);
    }

    public void OnPlanesR(float value)
    {
        Color col = mat[picked].GetColor("_Planes");
        col.r = value;
        mat[picked].SetColor("_Planes", col);
    }
    public void OnPlanesG(float value)
    {
        Color col = mat[picked].GetColor("_Planes");
        col.g = value;
        mat[picked].SetColor("_Planes", col);
    }
    public void OnPlanesB(float value)
    {
        Color col = mat[picked].GetColor("_Planes");
        col.b = value;
        mat[picked].SetColor("_Planes", col);
    }

    public void OnMountainsR(float value)
    {
        Color col = mat[picked].GetColor("_Mountains");
        col.r = value;
        mat[picked].SetColor("_Mountains", col);
    }
    public void OnMountainsG(float value)
    {
        Color col = mat[picked].GetColor("_Mountains");
        col.g = value;
        mat[picked].SetColor("_Mountains", col);
    }
    public void OnMountainsB(float value)
    {
        Color col = mat[picked].GetColor("_Mountains");
        col.b = value;
        mat[picked].SetColor("_Mountains", col);
    }

    public void OnAtmosphereR(float value)
    {
        Color col = mat[picked].GetColor("_AtmosphereColor");
        col.r = value;
        if (volAtm.isOn)
        {
            if (planets[picked].transform.Find("Atmosphere") == null) GenerateAtm();
            planets[picked].transform.Find("Atmosphere").gameObject.GetComponent<Renderer>().material.SetColor("_Color", col);
        }
        mat[picked].SetColor("_AtmosphereColor", col);
    }
    public void OnAtmosphereG(float value)
    {
        Color col = mat[picked].GetColor("_AtmosphereColor");
        col.g = value;
        if (volAtm.isOn)
        {
            if (planets[picked].transform.Find("Atmosphere") == null) GenerateAtm();
            planets[picked].transform.Find("Atmosphere").gameObject.GetComponent<Renderer>().material.SetColor("_Color", col);
        }
        mat[picked].SetColor("_AtmosphereColor", col);
    }
    public void OnAtmosphereB(float value)
    {
        Color col = mat[picked].GetColor("_AtmosphereColor");
        col.b = value;
        if (volAtm.isOn)
        {
            if (planets[picked].transform.Find("Atmosphere") == null) GenerateAtm();
            planets[picked].transform.Find("Atmosphere").gameObject.GetComponent<Renderer>().material.SetColor("_Color", col);
        }
        mat[picked].SetColor("_AtmosphereColor", col);
    }

    public void OnCloudsR(float value)
    {
        Color col = mat[picked].GetColor("_CloudsColor");
        col.r = value;
        mat[picked].SetColor("_CloudsColor", col);
    }
    public void OnCloudsG(float value)
    {
        Color col = mat[picked].GetColor("_CloudsColor");
        col.g = value;
        mat[picked].SetColor("_CloudsColor", col);
    }
    public void OnCloudsB(float value)
    {
        Color col = mat[picked].GetColor("_CloudsColor");
        col.b = value;
        mat[picked].SetColor("_CloudsColor", col);
    }

    public void OnVegetationR(float value)
    {
        Color col = mat[picked].GetColor("_VegetationColor");
        col.r = value;
        mat[picked].SetColor("_VegetationColor", col);
    }
    public void OnVegetationG(float value)
    {
        Color col = mat[picked].GetColor("_VegetationColor");
        col.g = value;
        mat[picked].SetColor("_VegetationColor", col);
    }
    public void OnVegetationB(float value)
    {
        Color col = mat[picked].GetColor("_VegetationColor");
        col.b = value;
        mat[picked].SetColor("_VegetationColor", col);
    }

    public void CityR(float value)
    {
        Color col = mat[picked].GetColor("_CityColor");
        col.r = value;
        mat[picked].SetColor("_CityColor", col);
    }
    public void CityG(float value)
    {
        Color col = mat[picked].GetColor("_CityColor");
        col.g = value;
        mat[picked].SetColor("_CityColor", col);
    }
    public void CityB(float value)
    {
        Color col = mat[picked].GetColor("_CityColor");
        col.b = value;
        mat[picked].SetColor("_CityColor", col);
    }
    public void CracksR(float value)
    {
        Color col = mat[picked].GetColor("_CracksColor");
        col.r = value;
        mat[picked].SetColor("_CracksColor", col);
    }
    public void CracksG(float value)
    {
        Color col = mat[picked].GetColor("_CracksColor");
        col.g = value;
        mat[picked].SetColor("_CracksColor", col);
    }
    public void CracksB(float value)
    {
        Color col = mat[picked].GetColor("_CracksColor");
        col.b = value;
        mat[picked].SetColor("_CracksColor", col);
    }
    public void CracksA(float value)
    {
        Color col = mat[picked].GetColor("_CracksColor");
        col.a = value;
        mat[picked].SetColor("_CracksColor", col);
    }
    public void CracksV(float value)
    {
        float h, s, v;
        Color col = mat[picked].GetColor("_CracksColor");
        Color.RGBToHSV(col, out h, out s, out v);
        v = value;
        col = Color.HSVToRGB(h, s, v);
        mat[picked].SetColor("_CracksColor", col);
    }
    public void OnCracksSize(float value)
    {
        mat[picked].SetFloat("_Cracks", value);
    }
    public void OnCracksDepth(float value)
    {
        mat[picked].SetFloat("_CracksDepth", value);
    }
    public void OnEmissiveCracks(bool value)
    {
        int i;
        if (value) i = 1;
        else i = 0;
        mat[picked].SetInt("_EmissiveCracks", i);
    }

}
[System.Serializable]
public struct AtmosphereInfo
{
    public float rim;
    public float refration;
    public float border;
    public float size;
}

