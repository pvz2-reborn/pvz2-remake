// 倒计时
// 倒计时结束的回调

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
public class CountDownTime : MonoBehaviour
{
    public float testTime = 15.0f;

    private float _timeLeft = 0.0f;
    private Text _textTimer = null;
    private float _delay = 0.1f;
    private Action _endCallback = null;

    private void Start()
    {
        /*
        if (_textTimer == null)
            _textTimer = GetComponent<Text>();
        */
        SetEndCallback(TestEndCallback);
        Begin(testTime, true);
    }

    public void SetEndCallback(Action callback)
    {
        _endCallback = callback;
    }

    public void Begin(float timeLeft, bool isRightNow)
    {
        _timeLeft = timeLeft;
        /*
        if (_textTimer == null)
            _textTimer = GetComponent<Text>();
        */
        if (isRightNow) CountDown();
       // if (gameObject.activeInHierarchy)
        StartCoroutine(Polling(_delay, CountDown));
    }

    private IEnumerator Polling(float delay, Action voidFunc)
    {
        while (delay > 0.0f)
        {
            voidFunc();

            if (_timeLeft < 0.0f && _endCallback != null) {
                _endCallback();
                _endCallback = null;
                yield return null;

            }
            yield return new WaitForSeconds(delay);
        }
    }

    private void CountDown()
    {
        if (_timeLeft >= 0.0f)
        {
            //TimeSpan ts = new TimeSpan(0, 0, _timeLeft-= 0.1f);
            //_textTimer.text = ts.ToString();
            _timeLeft-= 0.1f;
        }
        else if (_timeLeft < -1.0f)
        {
            //_textTimer.text = _timeLeft.ToString();
        }
    }

    private void TestEndCallback() {
        //_textTimer.text = "End!!!";
    }
}
