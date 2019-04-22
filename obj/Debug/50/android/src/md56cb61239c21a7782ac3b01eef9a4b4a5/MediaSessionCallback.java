package md56cb61239c21a7782ac3b01eef9a4b4a5;


public class MediaSessionCallback
	extends android.media.session.MediaSession.Callback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPlay:()V:GetOnPlayHandler\n" +
			"n_onSkipToQueueItem:(J)V:GetOnSkipToQueueItem_JHandler\n" +
			"n_onSeekTo:(J)V:GetOnSeekTo_JHandler\n" +
			"n_onPlayFromMediaId:(Ljava/lang/String;Landroid/os/Bundle;)V:GetOnPlayFromMediaId_Ljava_lang_String_Landroid_os_Bundle_Handler\n" +
			"n_onPause:()V:GetOnPauseHandler\n" +
			"n_onStop:()V:GetOnStopHandler\n" +
			"n_onSkipToNext:()V:GetOnSkipToNextHandler\n" +
			"n_onSkipToPrevious:()V:GetOnSkipToPreviousHandler\n" +
			"n_onCustomAction:(Ljava/lang/String;Landroid/os/Bundle;)V:GetOnCustomAction_Ljava_lang_String_Landroid_os_Bundle_Handler\n" +
			"n_onPlayFromSearch:(Ljava/lang/String;Landroid/os/Bundle;)V:GetOnPlayFromSearch_Ljava_lang_String_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("MyPodCast.MediaSessionCallback, MyPodCast", MediaSessionCallback.class, __md_methods);
	}


	public MediaSessionCallback ()
	{
		super ();
		if (getClass () == MediaSessionCallback.class)
			mono.android.TypeManager.Activate ("MyPodCast.MediaSessionCallback, MyPodCast", "", this, new java.lang.Object[] {  });
	}


	public void onPlay ()
	{
		n_onPlay ();
	}

	private native void n_onPlay ();


	public void onSkipToQueueItem (long p0)
	{
		n_onSkipToQueueItem (p0);
	}

	private native void n_onSkipToQueueItem (long p0);


	public void onSeekTo (long p0)
	{
		n_onSeekTo (p0);
	}

	private native void n_onSeekTo (long p0);


	public void onPlayFromMediaId (java.lang.String p0, android.os.Bundle p1)
	{
		n_onPlayFromMediaId (p0, p1);
	}

	private native void n_onPlayFromMediaId (java.lang.String p0, android.os.Bundle p1);


	public void onPause ()
	{
		n_onPause ();
	}

	private native void n_onPause ();


	public void onStop ()
	{
		n_onStop ();
	}

	private native void n_onStop ();


	public void onSkipToNext ()
	{
		n_onSkipToNext ();
	}

	private native void n_onSkipToNext ();


	public void onSkipToPrevious ()
	{
		n_onSkipToPrevious ();
	}

	private native void n_onSkipToPrevious ();


	public void onCustomAction (java.lang.String p0, android.os.Bundle p1)
	{
		n_onCustomAction (p0, p1);
	}

	private native void n_onCustomAction (java.lang.String p0, android.os.Bundle p1);


	public void onPlayFromSearch (java.lang.String p0, android.os.Bundle p1)
	{
		n_onPlayFromSearch (p0, p1);
	}

	private native void n_onPlayFromSearch (java.lang.String p0, android.os.Bundle p1);

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
