/**
 * Copyright (c) 2017 Enzien Audio, Ltd.
 * 
 * Redistribution and use in source and binary forms, with or without modification,
 * are permitted provided that the following conditions are met:
 * 
 * 1. Redistributions of source code must retain the above copyright notice,
 *    this list of conditions, and the following disclaimer.
 * 
 * 2. Redistributions in binary form must reproduce the phrase "powered by heavy",
 *    the heavy logo, and a hyperlink to https://enzienaudio.com, all in a visible
 *    form.
 * 
 *   2.1 If the Application is distributed in a store system (for example,
 *       the Apple "App Store" or "Google Play"), the phrase "powered by heavy"
 *       shall be included in the app description or the copyright text as well as
 *       the in the app itself. The heavy logo will shall be visible in the app
 *       itself as well.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO,
 * THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
 * FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
 * CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
 * OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
 * THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 * 
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Assertions;
using AOT;

#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(Hv_FilterRolling_AudioLib))]
public class Hv_FilterRolling_Editor : Editor {

  [MenuItem("Heavy/FilterRolling")]
  static void CreateHv_FilterRolling() {
    GameObject target = Selection.activeGameObject;
    if (target != null) {
      target.AddComponent<Hv_FilterRolling_AudioLib>();
    }
  }
  
  private Hv_FilterRolling_AudioLib _dsp;

  private void OnEnable() {
    _dsp = target as Hv_FilterRolling_AudioLib;
  }

  public override void OnInspectorGUI() {
    bool isEnabled = _dsp.IsInstantiated();
    if (!isEnabled) {
      EditorGUILayout.LabelField("Press Play!",  EditorStyles.centeredGreyMiniLabel);
    }
    // events
    GUI.enabled = isEnabled;
    EditorGUILayout.Space();
    // excite
    if (GUILayout.Button("excite")) {
      _dsp.SendEvent(Hv_FilterRolling_AudioLib.Event.Excite);
    }
    
    // whackImpact
    if (GUILayout.Button("whackImpact")) {
      _dsp.SendEvent(Hv_FilterRolling_AudioLib.Event.Whackimpact);
    }
    
    GUILayout.EndVertical();

    // parameters
    GUI.enabled = true;
    GUILayout.BeginVertical();
    EditorGUILayout.Space();
    EditorGUI.indentLevel++;
    
    // amp1
    GUILayout.BeginHorizontal();
    float amp1 = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp1);
    float newAmp1 = EditorGUILayout.Slider("amp1", amp1, 0.0f, 1.0f);
    if (amp1 != newAmp1) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp1, newAmp1);
    }
    GUILayout.EndHorizontal();
    
    // amp10
    GUILayout.BeginHorizontal();
    float amp10 = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp10);
    float newAmp10 = EditorGUILayout.Slider("amp10", amp10, 0.0f, 1.0f);
    if (amp10 != newAmp10) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp10, newAmp10);
    }
    GUILayout.EndHorizontal();
    
    // amp2
    GUILayout.BeginHorizontal();
    float amp2 = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp2);
    float newAmp2 = EditorGUILayout.Slider("amp2", amp2, 0.0f, 1.0f);
    if (amp2 != newAmp2) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp2, newAmp2);
    }
    GUILayout.EndHorizontal();
    
    // amp3
    GUILayout.BeginHorizontal();
    float amp3 = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp3);
    float newAmp3 = EditorGUILayout.Slider("amp3", amp3, 0.0f, 1.0f);
    if (amp3 != newAmp3) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp3, newAmp3);
    }
    GUILayout.EndHorizontal();
    
    // amp4
    GUILayout.BeginHorizontal();
    float amp4 = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp4);
    float newAmp4 = EditorGUILayout.Slider("amp4", amp4, 0.0f, 1.0f);
    if (amp4 != newAmp4) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp4, newAmp4);
    }
    GUILayout.EndHorizontal();
    
    // amp5
    GUILayout.BeginHorizontal();
    float amp5 = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp5);
    float newAmp5 = EditorGUILayout.Slider("amp5", amp5, 0.0f, 1.0f);
    if (amp5 != newAmp5) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp5, newAmp5);
    }
    GUILayout.EndHorizontal();
    
    // amp6
    GUILayout.BeginHorizontal();
    float amp6 = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp6);
    float newAmp6 = EditorGUILayout.Slider("amp6", amp6, 0.0f, 1.0f);
    if (amp6 != newAmp6) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp6, newAmp6);
    }
    GUILayout.EndHorizontal();
    
    // amp7
    GUILayout.BeginHorizontal();
    float amp7 = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp7);
    float newAmp7 = EditorGUILayout.Slider("amp7", amp7, 0.0f, 1.0f);
    if (amp7 != newAmp7) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp7, newAmp7);
    }
    GUILayout.EndHorizontal();
    
    // amp8
    GUILayout.BeginHorizontal();
    float amp8 = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp8);
    float newAmp8 = EditorGUILayout.Slider("amp8", amp8, 0.0f, 1.0f);
    if (amp8 != newAmp8) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp8, newAmp8);
    }
    GUILayout.EndHorizontal();
    
    // amp9
    GUILayout.BeginHorizontal();
    float amp9 = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp9);
    float newAmp9 = EditorGUILayout.Slider("amp9", amp9, 0.0f, 1.0f);
    if (amp9 != newAmp9) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp9, newAmp9);
    }
    GUILayout.EndHorizontal();
    
    // freq1
    GUILayout.BeginHorizontal();
    float freq1 = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Freq1);
    float newFreq1 = EditorGUILayout.Slider("freq1", freq1, 20.0f, 20000.0f);
    if (freq1 != newFreq1) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Freq1, newFreq1);
    }
    GUILayout.EndHorizontal();
    
    // freq10
    GUILayout.BeginHorizontal();
    float freq10 = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Freq10);
    float newFreq10 = EditorGUILayout.Slider("freq10", freq10, 20.0f, 20000.0f);
    if (freq10 != newFreq10) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Freq10, newFreq10);
    }
    GUILayout.EndHorizontal();
    
    // freq2
    GUILayout.BeginHorizontal();
    float freq2 = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Freq2);
    float newFreq2 = EditorGUILayout.Slider("freq2", freq2, 20.0f, 20000.0f);
    if (freq2 != newFreq2) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Freq2, newFreq2);
    }
    GUILayout.EndHorizontal();
    
    // freq3
    GUILayout.BeginHorizontal();
    float freq3 = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Freq3);
    float newFreq3 = EditorGUILayout.Slider("freq3", freq3, 20.0f, 20000.0f);
    if (freq3 != newFreq3) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Freq3, newFreq3);
    }
    GUILayout.EndHorizontal();
    
    // freq4
    GUILayout.BeginHorizontal();
    float freq4 = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Freq4);
    float newFreq4 = EditorGUILayout.Slider("freq4", freq4, 20.0f, 20000.0f);
    if (freq4 != newFreq4) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Freq4, newFreq4);
    }
    GUILayout.EndHorizontal();
    
    // freq5
    GUILayout.BeginHorizontal();
    float freq5 = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Freq5);
    float newFreq5 = EditorGUILayout.Slider("freq5", freq5, 20.0f, 20000.0f);
    if (freq5 != newFreq5) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Freq5, newFreq5);
    }
    GUILayout.EndHorizontal();
    
    // freq6
    GUILayout.BeginHorizontal();
    float freq6 = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Freq6);
    float newFreq6 = EditorGUILayout.Slider("freq6", freq6, 20.0f, 20000.0f);
    if (freq6 != newFreq6) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Freq6, newFreq6);
    }
    GUILayout.EndHorizontal();
    
    // freq7
    GUILayout.BeginHorizontal();
    float freq7 = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Freq7);
    float newFreq7 = EditorGUILayout.Slider("freq7", freq7, 20.0f, 20000.0f);
    if (freq7 != newFreq7) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Freq7, newFreq7);
    }
    GUILayout.EndHorizontal();
    
    // freq8
    GUILayout.BeginHorizontal();
    float freq8 = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Freq8);
    float newFreq8 = EditorGUILayout.Slider("freq8", freq8, 20.0f, 20000.0f);
    if (freq8 != newFreq8) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Freq8, newFreq8);
    }
    GUILayout.EndHorizontal();
    
    // freq9
    GUILayout.BeginHorizontal();
    float freq9 = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Freq9);
    float newFreq9 = EditorGUILayout.Slider("freq9", freq9, 20.0f, 20000.0f);
    if (freq9 != newFreq9) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Freq9, newFreq9);
    }
    GUILayout.EndHorizontal();
    
    // impactForce
    GUILayout.BeginHorizontal();
    float impactForce = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Impactforce);
    float newImpactforce = EditorGUILayout.Slider("impactForce", impactForce, 0.0f, 10.0f);
    if (impactForce != newImpactforce) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Impactforce, newImpactforce);
    }
    GUILayout.EndHorizontal();
    
    // object_roughness
    GUILayout.BeginHorizontal();
    float object_roughness = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Object_roughness);
    float newObject_roughness = EditorGUILayout.Slider("object_roughness", object_roughness, 0.0f, 50.0f);
    if (object_roughness != newObject_roughness) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Object_roughness, newObject_roughness);
    }
    GUILayout.EndHorizontal();
    
    // qfactor
    GUILayout.BeginHorizontal();
    float qfactor = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Qfactor);
    float newQfactor = EditorGUILayout.Slider("qfactor", qfactor, 20.0f, 5000.0f);
    if (qfactor != newQfactor) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Qfactor, newQfactor);
    }
    GUILayout.EndHorizontal();
    
    // size
    GUILayout.BeginHorizontal();
    float size = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Size);
    float newSize = EditorGUILayout.Slider("size", size, 0.1f, 2.0f);
    if (size != newSize) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Size, newSize);
    }
    GUILayout.EndHorizontal();
    
    // time_roll
    GUILayout.BeginHorizontal();
    float time_roll = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Time_roll);
    float newTime_roll = EditorGUILayout.Slider("time_roll", time_roll, 0.0f, 1000.0f);
    if (time_roll != newTime_roll) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Time_roll, newTime_roll);
    }
    GUILayout.EndHorizontal();
    
    // time_scratch
    GUILayout.BeginHorizontal();
    float time_scratch = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Time_scratch);
    float newTime_scratch = EditorGUILayout.Slider("time_scratch", time_scratch, 0.0f, 1000.0f);
    if (time_scratch != newTime_scratch) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Time_scratch, newTime_scratch);
    }
    GUILayout.EndHorizontal();
    
    // velocity
    GUILayout.BeginHorizontal();
    float velocity = _dsp.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Velocity);
    float newVelocity = EditorGUILayout.Slider("velocity", velocity, 0.0f, 10.0f);
    if (velocity != newVelocity) {
      _dsp.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Velocity, newVelocity);
    }
    GUILayout.EndHorizontal();
    EditorGUI.indentLevel--;
  }
}
#endif // UNITY_EDITOR

[RequireComponent (typeof (AudioSource))]
public class Hv_FilterRolling_AudioLib : MonoBehaviour {
  
  // Events are used to trigger bangs in the patch context (thread-safe).
  // Example usage:
  /*
    void Start () {
        Hv_FilterRolling_AudioLib script = GetComponent<Hv_FilterRolling_AudioLib>();
        script.SendEvent(Hv_FilterRolling_AudioLib.Event.Excite);
    }
  */
  public enum Event : uint {
    Excite = 0x536B1B97,
    Whackimpact = 0x1B54B46E,
  }
  
  // Parameters are used to send float messages into the patch context (thread-safe).
  // Example usage:
  /*
    void Start () {
        Hv_FilterRolling_AudioLib script = GetComponent<Hv_FilterRolling_AudioLib>();
        // Get and set a parameter
        float amp1 = script.GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp1);
        script.SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter.Amp1, amp1 + 0.1f);
    }
  */
  public enum Parameter : uint {
    Amp1 = 0x71B966D1,
    Amp10 = 0x3079D606,
    Amp2 = 0x4079D6F0,
    Amp3 = 0xA49ABE9A,
    Amp4 = 0xD96B1088,
    Amp5 = 0x86286C0A,
    Amp6 = 0xA7087895,
    Amp7 = 0x2A358EC9,
    Amp8 = 0xA01AA5DF,
    Amp9 = 0x219B6511,
    Freq1 = 0x2394264B,
    Freq10 = 0x6924F41F,
    Freq2 = 0x24A00017,
    Freq3 = 0x67EFE3A8,
    Freq4 = 0x70A55D29,
    Freq5 = 0xBF502796,
    Freq6 = 0x943D5DB2,
    Freq7 = 0x5D4BD0DE,
    Freq8 = 0x2E2FAE9F,
    Freq9 = 0x2979685B,
    Impactforce = 0xE7966DE8,
    Object_roughness = 0x7090EA67,
    Qfactor = 0x2DA3B4FC,
    Size = 0x4AD2D14C,
    Time_roll = 0x1160F12,
    Time_scratch = 0xD624CA99,
    Velocity = 0x853B1BE7,
  }
  
  // Delegate method for receiving float messages from the patch context (thread-safe).
  // Example usage:
  /*
    void Start () {
        Hv_FilterRolling_AudioLib script = GetComponent<Hv_FilterRolling_AudioLib>();
        script.RegisterSendHook();
        script.FloatReceivedCallback += OnFloatMessage;
    }

    void OnFloatMessage(Hv_FilterRolling_AudioLib.FloatMessage message) {
        Debug.Log(message.receiverName + ": " + message.value);
    }
  */
  public class FloatMessage {
    public string receiverName;
    public float value;

    public FloatMessage(string name, float x) {
      receiverName = name;
      value = x;
    }
  }
  public delegate void FloatMessageReceived(FloatMessage message);
  public FloatMessageReceived FloatReceivedCallback;
  public float amp1 = 0.5f;
  public float amp10 = 0.5f;
  public float amp2 = 0.5f;
  public float amp3 = 0.5f;
  public float amp4 = 0.5f;
  public float amp5 = 0.5f;
  public float amp6 = 0.5f;
  public float amp7 = 0.5f;
  public float amp8 = 0.5f;
  public float amp9 = 0.5f;
  public float freq1 = 20.0f;
  public float freq10 = 20.0f;
  public float freq2 = 20.0f;
  public float freq3 = 20.0f;
  public float freq4 = 20.0f;
  public float freq5 = 20.0f;
  public float freq6 = 20.0f;
  public float freq7 = 20.0f;
  public float freq8 = 20.0f;
  public float freq9 = 20.0f;
  public float impactForce = 0.0f;
  public float object_roughness = 25.0f;
  public float qfactor = 250.0f;
  public float size = 1.0f;
  public float time_roll = 0.0f;
  public float time_scratch = 0.0f;
  public float velocity = 0.0f;

  // internal state
  private Hv_FilterRolling_Context _context;

  public bool IsInstantiated() {
    return (_context != null);
  }

  public void RegisterSendHook() {
    _context.RegisterSendHook();
  }
  
  // see Hv_FilterRolling_AudioLib.Event for definitions
  public void SendEvent(Hv_FilterRolling_AudioLib.Event e) {
    if (IsInstantiated()) _context.SendBangToReceiver((uint) e);
  }
  
  // see Hv_FilterRolling_AudioLib.Parameter for definitions
  public float GetFloatParameter(Hv_FilterRolling_AudioLib.Parameter param) {
    switch (param) {
      case Parameter.Amp1: return amp1;
      case Parameter.Amp10: return amp10;
      case Parameter.Amp2: return amp2;
      case Parameter.Amp3: return amp3;
      case Parameter.Amp4: return amp4;
      case Parameter.Amp5: return amp5;
      case Parameter.Amp6: return amp6;
      case Parameter.Amp7: return amp7;
      case Parameter.Amp8: return amp8;
      case Parameter.Amp9: return amp9;
      case Parameter.Freq1: return freq1;
      case Parameter.Freq10: return freq10;
      case Parameter.Freq2: return freq2;
      case Parameter.Freq3: return freq3;
      case Parameter.Freq4: return freq4;
      case Parameter.Freq5: return freq5;
      case Parameter.Freq6: return freq6;
      case Parameter.Freq7: return freq7;
      case Parameter.Freq8: return freq8;
      case Parameter.Freq9: return freq9;
      case Parameter.Impactforce: return impactForce;
      case Parameter.Object_roughness: return object_roughness;
      case Parameter.Qfactor: return qfactor;
      case Parameter.Size: return size;
      case Parameter.Time_roll: return time_roll;
      case Parameter.Time_scratch: return time_scratch;
      case Parameter.Velocity: return velocity;
      default: return 0.0f;
    }
  }

  public void SetFloatParameter(Hv_FilterRolling_AudioLib.Parameter param, float x) {
    switch (param) {
      case Parameter.Amp1: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        amp1 = x;
        break;
      }
      case Parameter.Amp10: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        amp10 = x;
        break;
      }
      case Parameter.Amp2: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        amp2 = x;
        break;
      }
      case Parameter.Amp3: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        amp3 = x;
        break;
      }
      case Parameter.Amp4: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        amp4 = x;
        break;
      }
      case Parameter.Amp5: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        amp5 = x;
        break;
      }
      case Parameter.Amp6: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        amp6 = x;
        break;
      }
      case Parameter.Amp7: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        amp7 = x;
        break;
      }
      case Parameter.Amp8: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        amp8 = x;
        break;
      }
      case Parameter.Amp9: {
        x = Mathf.Clamp(x, 0.0f, 1.0f);
        amp9 = x;
        break;
      }
      case Parameter.Freq1: {
        x = Mathf.Clamp(x, 20.0f, 20000.0f);
        freq1 = x;
        break;
      }
      case Parameter.Freq10: {
        x = Mathf.Clamp(x, 20.0f, 20000.0f);
        freq10 = x;
        break;
      }
      case Parameter.Freq2: {
        x = Mathf.Clamp(x, 20.0f, 20000.0f);
        freq2 = x;
        break;
      }
      case Parameter.Freq3: {
        x = Mathf.Clamp(x, 20.0f, 20000.0f);
        freq3 = x;
        break;
      }
      case Parameter.Freq4: {
        x = Mathf.Clamp(x, 20.0f, 20000.0f);
        freq4 = x;
        break;
      }
      case Parameter.Freq5: {
        x = Mathf.Clamp(x, 20.0f, 20000.0f);
        freq5 = x;
        break;
      }
      case Parameter.Freq6: {
        x = Mathf.Clamp(x, 20.0f, 20000.0f);
        freq6 = x;
        break;
      }
      case Parameter.Freq7: {
        x = Mathf.Clamp(x, 20.0f, 20000.0f);
        freq7 = x;
        break;
      }
      case Parameter.Freq8: {
        x = Mathf.Clamp(x, 20.0f, 20000.0f);
        freq8 = x;
        break;
      }
      case Parameter.Freq9: {
        x = Mathf.Clamp(x, 20.0f, 20000.0f);
        freq9 = x;
        break;
      }
      case Parameter.Impactforce: {
        x = Mathf.Clamp(x, 0.0f, 10.0f);
        impactForce = x;
        break;
      }
      case Parameter.Object_roughness: {
        x = Mathf.Clamp(x, 0.0f, 50.0f);
        object_roughness = x;
        break;
      }
      case Parameter.Qfactor: {
        x = Mathf.Clamp(x, 20.0f, 5000.0f);
        qfactor = x;
        break;
      }
      case Parameter.Size: {
        x = Mathf.Clamp(x, 0.1f, 2.0f);
        size = x;
        break;
      }
      case Parameter.Time_roll: {
        x = Mathf.Clamp(x, 0.0f, 1000.0f);
        time_roll = x;
        break;
      }
      case Parameter.Time_scratch: {
        x = Mathf.Clamp(x, 0.0f, 1000.0f);
        time_scratch = x;
        break;
      }
      case Parameter.Velocity: {
        x = Mathf.Clamp(x, 0.0f, 10.0f);
        velocity = x;
        break;
      }
      default: return;
    }
    if (IsInstantiated()) _context.SendFloatToReceiver((uint) param, x);
  }
  
  public void FillTableWithMonoAudioClip(string tableName, AudioClip clip) {
    if (clip.channels > 1) {
      Debug.LogWarning("Hv_FilterRolling_AudioLib: Only loading first channel of '" +
          clip.name + "' into table '" +
          tableName + "'. Multi-channel files are not supported.");
    }
    float[] buffer = new float[clip.samples]; // copy only the 1st channel
    clip.GetData(buffer, 0);
    _context.FillTableWithFloatBuffer(tableName, buffer);
  }

  public void FillTableWithFloatBuffer(string tableName, float[] buffer) {
    _context.FillTableWithFloatBuffer(tableName, buffer);
  }

  private void Awake() {
    _context = new Hv_FilterRolling_Context((double) AudioSettings.outputSampleRate);
  }
  
  private void Start() {
    _context.SendFloatToReceiver((uint) Parameter.Amp1, amp1);
    _context.SendFloatToReceiver((uint) Parameter.Amp10, amp10);
    _context.SendFloatToReceiver((uint) Parameter.Amp2, amp2);
    _context.SendFloatToReceiver((uint) Parameter.Amp3, amp3);
    _context.SendFloatToReceiver((uint) Parameter.Amp4, amp4);
    _context.SendFloatToReceiver((uint) Parameter.Amp5, amp5);
    _context.SendFloatToReceiver((uint) Parameter.Amp6, amp6);
    _context.SendFloatToReceiver((uint) Parameter.Amp7, amp7);
    _context.SendFloatToReceiver((uint) Parameter.Amp8, amp8);
    _context.SendFloatToReceiver((uint) Parameter.Amp9, amp9);
    _context.SendFloatToReceiver((uint) Parameter.Freq1, freq1);
    _context.SendFloatToReceiver((uint) Parameter.Freq10, freq10);
    _context.SendFloatToReceiver((uint) Parameter.Freq2, freq2);
    _context.SendFloatToReceiver((uint) Parameter.Freq3, freq3);
    _context.SendFloatToReceiver((uint) Parameter.Freq4, freq4);
    _context.SendFloatToReceiver((uint) Parameter.Freq5, freq5);
    _context.SendFloatToReceiver((uint) Parameter.Freq6, freq6);
    _context.SendFloatToReceiver((uint) Parameter.Freq7, freq7);
    _context.SendFloatToReceiver((uint) Parameter.Freq8, freq8);
    _context.SendFloatToReceiver((uint) Parameter.Freq9, freq9);
    _context.SendFloatToReceiver((uint) Parameter.Impactforce, impactForce);
    _context.SendFloatToReceiver((uint) Parameter.Object_roughness, object_roughness);
    _context.SendFloatToReceiver((uint) Parameter.Qfactor, qfactor);
    _context.SendFloatToReceiver((uint) Parameter.Size, size);
    _context.SendFloatToReceiver((uint) Parameter.Time_roll, time_roll);
    _context.SendFloatToReceiver((uint) Parameter.Time_scratch, time_scratch);
    _context.SendFloatToReceiver((uint) Parameter.Velocity, velocity);
  }
  
  private void Update() {
    // retreive sent messages
    if (_context.IsSendHookRegistered()) {
      Hv_FilterRolling_AudioLib.FloatMessage tempMessage;
      while ((tempMessage = _context.msgQueue.GetNextMessage()) != null) {
        FloatReceivedCallback(tempMessage);
      }
    }
  }

  private void OnAudioFilterRead(float[] buffer, int numChannels) {
    Assert.AreEqual(numChannels, _context.GetNumOutputChannels()); // invalid channel configuration
    _context.Process(buffer, buffer.Length / numChannels); // process dsp
  }
}

