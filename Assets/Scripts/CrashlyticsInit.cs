using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;

public class CrashlyticsInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) => {
    		// AppLovin SDK is initialized, start loading ads
    		//MaxSdk.ShowMediationDebugger();
		};

			MaxSdk.SetSdkKey("LGJb2N_O2AUMyUaLEkHNXDBedPER7neqaC1USC_8Tm5xA18NhqndDzR-teUIVZkQ04uhku4oq91_a2X4WIAPaq");
			MaxSdk.InitializeSdk();

        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                // Crashlytics will use the DefaultInstance, as well;
                // this ensures that Crashlytics is initialized.
                Firebase.FirebaseApp app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here for indicating that your project is ready to use Firebase.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
