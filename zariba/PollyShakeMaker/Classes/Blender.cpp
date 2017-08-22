#include "MainMenu.h"
#include "SliceTheFruits.h"
#include "Blender.h"
#include "YogurtMachine.h"

USING_NS_CC;

#define WIN_SIZE  CCDirector::sharedDirector()->getWinSize()


//@TODO
//fix visible size problem
//try move the elements, not deleting them
//fix the big loading


Scene* Blender::scene()
{
    // 'scene' is an autorelease object
    auto scene = Scene::create();
    
    // 'layer' is an autorelease object
    Blender *layer = Blender::create();

    // add layer as a child to scene
    scene->addChild(layer);

    // return the scene
    return scene;
}

// on "init" you need to initialize your instance
bool Blender::init()
{
    //////////////////////////////
    // 1. super init first
    if ( !Layer::init() )
    {
        return false;
    }
    
    auto visibleSize = Director::getInstance()->getVisibleSize();
    auto origin = Director::getInstance()->getVisibleOrigin();


    //background
    Sprite *backgroundImage = cocos2d::Sprite::create("Blender/backgrounds.jpg");
    backgroundImage->setPosition(Point::ZERO);
    backgroundImage->setAnchorPoint(Vec2(0, 0));
    backgroundImage->setScaleX(WIN_SIZE.width / backgroundImage->getContentSize().width);
    backgroundImage->setScaleY(WIN_SIZE.height / backgroundImage->getContentSize().height);
    this->addChild(backgroundImage, 1);

    //table
    Sprite *table = cocos2d::Sprite::create("Blender/backgrounds_table.jpg");
//    table->setPosition(Point::ZERO);
    table->setAnchorPoint(Vec2(0.5, 0.5));    
    table->setPosition(Point((visibleSize.width * 0.5), (visibleSize.height * 0.05)));
    table->setScaleX(0.8);
    table->setScaleY(1.2);
    this->addChild(table, 2);
    
    //buttons
    auto backButton = MenuItemSprite::create(Sprite::create("SliceTheFruits/buton_1.png"),
                                    Sprite::create("SliceTheFruits/buton_1_blue.png"),
                                    CC_CALLBACK_1(Blender::GoToScene, this));
    backButton->setTag(1);
    backButton->setScale(0.7f);
    backButton->setPosition(Point((int)(visibleSize.width * 0.125), (int)(visibleSize.height * 0.08)));

    auto nextButton = MenuItemSprite::create(Sprite::create("SliceTheFruits/buton_1.png"),
                                    Sprite::create("SliceTheFruits/buton_1_blue.png"),
                                    CC_CALLBACK_1(Blender::GoToScene, this));
                                    
    nextButton->setTag(2);
    nextButton->setScale(0.7f);
    nextButton->setPosition(Point((int)(visibleSize.width * 0.875), (int)(visibleSize.height * 0.08)));

    //the blender with all his parts
    blenderBody = cocos2d::Sprite::create("Blender/blender_image.png");
    blenderBody->setAnchorPoint(Vec2(0.5, 0.5));
    blenderBody->setPosition(Point(visibleSize.width * 0.55, visibleSize.height * 0.44));
    blenderBody->setScale(0.38f, 0.4f);
    this->addChild(blenderBody, 3);


    cup = cocos2d::Sprite::create("Blender/blender_image_2a.png");
    cup->setAnchorPoint(Vec2(0.5, 0.5));
    cup->setPosition(Point(visibleSize.width * 0.55, visibleSize.height * 0.44));   //45
    cup->setScale(0.38f, 0.4f);
    this->addChild(cup, 6);

    cupBack = cocos2d::Sprite::create("Blender/blender_mask.png");   //"Blender/blender_image_2.png"

    cupMask = cocos2d::Sprite::create("Blender/blender_image_2a.png"); //"Blender/blender_mask.png"

    //==========================================

    rt = RenderTexture::create( cupMask->getContentSize().width,
                                cupMask->getContentSize().height );

    //==========================================



    waterEff = maskedSpriteWithSprite(cupBack, cupMask, position);
    waterEff->setAnchorPoint(Vec2(0.5, 0.5));
    waterEff->setPosition(Point(visibleSize.width * 0.55, visibleSize.height * 0.44));   //45
    waterEff->setScale(0.38f, 0.4f);
    this->addChild(waterEff, 5);


    knife = cocos2d::Sprite::create("Blender/knife_2.png");
    knife->setAnchorPoint(Vec2(0.5, 0.5));
    knife->setPosition(Point(visibleSize.width * 0.42, visibleSize.height * 0.375));
    knife->setScale(0.4f, 0.4f);
    this->addChild(knife, 4);

    knifeBody = cocos2d::Sprite::create("Blender/blender_knife_1.png");
    knifeBody->setAnchorPoint(Vec2(0.5, 0.5));
    knifeBody->setPosition(Point(visibleSize.width * 0.49, visibleSize.height * 0.37));
    knifeBody->setScale(0.4f, 0.42f);
    this->addChild(knifeBody, 5);


    blenderButton = cocos2d::Sprite::create("Blender/button_unpressed.png");
    blenderButton->setScale(0.38f, 0.4f);
    blenderButton->setTag(1);
    blenderButton->setPosition(Point(visibleSize.width * 0.49, visibleSize.height * 0.22));
    this->addChild(blenderButton, 5);


    //the fruits in the blender
    int numOfFruids = 50;
    arrayOfFruits = cocos2d::CCArray::create();
    arrayOfFruits->retain();

    float randomX = 0.38;
    float randomY = 0.37;
    for (int var = 0; var < numOfFruids; var++) {
        int randomRotation = rand() % 360;
        int fr = rand() % 5 + 1;
        cocos2d::Sprite *fruit;

        switch (fr) {
        case 1:
            {
                 fruit = cocos2d::Sprite::create("Blender/strawbarry_slice.png");

                break;
            }
            case 2:
            {
                 fruit = cocos2d::Sprite::create("Blender/banana_slice.png");
                break;
            }
            case 3:
            {
                 fruit = cocos2d::Sprite::create("Blender/mango_slices.png");
                 break;
            }
            case 4:
            {
                 fruit = cocos2d::Sprite::create("Blender/orange_slice.png");
                break;
            }
            case 5:
            {
                 fruit = cocos2d::Sprite::create("Blender/pineapple_slice.png");
                break;
            }
        }


        fruit->setAnchorPoint(Vec2(0.5, 0.5));
        fruit->setPosition(Point(visibleSize.width * randomX, visibleSize.height * randomY));
        fruit->setScale(0.65f, 0.65f);
        fruit->setRotation(randomRotation);
        this->addChild(fruit, 2);
        arrayOfFruits->addObject(fruit);


        if (randomX < 0.6) {
            randomX += 0.02;
        }else{
            randomX = 0.39;
            randomY += 0.03;
        }
    }




    //menu
    auto menu = Menu::create(backButton, nextButton, NULL);
    menu->setPosition(0, 0);
    this->addChild(menu, 4);

    //touches
    auto listener = EventListenerTouchOneByOne::create();
    listener->setSwallowTouches(true);

    listener->onTouchBegan = CC_CALLBACK_2(Blender::onTouchBegan, this);
    listener->onTouchMoved = CC_CALLBACK_2(Blender::onTouchMoved, this);
    listener->onTouchEnded = CC_CALLBACK_2(Blender::onTouchEnded, this);

    _eventDispatcher->addEventListenerWithSceneGraphPriority(listener, this);

    scheduleUpdate();


    return true;
}