class Hv_FilterRolling_Context {

#if UNITY_IOS && !UNITY_EDITOR
  private const string _dllName = "__Internal";
#else
  private const string _dllName = "Hv_FilterRolling_AudioLib";
#endif

  // Thread-safe message queue
  public class SendMessageQueue {
    private readonly object _msgQueueSync = new object();
    private readonly Queue<Hv_FilterRolling_AudioLib.FloatMessage> _msgQueue = new Queue<Hv_FilterRolling_AudioLib.FloatMessage>();

    public Hv_FilterRolling_AudioLib.FloatMessage GetNextMessage() {
      lock (_msgQueueSync) {
        return (_msgQueue.Count != 0) ? _msgQueue.Dequeue() : null;
      }
    }

    public void AddMessage(string receiverName, float value) {
      Hv_FilterRolling_AudioLib.FloatMessage msg = new Hv_FilterRolling_AudioLib.FloatMessage(receiverName, value);
      lock (_msgQueueSync) {
        _msgQueue.Enqueue(msg);
      }
    }
  }

  public readonly SendMessageQueue msgQueue = new SendMessageQueue();
  private readonly GCHandle gch;
  private readonly IntPtr _context; // handle into unmanaged memory
  private SendHook _sendHook = null;

  [DllImport (_dllName)]
  private static extern IntPtr hv_FilterRolling_new_with_options(double sampleRate, int poolKb, int inQueueKb, int outQueueKb);

