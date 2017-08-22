#include "AppDelegate.h"
#include "MainMenu.h"
#include "AppMacros.h"
#include <vector>
#include <string>

USING_NS_CC;

#define COCOS2D_DEBUG 1


AppDelegate::AppDelegate() {

}

AppDelegate::~AppDelegate() {

}

bool AppDelegate::applicationDidFinishLaunching() {
    // initialize director
    auto director = Director::getInstance();
    auto glview = director->getOpenGLView();
    if(!glview) {
        glview = GLView::create("My Game");
        director->setOpenGLView(glview);
    }

    CCDirector* pDirector = CCDirector::sharedDirector();
    //CCEGLView* pEGLView = CCEGLView::sharedOpenGLView();

    //pDirector->setOpenGLView(pEGLView);


    // Set the design resolution
    glview->setDesignResolutionSize(designResolutionSize.width, designResolutionSize.height, kResolutionNoBorder);

    CCSize frameSize = glview->getFrameSize();
    std::vector<std::string> searchPath;

    // In this demo, we select resource according to the frame's height.
    // If the resource size is different from design resolution size, you need to set contentScaleFactor.
    // We use the ratio of resource's height to the height of design resolution,
    // this can make sure that the resource's height could fit for the height of design resolution.

    // if the frame's height is larger than the height of small resource size, select medium resource.
    if (frameSize.height > extraLargeResource.size.height){ 
        searchPath.push_back(superLargeResource.directory);
        pDirector->setContentScaleFactor(superLargeResource.size.height/designResolutionSize.height);
    }else if((frameSize.height < extraLargeResource.size.height) && (frameSize.height >= largeResource.size.height)){
        searchPath.push_back(extraLargeResource.directory);
        pDirector->setContentScaleFactor(extraLargeResource.size.height/designResolutionSize.height);
    }else if((frameSize.height < largeResource.size.height) && (frameSize.height >= mediumResource.size.height)){
        searchPath.push_back(largeResource.directory);
        pDirector->setContentScaleFactor(largeResource.size.height/designResolutionSize.height);
    }else if((frameSize.height < mediumResource.size.height) && (frameSize.height >= smallResource.size.height)){
        searchPath.push_back(mediumResource.directory);
        pDirector->setContentScaleFactor(mediumResource.size.height/designResolutionSize.height);
    }else if((frameSize.height < smallResource.size.height) && (frameSize.height >= extraSmallResource.size.height)){
        searchPath.push_back(smallResource.directory);
        pDirector->setContentScaleFactor(smallResource.size.height/designResolutionSize.height);
    }

    // if the frame's height is smaller than the height of medium resource size, select small resource.
    else{ 
        searchPath.push_back(extraSmallResource.directory);
        pDirector->setContentScaleFactor(extraSmallResource.size.height/designResolutionSize.height);
    }

    CCFileUtils::sharedFileUtils()->setSearchPaths(searchPath);

    // turn on display FPS
    director->setDisplayStats(true);

    // set FPS. the default value is 1.0/60 if you don't call this
    director->setAnimationInterval(1.0 / 60);

    // create a scene. it's an autorelease object
    auto scene = MainMenu::createScene();
       


    // run
    director->runWithScene(scene);
    return true;
}

// This function will be called when the app is inactive. When comes a phone call,it's be invoked too
void AppDelegate::applicationDidEnterBackground() {
    Director::getInstance()->stopAnimation();

    // if you use SimpleAudioEngine, it must be pause
    // SimpleAudioEngine::getInstance()->pauseBackgroundMusic();
}

// this function will be called when the app is active again
void AppDelegate::applicationWillEnterForeground() {
    Director::getInstance()->startAnimation();

    // if you use SimpleAudioEngine, it must resume here
    // SimpleAudioEngine::getInstance()->resumeBackgroundMusic();
}
