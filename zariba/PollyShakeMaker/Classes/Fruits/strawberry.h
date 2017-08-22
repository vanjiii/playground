#ifndef __STRAWBERRY_FRUIT_H__
#define __STRAWBERRY_FRUIT_H__

#include "cocos2d.h"

class Strawberry : public cocos2d::Sprite {
public:
    static Strawberry *createStrawberry(const char *FileName);
};

#endif // __STRAWBERRY_FRUIT_H__