  [DllImport (_dllName)]
  private static extern int hv_processInlineInterleaved(IntPtr ctx,
      [In] float[] inBuffer, [Out] float[] outBuffer, int numSamples);

  [DllImport (_dllName)]
  private static extern void hv_delete(IntPtr ctx);

  [DllImport (_dllName)]
  private static extern double hv_getSampleRate(IntPtr ctx);

  [DllImport (_dllName)]
  private static extern int hv_getNumInputChannels(IntPtr ctx);

  [DllImport (_dllName)]
  private static extern int hv_getNumOutputChannels(IntPtr ctx);

  [DllImport (_dllName)]
  private static extern void hv_setSendHook(IntPtr ctx, SendHook sendHook);

  [DllImport (_dllName)]
  private static extern void hv_setPrintHook(IntPtr ctx, PrintHook printHook);

  [DllImport (_dllName)]
  private static extern int hv_setUserData(IntPtr ctx, IntPtr userData);

  [DllImport (_dllName)]
  private static extern IntPtr hv_getUserData(IntPtr ctx);

  [DllImport (_dllName)]
  private static extern void hv_sendBangToReceiver(IntPtr ctx, uint receiverHash);

  [DllImport (_dllName)]
  private static extern void hv_sendFloatToReceiver(IntPtr ctx, uint receiverHash, float x);

