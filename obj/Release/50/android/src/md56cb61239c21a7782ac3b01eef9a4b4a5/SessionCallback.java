package md56cb61239c21a7782ac3b01eef9a4b4a5;


public class SessionCallback
	extends android.media.session.MediaController.Callback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSessionDestroyed:()V:GetOnSessionDestroyedHandler\n" +
			"n_onPlaybackStateChanged:(Landroid/media/session/PlaybackState;)V:GetOnPlaybackStateChanged_Landroid_media_session_PlaybackState_Handler\n" +
			"n_onQueueChanged:(Ljava/util/List;)V:GetOnQueueChanged_Ljava_util_List_Handler\n" +
			"";
		mono.android.Runtime.register ("MyPodCast.SessionCallback, MyPodCast", SessionCallback.class, __md_methods);
	}


	public SessionCallback ()
	{
		super ();
		if (getClass () == SessionCallback.class)
			mono.android.TypeManager.Activate ("MyPodCast.SessionCallback, MyPodCast", "", this, new java.lang.Object[] {  });
	}


	public void onSessionDestroyed ()
	{
		n_onSessionDestroyed ();
	}

	private native void n_onSessionDestroyed ();


	public void onPlaybackStateChanged (android.media.session.PlaybackState p0)
	{
		n_onPlaybackStateChanged (p0);
	}

	private native void n_onPlaybackStateChanged (android.media.session.PlaybackState p0);


	public void onQueueChanged (java.util.List p0)
	{
		n_onQueueChanged (p0);
	}

	private native void n_onQueueChanged (java.util.List p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
