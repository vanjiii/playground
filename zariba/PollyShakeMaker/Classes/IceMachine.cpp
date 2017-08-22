#include "IceMachine.h"
#include "YogurtMachine.h"


USING_NS_CC;

Scene* IceMachine::createScene()
{
    // 'scene' is an autorelease object
    auto scene = Scene::create();
    
    // 'layer' is an autorelease object
    auto layer = IceMachine::create();

    // add layer as a child to scene
    scene->addChild(layer);

    // return the scene
    return scene;
}

// on "init" you need to initialize your instance
bool IceMachine::init()
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
    Sprite *backgroundImage = cocos2d::Sprite::create("Blender/backgrounds.jpg");
    backgroundImage->setPosition(Point::ZERO);
    backgroundImage->setAnchorPoint(Vec2(0, 0));
    backgroundImage->setScaleX(winSize.width / backgroundImage->getContentSize().width);
    backgroundImage->setScaleY(winSize.height / backgroundImage->getContentSize().height);
    this->addChild(backgroundImage, 1);
  

    //buttons
    auto backButton = MenuItemSprite::create(Sprite::create("SliceTheFruits/buton_1.png"),
                                    Sprite::create("SliceTheFruits/buton_1_blue.png"),
                                    CC_CALLBACK_1(IceMachine::GoToScene, this));
    backButton->setTag(1);
    backButton->setScale(0.7f);
    backButton->setPosition(Point((int)(visibleSize.width * 0.125), (int)(visibleSize.height * 0.08)));

    auto nextButton = MenuItemSprite::create(Sprite::create("SliceTheFruits/buton_1.png"),
                                    Sprite::create("SliceTheFruits/buton_1_blue.png"),
                                    CC_CALLBACK_1(IceMachine::GoToScene, this));
                                    
    nextButton->setTag(2);
    nextButton->setScale(0.7f);
    nextButton->setPosition(Point((int)(visibleSize.width * 0.875), (int)(visibleSize.height * 0.08)));


    //menu
    auto menu = Menu::create(backButton, nextButton, NULL);
    menu->setPosition(0, 0);
    this->addChild(menu, 4);
    return true;
}

void IceMachine::GoToScene(cocos2d::Ref* pSender){
    CCMenuItem* pMenuItem = (CCMenuItem *)(pSender);
    int tag = (int)pMenuItem->getTag();

    switch (tag)
    {
        case 1:
        {
            auto scene = YogurtMachine::createScene();
            Director::getInstance()->replaceScene(TransitionFade::create(1, scene));
        }break;

       
        //case 2:
        //{
        //    auto scene = IceMachine::createScene();
        //    Director::getInstance()->replaceScene(TransitionFade::create(1, scene));
        //}break;
        
    }
}

void IceMachine::menuCloseCallback(Ref* pSender)
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
