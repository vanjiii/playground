#ifndef __SLICETHEFRUITS_H__
#define __SLICETHEFRUITS_H__

#include "cocos2d.h"
//#include "Box2D.h"
#include <vector>
//#include "mango.h"

//predeclared for the compiler to know about them
class Banana;
class Strawberry;
class Mango;
class Pineapple;
class Orange;


class SliceTheFruits : public cocos2d::Layer
{
public:

    virtual void onExit();

    // Here's a difference. Method 'init' in cocos2d-x returns bool, instead of returning 'id' in cocos2d-iphone
    virtual bool init();  

    // there's no 'id' in cpp, so we recommend returning the class instance pointer
    static cocos2d::Scene* scene();
    
    // implement the "static node()" method manually
    CREATE_FUNC(SliceTheFruits);


private:
    //fields
    cocos2d::CCArray *arrayOfFruits;
    cocos2d::Sprite *fruitLeftSide;
    cocos2d::Sprite *fruitRightSide;
    cocos2d::Point touchPoint;
    bool isOnTouch = false;
    float time = 0;
    int count;



    //methods
    void changeSprite(float xx, float yy, int fruitID);
    void GoToScene(cocos2d::Ref *pSender);
    void throwFruits();
    void CreateFruits(int numberOfFruits);
    void ReleaseToScene();
    void CheckForColliosions();
    void DestroyFruit(cocos2d::CCNode* sender, void* fruit);

    virtual void update(float dt);
    void onEnter();



    //touches
    bool onTouchBegan(cocos2d::Touch *touch, cocos2d::Event *unused_event);
    void onTouchMoved(cocos2d::Touch * touch, cocos2d::Event *unused_event);
    void onTouchEnded(cocos2d::Touch *touch, cocos2d::Event *unused_event);

    
};

#endif // __SLICETHEFRUITS_H__
