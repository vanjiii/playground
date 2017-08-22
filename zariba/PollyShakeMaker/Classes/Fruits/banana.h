#ifndef __BANANA_FRUIT_H__
#define __BANANA_FRUIT_H__

#include "cocos2d.h"

class Banana : public cocos2d::Sprite {
private:
public:
    //work exactly the same way of sprite::create()
    static Banana *createBanana(const char *FileName);
};
#endif // __BANANA_FRUIT_H__
