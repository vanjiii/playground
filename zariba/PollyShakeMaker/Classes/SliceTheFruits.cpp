#include <stdlib.h>
#include <unistd.h>

#include "MainMenu.h"
#include "SliceTheFruits.h"
#include "Blender.h"
#include "Fruits/strawberry.h"
#include "Fruits/banana.h"
#include "Fruits/mango.h"
#include "Fruits/orange.h"
#include "Fruits/pineapple.h"


USING_NS_CC;

//@TODO
//fix the fall

#define PTM_RATIO 32
#define WINSIZE  CCDirector::sharedDirector()->getWinSize()

//TODO: to destructor

void SliceTheFruits::onExit(){
    setTouchEnabled(false);
    arrayOfFruits->removeAllObjects();
    this->unscheduleAllSelectors();
//    CCTextureCache.sharedTextureCache()->removeAllTextures();
    CCLayer::onExit();
}

Scene* SliceTheFruits::scene()
{
    // 'scene' is an autorelease object
    auto scene = Scene::create();
    
    // 'layer' is an autorelease object
    SliceTheFruits *layer = SliceTheFruits::create();

    // add layer as a child to scene
    scene->addChild(layer);

    // return the scene
    return scene;
}


// on "init" you need to initialize your instance
bool SliceTheFruits::init()
{
    //////////////////////////////
    // 1. super init first
    if ( !Layer::init() )
    {
        return false;
    }
    
    auto visibleSize = Director::getInstance()->getVisibleSize();
    auto origin = Director::getInstance()->getVisibleOrigin();
    
    // CCSize winSize = CCDirector::sharedDirector()->getWinSize();
    
    //background
    Sprite *backgroundImage = cocos2d::Sprite::create("SliceTheFruits/background.jpg");
    backgroundImage->setPosition(Point::ZERO);
    backgroundImage->setAnchorPoint(Vec2(0, 0));
    backgroundImage->setScaleX(WINSIZE.width / backgroundImage->getContentSize().width);
    backgroundImage->setScaleY(WINSIZE.height / backgroundImage->getContentSize().height);
    this->addChild(backgroundImage, 1);
   
    //the cup
    Sprite *cup = cocos2d::Sprite::create("SliceTheFruits/cup.png");
    cup->setAnchorPoint(Vec2(0.5, 0.5));
    cup->setPosition(Point((visibleSize.width * 0.5), (visibleSize.height * 0.13)));
    cup->setScaleX((WINSIZE.width / cup->getContentSize().width) * 1.15);
    cup->setScaleY(2.2);
    this->addChild(cup, 2); 
    
    Sprite *cupFrontOnly = cocos2d::Sprite::create("SliceTheFruits/cup_half.png");
    cupFrontOnly->setAnchorPoint(Vec2(0.5, 0.5));
    cupFrontOnly->setPosition(Point((visibleSize.width * 0.5), (visibleSize.height * 0.13)));
    cupFrontOnly->setScaleY((WINSIZE.height / cupFrontOnly->getContentSize().height) * 0.3);
    cupFrontOnly->setScaleX((WINSIZE.height / cupFrontOnly->getContentSize().height) * 0.08);
    this->addChild(cupFrontOnly, 3); 

    //buttons
    auto backButton = MenuItemSprite::create(Sprite::create("SliceTheFruits/buton_1.png"),
                                                            Sprite::create("SliceTheFruits/buton_1_blue.png"),
                                                            CC_CALLBACK_1(SliceTheFruits::GoToScene, this));
    backButton->setTag(1);
    backButton->setScale(0.7f);
    backButton->setPosition(Point((int)(visibleSize.width * 0.125), (int)(visibleSize.height * 0.08)));

    auto nextButton = MenuItemSprite::create(Sprite::create("SliceTheFruits/buton_1.png"),
                                                            Sprite::create("SliceTheFruits/buton_1_blue.png"),
                                                            CC_CALLBACK_1(SliceTheFruits::GoToScene, this));
                                    
    nextButton->setTag(2);
    nextButton->setScale(0.7f);
    nextButton->setPosition(Point((int)(visibleSize.width * 0.875), (int)(visibleSize.height * 0.08)));

    //menu
    auto menu = Menu::create(backButton, nextButton, NULL);
    menu->setPosition(0, 0);
    this->addChild(menu, 4);

    arrayOfFruits = cocos2d::CCArray::create();
    arrayOfFruits->retain();

    //listener to activate the touches
    auto listener = EventListenerTouchOneByOne::create();
    listener->setSwallowTouches(true);

    listener->onTouchBegan = CC_CALLBACK_2(SliceTheFruits::onTouchBegan, this);
    listener->onTouchMoved = CC_CALLBACK_2(SliceTheFruits::onTouchMoved, this);
    listener->onTouchEnded = CC_CALLBACK_2(SliceTheFruits::onTouchEnded, this);

    _eventDispatcher->addEventListenerWithSceneGraphPriority(listener, this);

    scheduleUpdate();

    count = 0;

    return true;
}


