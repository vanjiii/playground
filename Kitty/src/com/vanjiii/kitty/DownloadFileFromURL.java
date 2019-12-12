package com.vanjiii.kitty;

import java.io.BufferedInputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.URL;
import java.net.URLConnection;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.os.AsyncTask;
import android.os.Environment;
import android.util.Log;

/**
 * Background Async Task to download file
 * */
public class DownloadFileFromURL extends AsyncTask<String, String, String> {
	 // Progress Dialog
    private ProgressDialog pDialog;
     // Progress dialog type (0 - for Horizontal progress bar)
     public static final int progress_bar_type = 0;
     private Activity mainActivity = null;
     private Context mainContext = null;
     
     final private File SDCardRoot = Environment.getExternalStorageDirectory();

     public DownloadFileFromURL(Activity a,Context c){
      this.mainActivity = a;
      this.mainContext = c;
      pDialog = new ProgressDialog(mainContext);
     }
     protected void onPreExecute() {
      super.onPreExecute();
      pDialog.setMessage("Downloading file. Please wait...");
      pDialog.setIndeterminate(false);
      pDialog.setMax(100);
      pDialog.setProgressStyle(ProgressDialog.STYLE_HORIZONTAL);
      pDialog.setCancelable(false);
      pDialog.show();
     }
     @Override
     protected String doInBackground(String... params) {
            int count;
            try {
             URL url = new URL(params[0]);
             URLConnection conection = url.openConnection();
             conection.connect();
             // this will be useful so that you can show a typical 0-100%
             int lenghtOfFile = conection.getContentLength();
             // download the file
             InputStream input = new BufferedInputStream(url.openStream(),8192);
             /* Output stream
              * 
              */
             OutputStream output = new FileOutputStream(new File(SDCardRoot, "kitty.gif"));
             byte data[] = new byte[1024];
             long total = 0;
             while ((count = input.read(data)) != -1) {
                    total += count;
                    // publishing the progress....
                    // After this onProgressUpdate will be called
                    publishProgress("" + (int) ((total * 100) / lenghtOfFile));
                    // writing data to file
                   output.write(data, 0, count);
             }
             output.flush();
             output.close();
             input.close();
            } catch (Exception e) {
             Log.w("Your_Tag","Download Error", e);
            }
      return null;
     }
     /**
      * Updating progress bar
      * */
     protected void onProgressUpdate(String... progress) {
      // setting progress percentage
      this.pDialog.setProgress(Integer.parseInt(progress[0]));
     }
     /**
      * After completing background task Dismiss the progress dialog
      * **/
     @SuppressWarnings("deprecation")
     @Override
     protected void onPostExecute(String file_url) {
            // dismiss the dialog after the file was downloaded
            pDialog.dismiss();
            AlertDialog alertDialog = new AlertDialog.Builder(mainActivity).create();
            // Setting Dialog Title
            alertDialog.setTitle("Dev Labs");
            // Setting Dialog Message
            alertDialog.setMessage("Download Complete");
            // Setting OK Button
            alertDialog.setButton("OK", new DialogInterface.OnClickListener() {
             public void onClick(final DialogInterface dialog,
               final int which) {
             }
            });
            // Showing Alert Message
            alertDialog.show();
     }
}