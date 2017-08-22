#ifndef __PINEAPPLE_FRUIT_H__
#define __PINEAPPLE_FRUIT_H__

#include "cocos2d.h"

class Pineapple : public cocos2d::Sprite {
public:
    static Pineapple *createPineapple(const char *FileName);
};

#endif // __PINEAPPLE_FRUIT_H__