void SliceTheFruits::update(float dt)
{

//    CCLOG("++++++++++++++++++++++++number of sprites: %d", arrayOfFruits->count());
    //    CCLOG("--->call every frame!");
    time += dt;
    int randomTimeToSpawn = rand() % 5 + 3;
    if (time > randomTimeToSpawn) {
//        CCLOG("--->in the update function");
        throwFruits();
        time = 0;

    }

    if (isOnTouch) //spriteTest->getBoundingBox().containsPoint(touchPoint)&& (arrayOfFruits->count() != 0)
    {
        CheckForColliosions();
    }

}

void SliceTheFruits::CheckForColliosions()
{
    CCObject *it = NULL;
    CCARRAY_FOREACH(arrayOfFruits, it){
        CCSprite *fruit = dynamic_cast<CCSprite*>(it);

        if ((fruit->getBoundingBox().containsPoint(touchPoint))) {
            int typeOfFruit= fruit->getTag();
            changeSprite(touchPoint.x, touchPoint.y, typeOfFruit);

             //remove the original fruit
            fruit->setPosition(-300, -300);
        }
    }

}

void SliceTheFruits::GoToScene(cocos2d::Ref *pSender)
{
    //simple switcher of scenes
    CCMenuItem* pMenuItem = (CCMenuItem *)(pSender);
    int tag = (int)pMenuItem->getTag();

    switch (tag)
    {
        case 1:
        {
            auto scene = MainMenu::createScene();
            Director::getInstance()->replaceScene(TransitionMoveInR::create(1, scene));   //0.5
        }break;

       
        case 2:
        {
            auto scene = Blender::scene();
            Director::getInstance()->replaceScene(TransitionFade::create(1, scene));
        }break;
        
    }
}

void SliceTheFruits::onEnter()
{
//    CCLOG("Enter the activity! - Slice The Fruits");
    Layer::onEnter();
}

bool SliceTheFruits::onTouchBegan(cocos2d::Touch *touch, cocos2d::Event *unused_event)
{

//    touchPoint->setPoint(touch->getLocation().x, touch->getLocation().y);
    touchPoint.setPoint(touch->getLocation().x, touch->getLocation().y);
//    CCLOG("onTouchBegan x = %f, y = %f", touch->getLocation().x, touch->getLocation().y);

    isOnTouch = true;
    return true;
}

void SliceTheFruits::onTouchEnded(cocos2d::Touch *touch, cocos2d::Event *unused_event)
{
//    CCLOG("onTouchEnded x = %f, y = %f", touch->getLocation().x, touch->getLocation().y);
    touchPoint.setPoint(touch->getLocation().x, touch->getLocation().y);
    isOnTouch = false;
}

void SliceTheFruits::onTouchMoved(cocos2d::Touch * touch, cocos2d::Event * unused_event)
{
//    CCLOG("onTouchMoved x = %f, y = %f", touch->getLocation().x, touch->getLocation().y);
    touchPoint.setPoint(touch->getLocation().x, touch->getLocation().y);
}

