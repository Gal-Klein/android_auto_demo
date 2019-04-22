package com.audioburst.playlist;


public class service
	extends android.service.media.MediaBrowserService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:()V:GetOnCreateHandler\n" +
			"n_onDestroy:()V:GetOnDestroyHandler\n" +
			"n_onGetRoot:(Ljava/lang/String;ILandroid/os/Bundle;)Landroid/service/media/MediaBrowserService$BrowserRoot;:GetOnGetRoot_Ljava_lang_String_ILandroid_os_Bundle_Handler\n" +
			"n_onLoadChildren:(Ljava/lang/String;Landroid/service/media/MediaBrowserService$Result;)V:GetOnLoadChildren_Ljava_lang_String_Landroid_service_media_MediaBrowserService_Result_Handler\n" +
			"";
		mono.android.Runtime.register ("MyPodCast.MusicService, MyPodCast", service.class, __md_methods);
	}


	public service ()
	{
		super ();
		if (getClass () == service.class)
			mono.android.TypeManager.Activate ("MyPodCast.MusicService, MyPodCast", "", this, new java.lang.Object[] {  });
	}


	public void onCreate ()
	{
		n_onCreate ();
	}

	private native void n_onCreate ();


	public void onDestroy ()
	{
		n_onDestroy ();
	}

	private native void n_onDestroy ();


	public android.service.media.MediaBrowserService.BrowserRoot onGetRoot (java.lang.String p0, int p1, android.os.Bundle p2)
	{
		return n_onGetRoot (p0, p1, p2);
	}

	private native android.service.media.MediaBrowserService.BrowserRoot n_onGetRoot (java.lang.String p0, int p1, android.os.Bundle p2);


	public void onLoadChildren (java.lang.String p0, android.service.media.MediaBrowserService.Result p1)
	{
		n_onLoadChildren (p0, p1);
	}

	private native void n_onLoadChildren (java.lang.String p0, android.service.media.MediaBrowserService.Result p1);

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