  [DllImport (_dllName)]
  private static extern uint hv_msg_getTimestamp(IntPtr message);

  [DllImport (_dllName)]
  private static extern bool hv_msg_hasFormat(IntPtr message, string format);

  [DllImport (_dllName)]
  private static extern float hv_msg_getFloat(IntPtr message, int index);

  [DllImport (_dllName)]
  private static extern bool hv_table_setLength(IntPtr ctx, uint tableHash, uint newSampleLength);

  [DllImport (_dllName)]
  private static extern IntPtr hv_table_getBuffer(IntPtr ctx, uint tableHash);

  [DllImport (_dllName)]
  private static extern float hv_samplesToMilliseconds(IntPtr ctx, uint numSamples);

  [DllImport (_dllName)]
  private static extern uint hv_stringToHash(string s);

  private delegate void PrintHook(IntPtr context, string printName, string str, IntPtr message);

  private delegate void SendHook(IntPtr context, string sendName, uint sendHash, IntPtr message);

  public Hv_FilterRolling_Context(double sampleRate, int poolKb=10, int inQueueKb=2, int outQueueKb=2) {
    gch = GCHandle.Alloc(msgQueue);
    _context = hv_FilterRolling_new_with_options(sampleRate, poolKb, inQueueKb, outQueueKb);
    hv_setPrintHook(_context, new PrintHook(OnPrint));
    hv_setUserData(_context, GCHandle.ToIntPtr(gch));
  }

