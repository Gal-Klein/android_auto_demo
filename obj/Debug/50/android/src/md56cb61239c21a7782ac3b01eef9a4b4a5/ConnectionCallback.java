package md56cb61239c21a7782ac3b01eef9a4b4a5;


public class ConnectionCallback
	extends android.media.browse.MediaBrowser.ConnectionCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onConnected:()V:GetOnConnectedHandler\n" +
			"n_onConnectionFailed:()V:GetOnConnectionFailedHandler\n" +
			"n_onConnectionSuspended:()V:GetOnConnectionSuspendedHandler\n" +
			"";
		mono.android.Runtime.register ("MyPodCast.ConnectionCallback, MyPodCast", ConnectionCallback.class, __md_methods);
	}


	public ConnectionCallback ()
	{
		super ();
		if (getClass () == ConnectionCallback.class)
			mono.android.TypeManager.Activate ("MyPodCast.ConnectionCallback, MyPodCast", "", this, new java.lang.Object[] {  });
	}


	public void onConnected ()
	{
		n_onConnected ();
	}

	private native void n_onConnected ();


	public void onConnectionFailed ()
	{
		n_onConnectionFailed ();
	}

	private native void n_onConnectionFailed ();


	public void onConnectionSuspended ()
	{
		n_onConnectionSuspended ();
	}

	private native void n_onConnectionSuspended ();

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
