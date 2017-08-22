#ifndef __MANGO_FRUIT_H__
#define __MANGO_FRUIT_H__

#include "cocos2d.h"

class Mango : public cocos2d::Sprite {
public:
    static Mango *createMango(const char *FileName);
};

#endif // __MANGO_FRUIT_H__
