using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using UnityEngine;

public class AndroidNotificationHandler : MonoBehaviour
{
    private const string ChannelId = "notification_channel";


#if UNITY_ANDROID
    public void ScheduleNotification(DateTime dateTime)
    {
        // create channel setting
        AndroidNotificationChannel notificationChannel =
            new AndroidNotificationChannel {
                Id = ChannelId,
                Name = "Notification Channel",
                Description = "Some random description",
                Importance = Importance.Default
            };

        // register channel setting
        AndroidNotificationCenter.RegisterNotificationChannel (
            notificationChannel
        );

        // create notification
        AndroidNotification notification =
            new AndroidNotification {
                Title = "Energy Recharged!",
                Text = "Your energy has recharged, come back to play again!",
                SmallIcon = "default",
                LargeIcon = "default",
                FireTime = dateTime
            };

        AndroidNotificationCenter.SendNotification (notification, ChannelId);
    }
#endif
}
