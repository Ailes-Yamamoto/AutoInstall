package crc646f8cb4d70aa54740;


public class MainActivity_UpdatePB
	extends android.os.AsyncTask
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_doInBackground:([Ljava/lang/Object;)Ljava/lang/Object;:GetDoInBackground_arrayLjava_lang_Object_Handler\n" +
			"n_onProgressUpdate:([Ljava/lang/Object;)V:GetOnProgressUpdate_arrayLjava_lang_Object_Handler\n" +
			"n_onPostExecute:(Ljava/lang/Object;)V:GetOnPostExecute_Ljava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("AutoInstall.MainActivity+UpdatePB, AutoInstall", MainActivity_UpdatePB.class, __md_methods);
	}


	public MainActivity_UpdatePB ()
	{
		super ();
		if (getClass () == MainActivity_UpdatePB.class)
			mono.android.TypeManager.Activate ("AutoInstall.MainActivity+UpdatePB, AutoInstall", "", this, new java.lang.Object[] {  });
	}

	public MainActivity_UpdatePB (android.app.Activity p0, android.widget.ProgressBar p1, android.app.Dialog p2)
	{
		super ();
		if (getClass () == MainActivity_UpdatePB.class)
			mono.android.TypeManager.Activate ("AutoInstall.MainActivity+UpdatePB, AutoInstall", "Android.App.Activity, Mono.Android:Android.Widget.ProgressBar, Mono.Android:Android.App.Dialog, Mono.Android", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public java.lang.Object doInBackground (java.lang.Object[] p0)
	{
		return n_doInBackground (p0);
	}

	private native java.lang.Object n_doInBackground (java.lang.Object[] p0);


	public void onProgressUpdate (java.lang.Object[] p0)
	{
		n_onProgressUpdate (p0);
	}

	private native void n_onProgressUpdate (java.lang.Object[] p0);


	public void onPostExecute (java.lang.Object p0)
	{
		n_onPostExecute (p0);
	}

	private native void n_onPostExecute (java.lang.Object p0);

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
