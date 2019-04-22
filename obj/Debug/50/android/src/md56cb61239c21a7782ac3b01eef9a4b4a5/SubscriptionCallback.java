package md56cb61239c21a7782ac3b01eef9a4b4a5;


public class SubscriptionCallback
	extends android.media.browse.MediaBrowser.SubscriptionCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onChildrenLoaded:(Ljava/lang/String;Ljava/util/List;)V:GetOnChildrenLoaded_Ljava_lang_String_Ljava_util_List_Handler\n" +
			"n_onError:(Ljava/lang/String;)V:GetOnError_Ljava_lang_String_Handler\n" +
			"";
		mono.android.Runtime.register ("MyPodCast.SubscriptionCallback, MyPodCast", SubscriptionCallback.class, __md_methods);
	}


	public SubscriptionCallback ()
	{
		super ();
		if (getClass () == SubscriptionCallback.class)
			mono.android.TypeManager.Activate ("MyPodCast.SubscriptionCallback, MyPodCast", "", this, new java.lang.Object[] {  });
	}


	public void onChildrenLoaded (java.lang.String p0, java.util.List p1)
	{
		n_onChildrenLoaded (p0, p1);
	}

	private native void n_onChildrenLoaded (java.lang.String p0, java.util.List p1);


	public void onError (java.lang.String p0)
	{
		n_onError (p0);
	}

	private native void n_onError (java.lang.String p0);

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
