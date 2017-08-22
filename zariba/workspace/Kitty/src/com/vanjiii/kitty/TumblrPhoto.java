package com.vanjiii.kitty;

import android.preference.PreferenceActivity.Header;

public class TumblrPhoto {
	
	/*
	 * Holds the 'original_size' stats of a post.
	 */
	
	public static String msg;
	public static int status;
	public static int totalPosts;
	
	private String mCaption;
	
	private int mWidth;
	private int mHeight;
	private String mURL;
	
	public TumblrPhoto(String caption, int width, int height, String url){
		this.mCaption = caption;
		this.mWidth = width;
		this.mHeight = height;
		this.mURL = url;
	}
	
	
	public int getWidth() {
		return mWidth;
	}
	public void setWidth(int width) {
		this.mWidth = width;
	}
	public int getHeight() {
		return mHeight;
	}
	public void setHeight(int height) {
		this.mHeight = height;
	}
	public String getUrl() {
		return mURL;
	}
	public void setUrl(String url) {
		this.mURL = url;
	}
	public String getCaption() {
		return mCaption;
	}
	public void setCaption(String caption) {
		this.mCaption = caption;
	}

}
