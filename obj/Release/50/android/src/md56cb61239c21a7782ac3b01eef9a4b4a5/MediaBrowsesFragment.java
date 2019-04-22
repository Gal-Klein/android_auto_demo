package md56cb61239c21a7782ac3b01eef9a4b4a5;


public class MediaBrowsesFragment
	extends android.app.Fragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"n_onStart:()V:GetOnStartHandler\n" +
			"n_onStop:()V:GetOnStopHandler\n" +
			"";
		mono.android.Runtime.register ("MyPodCast.MediaBrowsesFragment, MyPodCast", MediaBrowsesFragment.class, __md_methods);
	}


	public MediaBrowsesFragment ()
	{
		super ();
		if (getClass () == MediaBrowsesFragment.class)
			mono.android.TypeManager.Activate ("MyPodCast.MediaBrowsesFragment, MyPodCast", "", this, new java.lang.Object[] {  });
	}

	public MediaBrowsesFragment (java.lang.String p0)
	{
		super ();
		if (getClass () == MediaBrowsesFragment.class)
			mono.android.TypeManager.Activate ("MyPodCast.MediaBrowsesFragment, MyPodCast", "System.String, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);


	public void onStart ()
	{
		n_onStart ();
	}

	private native void n_onStart ();


	public void onStop ()
	{
		n_onStop ();
	}

	private native void n_onStop ();

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
