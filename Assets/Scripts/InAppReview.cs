using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Play.Review;

public class InAppReview : MonoBehaviour
{

    private ReviewManager _reviewManager;
    private PlayReviewInfo _playReviewInfo;
    int launchCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        launchCount = PlayerPrefs.GetInt("lauchTime", 0);
        launchCount = launchCount + 1;
        PlayerPrefs.SetInt("lauchTime", launchCount);

        if (launchCount == 3 || launchCount == 8 || launchCount == 13)
        {
            StartCoroutine(RequestReview());
        }

    }

    IEnumerator RequestReview()
    {
        _reviewManager = new ReviewManager();

        //Pedir el objeto de ReviewInfo

        var requestFlowOperation = _reviewManager.RequestReviewFlow();
        yield return requestFlowOperation;
        if (requestFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }
        _playReviewInfo = requestFlowOperation.GetResult();

        //Lanzar la poup de Review

        var launchFlowOperation = _reviewManager.LaunchReviewFlow(_playReviewInfo);
        yield return launchFlowOperation;
        _playReviewInfo = null; // Reset the object
        if (launchFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }
        // The flow has finished. The API does not indicate whether the user
        // reviewed or not, or even whether the review dialog was shown. Thus, no
        // matter the result, we continue our app flow.


    }
}