  ~Hv_FilterRolling_Context() {
    hv_delete(_context);
    GC.KeepAlive(_context);
    GC.KeepAlive(_sendHook);
    gch.Free();
  }

  public void RegisterSendHook() {
    // Note: send hook functionality only applies to messages containing a single float value
    if (_sendHook == null) {
      _sendHook = new SendHook(OnMessageSent);
      hv_setSendHook(_context, _sendHook);
    }
  }

  public bool IsSendHookRegistered() {
    return (_sendHook != null);
  }

  public double GetSampleRate() {
    return hv_getSampleRate(_context);
  }

  public int GetNumInputChannels() {
    return hv_getNumInputChannels(_context);
  }

  public int GetNumOutputChannels() {
    return hv_getNumOutputChannels(_context);
  }

  public void SendBangToReceiver(uint receiverHash) {
    hv_sendBangToReceiver(_context, receiverHash);
  }

  public void SendFloatToReceiver(uint receiverHash, float x) {
    hv_sendFloatToReceiver(_context, receiverHash, x);
  }

  public void FillTableWithFloatBuffer(string tableName, float[] buffer) {
    uint tableHash = hv_stringToHash(tableName);
    if (hv_table_getBuffer(_context, tableHash) != IntPtr.Zero) {
      hv_table_setLength(_context, tableHash, (uint) buffer.Length);
      Marshal.Copy(buffer, 0, hv_table_getBuffer(_context, tableHash), buffer.Length);
    } else {
      Debug.Log(string.Format("Table '{0}' doesn't exist in the patch context.", tableName));
    }
  }

  public uint StringToHash(string s) {
    return hv_stringToHash(s);
  }

  public int Process(float[] buffer, int numFrames) {
    return hv_processInlineInterleaved(_context, buffer, buffer, numFrames);
  }

  [MonoPInvokeCallback(typeof(PrintHook))]
  private static void OnPrint(IntPtr context, string printName, string str, IntPtr message) {
    float timeInSecs = hv_samplesToMilliseconds(context, hv_msg_getTimestamp(message)) / 1000.0f;
    Debug.Log(string.Format("{0} [{1:0.000}]: {2}", printName, timeInSecs, str));
  }

  [MonoPInvokeCallback(typeof(SendHook))]
  private static void OnMessageSent(IntPtr context, string sendName, uint sendHash, IntPtr message) {
    if (hv_msg_hasFormat(message, "f")) {
      SendMessageQueue msgQueue = (SendMessageQueue) GCHandle.FromIntPtr(hv_getUserData(context)).Target;
      msgQueue.AddMessage(sendName, hv_msg_getFloat(message, 0));
    }
  }
}
