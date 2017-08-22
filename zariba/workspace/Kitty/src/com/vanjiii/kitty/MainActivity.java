package com.vanjiii.kitty;

import java.io.File;
import java.util.ArrayList;
import java.util.Random;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.Response.Listener;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.ImageRequest;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;

public class MainActivity extends Activity {

	final String testURL = "http://tu-knt.herokuapp.com/android";
	final Random randomGenerator = new Random();
	final String tumblrURL = "http://api.tumblr.com/v2/blog/iheartcatgifs.tumblr.com/posts?api_key=NCoxBTzSzaf62VmPknRLosrMxcev6dV6KfOGP1l4i2s8AO5gLK";
	final String myEmail = "ivan.dimitrov90@gmail.com";
	final private File SDCardRoot = Environment.getExternalStorageDirectory();
	
	int numberPost = Integer.MIN_VALUE;
	ArrayList<TumblrPhoto> arrayGIF;
	
	TextView txtView;
	Button btnRequest;
	Button btnSend;
	Button btnSave;
	Context context;
	ImageView imageGIF;
	RequestQueue queue;
		
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		txtView = (TextView)findViewById(R.id.txtDisplay);
		final Activity activity = this;
		context = this;
		btnRequest = (Button)findViewById(R.id.getRequestBtn);
		btnSave = (Button)findViewById(R.id.saveButton);
		btnSend = (Button)findViewById(R.id.sendButton);
		imageGIF = (ImageView)findViewById(R.id.imageGIFView);
		btnRequest.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				numberPost = GetRandomPost();
				DisplayImage(numberPost);
				
			}
		});
		
		btnSave.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				DownloadFileFromURL DF = new DownloadFileFromURL(activity, context);
				DF.execute(arrayGIF.get(numberPost).getUrl());
				
			}
		});
		
		btnSend.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				SendEmail(SDCardRoot);
				
			}
		});
		
		queue = Volley.newRequestQueue(this);
		
		JsonObjectRequest getRequest = new JsonObjectRequest
				(Request.Method.GET, tumblrURL, null, new Response.Listener<JSONObject>() {

					@SuppressWarnings("rawtypes")
					@Override
					public void onResponse(JSONObject response) {
						int currWidth = Integer.MIN_VALUE;
						int currHeight = Integer.MIN_VALUE;
						
						try {
							//txtView.setText("Response => " + response.getJSONObject("response").getInt("total_posts"));
							
							TumblrPhoto.msg = response.getJSONObject("meta").getString("msg");
							TumblrPhoto.status = response.getJSONObject("meta").getInt("status");
							TumblrPhoto.totalPosts = response.getJSONObject("response").getInt("total_posts");
							
							
							JSONArray postArr = response.getJSONObject("response").getJSONArray("posts");
								
							arrayGIF = new ArrayList<TumblrPhoto>();
							
							for (int idx = 0; idx < postArr.length(); idx++) {
								JSONObject currentJSON = postArr.getJSONObject(idx);
								String cpt = currentJSON.getString("caption");
								currWidth = currentJSON.getJSONArray("photos").getJSONObject(0).getJSONObject("original_size").getInt("width");
								currHeight = currentJSON.getJSONArray("photos").getJSONObject(0).getJSONObject("original_size").getInt("height");
								String someURL = currentJSON.getJSONArray("photos").getJSONObject(0).getJSONObject("original_size").getString("url");
								//Toast.makeText(context, someURL, Toast.LENGTH_LONG).show();
								
								arrayGIF.add(new TumblrPhoto(cpt, currWidth, currHeight, someURL));
							}
							
							
						} catch (JSONException e) {
							// TODO Auto-generated catch block
							e.printStackTrace();
						}
						
					}
				
				}, new Response.ErrorListener() {

					@Override
					public void onErrorResponse(VolleyError error) {
						Toast.makeText(context, error.toString(), Toast.LENGTH_LONG).show();
						
					}
				});
		
		queue.add(getRequest);

					//TODO: resize image

	}

	protected void SendEmail(File file) {

		File F = new File(file, "kitty.gif");
		F.setReadable(true, false);                     // This allows external program access
		Uri U = Uri.fromFile(F);
		
		Intent sendIntent = new Intent(Intent.ACTION_SEND);
		sendIntent.setType("image/gif");							//png
		sendIntent.putExtra(Intent.EXTRA_SUBJECT, "GIF From DevLabs");
		sendIntent.putExtra(Intent.EXTRA_TEXT,  "Вие получихте тази котка с любезното съдействие на Dev Labs");
//		sendIntent.putExtra(Intent.EXTRA_EMAIL, emailFrom);
		sendIntent.putExtra(Intent.EXTRA_STREAM, U);
		startActivity(Intent.createChooser(sendIntent,"Email:"));
		
	}
	
	protected void DisplayImage(int numberGIF) {
		
		ImageRequest request = new ImageRequest
				(arrayGIF.get(numberGIF).getUrl(), new Listener<Bitmap>() {

					@Override
					public void onResponse(Bitmap bitmap) {
						imageGIF.setImageBitmap(bitmap);
						
					}
					
				}, 0, 0, null, 
						new Response.ErrorListener() {

					@Override
					public void onErrorResponse(VolleyError arg0) {
						imageGIF.setImageResource(R.drawable.ic_launcher);
						
					}
				});
		
		queue.add(request);
		
	}

	protected int GetRandomPost(){
		int gifNumber = randomGenerator.nextInt(arrayGIF.size());
		
		txtView.setText(arrayGIF.get(gifNumber).getCaption());
		Toast.makeText(context, arrayGIF.get(gifNumber).getUrl(), Toast.LENGTH_LONG).show();
		
		return gifNumber;
	}
		
}