void SliceTheFruits::changeSprite(float xx, float yy, int fruitID)
{
//    //the substitude

    auto actioMoveL = MoveTo::create(2, Point(xx - 15, -50));
    auto actioMoveR = MoveTo::create(2, Point(xx + 15, -50));


    switch (fruitID) {
    case 1:
    {
        //right side of the fruit
        fruitRightSide = Strawberry::createStrawberry("Fruits/partFruits/strawberry_right.png");
        fruitRightSide->setAnchorPoint(Vec2(0.5, 0.5));
        fruitRightSide->setPosition(Point(xx - 5, yy));
        fruitRightSide->setScale(0.5f);
        this->addChild(fruitRightSide, 2);
        fruitRightSide->runAction(actioMoveR);

        //left side
        fruitLeftSide = Strawberry::createStrawberry("Fruits/partFruits/strawberry_left.png");
        fruitLeftSide->setAnchorPoint(Vec2(0.5, 0.5));
        fruitLeftSide->setPosition(Point(xx + 5, yy));
        fruitLeftSide->setScale(0.5f);
        this->addChild(fruitLeftSide, 2);
        fruitLeftSide->runAction(actioMoveL);

        break;
    }
    case 2:
    {
        //right side of the fruit
        fruitRightSide = Mango::createMango("Fruits/partFruits/mango_right.png");
        fruitRightSide->setAnchorPoint(Vec2(0.5, 0.5));
        fruitRightSide->setPosition(Point(xx - 5, yy));
        fruitRightSide->setScale(0.5f);
        this->addChild(fruitRightSide, 2);
        fruitRightSide->runAction(actioMoveR);

        //left side
        fruitLeftSide = Mango::createMango("Fruits/partFruits/mango_left.png");
        fruitLeftSide->setAnchorPoint(Vec2(0.5, 0.5));
        fruitLeftSide->setPosition(Point(xx + 5, yy ));
        fruitLeftSide->setScale(0.5f);
        this->addChild(fruitLeftSide, 2);
        fruitLeftSide->runAction(actioMoveL);

        break;
    }
    case 3:
    {
        //right side of the fruit
        fruitRightSide = Banana::createBanana("Fruits/partFruits/banana_right.png");
        fruitRightSide->setAnchorPoint(Vec2(0.5, 0.5));
        fruitRightSide->setPosition(Point(xx - 5, yy));
        fruitRightSide->setScale(0.5f);
        this->addChild(fruitRightSide, 2);
        fruitRightSide->runAction(actioMoveR);

        //left side
        fruitLeftSide = Banana::createBanana("Fruits/partFruits/banana_left.png");
        fruitLeftSide->setAnchorPoint(Vec2(0.5, 0.5));
        fruitLeftSide->setPosition(Point(xx + 5, yy));
        fruitLeftSide->setScale(0.5f);
        this->addChild(fruitLeftSide, 2);
        fruitLeftSide->runAction(actioMoveL);

        break;
    }
    case 4:
    {
        //right side of the fruit
        fruitRightSide = Pineapple::createPineapple("Fruits/partFruits/pineapple_right.png");
        fruitRightSide->setAnchorPoint(Vec2(0.5, 0.5));
        fruitRightSide->setPosition(Point(xx - 5, yy));
        fruitRightSide->setScale(0.5f);
        this->addChild(fruitRightSide, 2);
        fruitRightSide->runAction(actioMoveR);

        //left side
        fruitLeftSide = Pineapple::createPineapple("Fruits/partFruits/pineapple_left.png");
        fruitLeftSide->setAnchorPoint(Vec2(0.5, 0.5));
        fruitLeftSide->setPosition(Point(xx + 5, yy));
        fruitLeftSide->setScale(0.5f);
        this->addChild(fruitLeftSide, 2);
        fruitLeftSide->runAction(actioMoveL);

        break;
    }
    case 5:
    {
        //right side of the fruit
        fruitRightSide = Orange::createOrange("Fruits/partFruits/orange_right.png");
        fruitRightSide->setAnchorPoint(Vec2(0.5, 0.5));
        fruitRightSide->setPosition(Point(xx - 5, yy));
        fruitRightSide->setScale(0.5f);
        this->addChild(fruitRightSide, 2);
        fruitRightSide->runAction(actioMoveR);

        //left side
        fruitLeftSide = Orange::createOrange("Fruits/partFruits/orange_left.png");
        fruitLeftSide->setAnchorPoint(Vec2(0.5, 0.5));
        fruitLeftSide->setPosition(Point(xx + 5, yy));
        fruitLeftSide->setScale(0.5f);
        this->addChild(fruitLeftSide, 2);
        fruitLeftSide->runAction(actioMoveL);

        break;
    }


    }

}

void SliceTheFruits::throwFruits()
{
//    we will create pseudo random number to choose
//    want kind of fruit we are going to release.
//    1 - strawberry
//    2 - mango
//    3 - banana
//    4 - pineapple
//    5 - orange
//    CCLOG("--->in the throwfruits function");

    //determine how many fruits we are going to throw! (1 - 5)
    int numberOfFruits = rand() % 5 + 1;
    //what kind of fruits to spawn
    CreateFruits(numberOfFruits);
//    CCLOG("--->end of create function");
    ReleaseToScene();
//    CCLOG("--->end of release function");



}