void Blender::update(float dt)
{
    auto visibleSize = Director::getInstance()->getVisibleSize();
    //dt ~= 30 ms
    count += dt;
    if ((count > 0.03) && isOnTouch && (blenderButton->getBoundingBox().containsPoint(touchPoint))) {
        animateTheBlender();
        isPressedButton = true;
        count = 0;
    }

    if (isPressedButton) {
        blenderButton->removeFromParentAndCleanup(true);
        blenderButton = cocos2d::Sprite::create("Blender/button_pressed.png");
        blenderButton->setScale(0.38f, 0.4f);
        blenderButton->setTag(2);
        blenderButton->setPosition(Point(visibleSize.width * 0.49, visibleSize.height * 0.22));
        this->addChild(blenderButton, 5);
    }else if(blenderButton->getTag() != 1){
        blenderButton->removeFromParentAndCleanup(true);
        blenderButton = cocos2d::Sprite::create("Blender/button_unpressed.png");
        blenderButton->setScale(0.38f, 0.4f);
        blenderButton->setTag(1);
        blenderButton->setPosition(Point(visibleSize.width * 0.49, visibleSize.height * 0.22));
        this->addChild(blenderButton, 5);
        blenderBody->setPosition(Point(visibleSize.width * 0.55, visibleSize.height * 0.44));

        cup->setPosition(Point(visibleSize.width * 0.55, visibleSize.height * 0.44));

        knife->removeFromParentAndCleanup(true);
        knife = cocos2d::Sprite::create("Blender/knife_2.png");
        knife->setAnchorPoint(Vec2(0.5, 0.5));
        knife->setPosition(Point(visibleSize.width * 0.42, visibleSize.height * 0.375));
        knife->setScale(0.4f, 0.4f);
        this->addChild(knife, 4);
    }


}

void Blender::animateTheBlender()

