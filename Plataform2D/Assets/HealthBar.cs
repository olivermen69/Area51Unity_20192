using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float minScale = 0f;
    public float maxScale = 15f;

    public RectTransform barMiddle;
    public RectTransform barEnd;

    public Image bar;
    public float maxLife = 50;
    public float _currentLife;

    public float CurrentLife {
        set {
            _currentLife = Mathf.Clamp(value, 0, maxLife);
            UpdateBar();
        }

        get {
            return _currentLife;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CurrentLife = maxLife;
        //barMiddle.localScale.x = maxScale;
    }

    // Update is called once per frame
    void Update() {
        //if (Input.GetKeyDown(KeyCode.O)) {
        //    //bar.fillAmount -= 0.1f;
        //    _currentLife--;
        //    UpdateBar();
        //}

        //if (Input.GetKeyDown(KeyCode.P)) {
        //    //bar.fillAmount += 0.1f;
        //    _currentLife++;
        //    UpdateBar();
        //}
        ////_currentLife = Mathf.Clamp(_currentLife, 0, maxLife);
        ////bar.fillAmount = _currentLife / maxLife;
        
    }

    void UpdateBar() {
        //_currentLife = Mathf.Clamp(_currentLife, 0, maxLife);        
        float percentLife = CurrentLife / maxLife;
        float percentScale = percentLife * maxScale;

        Vector3 scale = barMiddle.localScale;
        //float scaleX = Mathf.Clamp(percentScale, minScale, maxScale);
        scale.x = Mathf.Clamp(percentScale, minScale, maxScale);

        Vector3 pos = barEnd.localPosition;

        pos.x = barMiddle.localPosition.x + (barMiddle.sizeDelta.x * scale.x);
        barEnd.localPosition = pos;
        barMiddle.localScale = scale;
        //barEnd.sizeDelta
        //barMiddle.localScale
        //barEnd.position
    }

    public void SetLife(float life) {
        CurrentLife = life;
        UpdateBar();
    }
}
