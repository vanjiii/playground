#include "MainMenu.h"
#include "SliceTheFruits.h"
#include "Blender.h"

USING_NS_CC;

//@TODO
//add 3 more buttons
//make labels on the buttons

Scene* MainMenu::createScene()
{
    // 'scene' is an autorelease object
    auto scene = Scene::create();
    
    // 'layer' is an autorelease object
    auto layer = MainMenu::create();

    // add layer as a child to scene
    scene->addChild(layer);

    // return the scene
    return scene;
}

// on "init" you need to initialize your instance
bool MainMenu::init()
{
    //////////////////////////////
    // 1. super init first
    if ( !Layer::init() )
    {
        return false;
    }
    
    Size visibleSize = Director::getInstance()->getVisibleSize();
    Vec2 origin = Director::getInstance()->getVisibleOrigin();

    CCSize winSize = CCDirector::sharedDirector()->getWinSize();
    
    //background
    Sprite *backgroundImage = cocos2d::Sprite::create("SceneMainMenu/title_screen_final_bg.jpg");
    backgroundImage->setPosition(Point::ZERO);
    backgroundImage->setAnchorPoint(Vec2(0, 0));
    backgroundImage->setScaleX(winSize.width / backgroundImage->getContentSize().width);
    backgroundImage->setScaleY(winSize.height / backgroundImage->getContentSize().height);
    this->addChild(backgroundImage, 1);
    
    //logo image
    Sprite *logoImage = cocos2d::Sprite::create("SceneMainMenu/cn_logo.png");
    logoImage->setScaleX((winSize.width / logoImage->getContentSize().width) * 0.9); //reduce to 90 %
    logoImage->setPosition(Point(visibleSize.width / 2, (visibleSize.height / 8) * 6.5));
    this->addChild(logoImage, 2);
  

    //-----------------------buttons----------------------------------

    auto buttonPlay = MenuItemSprite::create(Sprite::create("SceneMainMenu/buton_2.png"),
                                    Sprite::create("SceneMainMenu/buton_2_blue.png"),
                                    CC_CALLBACK_1(MainMenu::GoToScene, this));

    buttonPlay->setPosition(Point(visibleSize.width * 0.25f, (visibleSize.height / 12) * 7));
    buttonPlay->setScaleX((winSize.width / buttonPlay->getContentSize().width) * 0.4f);
    buttonPlay->setScaleY((winSize.height / buttonPlay->getContentSize().height) * 0.1f);
    buttonPlay->setTag(1);


    auto menu = Menu::create(buttonPlay, NULL);
    menu->setPosition(0, 0);
    this->addChild(menu, 1);
    /*
    playButton = Sprite::create("SceneMainMenu/buton_1.png");
    playButton->setPosition(Point(visibleSize.width * 0.25f, (visibleSize.height / 12) * 7));
    playButton->setScaleX((winSize.width / playButton->getContentSize().width) * 0.4f);
    playButton->setScaleY((winSize.height / playButton->getContentSize().height) * 0.1f);
    playButtonLabel = CCLabelBMFont::create("Play",
            "fonts/Marker_Felt.ttf",
//            1.5,
//            kCCTextAlignmentCenter);
//    playButton->addChild(playButtonLabel);
    this->addChild(playButton, 2);
    
    storeButton = Sprite::create("SceneMainMenu/buton_1.png");
    storeButton->setPosition(Point(visibleSize.width * 0.25f, (visibleSize.height / 12) * 4.5));
    storeButton->setScaleX((winSize.width / storeButton->getContentSize().width) * 0.36f);
    storeButton->setScaleY((winSize.height / storeButton->getContentSize().height) * 0.085f);
    this->addChild(storeButton, 2);
    
    myShakesButton = Sprite::create("SceneMainMenu/buton_1.png");
    myShakesButton->setPosition(Point(visibleSize.width * 0.35f, (visibleSize.height / 12) * 3));
    myShakesButton->setScaleX((winSize.width / myShakesButton->getContentSize().width) * 0.4f);
    myShakesButton->setScaleY((winSize.height / myShakesButton->getContentSize().height) * 0.1f);
////    myShakesButtonLabel = CCLabelBMFont::create("My Shakes",
                "fonts/Marker_Felt.ttf", 
                1.5, 
                kCCTextAlignmentCenter);
//    playButton->addChild(myShakesButtonLabel);
    this->addChild(myShakesButton, 2);
    
    goalsButton = Sprite::create("SceneMainMenu/buton_1.png");
    goalsButton->setPosition(Point(visibleSize.width * 0.25f, (visibleSize.height / 12) * 1.5));
    goalsButton->setScaleX((winSize.width / goalsButton->getContentSize().width) * 0.36f);
    goalsButton->setScaleY((winSize.height / goalsButton->getContentSize().height) * 0.085f);
    this->addChild(goalsButton, 2);
     */
    //-----------------------buttons----------------------------------
    

    /*
    simple menu to go to different levels
     */
    

    return true;
}

void MainMenu::GoToScene(cocos2d::Ref *pSender)
{
    CCMenuItem* pMenuItem = (CCMenuItem *)(pSender);
    int tag = (int)pMenuItem->getTag();

    switch (tag)
    {
        case 1:
        {
            auto scene = SliceTheFruits::scene();
            Director::getInstance()->replaceScene(TransitionFade::create(1, scene));
        }break;
        /*
        case 2:
        {
            auto scene = MainMenu::createScene();
            Director::getInstance()->replaceScene(TransitionMoveInR::create(1, scene));   //0.5
        }break;
        
        case 3:
        {
            auto scene = Blender::scene();
            Director::getInstance()->replaceScene(TransitionFade::create(1, scene));
        }break;
        
         */
    }
}

void MainMenu::menuCloseCallback(Ref* pSender)
{
#if (CC_TARGET_PLATFORM == CC_PLATFORM_WP8) || (CC_TARGET_PLATFORM == CC_PLATFORM_WINRT)
	MessageBox("You pressed the close button. Windows Store Apps do not implement a close button.","Alert");
    return;
#endif

    Director::getInstance()->end();

#if (CC_TARGET_PLATFORM == CC_PLATFORM_IOS)
    exit(0);
#endif
}