void SliceTheFruits::ReleaseToScene()
{

//    CCLOG("--->in the release to scene!!!");


    CCObject *it = NULL;
    CCARRAY_FOREACH(arrayOfFruits, it){
        CCSprite *fruit = dynamic_cast<CCSprite*>(it);

        int randomX = WINSIZE.width - fruit->getPositionX();
        int randomH = rand() % 25 + 10;
//        CCLOG("x: %d", randomX);
        auto actionJump = JumpTo::create(3, Point(randomX, -100), (WINSIZE.height - (WINSIZE.height * randomH) / 100), 1);
        auto actionRotate = RotateBy::create(3, 1080);
        CCSpawn *sphereEffect = CCSpawn::createWithTwoActions(actionJump, actionRotate);
        fruit->runAction(cocos2d::CCSequence::create(sphereEffect,
                        CCCallFuncND::create(
                                    this,
                                    callfuncND_selector(SliceTheFruits::DestroyFruit),
                                    (void*)fruit), NULL));

    }

}
void SliceTheFruits::DestroyFruit(cocos2d::CCNode* sender, void* fruit)
{
    cocos2d::CCSprite *fr = (cocos2d::CCSprite*) fruit;

    fr->removeFromParentAndCleanup(true);
    arrayOfFruits->removeObject(fr);
    count--;
//    CCLOG("================from the destroyer");
//    delete fr;
}


void SliceTheFruits::CreateFruits(int numberOfFruits) {

//    CCLOG("---> in the createFruits function");
    for (int var = 0; var < numberOfFruits; var++) {

//        CCLOG("--->in the for; cycle number: %d", var);
        int randFruit = rand() % 5 + 1;
        int randomPosition = rand() % ((int)WINSIZE.width - 30) + 30;

        if (arrayOfFruits) {
//            CCLOG("---->>array is created!!!");
        }


        switch (randFruit) {
            case 1:{
//                CCLOG("--->switch case 1");
                Strawberry *stra = Strawberry::createStrawberry("Fruits/strawberry.png");

                if (stra) {
//                    CCLOG("--->>object strawberry is created!");
                }
                stra->setAnchorPoint(Vec2(0.5, 0.5));
                stra->setPosition(Point(randomPosition, -20));
                stra->setScale(0.5f);
                stra->setTag(1);
                this->addChild(stra, 4);
                arrayOfFruits->addObject(stra);
                count++;
                break;
            }
            case 2:{
//                CCLOG("--->switch case 2");
                Mango *man = Mango::createMango("Fruits/mango.png");

                if (man) {
//                    CCLOG("--->>object mango is created!");
                }
                man->setAnchorPoint(Vec2(0.5, 0.5));
                man->setPosition(Point(randomPosition, -20));
                man->setScale(0.5f);
                man->setTag(2);
                this->addChild(man, 4);
                arrayOfFruits->addObject(man);
                count++;
                break;
            }
            case 3:{
//            CCLOG("--->switch case 3");
                Banana *ban = Banana::createBanana("Fruits/banana.png");

                if (ban) {
//                    CCLOG("--->>object banana is created!");
                }
                ban->setAnchorPoint(Vec2(0.5, 0.5));
                ban->setPosition(Point(randomPosition, -20));
                ban->setScale(0.5f);
                ban->setTag(3);
                this->addChild(ban, 4);
                arrayOfFruits->addObject(ban);
                count++;
                break;
            }
            case 4:{
//            CCLOG("--->switch case 4");
                Pineapple *pin = Pineapple::createPineapple("Fruits/pineapple.png");

                if (pin) {
//                    CCLOG("--->>object pineapple is created!");
                }
                pin->setAnchorPoint(Vec2(0.5, 0.5));
                pin->setPosition(Point(randomPosition, -20));
                pin->setScale(0.5f);
                pin->setTag(4);
                this->addChild(pin, 4);
                arrayOfFruits->addObject(pin);
                count++;
                break;
            }
            case 5:{
//                CCLOG("--->switch case 5");
                Orange *ora = Orange::createOrange("Fruits/orange.png");

                if (ora) {
//                    CCLOG("--->>object orange is created!");
                }
                ora->setAnchorPoint(Vec2(0.5, 0.5));
                ora->setPosition(Point(randomPosition, -20));
                ora->setScale(0.5f);
                ora->setTag(5);
                this->addChild(ora, 4);
                arrayOfFruits->addObject(ora);
                count++;

                break;
            }
        }

    }

}
