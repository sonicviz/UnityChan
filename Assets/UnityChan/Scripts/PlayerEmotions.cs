using UnityEngine;
using UnityEngine.UI;
using Affdex;
using System.Collections.Generic;

public class PlayerEmotions : ImageResultsListener
{
    public float currentValence;
    public float currentAnger;
    public float currentSurprise;
    public float currentSmile;
    public float currentDisgust;
    public float currentEyeClosure;

    public ParticleSystem fog;

    public override void onFaceFound(float timestamp, int faceId)
    {
        fog.enableEmission = false;
        if (Debug.isDebugBuild) Debug.Log("Found the face");
    }

    public override void onFaceLost(float timestamp, int faceId)
    {
        fog.enableEmission = true;
        currentValence = 0;
        currentAnger = 0;
        currentSurprise = 0;
        currentSmile = 0;
        currentDisgust = 0;
        currentEyeClosure = 0;
        if (Debug.isDebugBuild) Debug.Log("Lost the face");
    }

    public override void onImageResults(Dictionary<int, Face> faces)
    {
        if (faces.Count > 0)
        {
            faces[0].Emotions.TryGetValue(Emotions.Valence, out currentValence);
            faces[0].Emotions.TryGetValue(Emotions.Anger, out currentAnger);
            faces[0].Emotions.TryGetValue(Emotions.Surprise, out currentSurprise);
            faces[0].Emotions.TryGetValue(Emotions.Disgust, out currentDisgust);
            faces[0].Expressions.TryGetValue(Expressions.Smile, out currentSmile);
            faces[0].Expressions.TryGetValue(Expressions.EyeClosure, out currentEyeClosure);
        }
    }
}