#ifndef __ORANGE_FRUIT_H__
#define __ORANGE_FRUIT_H__

#include "cocos2d.h"

class Orange : public cocos2d::Sprite {
public:
    static Orange *createOrange(const char *FileName);
};

#endif // __ORANGE_FRUIT_H__
