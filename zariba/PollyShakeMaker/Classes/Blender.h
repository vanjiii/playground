#ifndef __BLENDER_SCENE_H__
#define __BLENDER_SCENE_H__

#include "cocos2d.h"

class Blender : public cocos2d::Layer
{
public:
    // Here's a difference. Method 'init' in cocos2d-x returns bool, instead of returning 'id' in cocos2d-iphone
    virtual bool init();  

    // there's no 'id' in cpp, so we recommend returning the class instance pointer
    static cocos2d::Scene* scene();
    
    // a selector callback
    void menuCloseCallback(Ref* sender);
    
    // implement the "static node()" method manually
    CREATE_FUNC(Blender);

    void GoToScene(cocos2d::Ref *pSender);
    void animateTheBlender();
    cocos2d::Sprite* maskedSpriteWithSprite(cocos2d::Sprite* textureSprite, cocos2d::Sprite* maskSprite, float positionOfHeight);

    //touches
    bool onTouchBegan(cocos2d::Touch *touch, cocos2d::Event *unused_event);
    void onTouchMoved(cocos2d::Touch * touch, cocos2d::Event *unused_event);
    void onTouchEnded(cocos2d::Touch *touch, cocos2d::Event *unused_event);
    void update (float dt);

private:
    cocos2d::Sprite *blenderBody;
    cocos2d::Sprite *cup;
    cocos2d::Sprite *knife;
    cocos2d::Sprite *knifeBody;
    cocos2d::CCArray *arrayOfFruits;
    cocos2d::Point touchPoint;
    cocos2d::Sprite *blenderButton;
    bool isPressedButton = false;
    bool isOnTouch = false;
    float count = 0;
    float scale = 0.95;
    cocos2d::Sprite *cupBack;
    cocos2d::Sprite *cupMask;
    cocos2d::Sprite *waterEff;
    float position = 0.0;
    cocos2d::RenderTexture *rt;
//    cocos2d::Sprite *retval ;

};

#endif //__BLENDER_SCENE_H__