{

    auto visibleSize = Director::getInstance()->getVisibleSize();

    if (blenderBody->getPositionX() == visibleSize.width * 0.55) {
        blenderBody->setPosition(Point(visibleSize.width * 0.555, visibleSize.height * 0.44));

        cup->setPosition(Point(visibleSize.width * 0.553, visibleSize.height * 0.443));

        knife->removeFromParentAndCleanup(true);
        knife = cocos2d::Sprite::create("Blender/knife_2_hor.png");
        knife->setAnchorPoint(Vec2(0.5, 0.5));
        knife->setPosition(Point(visibleSize.width * 0.56, visibleSize.height * 0.375));
        knife->setScale(0.4f, 0.4f);
        this->addChild(knife, 4);
    }else {
        blenderBody->setPosition(Point(visibleSize.width * 0.55, visibleSize.height * 0.44));

        cup->setPosition(Point(visibleSize.width * 0.55, visibleSize.height * 0.44));

        knife->removeFromParentAndCleanup(true);
        knife = cocos2d::Sprite::create("Blender/knife_2.png");
        knife->setAnchorPoint(Vec2(0.5, 0.5));
        knife->setPosition(Point(visibleSize.width * 0.42, visibleSize.height * 0.375));
        knife->setScale(0.4f, 0.4f);
        this->addChild(knife, 4);
    }



    //the pieces in the blender
    CCObject *it = NULL;
    CCARRAY_FOREACH(arrayOfFruits, it){
        CCSprite *fruit = dynamic_cast<CCSprite*>(it);

        int randomRotation = rand() % 360;
        fruit->setRotation(randomRotation);
        scale -= 0.0001;
        fruit->setScale(scale);

//        CCLOG("get position Y: %f", fruit->getPositionY());

        if (fruit->getPositionY() > visibleSize.width * 0.37) {
            float pos = fruit->getPositionY();
            fruit->setPositionY((pos - 1));
        }

        if (scale < 0) {
            fruit->removeFromParentAndCleanup(true);
        }

    }


    //the fluid
    position += 0.01;

//    waterEff->removeFromParentAndCleanup(true);
//    if (waterEff) {
//        CCLOG("removeFromParentAndCleanup from parent not working!");
//    }else{
//        CCLOG("removeFromParentAndCleanup from parent working fine!");
//    }

    waterEff = nullptr;
    if (waterEff) {
        CCLOG(" nullptr not working properly!");
    }else{
        CCLOG(" nullptr works fine!");
    }
    CCLOG("removed");
    waterEff = maskedSpriteWithSprite(cupBack, cupMask, position);
    CCLOG("created");
    waterEff->setAnchorPoint(Vec2(0.5, 0.5));
    CCLOG("anchor");
    waterEff->setPosition(Point(visibleSize.width * 0.55, visibleSize.height * 0.44));   //45
    CCLOG("position");
    waterEff->setScale(0.38f, 0.4f);
    CCLOG("scale");
    this->addChild(waterEff, 5);
    CCLOG("add child");

}

cocos2d::Sprite* Blender::maskedSpriteWithSprite(Sprite* textureSprite, Sprite* maskSprite, float pos)
{

    if (!textureSprite || !maskSprite) {
        CCLOG("problem with creating");
    }else{
        CCLOG("it's ok!");
    }

    // 1

    rt = RenderTexture::create( cupMask->getContentSize().width,
                                cupMask->getContentSize().height );
    CCLOG("1");

    // 2
    maskSprite->setPosition(maskSprite->getContentSize().width/2,
                            maskSprite->getContentSize().height * pos);
    textureSprite->setPosition(textureSprite->getContentSize().width/2,
                               textureSprite->getContentSize().height/2);

    CCLOG("2");

    // 3
    maskSprite->setBlendFunc( BlendFunc{GL_ONE, GL_ZERO} );
    textureSprite->setBlendFunc( BlendFunc{GL_DST_ALPHA, GL_ZERO} );

    CCLOG("3");

    // 4
    rt->begin();
    maskSprite->visit();
    textureSprite->visit();
    rt->end();

    CCLOG("4");

    // 5
    cocos2d::Sprite *retval = Sprite::createWithTexture(rt->getSprite()->getTexture());
    retval->setFlippedY(true);

    return retval;
}




bool Blender::onTouchBegan(cocos2d::Touch *touch, cocos2d::Event *unused_event)
{
    touchPoint.setPoint(touch->getLocation().x, touch->getLocation().y);
    isOnTouch = true;
    return true;
}

void Blender::onTouchEnded(cocos2d::Touch *touch, cocos2d::Event *unused_event)
{
    isOnTouch = false;
    isPressedButton = false;
    touchPoint.setPoint(touch->getLocation().x, touch->getLocation().y);
}

void Blender::onTouchMoved(cocos2d::Touch * touch, cocos2d::Event * unused_event)
{
    touchPoint.setPoint(touch->getLocation().x, touch->getLocation().y);
}

void Blender::GoToScene(cocos2d::Ref *pSender)
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

       
        case 2:
        {
            auto scene = YogurtMachine::createScene();
            Director::getInstance()->replaceScene(TransitionFade::create(1, scene));
        }break;
        
    }
}
